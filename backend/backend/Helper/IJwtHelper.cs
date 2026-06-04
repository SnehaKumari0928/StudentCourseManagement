using backend.Entities;

namespace backend.Helper
{
    public interface IJwtHelper
    {

        Task<string> GenerateAccessTokenAsync(User user);
        string GenerateRefreshTokenAsync();
    }
}
