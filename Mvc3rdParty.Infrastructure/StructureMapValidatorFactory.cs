using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using FluentValidation;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Mvc3rdParty.Infrastructure
{
    public class StructureMapValidatorFactory : ValidatorFactoryBase
    {
        private readonly IContainer container;

        public StructureMapValidatorFactory(Registry registry)
        {
            container = new Container();
            container.Configure(c => c.AddRegistry(registry));
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            var validator = container.TryGetInstance(validatorType) as IValidator;
            return validator;
        }
    }

    static class Hardcore
    {
        private static string AspNetNamespace = "ASP";
        public static Assembly getApplicationAssembly()
        {
            // Try the EntryAssembly, this doesn't work for ASP.NET classic pipeline (untested on integrated)
            Assembly ass = Assembly.GetEntryAssembly();

            // Look for web application assembly
            HttpContext ctx = HttpContext.Current;
            if (ctx != null)
                ass = getWebApplicationAssembly(ctx);

            // Fallback to executing assembly
            return ass ?? (Assembly.GetExecutingAssembly());
        }

        private static Assembly getWebApplicationAssembly(HttpContext context)
        {
            IHttpHandler handler = context.CurrentHandler;
            if (handler == null) return null;

            Type type = handler.GetType();
            while (type != null && type != typeof(object) && type.Namespace == AspNetNamespace)
                type = type.BaseType;

            return type.Assembly;
        }
    }


}
