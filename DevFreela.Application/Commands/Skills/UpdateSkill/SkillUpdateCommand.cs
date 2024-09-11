using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Skills.UpdateSkill
{
    public class SkillUpdateCommand : IRequest<ResultViewModel>
    {
        public SkillUpdateCommand(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
        public Skill ToEntity() => new(Description);
    }
}
