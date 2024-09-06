using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Users.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.Id);

            if (result is null)
                return ResultViewModel<UserViewModel>.Error("Skill não existe");

            var model = UserViewModel.FromEntity(result);

            return ResultViewModel<UserViewModel>.Success(model);
        }
    }
}
