using FluentNHibernate.Testing;
using Mvc3rdParty.Core.Entities;
using Xunit;

namespace Mvc3rdParty.Data.IntegrationTests.Mapping
{
    public class StockMapTests: MappingTestBase<Stock>
    {
        [Fact]
        public override void CanCorrectlyMapEntity()
        {
            Specification
                .CheckProperty(s => s.Name, "Facebook")
                .CheckProperty(s => s.Ticker, "FB")
                .VerifyTheMappings();
        }
    }
}
