using Microsoft.AspNetCore.Authorization;

namespace MVC_New_Project.Helpers
{
    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        public BasicAuthorizationAttribute()
        {
            AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme;
        }
    }
    public class BasicAuthenticationDefaults
    {
        public const string AuthenticationScheme = "Basic";
    }
}
