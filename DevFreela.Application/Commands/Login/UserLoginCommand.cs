using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Commands.Login
{
    public class UserLoginCommand : IRequest<UserLoginViewModel>
    {
        public UserLoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
