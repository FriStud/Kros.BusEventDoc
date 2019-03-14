using Kros.EventBusDoc.Demo.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Data
{
    /// <summary>
    /// Demo repository to fetch required data.
    /// </summary>
    public interface IDemoRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItems);
        Order GetOrderById(string username, int id);

        bool SaveAll();

        void AddEntity(object model);
        void AddOrder(Order newOrder);
    }
}
