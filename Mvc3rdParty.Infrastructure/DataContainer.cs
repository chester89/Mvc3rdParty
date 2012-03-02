using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Mvc3rdParty.Infrastructure
{
    public class DataContainer: Container
    {
        public DataContainer()
        {
            Configure(c => c.AddRegistry<NhRegistry>());
        }
    }
}
