using backend.DTOs.Auth;

namespace backend.Services.Interfaces
{
    public interface IAuthService
    {

        Task<RegisterStudentDto> Register(RegisterStudentDto registerStudentDto);
            Task<LoginStudentDto> Login(LoginStudentDto loginRequestDto);
    }
}
