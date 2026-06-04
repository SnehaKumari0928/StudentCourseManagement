using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IUserRepository
    {

        public Task<User> GetUserByIdAsync(int id);
        public Task CreateUserAsync(User student);
        public Task UpdateUserAsync(User student);
        public Task DeleteUserAsync(int id);

    }
}
