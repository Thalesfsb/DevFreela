namespace DevFreela.Api.Modelos
{
    public class ConfigServico : IConfigServico
    {
        private int _contador;

        public int GetValue()
        {
            _contador++;
            return _contador;
        }
    }
}
