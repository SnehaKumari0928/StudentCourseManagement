using backend.DTOs.Auth;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementation
{
    public class AuthService: IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;

        public AuthService(IUserRepository userRepository, IStudentRepository studentRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
        }

        public async Task<AuthResponseDto> Register(RegisterStudentDto registerStudentDto)
        {
            var user = await _userRepository.GetByEmailAsync(registerStudentDto.Email);
            if(user != null)
            {
                throw new ArgumentException("Email already exists");
            }

            var newUser = new User
            {
                FirstName = registerStudentDto.FirstName,
                LastName = registerStudentDto.LastName,
                Email = registerStudentDto.Email,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(registerStudentDto.Password),
                Role = registerStudentDto.Role,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.CreateUserAsync(newUser);

            if(newUser.Role == "Student")
            {
                var student = new Student
                {
                    UserId = newUser.UserId,
                    FirstName = registerStudentDto.FirstName,
                    LastName=registerStudentDto.LastName,
                };

                await _studentRepository.CreateStudentAsync(student);
            }

            return new AuthResponseDto
            {
                UserId = newUser.UserId.ToString(),
                FirstName = registerStudentDto.FirstName,
                LastName = registerStudentDto.LastName,
            };

            
        }
        public async Task<AuthResponseDto> Login(LoginStudentDto loginRequestDto)
        {

        }


    }
}
