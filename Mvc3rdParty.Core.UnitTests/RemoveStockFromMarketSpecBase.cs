using Machine.Specifications;
using Mvc3rdParty.Core.Entities;

namespace Mvc3rdParty.Core.UnitTests
{
    public class When_removing_stock_from_stock_market_fixture
    {
        private Because of = () => stockMarket.DeleteTradedStock(stock);
        protected static StockMarket stockMarket;
        protected static Stock stock;
    }
}