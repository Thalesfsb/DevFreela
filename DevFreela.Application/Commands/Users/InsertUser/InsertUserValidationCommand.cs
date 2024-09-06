using DevFreela.Application.Models.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserValidationCommand : IPipelineBehavior<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;

        public InsertUserValidationCommand(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var result = _context.Users.Any(u => u.Id == request.Id);

            var userExists = await _context.Users.AnyAsync(u => u.Id == request.Id);

            if (userExists)
                return ResultViewModel<int>.Error("Usuario já existe");

            return await next();
        }
    }
}
