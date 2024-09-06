using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUserSkills
{
    public class InsertUserSkillsCommand : IRequest<ResultViewModel<int>>
    {
        public InsertUserSkillsCommand(int idUser, int idSkill)
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }

        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
        public UserSkill ToEntity()
            => new(IdUser, IdSkill);
    }
}
