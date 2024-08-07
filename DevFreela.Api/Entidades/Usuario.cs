namespace DevFreela.Api.Entidades
{
    public class Usuario : EntidadeBase
    {
        public Usuario(string nomeCompleto, string email, DateTime aniversario)
            : base()
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Aniversario = aniversario;
            Ativo = true;

            Habilidades = [];
            DonoProjeto = [];
            AtuandoFreelance = [];
            Comentarios = [];
        }
        public int Id { get; set; }
        public int IdFreelancer { get; set; }
        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public DateTime Aniversario { get; private set; }
        public bool Ativo { get; set; }
        public List<UsuarioHabilidade> Habilidades{ get; private set; }
        public List<Projeto> DonoProjeto { get; private set; }
        public List<Projeto> AtuandoFreelance { get; private set; }
        public List<ProjetoComentario> Comentarios { get; private set; }
    }
}
