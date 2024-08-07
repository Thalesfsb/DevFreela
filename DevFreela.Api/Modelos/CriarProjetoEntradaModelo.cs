using DevFreela.Api.Entidades;

namespace DevFreela.Api.Modelos
{
    public class CriarProjetoEntradaModelo
    {
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public int IdCliente { get; set; }
        public int IdFreelancer { get; set; }
        public decimal CustoTotal { get; set; }

        public Projeto ParaEntidade()
            => new (Titulo, Descricao, IdCliente, IdFreelancer, CustoTotal);
    }
}
