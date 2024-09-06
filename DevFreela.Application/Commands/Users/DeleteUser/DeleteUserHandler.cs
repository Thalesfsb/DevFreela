using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Users.DeleteProject
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public DeleteUserHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);

            if (user is null)
                return ResultViewModel.Error("Projeto não existe");

            user.SetAsDeleted();
            await _repository.Update(user);

            return ResultViewModel.Success();
        }
    }
}
