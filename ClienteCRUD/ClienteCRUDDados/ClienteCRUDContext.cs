using ClienteCRUDModel;
using System.Data.Entity;

namespace ClienteCRUDDados
{
    public class ClienteCRUDContext : DbContext
    {
        public ClienteCRUDContext() : base("name=ClienteCRUDCnn")
        {
            
        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }
        public DbSet<EstadoCivilModel> EstadoCivil { get; set; }
        public DbSet<OrgaoExpedicaoModel> OrgaoExpedicao { get; set; }
        public DbSet<SexoModel> Sexo { get; set; }
    }
}
