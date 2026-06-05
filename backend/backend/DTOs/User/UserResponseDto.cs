using backend.DTOs.Enrollment;

namespace backend.DTOs.User
{
    public class UserResponseDto
    {

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        List<EnrollmentResponseDto> Enrollments { get; set; }

    }
}
