namespace WebSite.Models
{
    public interface ICategoryRegisteredHandler
    {
        void Handles(Category category, Registration newRegistration);
    }
}