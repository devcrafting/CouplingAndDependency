namespace WebSite.Controllers
{
    using System;
    using System.Web.Mvc;

    using WebSite.Models;

    public class NewsletterController : Controller
    {
        private readonly NewsletterService newsletterService;

        public NewsletterController(NewsletterService newsletterService)
        {
            this.newsletterService = newsletterService;
        }

        public ActionResult Index()
        {
            var availableCategories = newsletterService.GetAllCategories();
            return View(availableCategories);
        }

        public ActionResult Register(RegisterData data)
        {
            try
            {
                // TODO : validation logic
                var registration = newsletterService.Register(data);
                return this.View(registration);
            }
            catch (Exception e)
            {
                return this.View("Error", (object)e.Message);
            }
        }
    }
}
