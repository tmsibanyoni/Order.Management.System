using Order.Management.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Repository.Interfaces
{
    public interface IDomainManager
    {
        decimal CalculateDiscountAsync(CustomerOrder customer);
        Task<decimal> PlaceOrder(CustomerOrder customer);
        Task<List<OrdersDetail>> GetCustomerOrders(int id);
        Task<List<OrdersDetail>> GetAllOrders();
        Task<OrderAnalytics> GetOrderAnalytic();
        Task<OrdersDetail> OrderStatusTracking(int orderDetailsId, OrderStatus newStatus);
    }
}