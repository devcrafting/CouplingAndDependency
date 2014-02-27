﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebSite
{
    using WebSite.Controllers;
    using WebSite.Models;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private IDependencyResolver defaultResolver;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            this.defaultResolver = DependencyResolver.Current;
            DependencyResolver.SetResolver(GetService, this.defaultResolver.GetServices);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private object GetService(Type type)
        {
            if (type.Equals(typeof(NewsletterController)))
            {
                return
                    new NewsletterController(
                        new NewsletterService(new RegistrationRepository(), new CategoryRepository(), new PartnerService(), new MailingService()));
            }

            return this.defaultResolver.GetService(type);
        }
    }
}