using backend.DTOs.Auth;
using backend.DTOs.User;
using backend.Entities;
using backend.Helper;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace backend.Services.Implementation
{
    public class AuthService: IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IJwtHelper _jwtHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthService(IUserRepository userRepository, IStudentRepository studentRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _refreshTokenRepository = refreshTokenRepository;
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

           var createdUser = await _userRepository.CreateUserAsync(newUser);

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

            return await GenerateAuthResponse(createdUser);


            
        }
        public async Task<AuthResponseDto> Login(LoginStudentDto loginRequestDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(loginRequestDto.Email);

            if(existingUser == null)
            {
                throw new ArgumentException("Email already exists");
            }

            var isValidPassword =  BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, existingUser.HashedPassword);
            if (!isValidPassword)
                throw new ArgumentException("Password verification fails");

            return await GenerateAuthResponse(existingUser);


        }

        private async Task<AuthResponseDto> GenerateAuthResponse(User user)
        {

            var AccessToken = await _jwtHelper.GenerateAccessTokenAsync(user);
            var RefreshToken = _jwtHelper.GenerateRefreshTokenAsync();

             await _refreshTokenRepository.AddAsync(new RefreshToken
            {
                UserId = user.UserId,
                Token = RefreshToken,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            });



            return new AuthResponseDto
            {
                AccessToken = AccessToken,
                RefreshToken = RefreshToken,
                User = new UserResponseDto
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role
                }
                
            };
        }





    }
}
