using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;

        public InsertUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var result = request.ToEntity();

            if (await _repository.Exists(request.Id))
                return ResultViewModel<int>.Error("Usuario já existe");

            await _repository.Add(result);

            return ResultViewModel<int>.Success(request.Id);
        }
    }
}
