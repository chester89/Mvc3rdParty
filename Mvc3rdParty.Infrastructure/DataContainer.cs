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
            Configure(cfg => cfg.Scan(scanner =>
                                               {
                                                   scanner.WithDefaultConventions();
                                                   scanner.TheCallingAssembly();
                                                   scanner.LookForRegistries();
                                               }));
        }
    }
}
