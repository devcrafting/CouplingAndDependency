namespace WebSite
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Microsoft.Practices.Unity;

    using UnityConfiguration;

    public class MvcApplication : System.Web.HttpApplication
    {
        private UnityContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            this.ConfigureIoc();
            DependencyResolver.SetResolver(this.GetService, this.GetServices);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureIoc()
        {
            this.container = new UnityContainer();
            this.container.Configure(x => x.AddRegistry<ConventionRegistry>());
        }

        private object GetService(Type type)
        {
            // return null when no type registered (according requested contract)
            return this.container.IsRegistered(type) || (type.IsClass && !type.IsAbstract) ? this.container.Resolve(type) : null;
        }

        private IEnumerable<object> GetServices(Type type)
        {
            return this.container.ResolveAll(type);
        }
    }
}