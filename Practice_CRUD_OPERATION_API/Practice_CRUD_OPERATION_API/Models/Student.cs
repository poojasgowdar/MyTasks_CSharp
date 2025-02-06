namespace Practice_CRUD_OPERATION_API.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        // One-to-one relationship with Course
        public int CourseId { get; set; }  // Foreign Key for Course
        public Course Course { get; set; } // Navigation Property for Course
    }
}
