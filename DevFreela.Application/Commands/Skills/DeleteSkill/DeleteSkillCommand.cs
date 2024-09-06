using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Commands.Skills.DeleteSkill
{
    public class DeleteSkillCommand : IRequest<ResultViewModel>
    {
        public DeleteSkillCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
