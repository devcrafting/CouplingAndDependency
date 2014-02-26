namespace WebSite.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryRepository
    {
        private static readonly IList<Category> Categories = new List<Category>(new[]
                       {
                           new Category() { Id = 1, Name = "Informatique" }, 
                           new Category() { Id = 2, Name = "Jardin" },
                           new Category() { Id = 3, Name = "Animalerie" }
                       });

        public static Category GetItem(int id)
        {
            return Categories.SingleOrDefault(x => x.Id == id);
        }

        public static IEnumerable<Category> GetItems()
        {
            return Categories;
        }
    }
}