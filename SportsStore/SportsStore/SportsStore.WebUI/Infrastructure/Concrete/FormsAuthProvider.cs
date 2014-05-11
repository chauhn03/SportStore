namespace SportsStore.WebUI.Infrastructure.Concrete
{
    using SportsStore.Domain.Abstract;
    using System.Web.Security;

    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string userName, string password)
        {
            bool result = FormsAuthentication.Authenticate(userName, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(userName, false);
            }

            return result;
        }
    }
}