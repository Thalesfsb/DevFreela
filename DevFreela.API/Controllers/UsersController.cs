using Microsoft.AspNetCore.Mvc;
using MediatR;
using DevFreela.Application.Commands.Users.InsertUserSkills;
using DevFreela.Application.Commands.Users.InsertUser;
using DevFreela.Application.Queries.Skills.GetSkillById;
using DevFreela.Application.Queries.Users.GetUserById;
using DevFreela.Application.Queries.Skills.GetAllSkills;
using DevFreela.Application.Commands.Login;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search, int size, int page)
        {
            var result = await _mediator.Send(new GetAllSkillsQuery(search, size, page));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> Post(InsertUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
        }

        [HttpPost("{id}/skills")]
        public async Task<IActionResult> PostSkills(int id, InsertUserSkillsCommand command)
        {
            var result = command.ToEntity();

            await _mediator.Send(result);

            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public async Task<IActionResult> PostProfilePicture(int id, IFormFile file)
        {
            var description = $"FIle: {file.FileName}, Size: {file.Length}";

            // Processar a imagem

            return Ok(description);
        }
        // api/user/login
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginCommand command)
        {
            var result = await _mediator.Send(command);

            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
