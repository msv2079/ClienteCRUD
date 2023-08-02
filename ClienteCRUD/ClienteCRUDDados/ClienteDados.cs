using ClienteCRUDModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ClienteCRUDDados
{
    public interface IClienteDados
    {
        IEnumerable<ClienteModel> GetAll(int pagina, int paginacao);
        ClienteModel Get(int idCliente);
        ClienteModel Save(ClienteModel cliente);
        void Delete(ClienteModel idCliente);
        ClienteModel GetByCPF(string cpf);
    }

    public class ClienteDados : DIService, IClienteDados
    {
        public ClienteModel Save(ClienteModel cliente)
        {
            context.Cliente.AddOrUpdate(cliente);
            context.SaveChanges();

            return cliente;
        }

        public void Delete(ClienteModel cliente)
        {
            context.Cliente.Remove(cliente);

            context.SaveChanges();
        }

        public IEnumerable<ClienteModel> GetAll(int pagina, int paginacao)
        {
            var dados = context.Cliente.OrderBy(x => x.Id).Skip((pagina - 1) * paginacao).Take(paginacao).ToList();
            var totalClientes = context.Cliente.Count();
            dados = dados.Select(x => { x.TotalClientes = totalClientes; return x; }).ToList();

            return dados;
        }

        public ClienteModel Get(int idCliente)
        {
            return context.Cliente.Where(x => x.Id == idCliente).FirstOrDefault();
        }

        public ClienteModel GetByCPF(string cpf) 
        {
            return context.Cliente.Where(x => x.CPF == cpf).FirstOrDefault();
        }
    }
}
