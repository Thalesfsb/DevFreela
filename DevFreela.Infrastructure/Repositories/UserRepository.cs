using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Add(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<int> Delete(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();

        }
        public async Task<bool> Exists(int id)
           => await _dbContext.Projects.AnyAsync(u => u.Id == id);
        public async Task<List<User>> GetAll(Pagination entity)
        {
            var users = await _dbContext.Users
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
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id) ?? new User("Default", "default@default.com", DateTime.Now);

        }

        public async Task<User> GetDetails(int id)
        {
            var user = await _dbContext.Users
                .Include(p => p.OwnedProjects)
                .Include(p => p.FreelanceProjects)
                .Include(s => s.Skills)
                .Include(c => c.Comments)
                .SingleOrDefaultAsync(u => !u.IsDeleted && u.Id == id);

            return user;
        }

        public async Task<int> Update(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
