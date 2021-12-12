using cqrs.Application.Response;
using cqrs.Application.User.Commands;
using cqrs.Application.User.Dtos;
using cqrs.Application.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cqrs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IMediator _mediator;
        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand user)
        {
            return Ok(await this._mediator.Send(user));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._mediator.Send(new GetAllUsersQuery()));
        }

    }
}
