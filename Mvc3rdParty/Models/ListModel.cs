using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc3rdParty.Core.Entities;

namespace Mvc3rdParty.Web.Models
{
    public class ListModel
    {
        public ICollection<Stock> Stocks { get; set; }

        public ListModel()
        {
            Stocks = new List<Stock>();
        }
    }
}