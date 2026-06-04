namespace backend.DTOs.Student
{
    public class UpdateStudentDto
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
