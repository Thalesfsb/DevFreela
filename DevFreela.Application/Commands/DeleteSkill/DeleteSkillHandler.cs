using DevFreela.Application.Models.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.DeleteSkill
{
    public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;

        public DeleteSkillHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _context.Skills.SingleOrDefaultAsync(s => s.Id == request.Id);

            if (skill is null)
                return ResultViewModel.Error("Habilidade não existe");

            skill.SetAsDeleted();
            _context.Update(skill);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();

        }
    }
}
