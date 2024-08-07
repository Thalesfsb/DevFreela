using DevFreela.Api.Entidades;

namespace DevFreela.Api.Modelos
{
    public class CriarProjetoEntradaModelo
    {
        public CriarProjetoEntradaModelo(string titulo, string descricao, int idCliente, int idFreelancer, decimal custoTotal)
        {
            Titulo = titulo;
            Descricao = descricao;
            IdCliente = idCliente;
            IdFreelancer = idFreelancer;
            CustoTotal = custoTotal;
        }

        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public int IdCliente { get; set; }
        public int IdFreelancer { get; set; }
        public decimal CustoTotal { get; set; }

    }
}
