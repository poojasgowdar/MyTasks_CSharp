using Microsoft.AspNetCore.Authorization;

namespace SessionTracking_Controller.Helpers
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
