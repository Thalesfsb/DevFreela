using DevFreela.Api.Entidades;
using DevFreela.Api.Modelos;
using DevFreela.Api.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [Route("api/habilidades")]
    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        private readonly DevFreelaDBContexto _contexto;
        public HabilidadesController(DevFreelaDBContexto contexto)
        {
            _contexto = contexto;
        }
        // GET api/habilidades?buscar=string
        [HttpGet]
        public IActionResult GetAll(string buscar)
        {
            var habilidades = _contexto.Habilidades.ToList();

            return Ok(habilidades);
        }

        // GET api/habilidades/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var habilidade = _contexto.Habilidades.SingleOrDefault(h => h.Id == id);

            return Ok(habilidade);
        }

        // POST api/habilidades
        [HttpPost]
        public IActionResult Post(CriarHabilidadesEntradaModelo modelo)
        {
            var habilidade = new Habilidade(modelo.Descricao);

            _contexto.Habilidades.Add(habilidade);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = 1 }, modelo);
        }

        // PUT api/habilidades/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id, AtualizarHabilidadesEntradaModelo modelo)
        { 
            return NoContent(); 
        }

        // DELETE api/habilidades/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        { 
            return NoContent();
        }
    }
}
