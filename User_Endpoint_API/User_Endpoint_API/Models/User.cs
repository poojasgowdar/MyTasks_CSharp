using System.ComponentModel.DataAnnotations;

namespace User_Endpoint_API.Models
{
    public class User
    {
        public int Id { get; set; }
     
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsAdmin => Role == "Admin";
        public bool IsUser => Role == "User";
    }
}
