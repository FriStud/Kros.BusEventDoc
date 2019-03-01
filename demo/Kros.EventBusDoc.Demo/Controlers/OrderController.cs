using Kros.EventBusDoc.Demo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Controlers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderingService _orderSvc;
        private readonly ILogger<ProductsController> _logger;

        public OrderController(IOrderingService orderingService, ILogger<ProductsController> logger)
        {
            _orderSvc = orderingService;
            _logger = logger;
        }

        public async Task<IActionResult> Cancel(int orderId)
        {
            await _orderSvc.CancelOrder(orderId);

            return RedirectToAction("Index");
        }

    }
}
