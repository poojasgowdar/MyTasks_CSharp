using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;

namespace DemoExample_API.Helper
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        
        public IConfiguration Configuration { get; }
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder,
            ISystemClock clock, IConfiguration configuration) : base(options, logger, encoder, clock)
        {
            Configuration = configuration;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                if (username != Configuration["BasicAuth:Username"] || password != Configuration["BasicAuth:Password"])
                {
                    return AuthenticateResult.Fail("Invalid Username or Password");
                }
                //create claims
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Name, username),
                };
                // create Identity
                var Identity = new ClaimsIdentity(claims, Scheme.Name);
                var Principal = new ClaimsPrincipal(Identity);
                var Ticket = new AuthenticationTicket(Principal, Scheme.Name);
                return AuthenticateResult.Success(Ticket);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization header");
            }
        }
    }
}

