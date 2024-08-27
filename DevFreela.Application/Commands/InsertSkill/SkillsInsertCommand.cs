using DevFreela.Application.Models.ViewModel;
using DevFreela.Core.Entities;
using MediatR;
using System.Net.Sockets;

namespace DevFreela.Application.Commands.InsertSkills
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
