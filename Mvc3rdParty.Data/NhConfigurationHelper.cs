using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Mvc3rdParty.Data.Mappings;
using NHibernate;
using NHibernate.Cfg;

namespace Mvc3rdParty.Data
{
    public class NhConfigurationHelper
    {
        public static Configuration GetConfiguration()
        {
            return GetFluentConfiguration().BuildConfiguration();
        }

        private static FluentConfiguration GetFluentConfiguration()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        builder => builder.FromConnectionStringWithKey("testDb")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StockMap>()
                /*.Conventions.AddFromAssemblyOf<IdConvention>()*/);
        }

        public static ISessionFactory CreateSessionFactory()
        {
            return GetFluentConfiguration().BuildSessionFactory();
        }
    }
}
