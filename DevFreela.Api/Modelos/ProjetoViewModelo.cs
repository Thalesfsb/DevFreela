using DevFreela.Api.Entidades;

namespace DevFreela.Api.Modelos
{
    public class ProjetoViewModelo
    {
        public ProjetoViewModelo(int id, string titulo, string descricao, int idCliente, 
                                 int idFreelancer, string nomeCliente, string nomeFreelancer, 
                                 decimal custoTotal, List<ProjetoComentario> comentarios)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            IdCliente = idCliente;
            IdFreelancer = idFreelancer;
            NomeCliente = nomeCliente;
            NomeFreelancer = nomeFreelancer;
            CustoTotal = custoTotal;
            Comentarios = comentarios.Select(c => c.Conteudo).ToList();
        }

        #region propriedades
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int IdCliente { get; private set; }
        public int IdFreelancer { get; private set; }
        public string NomeCliente { get; private set; }
        public string NomeFreelancer { get; private set; }
        public decimal CustoTotal { get; private set; }
        public List<string> Comentarios { get; private set; }
        #endregion

        // Vantagem não precisa fazer a construção do objeto na camada de aplicação
        public static ProjetoViewModelo GerarEntidade(Projeto entidade)
            => new (entidade.Id, entidade.Titulo, entidade.Descricao, entidade.IdCliente, 
                    entidade.IdFreelancer, entidade.Cliente.NomeCompleto, entidade.Freelancer.NomeCompleto, 
                    entidade.CustoTotal, entidade.Comentarios);

    }
}
