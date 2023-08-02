using ClienteCRUDDados;
using ClienteCRUDModel;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EnderecoCRUDDados
{
    public interface IEnderecoDados
    {
        EnderecoModel Get(int idEndereco);
        EnderecoModel Get(string cep, string rua, string numero, string complemento, string bairro, string cidade, string uf);
        EnderecoModel Save(EnderecoModel Endereco);
        void Delete(EnderecoModel idEndereco);
    }

    public class EnderecoDados : DIService, IEnderecoDados
    {
        public EnderecoModel Save(EnderecoModel endereco)
        {
            context.Endereco.AddOrUpdate(endereco);

            context.SaveChanges();

            return endereco;
        }

        public void Delete(EnderecoModel endereco)
        {
            context.Endereco.Remove(endereco);

            context.SaveChanges();
        }

        public EnderecoModel Get(string cep, string rua, string numero, string complemento, string bairro, string cidade, string uf)
        {
            return context.Endereco.Where(x =>
                                            x.CEP == cep &&
                                            x.Rua == rua &&
                                            x.Numero == numero &&
                                            x.Complemento == complemento &&
                                            x.Bairro == bairro &&
                                            x.Cidade == cidade &&
                                            x.UF == uf
                                        ).FirstOrDefault();
        }

        public EnderecoModel Get(int idEndereco)
        {
            return context.Endereco.Where(x => x.Id == idEndereco).FirstOrDefault();
        }
    }
}
