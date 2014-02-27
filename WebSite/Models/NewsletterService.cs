namespace WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NewsletterService
    {
        private readonly RegistrationRepository registrationRepository;

        private readonly CategoryRepository categoryRepository;

        private readonly PartnerService partnerService;

        private readonly MailingService mailingService;

        public NewsletterService(RegistrationRepository registrationRepository, CategoryRepository categoryRepository, PartnerService partnerService, MailingService mailingService)
        {
            this.registrationRepository = registrationRepository;
            this.categoryRepository = categoryRepository;
            this.partnerService = partnerService;
            this.mailingService = mailingService;
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
                partnerService.Notify(category, newRegistration);
                mailingService.SendMail(category, newRegistration);
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