namespace WebSite.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class RegistrationRepository
    {
        private static readonly IList<Registration> Registrations = new List<Registration>();

        public static Registration GetItemByEmail(string email)
        {
            return Registrations.SingleOrDefault(x => x.Email == email);
        }

        public static void Save(Registration newRegistration)
        {
            Registrations.Add(newRegistration);
        }
    }
}