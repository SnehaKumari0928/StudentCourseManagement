using backend.DTOs.User;

namespace backend.DTOs.Auth
{
    public class AuthResponseDto
    {

      public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public UserResponseDto User { get; set; }
    }
}
