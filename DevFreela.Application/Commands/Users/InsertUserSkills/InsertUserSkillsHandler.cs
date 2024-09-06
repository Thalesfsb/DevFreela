using DevFreela.Application.Models.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUserSkills
{
    public class InsertUserSkillsHandler : IRequestHandler<InsertUserSkillsCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;

        public InsertUserSkillsHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserSkillsCommand request, CancellationToken cancellationToken)
        {
            var result = request.ToEntity();

            await _context.AddAsync(result);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(result.Id);
        }

    }

}
