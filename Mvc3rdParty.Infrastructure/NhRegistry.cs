using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mvc3rdParty.Core;
using Mvc3rdParty.Data;
using NHibernate;
using StructureMap.Configuration.DSL;

namespace Mvc3rdParty.Infrastructure
{
    public class NhRegistry: Registry
    {
        public NhRegistry()
        {
            For<ISessionFactory>().Singleton().Use(NhConfigurationHelper.CreateSessionFactory);
            For<ISession>().HttpContextScoped().Use(context => context.TryGetInstance<ISessionFactory>().OpenSession());
            Scan(sc =>
                     {
                         sc.AssembliesFromApplicationBaseDirectory();
                         sc.ConnectImplementationsToTypesClosing(typeof (IRepository<>));
                     });
        }
    }
}
