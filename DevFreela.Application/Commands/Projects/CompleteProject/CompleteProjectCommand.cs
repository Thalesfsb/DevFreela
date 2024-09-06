using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CompleteProject
{
    public class CompleteProjectCommand : IRequest<ResultViewModel>
    {
        // Quando tenho construtor é pq vou passar o Id o da URL e iniciar do 0
        // Quando não tenho é pq vou passar como se fosse corpo de requisição
        public CompleteProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
