using backend.Data;
using backend.Repositories.Interfaces;

namespace backend.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IUserRepository Users { get; }
        public ICourseRepository Courses { get; }
        public IEnrollmentRepository Enrollments { get; }
        public IRefreshTokenRepository RefreshTokens { get; }
        public async Task<int> SaveChangesAsync()
        {

        }
        public async Task BeginTransactionAsync()
        {

        }
        public async Task CommitTransactionAsync()
        {

        }
        public async Task RollbackTransactionAsync()
        {

        }
    }
}
