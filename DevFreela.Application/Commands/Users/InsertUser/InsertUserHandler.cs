using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;

        public InsertUserHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var result = request.ToEntity();

            await _context.Users.AddAsync(result);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(request.Id);
        }
    }
}
