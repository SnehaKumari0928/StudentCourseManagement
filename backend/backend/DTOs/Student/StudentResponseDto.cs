namespace backend.DTOs.Student
{
    public class StudentResponseDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
