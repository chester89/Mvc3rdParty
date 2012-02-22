using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using StructureMap.Configuration.DSL;

namespace Mvc3rdParty.Infrastructure
{
    public class FluentValidationRegistry: Registry
    {
        public FluentValidationRegistry()
        {
            Scan(sc =>
                     {
                         sc.TheCallingAssembly();
                         sc.ConnectImplementationsToTypesClosing(typeof (IValidator<>));
                     });
        }
    }
}
