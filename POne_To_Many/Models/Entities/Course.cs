﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
