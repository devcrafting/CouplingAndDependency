using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebSite
{
    using Microsoft.Practices.Unity;

    using WebSite.Controllers;
    using WebSite.Models;

    using UnityConfiguration;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private UnityContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            this.container = new UnityContainer();
            this.container.RegisterType<IRegistrationRepository, RegistrationRepository>();
            DependencyResolver.SetResolver(GetService, GetServices);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private IEnumerable<object> GetServices(Type arg)
        {
            return this.container.ResolveAll(arg);
        }

        private object GetService(Type type)
        {
            return this.container.IsRegistered(type) || (type.IsClass && !type.IsAbstract) ? this.container.Resolve(type) : null;
        }
    }
}