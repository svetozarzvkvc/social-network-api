using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Comments;
using SocialNetwork.DataAccess;
using SocialNetwork.Implementation;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using SocialNetwork.Application;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Metadata;
using SocialNetwork.Application.UseCases.Commands.Posts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private UseCaseHandler _commandHandler;
        private SocialNetworkContext _context;
        private IApplicationActor _actor;

        public CommentsController(UseCaseHandler commandHandler, SocialNetworkContext context, IApplicationActor actor)
        {
            _commandHandler = commandHandler;
            _context = context;
            _actor = actor;
        }

        // POST api/<CommentsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentDto dto, ICreateCommentCommand command)
        {
            try
            {
                dto.AuthorId = _actor.Id;
                _commandHandler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch (UnauthorizedUseCaseException ex)
            {
                return Unauthorized();
            }
            catch(ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (ValidationException ex)
            {
                return UnprocessableEntity(ex.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


        // DELETE api/<CommentsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            try
            {
                _commandHandler.HandleCommand(command, id);
                return StatusCode(204);
            }
            catch (UnauthorizedUseCaseException ex)
            {
                return Unauthorized();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return StatusCode(400);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (ForeignKeyConstraintException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<CommentsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCommentDto dto, IUpdateCommentCommand command)
        {
            try
            {
                dto.Id = id;
                _commandHandler.HandleCommand(command, dto);
                return StatusCode(204);
            }
            catch (UnauthorizedUseCaseException ex)
            {
                return Unauthorized();
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (ValidationException ex)
            {
                return UnprocessableEntity(ex.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


        // GET: api/<CommentsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



    }
}
