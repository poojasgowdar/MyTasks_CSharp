using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        //foreign Key
        public int UserId { get; set; }
        //Navigation Property
        public  User User { get; set; }
    }
}
