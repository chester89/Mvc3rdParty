using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc3rdParty.Core.Entities
{
    public class StockMarket
    {
        public virtual int Id { get; private set; }
        public virtual ICollection<Stock> StocksTraded { get; set; }
        public virtual string Location { get; set; }

        public StockMarket()
        {
            StocksTraded = new List<Stock>();
        }

        public virtual void AddTradedStock(Stock stock)
        {
            if (!StocksTraded.Contains(stock) && !stock.MarketsTradedOn.Contains(this))
            {
                stock.MarketsTradedOn.Add(this);
                StocksTraded.Add(stock);
            }
        }

        public virtual void DeleteTradedStock(Stock stock)
        {
            if (StocksTraded.Contains(stock) && stock.MarketsTradedOn.Contains(this))
            {
                stock.MarketsTradedOn.Remove(this);
                StocksTraded.Remove(stock);
            }
        }
    }
}
