using ClienteCRUDLogica;
using Ninject;

namespace ClienteCRUDWCF
{
    public class DIService
    {

        protected readonly IClienteLogica clienteLogica;
        protected readonly IEnderecoLogica enderecoLogica;
        protected readonly IEstadoCivilLogica estadoCivilLogica;
        protected readonly IOrgaoExpedicaoLogica orgaoExpedicaoLogica;
        protected readonly ISexoLogica sexoLogica;

        public DIService()
        {
            var inject = new StandardKernel();
            inject.Bind<IClienteLogica>().To<ClienteLogica>();
            inject.Bind<IEnderecoLogica>().To<EnderecoLogica>();
            inject.Bind<IEstadoCivilLogica>().To<EstadoCivilLogica>();
            inject.Bind<IOrgaoExpedicaoLogica>().To<OrgaoExpedicaoLogica>();
            inject.Bind<ISexoLogica>().To<SexoLogica>();

            clienteLogica = inject.Get<ClienteLogica>();
            enderecoLogica = inject.Get<EnderecoLogica>();
            estadoCivilLogica = inject.Get<EstadoCivilLogica>();
            orgaoExpedicaoLogica = inject.Get<OrgaoExpedicaoLogica>();
            sexoLogica = inject.Get<SexoLogica>();            
        }
    }
}