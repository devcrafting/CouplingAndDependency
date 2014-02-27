namespace WebSite.Models
{
    public class PartnerService
    {
        public void Notify(Category category, Registration newRegistration)
        {
            switch (category.Id)
            {
                case 1:
                    LdlcService.SendXmlFile(category, newRegistration.Email);
                    RdcService.SendEdiFile(category, newRegistration);
                    break;
                case 2:
                    OogardenService.CallWebService(category, newRegistration);
                    break;
                // Nothing to do by default
            }
        }
    }
}