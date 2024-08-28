using DevFreela.Application.Models.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetSkillById
{
    public class GetSkillByIdQuery : IRequest<ResultViewModel<SkillViewModel>>
    {
        public GetSkillByIdQuery(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
