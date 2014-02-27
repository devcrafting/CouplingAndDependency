namespace WebSite.Controllers
{
    using System;
    using System.Web.Mvc;

    using WebSite.Models;

    public class NewsletterController : Controller
    {
        public ActionResult Index()
        {
            var availableCategories = NewsletterService.GetAllCategories();
            return View(availableCategories);
        }

        public ActionResult Register(RegisterData data)
        {
            try
            {
                // TODO : validation logic
                var registration = NewsletterService.Register(data);
                return this.View(registration);
            }
            catch (Exception e)
            {
                return this.View("Error", (object)e.Message);
            }
        }
    }
}
