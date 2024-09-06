using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Commands.Comment.InsertComment
{
    public class InsertCommentCommand : IRequest<ResultViewModel>
    {
        public InsertCommentCommand(string content, int idProject, int idUser)
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
