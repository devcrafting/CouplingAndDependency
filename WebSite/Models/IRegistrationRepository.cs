namespace WebSite.Models
{
    public interface IRegistrationRepository
    {
        Registration GetItemByEmail(string email);

        void Save(Registration newRegistration);
    }
}