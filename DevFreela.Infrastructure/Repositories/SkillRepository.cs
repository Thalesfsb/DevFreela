using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Add(Skill skill)
        {
            await _dbContext.Skills.AddAsync(skill);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Skill> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Skill> GetAll(Pagination pagination)
        {
            throw new NotImplementedException();
        }

        public async Task<Skill> Update(Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}
