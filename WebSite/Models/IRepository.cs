namespace WebSite.Models
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        T GetItem(int id);

        T GetItem(Query<T> queryObject);

        IEnumerable<T> GetItems(Query<T> queryObject = null);

        void Save(T newRegistration);
    }
}