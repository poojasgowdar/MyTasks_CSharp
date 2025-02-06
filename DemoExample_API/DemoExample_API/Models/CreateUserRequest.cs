using System.Globalization;

namespace DemoExample_API.Models
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public String Role { get; set; }
    }
}
