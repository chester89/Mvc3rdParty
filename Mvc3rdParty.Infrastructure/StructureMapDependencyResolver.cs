using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using StructureMap;

namespace Mvc3rdParty.Infrastructure
{
    public class StructureMapDependencyResolver: IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver()
        {
            container = new DataContainer();
        }

        public object GetService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
        }
    }
}
