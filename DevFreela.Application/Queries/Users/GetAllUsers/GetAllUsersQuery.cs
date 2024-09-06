using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.User.GetAllUsers
{
    public class GetAllUsersQuery : Pagination, IRequest<ResultViewModel<List<UserViewModel>>>
    {
        public GetAllUsersQuery(string search, int size, int page) : base(search, size, page)
        {
        }
    }
}
