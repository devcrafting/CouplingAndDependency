namespace WebSite.Models
{
    using System.Text;

    public class MailingService : ICategoryRegisteredHandler
    {
        public void Handles(Category category, Registration newRegistration)
        {
            string mailBody;
            switch (category.Id)
            {
                case 1:
                case 2:
                    var mailBodyBuilder = new StringBuilder();
                    mailBodyBuilder.AppendLine("You will like the following products : ");
                    /******* Add lot of things... ********/
                    mailBody = mailBodyBuilder.ToString();
                    break;
                case 3:
                    /******* Add lot of things... ********/
                    break;
                // Do nothing by default
            }

            // Send mail
        }
    }
}