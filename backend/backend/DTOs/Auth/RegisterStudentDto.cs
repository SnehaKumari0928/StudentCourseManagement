namespace backend.DTOs.Auth
{
    public class RegisterStudentDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; } = "Student";

    }
}
