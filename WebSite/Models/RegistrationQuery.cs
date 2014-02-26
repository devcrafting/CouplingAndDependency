namespace WebSite.Models
{
    public class RegistrationQuery : Query<Registration>
    {
        public RegistrationQuery WithMail(string email)
        {
            this.AddFilter(x => x.Email == email);
            return this;
        }
    }
}