using Order.Management.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Repository.Interfaces
{
    public interface IOrderHelper
    {
        Task<decimal> PlaceOrder(CustomerOrder customer);
        Task<OrdersDetail> GetOrderById(int orderId);
        Task<List<OrdersDetail>> GetOrdersByClientId(int clientId);
        Task<List<OrdersDetail>> RetrieveAll();
        Task<OrderAnalytics> GetOrderAnalytic();
        Task<OrdersDetail> OrderStatusTracking(int orderDetailsId, OrderStatus newStatus);
    }
}
