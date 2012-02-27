using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Testing;
using Mvc3rdParty.Data.Conventions;
using Mvc3rdParty.Data.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Mvc3rdParty.Data.IntegrationTests.Mapping
{
    public class MappingTestBase<T>: IDisposable where T: class
    {
        private readonly ISessionFactory sessionFactory;
        protected readonly ISession Session;
        static Configuration configuration;

        static MappingTestBase()
        {
            Configure();
        }

        protected MappingTestBase()
        {
            sessionFactory = configuration.BuildSessionFactory();
            Session = sessionFactory.OpenSession();

            new SchemaExport(configuration).Execute(true, true, false, Session.Connection, null);
        }

        static void Configure()
        {
            configuration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql().FormatSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StockMap>()
                                   .Conventions.AddFromAssemblyOf<CustomIdConvention>()).BuildConfiguration();
        }

        public void Dispose()
        {
            if (Session.IsOpen)
            {
                Session.Close();
            }
        }

        protected PersistenceSpecification<T> Specification
        {
            get { return new PersistenceSpecification<T>(Session, new DbTestEqualityComparer()); }
        }
    }
}