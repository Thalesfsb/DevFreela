using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.Skills.DeleteSkill
{
    public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, ResultViewModel>
    {
        private readonly ISkillRepository _repository;

        public DeleteSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _repository.GetById(request.Id);

            if (skill is null)
                return ResultViewModel.Error("Habilidade não existe");

            skill.SetAsDeleted();
            await _repository.Delete(skill);

            return ResultViewModel.Success();

        }
    }
}
