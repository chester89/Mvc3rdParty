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
            Configure(cfg => cfg.Scan(asc =>
                                               {
                                                   asc.WithDefaultConventions();
                                                   asc.TheCallingAssembly();
                                                   asc.LookForRegistries();
                                               }));
        }
    }
}
