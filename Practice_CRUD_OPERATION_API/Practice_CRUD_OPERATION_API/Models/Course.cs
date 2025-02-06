namespace Practice_CRUD_OPERATION_API.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }

        // One-to-one relationship with Student
        public ICollection <Student> Student { get; set; } 
        // Navigation Property for Student
    }
}
