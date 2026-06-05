using backend.Data;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Implementations
{
    public class UserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<User> GetUserByIdAsync(int id)
        {
             return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> CreateUserAsync(User student)
        {
            await _context.Users.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task UpdateUserAsync(User student)
        {
            _context.Users.Update(student);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteUserAsync(int id)
        {

            var user = await GetUserByIdAsync(id);

            _context.Users.Remove(user);
        }
    }
}
