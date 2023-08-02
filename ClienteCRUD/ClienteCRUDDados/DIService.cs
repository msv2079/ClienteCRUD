using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCRUDDados
{
    public class DIService
    {
        protected readonly ClienteCRUDContext context;

        public DIService()
        {
            var inject = new StandardKernel();
            inject.Bind<ClienteCRUDContext>().ToSelf();

            context = inject.Get<ClienteCRUDContext>();
        }
    }
}
