using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;
        public InsertUserHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }
        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            request.Password = _authService.ComputeSha256Hash(request.Password);

            var result = request.ToEntity();

            if (await _repository.Exists(request.Id))
                return ResultViewModel<int>.Error("Usuario já existe");

            await _repository.Add(result);

            return ResultViewModel<int>.Success(request.Id);
        }
    }
}
