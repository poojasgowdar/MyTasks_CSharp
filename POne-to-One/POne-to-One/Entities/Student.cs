using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POne_to_One.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Course Course { get; set; }
    }
}
