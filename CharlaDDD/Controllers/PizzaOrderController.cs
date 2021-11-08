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
    [Route("order")]
    public class PizzaOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPizzaOrdersQueries _queries;

        public PizzaOrderController(IMediator mediator, IPizzaOrdersQueries queries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PizzaOrderDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PizzaOrderDto>>> GetPizzaOrders() 
        {
            var result = await _queries.GetOrdersAsync();

            return Ok(result);
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(PizzaOrderDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<PizzaOrderDto>> GetPizzaOrderById(int orderId) 
        {
            var result = await _queries.GetOrderByIdAsync(orderId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        } 

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePizzaOrderCommandResponse>> CreatePizzaOrder(CreatePizzaOrderCommand order) => await _mediator.Send(order);

        [HttpPut("add-item")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AddOrderItemCommandResponse>> AddOrderItem(AddOrderItemCommand order) => await _mediator.Send(order);

        [HttpPut("delete-item")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<DeleteOrderItemCommandResponse>> DeleteOrderItem(DeleteOrderItemCommand order) => await _mediator.Send(order);
    }
}
