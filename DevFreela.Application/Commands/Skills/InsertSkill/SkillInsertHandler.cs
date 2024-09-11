using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Skills.InsertSkill
{
    public class SkillInsertHandler : IRequestHandler<SkillInsertCommand, ResultViewModel<int>>
    {
        private readonly ISkillRepository _repository;

        public SkillInsertHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(SkillInsertCommand request, CancellationToken cancellationToken)
        {
            var skill = request.ToEntity();

            await _repository.Add(skill);

            return ResultViewModel<int>.Success(skill.Id);
        }
    }
}
