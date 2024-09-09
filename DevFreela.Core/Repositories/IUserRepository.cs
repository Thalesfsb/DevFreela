using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<int> Add(User entity);
        Task<int> Update(User entity);
        Task<List<User>> GetAll(Pagination entity);
        Task<User> GetById(int id);
        Task<User> GetDetails(int id);
        Task<int> Delete(User entity);
        Task<bool> Exists(int id);
    }
}
