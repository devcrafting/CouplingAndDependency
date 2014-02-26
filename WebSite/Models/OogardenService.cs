namespace WebSite.Models
{
    public class OogardenService : CategoryRegisteredHandler
    {
        protected override bool Supports(Category category, Registration newRegistration)
        {
            return category.Id == 2;
        }

        protected override void HandlesInternal(Category category, Registration newRegistration)
        {
            // call web service
        }
    }
}