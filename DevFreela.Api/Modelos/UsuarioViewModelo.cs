using DevFreela.Api.Entidades;

namespace DevFreela.Api.Modelos
{
    public class UsuarioViewModelo
    {
        public UsuarioViewModelo(string nomeCompleto, string email, DateTime aniversario, List<string> habilidades)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Aniversario = aniversario;
            Habilidades = habilidades;
        }

        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public DateTime Aniversario { get; private set; }
        public List<string> Habilidades { get; private set; }

        public static UsuarioViewModelo ConverterEntidade(Usuario usuario)
        {
            var habiliodades = usuario.Habilidades.Select(h => h.Habilidade.Descricao).ToList();

            return new(usuario.NomeCompleto, usuario.Email, usuario.Aniversario, habiliodades);
        }
    }
}
