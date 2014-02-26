namespace WebSite
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Microsoft.Practices.Unity;

    using WebSite.Models;

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
            this.container.RegisterType<IRepository<Registration>, RegistrationRepository>();
            this.container.RegisterType<IRepository<Category>, CategoryRepository>();
            this.container.RegisterType<ICategoryRegisteredHandler, LdlcService>("ldlc");
            this.container.RegisterType<ICategoryRegisteredHandler, RdcService>("rdc");
            this.container.RegisterType<ICategoryRegisteredHandler, OogardenService>("oog");
            this.container.RegisterType<ICategoryRegisteredHandler, MailingService>("mail");
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