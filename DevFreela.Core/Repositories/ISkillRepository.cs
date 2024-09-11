using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<int> Add(Skill entity);
        Task<List<Skill>> GetAll(Pagination entity);
        Task<Skill> GetById(int id);
        Task  Update(Skill entity);
        Task Delete(Skill entity);

    }
}
