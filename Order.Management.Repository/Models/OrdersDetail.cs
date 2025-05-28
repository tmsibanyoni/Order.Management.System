using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Repository.Models
{
    public class OrdersDetail
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Code { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderInitiateDateTime { get; set; }
        public DateTime OrderCompletedDateTime { get; set; }
        public OrderStatus Status { get; set; }
    }
}
