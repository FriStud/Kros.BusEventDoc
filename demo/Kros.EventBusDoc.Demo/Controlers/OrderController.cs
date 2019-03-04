using Kros.EventBusDoc.Demo.Services;
using Kros.EventBusDoc.Demo.Services.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderingService _orderSvc;
        private readonly ILogger<ProductsController> _logger;

        public OrderController(IOrderingService orderingService, ILogger<ProductsController> logger)
        {
            _orderSvc = orderingService;
            _logger = logger;
        }

        [Route("cancel")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CancelOrderAsync([FromBody]CancelOrderCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            return Ok();
        }

    }
}
