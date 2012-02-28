using System.Collections.Generic;
using FluentNHibernate.Testing;
using Mvc3rdParty.Core.Entities;
using Ploeh.AutoFixture;

namespace Mvc3rdParty.Data.IntegrationTests.Mapping
{
    public class AutoFixtureMappingTestBase<T> : MappingTestBase<T> where T : class
    {
        protected Fixture Fixture;

        public AutoFixtureMappingTestBase()
        {
            Fixture = new Fixture();
            Fixture.Customize(new MultipleCustomization());
        }

        public override void CanCorrectlyMapEntity()
        {
            Specification
               .VerifyTheMappings(Fixture.CreateAnonymous<T>());
        }
    }
}