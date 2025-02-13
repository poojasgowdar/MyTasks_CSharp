using Microsoft.AspNetCore.Authorization;

namespace Helpers.Helper
{
    public class BasicAuthenticationAttribute : AuthorizeAttribute
    {
        public BasicAuthenticationAttribute()
        {
            AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme;
        }
    }
    public class BasicAuthenticationDefaults
    {
        public const string AuthenticationScheme = "Basic";
    }

}
