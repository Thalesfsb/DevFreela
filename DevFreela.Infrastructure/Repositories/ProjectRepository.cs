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
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _context;

        public ProjectRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Project entity)
        {
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task AddComment(ProjectComment entity)
        {
            await _context.ProjectComments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Projects.AnyAsync(p => p.Id == id);
        }

        public async Task<List<Project>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
