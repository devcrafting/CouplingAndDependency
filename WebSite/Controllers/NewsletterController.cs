namespace WebSite.Controllers
{
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
            var availableCategories = this.newsletterService.GetAllCategories();
            return View(availableCategories);
        }

        public ActionResult Register(RegisterData data)
        {
            // TODO : validation logic
            this.newsletterService.Register(data);
            return this.View();
        }
    }
}
