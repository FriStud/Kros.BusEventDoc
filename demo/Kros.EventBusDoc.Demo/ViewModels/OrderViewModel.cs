using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; }

        public IEnumerable<OrderItemViewModel> Items { get; set; }

    }
}
