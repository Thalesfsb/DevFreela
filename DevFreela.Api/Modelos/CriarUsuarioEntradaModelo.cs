using DevFreela.Api.Entidades;

namespace DevFreela.Api.Modelos
{
    public class CriarUsuarioEntradaModelo
    {
        public CriarUsuarioEntradaModelo(string nomeCompleto, string email, DateTime aniversario)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Aniversario = aniversario;
        }

        public string NomeCompleto { get;  set; }
        public string Email { get;  set; }
        public DateTime Aniversario { get;  set; }

        public static CriarUsuarioEntradaModelo ConverterEntidade(Usuario usuario)
            => new(usuario.NomeCompleto, usuario.Email, usuario.Aniversario);
    }
}
