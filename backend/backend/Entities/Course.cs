namespace backend.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int price { get; set; }
        public int DurationInMonths { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();


    }
}
