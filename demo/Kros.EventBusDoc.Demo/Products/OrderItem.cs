using System;

namespace Kros.EventBusDoc.Demo.Products
{
    /// <summary>
    /// Specific item that is part of order.
    /// </summary>
    public class OrderItem
    {
        public int Id { get; set; }
        /// <summary>
        /// The refering product of order item.
        /// </summary>
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// Reference for the order that has this oreder item.
        /// </summary>
        public Order Order { get; set; }
    }
}