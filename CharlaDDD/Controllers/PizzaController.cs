using System;
using System.Threading.Tasks;
using CharlaDDD.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CharlaDDD.Controllers
{
    [ApiController]
    [Route("pizza")]
    public class PizzaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PizzaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ActionResult<CreatePizzaCommandResponse>> CreatePizza(CreatePizzaCommand order) => await _mediator.Send(order);
    }
}
