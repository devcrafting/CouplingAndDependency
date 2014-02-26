namespace WebSite
{
    using System;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using WebSite.Controllers;
    using WebSite.Models;

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IDependencyResolver defaultDependencyResolver;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            defaultDependencyResolver = DependencyResolver.Current;
            DependencyResolver.SetResolver(this.GetService, defaultDependencyResolver.GetServices);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private object GetService(Type type)
        {
            if (type == typeof(NewsletterController))
            {
                return
                    new NewsletterController(
                        new NewsletterService(new RegistrationRepository(), new CategoryRepository(), new ICategoryRegisteredHandler[] { new PartnerService(), new MailingService() }));
            }

            return defaultDependencyResolver.GetService(type);
        }
    }
}