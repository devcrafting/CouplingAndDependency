namespace WebSite.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryRepository
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

        public IEnumerable<Category> GetItems()
        {
            return Categories;
        }
    }
}