using ClienteCRUDDados;
using EnderecoCRUDDados;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCRUDLogica
{
    public class DIService
    {
        protected readonly IClienteDados clienteDados;
        protected readonly IEnderecoDados enderecoDados;
        protected readonly IEstadoCivilDados estadoCivilDados;
        protected readonly IOrgaoExpedicaoDados orgaoExpedicaoDados;
        protected readonly ISexoDados sexoDados;
        protected readonly IRequestLogica requestLogica;

        public DIService()
        {
            var inject = new StandardKernel();
            inject.Bind<IClienteDados>().To<ClienteDados>();
            inject.Bind<IEnderecoDados>().To<EnderecoDados>();
            inject.Bind<IEstadoCivilDados>().To<EstadoCivilDados>();
            inject.Bind<IOrgaoExpedicaoDados>().To<OrgaoExpedicaoDados>();
            inject.Bind<ISexoDados>().To<SexoDados>();
            inject.Bind<IRequestLogica>().To<RequestLogica>();
                        
            clienteDados = inject.Get<ClienteDados>();
            enderecoDados = inject.Get<EnderecoDados>();
            estadoCivilDados = inject.Get<EstadoCivilDados>();
            orgaoExpedicaoDados = inject.Get<OrgaoExpedicaoDados>();
            sexoDados = inject.Get<SexoDados>();
            requestLogica = inject.Get<RequestLogica>();
        }
    }
}
