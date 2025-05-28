using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Repository.Models
{
    public class OrderAnalytics
    {
        public decimal? AverageOrderValue { get; set; }
        public double AverageFulfillmentTime { get; set; }
        public int VIPCustomerSegments { get; set; }
        public int RegularCustomerSegments { get; set; }
    }
}
