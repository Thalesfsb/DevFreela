using Azure.Core;
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
            => await _context.Projects.AnyAsync(p => p.Id == id);

        public async Task<List<Project?>> GetAll(Pagination entity)
        {
            var projects = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
            .Where(p => !p.IsDeleted && (entity.Search == "" || p.Title.Contains(entity.Search) || p.Description.Contains(entity.Search)))
            .Skip(entity.Page * entity.Size)
            .Take(entity.Size)
            .ToListAsync();

            return projects;
        }

        public async Task<Project?> GetById(int id)
        {
            return await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);

        }

        public async Task<Project?> GetDetailsById(int id)
        {
            var project = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Id == id);

            return project;
        }

        public async Task Update(Project entity)
        {
            _context.Projects.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
