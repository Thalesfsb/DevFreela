using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUserSkills
{
    public class InsertUserSkillsHandler : IRequestHandler<InsertUserSkillsCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;

        public InsertUserSkillsHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserSkillsCommand request, CancellationToken cancellationToken)
        {
            var result = request.ToEntity();

            await _repository.AddUserSkill(result);

            return ResultViewModel<int>.Success(result.Id);
        }

    }

}
