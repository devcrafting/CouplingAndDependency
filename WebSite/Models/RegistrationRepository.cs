namespace WebSite.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class RegistrationRepository : IRegistrationRepository
    {
        private static readonly IList<Registration> Registrations = new List<Registration>();

        public Registration GetItemByEmail(string email)
        {
            return Registrations.SingleOrDefault(x => x.Email == email);
        }

        public void Save(Registration newRegistration)
        {
            Registrations.Add(newRegistration);
        }
    }
}