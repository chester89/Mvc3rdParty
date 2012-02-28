using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Mvc3rdParty.Core.Entities;
using Xunit;

namespace Mvc3rdParty.Core.UnitTests
{
    [Subject(typeof(StockMarket))]
    public class When_removing_traded_stock_from_stock_market : When_removing_stock_from_stock_market_fixture
    {
        private It stock_should_be_absent_from_list_of_stocks_traded_on_this_market = () => Assert.DoesNotContain(stock, stockMarket.StocksTraded);
        private It market_should_be_absent_from_list_of_markets_stock_is_traded_on = () => Assert.DoesNotContain(stockMarket, stock.MarketsTradedOn);

        private Establish context = () =>
                                        {
                                            stockMarket = new StockMarket();
                                            stock = new Stock() {Name = "Google", Ticker = "GOOG"};
                                            stockMarket.AddTradedStock(stock);
                                        };
    }

    [Subject(typeof(StockMarket))]
    public class When_removing_not_traded_stock_from_stock_market: When_removing_stock_from_stock_market_fixture
    {
        private Establish context = () =>
                                        {
                                            stockMarket = new StockMarket();
                                            stocksTradedCount = stockMarket.StocksTraded.Count;
                                            stock = new Stock() {Name = "Google", Ticker = "GOOG"};
                                            marketsCountForStock = stock.MarketsTradedOn.Count;
                                        };

        private static int stocksTradedCount;
        private static int marketsCountForStock;

        It should_not_affect_list_of_markets_stocks_is_traded_on = () => Assert.Equal(marketsCountForStock, stock.MarketsTradedOn.Count);
        It should_not_affect_list_of_stocks_traded_on_a_market = () => Assert.Equal(stocksTradedCount, stockMarket.StocksTraded.Count);
    }
}
