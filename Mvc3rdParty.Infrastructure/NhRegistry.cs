using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mvc3rdParty.Data;
using NHibernate;
using NHibernate.Cfg;
using StructureMap.Configuration.DSL;

namespace Mvc3rdParty.Infrastructure
{
    public class NhRegistry: Registry
    {
        public NhRegistry()
        {
            For<ISessionFactory>().Singleton().Use(NhConfigurationHelper.CreateSessionFactory);
            For<Configuration>().Singleton().Use(NhConfigurationHelper.GetConfiguration);
            For<ISession>().HttpContextScoped().Use(context => context.TryGetInstance<ISessionFactory>().OpenSession());
        }
    }
}
