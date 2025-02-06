namespace Web_Application.ViewModels
{
    public class ResponseUserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; internal set; }
    }
}
