namespace DevFreela.Api.Modelos
{
    public class AtualizarProjetoEntradaModelo
    {
        public int IdProjeto { get; set; }
        public string Titulo { get; set; }
        public required string Descricao { get; set; }
        public decimal CustoTotal { get; set; }
    }
}
