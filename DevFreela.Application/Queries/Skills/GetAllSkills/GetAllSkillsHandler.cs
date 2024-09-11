using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.Skills.GetAllSkills
{
    public class GetAllSkillsHandler : IRequestHandler<GetAllSkillsQuery, ResultViewModel<List<SkillViewModel>>>
    {
        private readonly ISkillRepository _repository;

        public GetAllSkillsHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<SkillViewModel>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repository.GetAll(request);

            if (skills is null)
                return ResultViewModel<List<SkillViewModel>>.Error("Lista de skill vazia");

            var model = skills.Select(SkillViewModel.FromEntity).ToList();

            return ResultViewModel<List<SkillViewModel>>.Success(model);
        }
    }
}
