namespace WebSite.Models
{
    public class LdlcService : CategoryRegisteredHandler
    {
        protected override void HandlesInternal(Category category, Registration newRegistration)
        {
            // TODO : send xml file
        }

        protected override bool Supports(Category category, Registration newRegistration)
        {
            return category.Id == 1;
        }
    }

    public abstract class CategoryRegisteredHandler : ICategoryRegisteredHandler
    {
        public void Handles(Category category, Registration newRegistration)
        {
            if (Supports(category, newRegistration))
            {
                HandlesInternal(category, newRegistration);
            }
        }

        protected abstract void HandlesInternal(Category category, Registration newRegistration);

        protected abstract bool Supports(Category category, Registration newRegistration);
    }
}