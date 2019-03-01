using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kros.EventBusDoc.Demo.Products;

namespace Kros.EventBusDoc.Demo.Data
{
    public class DemoRepository : IDemoRepository
    {
        public void AddEntity(object model)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItems)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(string username, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public bool SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}
