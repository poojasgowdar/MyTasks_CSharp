namespace APIwithEFCore.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation Property for List of students
        public ICollection<Student> Students { get; set; }
    }
}
