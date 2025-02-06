using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Application.ViewModels
{
    public class ResponseDto
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
