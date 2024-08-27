using DevFreela.Application.Models.ViewModel;
using MediatR;

namespace DevFreela.Application.Commands.InsertComment
{
    public class InsertProjectCommand : IRequest<ResultViewModel>
    {
        public InsertProjectCommand(string content, int idProject, int idUser)
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
