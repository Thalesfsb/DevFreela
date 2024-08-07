namespace DevFreela.Api.Entidades
{
    public class Habilidade : EntidadeBase
    {
        public Habilidade(string descricao) : base()
        {
            Descricao = descricao;
            UsuariosHabilidades = [];
        }
        public int Id { get; set; }
        public string Descricao { get; private set; }
        public List<UsuarioHabilidade> UsuariosHabilidades { get; set; }
    }
}
