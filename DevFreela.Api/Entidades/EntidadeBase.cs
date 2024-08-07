namespace DevFreela.Api.Entidades
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            DataCriacao = DateTime.Now;
            Deletado = false;
            
        }
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Deletado { get; set; }
        public void SetarComoDeletado()
        {
            Deletado = true;
        }
    }
}
