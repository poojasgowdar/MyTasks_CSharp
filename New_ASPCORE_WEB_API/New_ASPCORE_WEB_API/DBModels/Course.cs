namespace New_ASPCORE_WEB_API.DBModels
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }    
    }
}
