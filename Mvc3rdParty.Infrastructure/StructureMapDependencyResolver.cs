using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Pipeline;

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
            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                return container.TryGetInstance(serviceType);
            }
            return container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
        }

        public void DisposeOfHttpCachedObjects()
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }
    }
}
