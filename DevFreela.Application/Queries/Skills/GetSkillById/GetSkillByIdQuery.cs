using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetSkillById
{
    public class GetSkillByIdQuery : IRequest<ResultViewModel<SkillViewModel>>
    {
        public GetSkillByIdQuery(int id)
        {
            Id = id;

        }

        public int Id { get; set; }

    }
}
