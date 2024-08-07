using DevFreela.Api.Entidades;
using DevFreela.Api.Modelos;
using DevFreela.Api.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace DevFreela.Api.Controllers
{
    [Route("api/projetos")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        //private readonly FreelanceCustoTotal _config;
        //private readonly IConfigServico _configServico;

        private readonly DevFreelaDBContexto _contexto;


        //public ProjetosController(IOptions<FreelanceCustoTotal> options, IConfigServico configServico)
        //{
        //    string connectionString = "Server=localhost;Database=MinhaBaseDeDados;User Id=meuUsuario;Password=minhaSenha;";
        //    _config = options.Value;
        //    _configServico = configServico;
        //}

        public ProjetosController(DevFreelaDBContexto contexto)
        {
            _contexto = contexto;
        }

        // GET api/projetos?buscar=string
        [HttpGet]
        public IActionResult GetAll(string buscar)
        {

            var projetos = _contexto.Projetos
                .Include(c => c.Cliente)
                .Include(f => f.Freelancer)
                .Where(p => !p.Deletado)
                .ToList();

            // var model = projetos.Select(p => ProjetoItemViewModelo.GerarEntidade(p)).ToList();

            var model = projetos.Select(ProjetoItemViewModelo.ConverterEntidade).ToList();

            return Ok(model);
        }

        // GET api/projetos/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var projetos = _contexto.Projetos
                .Include(c => c.Cliente)
                .Include(f => f.Freelancer)
                .Include(c => c.Comentarios)
                .SingleOrDefault(p => p.Id == id);

            var model = ProjetoItemViewModelo.ConverterEntidade(projetos);

            return Ok(model);
        }

        // POST api/projetos
        [HttpPost]
        public IActionResult Post(CriarProjetoEntradaModelo modelo)
        {
            var projeto = modelo.ParaEntidade();

            _contexto.Projetos.Add(projeto);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = 1 }, modelo);
        }

        // PUT api/projetos/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id, AtualizarProjetoEntradaModelo modelo)
        {
            var projeto = _contexto.Projetos.SingleOrDefault(p => p.Id == id);

            if (projeto is null)
                return NotFound();

            projeto.Atualizar(modelo.Titulo, modelo.Descricao, modelo.CustoTotal);

            _contexto.Projetos.Update(projeto);
            _contexto.SaveChanges();

            return NoContent();
        }

        // DELETE api/projetos/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var projeto = _contexto.Projetos.SingleOrDefault(p => p.Id == id);

            if (projeto is null)
                return NotFound();

            projeto.SetarComoDeletado();

            _contexto.Update(projeto);
            _contexto.SaveChanges();

            return NoContent();
        }

        // PUT api/projetos/1234
        [HttpPut("{id}/iniciarprojeto")]
        public IActionResult IniciarProjeto(int id)
        {
            var projeto = _contexto.Projetos.SingleOrDefault(p => p.Id == id);

            if (projeto is null)
                return NotFound();

            projeto.Iniciar();

            _contexto.Update(projeto);
            _contexto.SaveChanges();

            return NoContent();
        }

        // PUT api/projetos/completarprojeto
        [HttpPut("{id}/completarprojeto")]
        public IActionResult CompletarProjeto(int id)
        {
            var projeto = _contexto.Projetos.SingleOrDefault(p => p.Id == id);

            if (projeto is null)
                return NotFound();

            projeto.Completo();

            _contexto.Update(projeto);
            _contexto.SaveChanges();

            return NoContent();
        }

        // POST api/projetos/1234/comentario
        [HttpPost("{id}/comentario")]
        public IActionResult PostComentario(int id, CriarComentarioProjetoEntradaModelo modelo)
        {
            var projeto = _contexto.Projetos.SingleOrDefault(p => p.Id == id);

            if (projeto is null)
                return NotFound();

            var comentario = new ProjetoComentario(modelo.Conteudo, modelo.IdProjeto, modelo.IdUsuario);

            _contexto.ProjetoComentarios.Add(comentario);
            _contexto.SaveChanges();

            return NoContent();
        }
    }
}
