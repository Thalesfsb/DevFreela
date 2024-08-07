using DevFreela.Api.Entidades;

namespace DevFreela.Api.Modelos
{
    public class ProjetoItemViewModelo
    {
        public ProjetoItemViewModelo(int id, string titulo, string nomeCliente, string nomeFreelancer)
        {
            Id = id;
            Titulo = titulo;
            NomeCliente = nomeCliente;
            NomeFreelancer = nomeFreelancer;
        }
        #region propriedades
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string NomeCliente { get; private set; }
        public string NomeFreelancer { get; private set; }

        public static ProjetoItemViewModelo ConverterEntidade(Projeto entidade)
            => new(entidade.Id, entidade.Titulo, entidade.Cliente.NomeCompleto,
                   entidade.Freelancer.NomeCompleto);
        #endregion
    }
}
