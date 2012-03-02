using System.Reflection;
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
