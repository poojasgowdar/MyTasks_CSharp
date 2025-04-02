using MiniOffice365Backend.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOffice365Backend.Manager
{
    public interface IUserManager
    {
        Task<UserDTO> GetUserByEmailAsync(string email);
        Task<bool> RegisterUserAsync(RegisterRequest request);
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(int id, UserDTO user);
        Task<bool> DeleteUserAsync(int id);
    }

}
