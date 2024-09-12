using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.Login
{
    public class UserLoginHandler : IRequestHandler<UserLoginCommand, UserLoginViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _repository;
        public UserLoginHandler(IAuthService authService, IUserRepository repository)
        {
            _authService = authService;
            _repository = repository;
        }
        public async Task<UserLoginViewModel> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            // Buscar no banco um user que tenha e-mail e senha em formato hash
            var user = await _repository.GetUserByEmailAndPassword(request.Email, passwordHash);

            // Se nao existir, retorna null para controller e trata la
            if (user.Id == 0)
                return null;

            // Se existir, gera o token usando os dados do usuario
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            // Retorna um UserLoginViewModel
            return new UserLoginViewModel(user.Email, token);
        }
    }
}
