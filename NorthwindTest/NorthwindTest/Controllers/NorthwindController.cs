using Microsoft.AspNetCore.Mvc;
using MediatR;

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


    }
}
