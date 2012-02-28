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
    public class When_adding_new_traded_stock_to_a_stock_market : When_adding_stock_to_a_stock_market_fixture
    {
        private Establish context = () =>
                                        {
                                            stockMarket = new StockMarket();
                                            stock = new Stock() { Name = "Somename", Ticker = "SN"};
                                        };

        private It should_add_stock_to_stocks_traded_on_this_market = () => Assert.Contains(stock, stockMarket.StocksTraded);
        private It should_add_current_stock_market_to_list_of_markets_where_stock_is_traded = () => Assert.Contains(stockMarket, stock.MarketsTradedOn);
    }

    [Subject(typeof(StockMarket))]
    public class When_adding_already_traded_stock_to_a_stock_market: When_adding_stock_to_a_stock_market_fixture
    {
        private Establish context = () =>
                                        {
                                            stockMarket = new StockMarket();
                                            stock = new Stock() { Name = "Facebook", Ticker = "FB" };
                                            stockMarket.AddTradedStock(stock);
                                            tradedStocksCount = stockMarket.StocksTraded.Count;
                                            marketsCountForStock = stock.MarketsTradedOn.Count;
                                        };

        private It should_not_add_stock_to_stocks_traded_on_this_market = () => Assert.Equal(tradedStocksCount, stockMarket.StocksTraded.Count);

        private It should_not_add_stock_market_to_list_of_markets_where_stock_is_traded = () => Assert.Equal(marketsCountForStock, stock.MarketsTradedOn.Count);

        private static int tradedStocksCount;
        private static int marketsCountForStock;
    }
}
