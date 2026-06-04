namespace backend.DTOs.Course
{
    public class CourseResponseDto
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
        public int Price { get; set; }
        public int DurationInMonths { get; set; }
    }
}
