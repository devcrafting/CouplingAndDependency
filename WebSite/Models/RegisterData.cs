namespace WebSite.Models
{
    using System.Collections.Generic;

    public class RegisterData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IList<int> Categories { get; set; }
    }
}