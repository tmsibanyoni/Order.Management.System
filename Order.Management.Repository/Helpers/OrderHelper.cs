using Microsoft.EntityFrameworkCore;
using Order.Management.Repository.Interfaces;
using Order.Management.Repository.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Repository.Helpers
{
    public class OrderHelper(ApplicationDbContextHelper dbContext, IDiscountHelper discountHelper) : IOrderHelper
    {
        public readonly ApplicationDbContextHelper _dbContext = dbContext;
        public readonly IDiscountHelper _discountHelper = discountHelper;

        public async Task<decimal> PlaceOrder(CustomerOrder customerOrder)
        {
            try
            {
                _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                customerOrder.Id = _dbContext.CustomersOrders.Count() + 1;
                customerOrder.OrderDiscount = _discountHelper.CalculateDiscount(customerOrder);

                foreach (var order in customerOrder.OrderList)
                {
                    //Add Orders to Table
                    var generateOrderId = _dbContext.OrdersDetail.Count() + 1;
                    order.Id  = generateOrderId;
                    order.CustomerId = customerOrder.Id;

                    _dbContext.OrdersDetail.Add(order);           
                }

                _dbContext.SaveChanges();

                return await Task.FromResult(customerOrder.OrderDiscount);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}. StackTrace: {ex.StackTrace}");
            }
        }

        public async Task<OrdersDetail> GetOrderById(int orderId)
        {
            try
            {
                return dbContext.OrdersDetail.FirstOrDefault(x => x.Id == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}. StackTrace: {ex.StackTrace}");
            }
        }

        public async Task<List<OrdersDetail>> GetOrdersByClientId(int clientId)
        {
            try
            {
                return dbContext.OrdersDetail.Where(x => x.CustomerId == clientId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}. StackTrace: {ex.StackTrace}");
            }
        }

        public async Task<List<OrdersDetail>> RetrieveAll()
        {
            try
            {
                _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                return dbContext.OrdersDetail.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}. StackTrace: {ex.StackTrace}");
            }
        }

        public async Task<OrderAnalytics> GetOrderAnalytic()
        {
            try
            {
                _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var orders = _dbContext.OrdersDetail.ToList();
                var customerOrders = _dbContext.CustomersOrders.ToList();

                return new OrderAnalytics()
                {
                    AverageOrderValue = orders.Average(o => o.TotalAmount),
                    AverageFulfillmentTime = orders.Average(o => (o.OrderCompletedDateTime - o.OrderInitiateDateTime).Ticks),
                    VIPCustomerSegments = customerOrders.Count(x => x.CustomerSegment == Segment.VIP),
                    RegularCustomerSegments = customerOrders.Count(x => x.CustomerSegment == Segment.Regular),
                }; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}. StackTrace: {ex.StackTrace}");
            }
        }

        public async Task<OrdersDetail> OrderStatusTracking(int orderDetailsId, OrderStatus newStatus)
        {
            try
            {
                var orderDetail = _dbContext.OrdersDetail.FirstOrDefault(x => x.Id == orderDetailsId);
                orderDetail.Status = newStatus;

                return orderDetail;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}. StackTrace: {ex.StackTrace}");
            }
        }
    }
}
