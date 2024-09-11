using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserCommand : IRequest<ResultViewModel<int>>
    {
        public InsertUserCommand(int id, string fullName, string email, DateTime birthDate, string password, string role)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Role = role;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public User ToEntity()
            => new(FullName, Email, BirthDate, Password, Role);
    }
}
