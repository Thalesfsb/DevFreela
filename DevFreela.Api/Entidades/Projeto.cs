using DevFreela.Api.Enums;

namespace DevFreela.Api.Entidades
{
    public class Projeto : EntidadeBase
    {
        public Projeto() { }
        public Projeto(string titulo, string descricao, int idCliente, int idFreelancer, decimal custoTotal)
            : base()
        {
            Titulo = titulo;
            Descricao = descricao;
            IdCliente = idCliente;
            IdFreelancer = idFreelancer;
            CustoTotal = custoTotal;

            Status = ProjetoStatusEnum.Criado;
            Comentarios = [];
        }
        public int Id { get; set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int IdCliente { get; private set; }
        public Usuario Cliente { get; private set; }
        public int IdFreelancer { get; private set; }
        public Usuario Freelancer { get; private set; }
        public decimal CustoTotal { get; private set; }
        public DateTime? IniciadoEm { get; private set; }
        public DateTime? TerminadoEm { get; private set; }
        public DateTime? CompletadoEm { get; private set; }
        public ProjetoStatusEnum Status { get; private set; }
        public List<ProjetoComentario> Comentarios { get; private set; }
        
        public void Cancelado()
        {
            if(Status == ProjetoStatusEnum.EmProgresso || Status == ProjetoStatusEnum.Suspenso)
            {
                Status = ProjetoStatusEnum.Cancelado;
            }
        }

        public void Iniciar()
        {
            if (Status == ProjetoStatusEnum.Criado)
            {
                Status = ProjetoStatusEnum.EmProgresso;
                IniciadoEm = DateTime.Now;
            }
        }

        public void Completo()
        {
            if (Status == ProjetoStatusEnum.PagamentoPendente || Status == ProjetoStatusEnum.EmProgresso)
            {
                Status = ProjetoStatusEnum.Completado;
                CompletadoEm = DateTime.Now;
            }
        }

        public void PagamentoPendente()
        {
            if (Status == ProjetoStatusEnum.EmProgresso)
            {
                Status = ProjetoStatusEnum.PagamentoPendente;
            }
        }
        public void Atualizar(string titulo, string descricao, decimal custoTotal)
        {
            Titulo = titulo;
            Descricao = descricao;
            CustoTotal = custoTotal;


            if (Status == ProjetoStatusEnum.EmProgresso || Status == ProjetoStatusEnum.Suspenso)
            {
                Status = ProjetoStatusEnum.Cancelado;
            }
        }
    }
}
