namespace WebSite.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryRepository : IRepository<Category>
    {
        private static readonly IList<Category> Categories = new List<Category>(new[]
                       {
                           new Category() { Id = 1, Name = "Computers" }, 
                           new Category() { Id = 2, Name = "Garden" },
                           new Category() { Id = 3, Name = "Pets" }
                       });

        public Category GetItem(int id)
        {
            return Categories.SingleOrDefault(x => x.Id == id);
        }

        public Category GetItem(Query<Category> queryObject)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetItems(Query<Category> queryObject = null)
        {
            return Categories;
        }

        public void Save(Category newRegistration)
        {
            throw new System.NotImplementedException();
        }
    }
}