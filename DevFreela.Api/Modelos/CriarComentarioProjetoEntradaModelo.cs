using DevFreela.Api.Entidades;

namespace DevFreela.Api.Modelos
{
    public class CriarComentarioProjetoEntradaModelo
    {
        public required string Conteudo { get; set; }
        public int IdProjeto { get; set; }
        public int IdUsuario { get; set; }

        public ProjetoComentario ConverterEntidade()
            => new(Conteudo, IdProjeto, IdUsuario);
    }
}
