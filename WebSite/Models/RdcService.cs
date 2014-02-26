namespace WebSite.Models
{
    public class RdcService : CategoryRegisteredHandler
    {
        protected override bool Supports(Category category, Registration newRegistration)
        {
            return category.Id == 1;
        }

        protected override void HandlesInternal(Category category, Registration newRegistration)
        {
            // send edi file
        }
    }
}