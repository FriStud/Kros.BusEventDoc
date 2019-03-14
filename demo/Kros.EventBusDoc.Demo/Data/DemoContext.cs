using Kros.EventBusDoc.Demo.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Data
{
    /// <summary>
    /// Simulate database context
    /// </summary>
    public class DemoContext
    {
        public DemoContext(){}
        /// <summary>
        /// Products contained in database
        /// </summary>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// Products contained in database
        /// </summary>
        public DbSet<Order> Orders { get; set; }
    }
}
