using DevFreela.Api.Entidades;
using DevFreela.Api.Modelos;
using DevFreela.Api.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return Ok(usuarios);
        }

        // GET api/usuarios/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Buscando usuario, fazendo join com habilidades e incluindo tb as habilidades 
            var usuario = _contexto.Usuarios
                .Include(h => h.Habilidades)
                    // Dentro da Usuario habilidades, trazer as habilidades
                    .ThenInclude(s => s.Habilidade)
                .SingleOrDefault(u => u.Id == id);
            
            if(usuario is null)
                return NotFound();

            // Utilizar uma view modelo para retornar apenas o que desejar 
            var model = UsuarioViewModelo.ConverterEntidade(usuario);

            return Ok(usuario);
        }

        // POST api/usuarios
        [HttpPost]
        public IActionResult Post([FromBody]CriarUsuarioEntradaModelo modelo)
        {
            var usuario = new Usuario(modelo.NomeCompleto, modelo.Email, modelo.Aniversario);

            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        // PUT api/1234/usuario-perfil
        [HttpPut("{id}/usuario-perfil")]
        public IActionResult PostPerfilImagem(IFormFile formFile)
        {
            return Ok($"Name: {formFile.Name}, Tamanho: {formFile.Length}");
        }

        // POST api/usuario/1234/habilidades
        [HttpPost("{id}/habilidades")]
        public IActionResult CriarHabilidades(int id, UsuarioHabilidadeEntradaModelo modelo)
        {
            var usuarioHabilidades = modelo.IdHabilidades.Select(h => new UsuarioHabilidade(id, h)).ToList();

            _contexto.UsuarioHabilidades.AddRange(usuarioHabilidades);
            _contexto.SaveChanges();

            return Ok(); 
        }
    }
}
