namespace WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NewsletterService
    {
        private readonly IRegistrationRepository registrationRepository;

        private readonly CategoryRepository categoryRepository;

        private readonly ICategoryRegisteredHandler[] categoryRegisteredHandlers;

        public NewsletterService(IRegistrationRepository registrationRepository, CategoryRepository categoryRepository, ICategoryRegisteredHandler[] categoryRegisteredHandlers)
        {
            this.registrationRepository = registrationRepository;
            this.categoryRepository = categoryRepository;
            this.categoryRegisteredHandlers = categoryRegisteredHandlers;
        }

        public Registration Register(RegisterData data)
        {
            var existingRegistration = registrationRepository.GetItemByEmail(data.Email);
            if (existingRegistration != null)
            {
                throw new Exception("You are already registered...");
            }

            var newRegistration = new Registration();
            newRegistration.Email = data.Email;
            newRegistration.FirstName = data.FirstName;
            newRegistration.LastName = data.LastName;
            foreach (var category in data.Categories.Select(categoryRepository.GetItem))
            {
                newRegistration.Categories.Add(category);
                foreach (var categoryRegisteredHandler in categoryRegisteredHandlers)
                {
                    categoryRegisteredHandler.Handles(category, newRegistration);
                }
            }

            registrationRepository.Save(newRegistration);
            return newRegistration;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepository.GetItems();
        }
    }
}