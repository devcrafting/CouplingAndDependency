namespace WebSite.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class RegistrationRepository : IRepository<Registration>
    {
        private static readonly IList<Registration> Registrations = new List<Registration>();

        public Registration GetItemByEmail(string email)
        {
            return Registrations.SingleOrDefault(x => x.Email == email);
        }

        public Registration GetItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public Registration GetItem(Query<Registration> queryObject)
        {
            return queryObject.GetSingle(Registrations.AsQueryable());
        }

        public IEnumerable<Registration> GetItems(Query<Registration> queryObject = null)
        {
            if (queryObject == null)
            {
                return Registrations;
            }

            return queryObject.GetList(Registrations.AsQueryable());
        }

        public void Save(Registration newRegistration)
        {
            Registrations.Add(newRegistration);
        }
    }
}