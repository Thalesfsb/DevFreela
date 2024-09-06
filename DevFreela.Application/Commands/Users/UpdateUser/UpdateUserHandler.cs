using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        public UpdateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);

            if (user is null)
                return ResultViewModel.Error("Projeto não existe");

            await _repository.Update(user);

            return ResultViewModel.Success();
        }
    }
}
