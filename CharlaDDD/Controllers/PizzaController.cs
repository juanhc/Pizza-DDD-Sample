using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CharlaDDD.Application.Commands;
using CharlaDDD.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CharlaDDD.Controllers
{
    [ApiController]
    [Route("pizza")]
    public class PizzaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPizzaApplicationQueries _queries;

        public PizzaController(IMediator mediator, 
            IPizzaApplicationQueries queries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PizzaDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PizzaDto>>> GetPizzas()
        {
            var result = await _queries.GetPizzasAsync();

            return Ok(result);
        }

        [HttpGet("{pizzaId}")]
        [ProducesResponseType(typeof(PizzaDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<PizzaDto>> GetPizzaById(int pizzaId)
        {
            var result = await _queries.GetPizzaByIdAsync(pizzaId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePizzaCommandResponse>> CreatePizza(CreatePizzaCommand order) => await _mediator.Send(order);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<DeletePizzaCommandResponse>> DeletePizza(int pizzaId) => await _mediator.Send(new DeletePizzaCommand(pizzaId));
    }
}
