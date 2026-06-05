using backend.DTOs.Auth;

namespace backend.Services.Interfaces
{
    public interface IAuthService
    {

        Task<AuthResponseDto> Register(RegisterStudentDto registerStudentDto);
            Task<AuthResponseDto> Login(LoginStudentDto loginRequestDto);
    }
}
