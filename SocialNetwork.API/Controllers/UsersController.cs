using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.UseCases.Commands.Users;
using SocialNetwork.DataAccess;
using SocialNetwork.Implementation;
using FluentValidation;
using FluentValidation.Results;
using SocialNetwork.API.Extensions;
using SocialNetwork.Application.Exceptions;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _commandHandler;

        public UsersController(UseCaseHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }


        // POST api/<UsersController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserDto dto, [FromServices] IRegisterUserCommand cmd)
        {
            try
            {
                _commandHandler.HandleCommand(cmd, dto);

                return StatusCode(201);
            }
            catch (ValidationException ex)
            {
                return UnprocessableEntity(ex.Errors.Select(x => new
                {
                    Error = x.ErrorMessage,
                    Property = x.PropertyName
                }));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(new { error = "An error has occured..." });
            }
        }


        [Authorize]
        [HttpPost("adduser")]
        public IActionResult AddUser([FromBody] AddUserRelationDto dto, [FromServices] IAddUserRelationCommand cmd)
        {
            try
            {
                _commandHandler.HandleCommand(cmd, dto);

                return StatusCode(201);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch(ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(new { error = "An error has occured..." });
            }

        }


        // PUT api/<UsersController>/5
        [Authorize]
        [HttpPut("acceptRequest")]
        public IActionResult AcceptRequest([FromServices] IAcceptUserRequestCommand command, [FromBody] AcceptUserRequestDto dto)
        {
            try
            {
                _commandHandler.HandleCommand(command, dto);
                return StatusCode(204);
            }
            catch (UnauthorizedUseCaseException ex)
            {
                return Unauthorized();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (ConflictException ex)
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
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // DELETE api/<UsersController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRejectUserRequestCommand command)
        {
            try
            {
                var dto = new RejectUserRequestDto();
                dto.RejectedUserId = id;
                _commandHandler.HandleCommand(command, dto);
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
            catch(ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
