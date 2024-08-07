namespace DevFreela.Api.Entidades
{
    public class ProjetoComentario : EntidadeBase
    {
        public ProjetoComentario(string conteudo, int idProjeto, int idUsuario)
            : base()
        {
            Conteudo = conteudo;
            IdProjeto = idProjeto;
            IdUsuario = idUsuario;
        }
        public int Id { get; set; }
        public string Conteudo { get; private set; }
        public int IdProjeto { get; private set; }
        public Projeto Projeto { get; private set; }
        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; set; }
    }
}
