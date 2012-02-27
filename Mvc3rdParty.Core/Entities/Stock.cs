using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc3rdParty.Core.Entities
{
    public class Stock
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Ticker { get; set; }
        public virtual ICollection<StockMarket> MarketsTradedOn { get; set; }

        public Stock()
        {
            MarketsTradedOn = new List<StockMarket>();
        }
    }
}
