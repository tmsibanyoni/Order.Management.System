using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Order.Management.Repository.Interfaces;
using Order.Management.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Order.Management.Repository.Helpers
{
    public class DomainManager(ILogger<DomainManager> logger,
                              IRedisRepositoryHelper redisRepositoryHelper,
                              IDiscountHelper discountHelper,
                              IOrderHelper orderHelper) : IDomainManager
    {
        public readonly ILogger<DomainManager> _logger = logger;
        public readonly IRedisRepositoryHelper _redisRepository = redisRepositoryHelper;
        public readonly IDiscountHelper _discountHelper = discountHelper;
        public readonly IOrderHelper _orderHelper = orderHelper;

        public decimal CalculateDiscountAsync(CustomerOrder customer)
        {
            return _discountHelper.CalculateDiscount(customer);
        }

        public async Task<decimal> PlaceOrder(CustomerOrder customer)
        {
            return await _orderHelper.PlaceOrder(customer);
        }

        public async Task<List<OrdersDetail>> GetAllOrders()
        {
            var cacheKey = $"get-all-orders-{DateTime.Now.ToString("yyyyMMddmm")}";
            var redisOrders = _redisRepository.GetValue(cacheKey);

            if (redisOrders == null)
            {
                var getAllOrders = _orderHelper.RetrieveAll();
                _redisRepository.SetValue(cacheKey, JsonSerializer.Serialize(getAllOrders));

                return getAllOrders.Result;
            }
            else
            {
                try
                {
                    return JsonSerializer.Deserialize<List<OrdersDetail>>(redisOrders);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<List<OrdersDetail>> GetCustomerOrders(int clientId)
        {
            return await _orderHelper.GetOrdersByClientId(clientId);
        }

        public async Task<OrderAnalytics> GetOrderAnalytic()
        {
            return await _orderHelper.GetOrderAnalytic();
        }
        public async Task<OrdersDetail> OrderStatusTracking(int orderDetailsId, OrderStatus newStatus)
        {
            return await _orderHelper.OrderStatusTracking(orderDetailsId, newStatus);
        }
    }
}