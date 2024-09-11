using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;
        public UserRepository(DevFreelaDbContext context)
        {
            if (_context is null)
                throw new InvalidOperationException("O contexto do banco de dados não está disponível.");

            _context = context;
        }
        public async Task<int> Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            return await _context.SaveChangesAsync();

        }
        public async Task<int> AddUserSkill(UserSkill entity)
        {
            await _context.UserSkills.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(User entity)
        {
            await _context.Users.AddAsync(entity);
            return await _context.SaveChangesAsync();

        }
        public async Task<bool> Exists(int id)
           => await _context.Projects.AnyAsync(u => u.Id == id);
        public async Task<List<User>> GetAll(Pagination entity)
        {
            var users = await _context.Users
                .Include(p => p.OwnedProjects)
                .Include(p => p.FreelanceProjects)
                .Include(s => s.Skills)
                .Include(c => c.Comments)
                .Where(u => !u.IsDeleted && (entity.Search == "" || u.FullName.Contains(entity.Search)))
                .Skip(entity.Page * entity.Size)
                .Take(entity.Size)
                .ToListAsync();

            return users;
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id) ?? new User();

        }
        public async Task<User> GetDetails(int id)
        {
            var user = await _context.Users
                .Include(p => p.OwnedProjects)
                .Include(p => p.FreelanceProjects)
                .Include(s => s.Skills)
                .Include(c => c.Comments)
                .SingleOrDefaultAsync(u => !u.IsDeleted && u.Id == id) ?? new User();

            return user;
        }
        public async Task<int> Update(User entity)
        {
            await _context.Users.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
