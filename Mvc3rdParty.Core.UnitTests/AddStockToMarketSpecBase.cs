using Machine.Specifications;
using Mvc3rdParty.Core.Entities;

namespace Mvc3rdParty.Core.UnitTests
{
    public class When_adding_stock_to_a_stock_market_fixture
    {
        private Because of = () => stockMarket.AddTradedStock(stock);
        protected static StockMarket stockMarket;
        protected static Stock stock;
    }
}