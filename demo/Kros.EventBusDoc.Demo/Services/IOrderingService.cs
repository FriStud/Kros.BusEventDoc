using Kros.EventBusDoc.Demo.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Contracts
{
    public interface IOrderingService
    {
        Task<List<Order>> GetMyOrders(StoreUser user);
        Task<Order> GetOrder(StoreUser user, int orderId);
        Task CancelOrder(int orderId);
    }
}
