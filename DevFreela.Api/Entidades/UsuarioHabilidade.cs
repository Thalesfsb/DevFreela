namespace DevFreela.Api.Entidades
{
    public class UsuarioHabilidade : EntidadeBase
    {
        public UsuarioHabilidade(int idUsuario, int idHabilidade) : base ()
        {
            IdUsuario = idUsuario;
            IdHabilidade = idHabilidade;
        }
        public int Id { get; set; }
        public int IdUsuario { get; private set; }
        public Usuario UsuarioHabilidades { get; set; }
        public int IdHabilidade { get; set; }
        public Habilidade Habilidade { get; set; }
    }
}
