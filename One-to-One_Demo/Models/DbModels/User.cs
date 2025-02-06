using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DbModels
{
    public class User
    {
        public int UserId { get; set; }
       
        public string UserName { get; set; }

        //Navigation Property
        public UserProfile UserProfile { get; set; }
    }
}
