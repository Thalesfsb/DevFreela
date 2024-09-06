using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Commands.Users.DeleteProject
{
    public class DeleteUserCommand : IRequest<ResultViewModel>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
