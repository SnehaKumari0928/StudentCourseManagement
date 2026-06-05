using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IUserRepository
    {

        public Task<User> GetUserByIdAsync(int id);
        public Task<User> CreateUserAsync(User student);
        public Task UpdateUserAsync(User student);

       public Task<User> GetByEmailAsync(string email);
        public Task DeleteUserAsync(int id);

    }
}
