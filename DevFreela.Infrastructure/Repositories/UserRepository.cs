using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;
        public UserRepository(DevFreelaDbContext context)
        {
            if (context is null)
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
        {
            return await _context.Projects.AnyAsync(u => u.Id == id);
        }
        public async Task<List<User>> GetAll(Pagination entity)
        {
            return await _context.Users
                .Include(p => p.OwnedProjects)
                .Include(p => p.FreelanceProjects)
                .Include(s => s.Skills)
                .Include(c => c.Comments)
                .Where(u => !u.IsDeleted && (entity.Search == "" || u.FullName.Contains(entity.Search)))
                .Skip((entity.Page - 1) * entity.Size)
                .Take(entity.Size)
                .ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User> GetDetails(int id)
        {
            return await _context.Users
                .Include(p => p.OwnedProjects)
                .Include(p => p.FreelanceProjects)
                .Include(s => s.Skills)
                .Include(c => c.Comments)
                .SingleOrDefaultAsync(u => !u.IsDeleted && u.Id == id);
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string passwordHash)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }

        public async Task<int> Update(User entity)
        {
            await _context.Users.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
