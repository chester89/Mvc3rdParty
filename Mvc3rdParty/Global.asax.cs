using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation.Mvc;
using Mvc3rdParty.Infrastructure;

namespace Mvc3rdParty.Web
{
    public class MvcApplication: HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            DependencyResolver.SetResolver(new StructureMapDependencyResolver());
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            FluentValidationModelValidatorProvider.Configure(cfg =>
                                                                 {
                                                                     cfg.ValidatorFactory = new StructureMapValidatorFactory();
                                                                 });
        }

        protected void Application_EndRequest()
        {
            dynamic resolver = DependencyResolver.Current;
            resolver.DisposeofHttpCachedObjects();
        }
    }
}