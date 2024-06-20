using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.DTO;
using SocialNetwork.Application.Exceptions;
using SocialNetwork.Application.UseCases.Commands.Posts;
using SocialNetwork.Implementation;
using SocialNetwork.Application.UseCases.Queries.Posts;
using SocialNetwork.API.Extensions;
using FluentValidation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using SocialNetwork.Application.UseCases.Commands.Categories;
using System.ComponentModel.DataAnnotations;
using ValidationException = FluentValidation.ValidationException;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public PostsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // POST api/<PostsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreatePostDto dto, ICreatePostCommand command)
        {
            try
            {
                _handler.HandleCommand(command, dto);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<PostsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePostCommand command)
        {
            try
            {
                var dto = new DeletePostDto();
                dto.Id = id;
                _handler.HandleCommand(command, dto);
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
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        public IActionResult Get([FromQuery] PostsSearch search,
                                 [FromServices] ISearchPostsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }



        // PUT api/<PostsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePostDto dto, [FromServices] IUpdatePostCommand command)
        {
            try
            {
                dto.Id = id;
                _handler.HandleCommand(command, dto);
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


        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}