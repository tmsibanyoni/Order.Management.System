using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Order.Management.Repository.Interfaces;
using Order.Management.Repository.Models;

namespace Order.Management.System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController(IDomainManager domainHelper): Controller
    {
        private readonly IDomainManager _domainHelper = domainHelper;

        [HttpPost("calculate-discount")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public async Task<IActionResult> CalculateDiscountAsync(CustomerOrder customerOrder)
        {
            return Ok(_domainHelper.CalculateDiscountAsync(customerOrder));
        }

        [HttpGet("get-all-orders")]
        [ProducesResponseType(200, Type = typeof(List<OrdersDetail>))]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _domainHelper.GetAllOrders());
        }

        [HttpGet("get-customer-orders-by-id")]
        [ProducesResponseType(200, Type = typeof(List<CustomerOrder>))]
        public async Task<IActionResult> GetCustomerOrders(int customerId)
        {
            return Ok(await _domainHelper.GetCustomerOrders(customerId));
        }

        [HttpPost("Place-customer-order")]
        [ProducesResponseType(200, Type = typeof(List<OrdersDetail>))]
        public async Task<IActionResult> PlaceOrder(CustomerOrder customer)
        {
            return Ok(await _domainHelper.PlaceOrder(customer));
        }

        [HttpGet("get-order-analytics")]
        [ProducesResponseType(200, Type = typeof(List<OrdersDetail>))]
        public async Task<IActionResult> CreateCustomerOrder()
        {
            return Ok(await _domainHelper.GetOrderAnalytic());
        }

        [HttpGet("order-status-tracking")]
        [ProducesResponseType(200, Type = typeof(List<OrdersDetail>))]
        public async Task<IActionResult> CreateCustomerOrder(int orderDetailId, OrderStatus orderStatusId)
        {
            return Ok(await _domainHelper.OrderStatusTracking(orderDetailId, orderStatusId));
        }
    }
}
