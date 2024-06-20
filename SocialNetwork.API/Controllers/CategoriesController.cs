using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.UseCases.Commands.Categories;
using SocialNetwork.DataAccess;
using SocialNetwork.Implementation;
using System.Reflection.Metadata;
using FluentValidation;
using SocialNetwork.API.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Queries.Posts;
using SocialNetwork.Application.UseCases.Queries.Categories;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private UseCaseHandler _commandHandler;
        private SocialNetworkContext _context;

        public CategoriesController(UseCaseHandler commandHandler, SocialNetworkContext context)
        {
            _commandHandler = commandHandler;
            _context = context;
        }

        // POST api/<CategoriesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromServices] ICreateCategoryCommand command, [FromBody] CreateCategoryDTO dto)
        {
            try
            {
                _commandHandler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch (UnauthorizedUseCaseException ex)
            {
                return Unauthorized();
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


        //DELETE api/<CategoriesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            try
            {
                var dto = new DeleteCategoryDto();
                dto.Id = id;
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
            catch(ForeignKeyConstraintException ex)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


        // PUT api/<CategoriesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryDto dto, [FromServices] IUpdateCategoryCommand command)
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
            catch (EntityNotFoundException ex)
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

        // GET: api/<CategoriesController>
        [HttpGet]

        public IActionResult Get([FromQuery] CategoriesSearch search,
                                [FromServices] ISearchCategoriesQuery query)
        {
            return Ok(_commandHandler.HandleQuery(query, search));
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


     

    }
}
