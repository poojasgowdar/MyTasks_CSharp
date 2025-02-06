using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }

        public UserProfileDto UserProfile { get; set; }
    }
}
