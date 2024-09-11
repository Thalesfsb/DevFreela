using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Skills.UpdateSkill
{
    public class SkillUpdateHandler : IRequestHandler<SkillUpdateCommand, ResultViewModel>
    {
        private readonly ISkillRepository _repository;
        public SkillUpdateHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(SkillUpdateCommand request, CancellationToken cancellationToken)
        {
            {
                var skill = request.ToEntity();

                await _repository.Add(skill);

                return ResultViewModel.Success();
            }
        }
    }
}
