namespace WebSite.Models
{
    public abstract class CategoryRegisteredHandler : ICategoryRegisteredHandler
    {
        public void Handles(Category category, Registration newRegistration)
        {
            if (this.Supports(category, newRegistration))
            {
                this.HandlesInternal(category, newRegistration);
            }
        }

        protected abstract bool Supports(Category category, Registration newRegistration);

        protected abstract void HandlesInternal(Category category, Registration newRegistration);
    }
}