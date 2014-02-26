namespace WebSite.Models
{
    public class LdlcService : CategoryRegisteredHandler
    {
        protected override bool Supports(Category category, Registration newRegistration)
        {
            return category.Id == 1;
        }

        protected override void HandlesInternal(Category category, Registration newRegistration)
        {
            // TODO : send xml file
        }
    }
}