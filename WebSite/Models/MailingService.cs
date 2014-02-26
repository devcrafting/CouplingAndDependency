namespace WebSite.Models
{
    using System.Text;

    public class MailingService
    {
        public static void SendMail(Category category, Registration newRegistration)
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
                    break;
                // Do nothing by default
            }
        }
    }
}