﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using DevFreela.Application.Commands.Skills.InsertSkill;
using DevFreela.Application.Commands.Skills.DeleteSkill;
using DevFreela.Application.Queries.Skills.GetSkillById;
using DevFreela.Application.Queries.User.GetAllUsers;
using DevFreela.Application.Queries.Skills.GetAllSkills;
using DevFreela.Core.Entities;
using Microsoft.AspNetCore.Authorization;
namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    [Authorize]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillsController(IMediator mediator)
            => _mediator = mediator;

        // GET api/skills/1234
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetSkillByIdQuery(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
        // GET api/skills
        [HttpGet]
        public async Task<IActionResult> GetAll(string search, int size, int page)
        {
            var result = await _mediator.Send(new GetAllSkillsQuery(search, size, page));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        // POST api/skills
        [HttpPost]
        public async Task<IActionResult> Post(SkillInsertCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
        }

        // DELETE api/skills/1234
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteSkillCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
