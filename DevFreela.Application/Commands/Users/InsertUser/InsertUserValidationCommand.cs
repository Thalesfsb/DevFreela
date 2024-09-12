using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserValidationCommand : IPipelineBehavior<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;

        public InsertUserValidationCommand(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var userExists = await _repository.Exists(request.Id);

            if (userExists)
                return ResultViewModel<int>.Error("Usuario já existe");

            return await next();
        }
    }
}
