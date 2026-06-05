namespace backend.DTOs.Enrollment
{
    public class EnrollmentResponseDto
    {

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public int Price { get; set; }
        public int DurationInMonths { get; set; }
    }
}
