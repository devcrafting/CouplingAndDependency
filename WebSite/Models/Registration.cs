namespace WebSite.Models
{
    using System.Collections.Generic;

    public class Registration
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Category> Categories { get; set; }
    }
}