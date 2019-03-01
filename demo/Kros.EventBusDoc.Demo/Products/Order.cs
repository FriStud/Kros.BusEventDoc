using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Products
{
    /// <summary>
    /// Represent placed order by user, includeing the collection of orderItmes.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// When was the order created.
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Order number.
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        ///The items that are part of this order.
        /// </summary>
        public ICollection<OrderItem> Items { get; set; }
        /// <summary>
        /// User which has placed order.
        /// </summary>
        public StoreUser User { get; set; }
    }
}
