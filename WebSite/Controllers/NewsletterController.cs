namespace WebSite.Controllers
{
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
            // TODO : validation logic
            NewsletterService.Register(data);
            return this.View();
        }
    }
}
