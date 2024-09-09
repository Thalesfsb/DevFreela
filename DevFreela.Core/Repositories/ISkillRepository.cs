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
        Task<int> Add(Skill skill);
        Task<Skill> GetAll(Pagination pagination);
        Task<Skill> Get(int id);
        Task<Skill> Update(Skill skill);
        Task Delete(int id);

    }
}
