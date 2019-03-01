using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Services
{
    public interface IOrderService
    {
        Task<bool> CancelOrderAsync(int orderId, string token);
    }
}
