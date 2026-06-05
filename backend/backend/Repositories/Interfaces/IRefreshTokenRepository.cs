using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task RevokeToken(string token);
        Task<List<RefreshToken>> GetUserTokensAsync(int UserId);
    }
}
