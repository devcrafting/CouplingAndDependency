namespace WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NewsletterService
    {
        public static Registration Register(RegisterData data)
        {
            var existingRegistration = RegistrationRepository.GetItemByEmail(data.Email);
            if (existingRegistration != null)
            {
                throw new Exception("You are already registered...");
            }

            var newRegistration = new Registration();
            newRegistration.Email = data.Email;
            newRegistration.FirstName = data.FirstName;
            newRegistration.LastName = data.LastName;
            foreach (var category in data.Categories.Select(CategoryRepository.GetItem))
            {
                newRegistration.Categories.Add(category);
                PartnerService.Notify(category, newRegistration);
                MailingService.SendMail(category, newRegistration);
            }

            RegistrationRepository.Save(newRegistration);
            return newRegistration;
        }

        public static IEnumerable<Category> GetAllCategories()
        {
            return CategoryRepository.GetItems();
        }
    }
}