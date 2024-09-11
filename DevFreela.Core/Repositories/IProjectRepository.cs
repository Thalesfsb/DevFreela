using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll(Pagination entity);
        Task<Project> GetDetailsById(int id);
        Task<Project> GetById(int id);
        Task<int> Add(Project entity);
        Task Update(Project entity);
        Task AddComment(ProjectComment entity);
        Task<bool> Exists(int id);
    }
}
