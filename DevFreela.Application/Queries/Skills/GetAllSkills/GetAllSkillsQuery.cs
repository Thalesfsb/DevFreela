using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetAllSkills
{
    public class GetAllSkillsQuery : Pagination, IRequest<ResultViewModel<List<SkillViewModel>>>
    {
        public GetAllSkillsQuery(string search, int size, int page) : base(search, size, page)
        {
        }
    }
}
