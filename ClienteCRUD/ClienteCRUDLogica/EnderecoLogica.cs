using ClienteCRUDModel;
using System;
using System.Linq;

namespace ClienteCRUDLogica
{
    public interface IEnderecoLogica
    {
        EnderecoModel GetEndereco(string idEndereco);
        EnderecoModel GetEnderecoByCep(string cep);
        EnderecoModel Save(EnderecoModel endereco);
    }

    public class EnderecoLogica : DIService, IEnderecoLogica
    {
        public EnderecoModel GetEnderecoByCep(string cep)
        {
            ValidarAjustarCEP(cep);

            var result = new EnderecoModel();

            var response = requestLogica.ExecutarRequest($"https://viacep.com.br/ws/{cep}/json/");

            if (response != null)
            {
                if (response["cep"] == null)
                    throw new Exception("CEP não localizado");

                result.CEP = response["cep"];
                result.Rua = response["logradouro"];
                result.Complemento = response["complemento"];
                result.Bairro = response["bairro"];
                result.Cidade = response["localidade"];
                result.UF = response["uf"];
            }

            return result;

        }

        public EnderecoModel Save(EnderecoModel endereco)
        {
            endereco.CEP = ValidarAjustarCEP(endereco.CEP);
            ValidarDadosBasicos(endereco);

            var enderecoDB = enderecoDados.Get(endereco.CEP, endereco.Rua, endereco.Numero, endereco.Complemento, endereco.Bairro, endereco.Cidade, endereco.UF);
            if (enderecoDB != null)
                endereco = enderecoDB;


            return enderecoDados.Save(endereco);
        }

        public EnderecoModel GetEndereco(string idEndereco)
        {
            int.TryParse(idEndereco, out var enderecoId);

            var endereco = enderecoDados.Get(enderecoId);

            if (endereco == null)
                throw new Exception("Endereço não Encontrado");

            return endereco;
        }

        private string ValidarAjustarCEP(string cep)
        {
            cep = cep.Replace(".", "");
            cep = cep.Replace("-", "");

            if (cep.Any(c => !char.IsDigit(c)) || cep.Length != 8)
                throw new Exception("CEP inválido");

            return cep;
        }

        private void ValidarDadosBasicos(EnderecoModel endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco.Rua))
                throw new Exception("Nome da rua é obrigatório");

            if (string.IsNullOrWhiteSpace(endereco.Numero))
                throw new Exception("Número da residência é obrigatório");

            if (string.IsNullOrWhiteSpace(endereco.Bairro))
                throw new Exception("Bairro é obrigatório");

            if (string.IsNullOrWhiteSpace(endereco.Cidade))
                throw new Exception("Cidade é obrigatória");

            if (string.IsNullOrWhiteSpace(endereco.UF))
                throw new Exception("UF é obrigatória");
        }
    }
}
