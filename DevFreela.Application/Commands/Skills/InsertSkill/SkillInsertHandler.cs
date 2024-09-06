using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Skills.InsertSkill
{
    public class SkillInsertHandler : IRequestHandler<SkillInsertCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;

        public SkillInsertHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(SkillInsertCommand request, CancellationToken cancellationToken)
        {
            var skill = request.ToEntity();

            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(skill.Id);
        }
    }
}
