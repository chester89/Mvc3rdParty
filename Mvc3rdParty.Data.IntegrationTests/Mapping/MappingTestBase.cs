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
        private readonly ISession session;
        static Configuration configuration;

        static MappingTestBase()
        {
            Configure();

            new SchemaExport(configuration).Create(true, true);
        }

        protected MappingTestBase()
        {
            sessionFactory = configuration.BuildSessionFactory();
            session = sessionFactory.OpenSession();
        }

        static void Configure()
        {
            configuration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StockMap>()
                                   .Conventions.AddFromAssemblyOf<CustomIdConvention>()).BuildConfiguration();
        }

        public void Dispose()
        {
            if (session.IsOpen)
            {
                session.Close();
            }
        }

        protected PersistenceSpecification<T> Specification
        {
            get { return new PersistenceSpecification<T>(session, new DbTestEqualityComparer()); }
        }
    }
}