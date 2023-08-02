using ClienteCRUDModel;
using EnderecoCRUDDados;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace ClienteCRUDLogica
{
    public interface IClienteLogica
    {
        IEnumerable<ClienteModel> GetAll(int pagina);
        ClienteModel Get(string idCliente);
        ClienteModel Save(ClienteModel cliente);
        ClienteModel Save(string idCliente, ClienteModel cliente);
        void Delete(string idCliente);
    }

    public class ClienteLogica : DIService, IClienteLogica
    {
        public ClienteModel Save(ClienteModel cliente)
        {
            ValidarDadosBasicos(cliente);

            return clienteDados.Save(cliente);
        }
        public ClienteModel Save(string idCliente, ClienteModel cliente)
        {
            ValidarDadosBasicos(cliente);

            return clienteDados.Save(cliente);
        }

        public void Delete(string idCliente)
        {
            var cliente = Get(idCliente);
            var endereco = enderecoDados.Get(cliente.EnderecoId);

            clienteDados.Delete(cliente);
            enderecoDados.Delete(endereco);
        }

        public IEnumerable<ClienteModel> GetAll(int pagina)
        {
            int.TryParse(ConfigurationManager.AppSettings["Paginacao"], out var paginacao);

            return clienteDados.GetAll(pagina, paginacao);
        }

        public ClienteModel Get(string idCliente)
        {
            int.TryParse(idCliente, out var clienteId);

            var cliente = clienteDados.Get(clienteId);

            if (cliente == null)
                throw new Exception("Cliente não Encontrado");

            return cliente;
        }

        private void ValidarDadosBasicos(ClienteModel cliente)
        {
            int.TryParse(ConfigurationManager.AppSettings["LimiteMaximoIdade"], out var limiteMaximoIdade);
            int.TryParse(ConfigurationManager.AppSettings["LimiteMinimoIdade"], out var limiteMinimoIdade);

            var cpfTeste = cliente.CPF;
            cpfTeste = cpfTeste.Replace(".", "");
            cpfTeste = cpfTeste.Replace("-", "");

            if (cpfTeste.Any(c => !char.IsDigit(c)) || cpfTeste.Length != 11 || !UtilLogica.IsCPF(cpfTeste))
                throw new Exception("O CPF não é válido");

            cliente.CPF = cpfTeste;

            var outroCliente = clienteDados.GetByCPF(cliente.CPF);

            if (outroCliente != null && cliente.Id != outroCliente.Id)
                throw new Exception("CPF já cadastrado para outro cliente!");

            if (cliente.DataNascimento > DateTime.Now)
                throw new Exception("Ainda não aceitamos clientes que não nasceram");

            var idade = UtilLogica.GetIdade(cliente.DataNascimento);

            if (idade > limiteMaximoIdade)
                throw new Exception($"Clientes com mais de {limiteMaximoIdade} anos só com a presença dos pais");

            if (idade < limiteMinimoIdade)
                throw new Exception($"Clientes precisam ter no mínimo {limiteMinimoIdade} anos para se cadastrar");

            if (cliente.DataExpedicao != null && cliente.DataExpedicao < cliente.DataNascimento)
                throw new Exception("Não tem como ter expedido o documento antes do nascimento!");
        }
    }
}
