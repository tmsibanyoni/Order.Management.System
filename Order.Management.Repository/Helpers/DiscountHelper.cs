using Order.Management.Repository.Interfaces;
using Order.Management.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Repository.Helpers
{
    public class DiscountHelper: IDiscountHelper
    {
        public decimal CalculateDiscount(CustomerOrder customer)
        {
            decimal discount = 0;
            var orderAmount = customer.OrderList.Sum(x => x.TotalAmount);

            if (customer.CustomerSegment == Segment.VIP)
            {
                // 10% Discount for VIPs
                discount = orderAmount * 0.10m;
            }
            else if (customer.CustomerSegment == Segment.Regular && customer.OrderList.Count >= 5)
            {
                // 5% Discount for Regular  customers with more than 5 orders
                discount = orderAmount * 0.05m;
            }

            return discount;
        }
    }
}
