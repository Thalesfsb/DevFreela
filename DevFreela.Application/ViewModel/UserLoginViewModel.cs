namespace DevFreela.Application.ViewModel
{
    public class UserLoginViewModel
    {
        public UserLoginViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
