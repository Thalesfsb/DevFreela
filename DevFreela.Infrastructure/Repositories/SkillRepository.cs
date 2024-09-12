using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _context;

        public SkillRepository(DevFreelaDbContext context)
        {
            if (context is null)
                throw new InvalidOperationException("O contexto do banco de dados não está disponível.");

            _context = context;
        }
        public async Task<int> Add(Skill entity)
        {
            await _context.Skills.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task Delete(Skill entity)
        {
            _context.Skills.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Skill> GetById(int id)
        {
            return await _context.Skills.SingleOrDefaultAsync(s => s.Id == id) ?? new Skill();
        }

        public async Task<List<Skill>> GetAll(Pagination entity)
        {
            var skills = await _context.Skills
              .Include(s => s.UserSkills)
              .Where(p => !p.IsDeleted && (entity.Search == "" || p.Description.Contains(entity.Search)))
              .Skip(entity.Page * entity.Size)
              .Take(entity.Size)
              .ToListAsync();

            return skills ?? new List<Skill>();
        }

        public async Task Update(Skill entity)
        {
            _context.Skills.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
