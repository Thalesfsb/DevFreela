using DevFreela.Api.Modelos;
using DevFreela.Api.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DevFreelaDBContexto _contexto;

        public UsuarioController(DevFreelaDBContexto contexto)
        {
            _contexto = contexto;
        }
        // GET api/usuarios?buscar=string
        [HttpGet]
        public IActionResult GetAll(string buscar)
        {
            var usuarios = _contexto.Usuarios.Where(u => !u.Deletado).ToList();

            return Ok();
        }

        // GET api/usuarios/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // POST api/usuarios
        [HttpPost]
        public IActionResult Post([FromBody]CriarUsuarioEntradaModelo modelo)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, modelo);
        }

        // PUT api/1234/usuario-perfil
        [HttpPut("{id}/usuario-perfil")]
        public IActionResult PostPerfilImagem(IFormFile formFile)
        {
            return Ok($"Name: {formFile.Name}, Tamanho: {formFile.Length}");
        }

        // POST api/usuario/1234/habilidades
        [HttpPost("{id}/habilidades")]
        public IActionResult CriarHabilidades(CriarUsuarioEntradaModelo modelo)
        {
            return Ok(); 
        }
    }
}
