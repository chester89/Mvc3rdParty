using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentNHibernate.Testing;
using Mvc3rdParty.Core.Entities;
using Ploeh.AutoFixture;
using Xunit;

namespace Mvc3rdParty.Data.IntegrationTests.Mapping
{
    public class StockMarketMapTests: MappingTestBase<StockMarket>
    {
        [Fact]
        public void CanCorrectlyMapStockMarket()
        {
            Specification
                .VerifyTheMappings(fixture.CreateAnonymous<StockMarket>());
        }

        [Fact]
        public void CanAddStockToStocksTraded()
        {
            var market = new StockMarket()
                             {
                                 Location = "Somewhere nearby",
                                 StocksTraded = new List<Stock>()
                             };
            Session.Save(market);

            var retrievedMarket = Session.Get<StockMarket>(market.Id);

            Assert.Equal(retrievedMarket.StocksTraded.Count, 0);

            var stock = new Stock()
                            {
                                Name = "Somename", Ticker = "SN"
                            };
            retrievedMarket.AddTradedStock(stock);

            Assert.True(stock.Id == 0);
            Session.Save(stock);

            var newlyRetrievedMarket = Session.Get<StockMarket>(market.Id);
            var retrievedStock = Session.Get<Stock>(stock.Id);

            Assert.Equal(newlyRetrievedMarket.StocksTraded.Count, 1);
            Assert.Equal(newlyRetrievedMarket.StocksTraded.ToList()[0], stock);
            Assert.True(retrievedStock.Id > 0);
            Assert.Equal(retrievedStock.MarketsTradedOn.Count, 1);
            Assert.Equal(retrievedStock.MarketsTradedOn.ToList()[0], retrievedMarket);
        }

        [Fact]
        public void CanDeleteStockFromStocksTraded()
        {
            var market = new StockMarket()
                             {
                                 Location = "Somewhere nearby",
                                 StocksTraded = new List<Stock>()
                             };

            var stock = new Stock()
                            {
                                Name = "Somename",
                                Ticker = "SN"
                            };
            market.AddTradedStock(stock);

            Session.Save(market);

            var retrievedMarket = Session.Get<StockMarket>(market.Id);

            Assert.Equal(retrievedMarket.StocksTraded.Count, 1);
            Assert.Equal(retrievedMarket.StocksTraded.ToList()[0], stock);

            retrievedMarket.DeleteTradedStock(stock);
            Session.Update(retrievedMarket);

            var retrievedMarket2 = Session.Get<StockMarket>(market.Id);

            Assert.Equal(retrievedMarket2.StocksTraded.Count, 0);
        }
    }
}