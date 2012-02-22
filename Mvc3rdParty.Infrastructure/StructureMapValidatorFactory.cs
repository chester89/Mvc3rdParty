using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using StructureMap;

namespace Mvc3rdParty.Infrastructure
{
    public class StructureMapValidatorFactory : ValidatorFactoryBase
    {
        private readonly IContainer container;

        public StructureMapValidatorFactory()
        {
            container = new Container(cfg => cfg.Scan(sc =>
                                                          {
                                                              sc.TheCallingAssembly();
                                                              sc.WithDefaultConventions();
                                                              sc.LookForRegistries();
                                                          }));
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return container.TryGetInstance(validatorType) as IValidator;
        }
    }
}
