using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.Skills.InsertSkill
{
    public class SkillInsertCommand : IRequest<ResultViewModel<int>>
    {
        public SkillInsertCommand(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
        public Skill ToEntity() => new(Description);
    }
}
