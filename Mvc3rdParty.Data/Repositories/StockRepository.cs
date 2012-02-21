using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mvc3rdParty.Core.Entities;
using Mvc3rdParty.Data.Foundation;
using NHibernate;

namespace Mvc3rdParty.Data.Repositories
{
    public class StockRepository: NhRepositoryBase<Stock>
    {
        public StockRepository(ISession session) : base(session)
        {
        }
    }
}
