using Microsoft.AspNetCore.Mvc;
using MediatR;
using NorthwindTest.Application.Northwind.Commands.CreateUserCommand;
using NorthwindTest.Application.Northwind.Queries.QueryUserLIstQuery;

namespace NorthwindTest.Controllers
{
    [ApiController]
    [Route("customer/[controller]")]
    public class NorthwindController
    {

        public readonly IMediator _mediator;
        public NorthwindController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<CreateUserResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPost("all")]
        public async Task<QueryUserListResult> Read([FromQuery] QueryUserListQuery qurey)
        {
            var result = await _mediator.Send(qurey);
            return result;
        }
    }
}
