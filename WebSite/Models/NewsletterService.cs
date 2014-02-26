namespace WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NewsletterService
    {
        private readonly IRepository<Registration> registrationRepository;

        private readonly IRepository<Category> categoryRepository;

        private readonly ICategoryRegisteredHandler[] categoryRegisteredHandlers;

        public NewsletterService(IRepository<Registration> registrationRepository, IRepository<Category> categoryRepository, ICategoryRegisteredHandler[] categoryRegisteredHandlers)
        {
            this.registrationRepository = registrationRepository;
            this.categoryRepository = categoryRepository;
            this.categoryRegisteredHandlers = categoryRegisteredHandlers;
        }

        public Registration Register(RegisterData data)
        {
            var existingRegistration = this.registrationRepository.GetItem(new RegistrationQuery().WithMail(data.Email));
            if (existingRegistration != null)
            {
                throw new Exception("You are already registered...");
            }

            var newRegistration = new Registration();
            newRegistration.Email = data.Email;
            newRegistration.FirstName = data.FirstName;
            newRegistration.LastName = data.LastName;
            foreach (var category in data.Categories.Select(this.categoryRepository.GetItem))
            {
                newRegistration.Categories.Add(category);
                foreach (var categoryRegisteredHandler in this.categoryRegisteredHandlers)
                {
                    categoryRegisteredHandler.Handles(category, newRegistration);
                }
            }

            this.registrationRepository.Save(newRegistration);
            return newRegistration;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return this.categoryRepository.GetItems();
        }
    }
}