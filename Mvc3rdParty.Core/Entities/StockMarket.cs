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
    }
}
