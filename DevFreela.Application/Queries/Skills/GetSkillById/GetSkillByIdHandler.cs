using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.Skills.GetSkillById
{
    public class GetSkillByIdHandler : IRequestHandler<GetSkillByIdQuery, ResultViewModel<SkillViewModel>>
    {
        private readonly ISkillRepository _repository;

        public GetSkillByIdHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<SkillViewModel>> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.Id);

            if (result is null)
                return ResultViewModel<SkillViewModel>.Error("Skill não existe");

            var model = SkillViewModel.FromEntity(result);

            return ResultViewModel<SkillViewModel>.Success(model);
        }
    }
}
