using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Mvc3rdParty.Core.Entities;

namespace Mvc3rdParty.Data.Mappings
{
    public class StockMarketMap: ClassMap<StockMarket>
    {
        public StockMarketMap()
        {
            Id(x => x.Id);
            Map(x => x.Location);
            HasManyToMany(x => x.StocksTraded);
        }
    }
}
