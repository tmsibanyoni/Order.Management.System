using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Order.Management.Repository.Interfaces;
using Order.Management.Repository.Models;

namespace Order.Management.System.Tests.Controller
{
    [TestClass]
    public class OrderControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly IDomainManager _domainManager;
        public OrderControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _domainManager = _factory.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<IDomainManager>();
        }

        [TestMethod()]
        public void CalculateDiscount_VIP_ReturnCorrectDiscount()
        {
            Random random = new Random();

            var orderDetail = new OrdersDetail
            {
                OrderCompletedDateTime = DateTime.Now.AddHours(5),
                OrderInitiateDateTime = DateTime.Now,
                Status = OrderStatus.Delivered,
                Code = $"Code-{random.Next(1000,5000)}",
                TotalAmount = 100
            };

            var placeOrder = new CustomerOrder
            {
                CustomerSegment = Segment.VIP,
                OrderList = new List<OrdersDetail> { orderDetail }
            };

            var orderDiscount =  _domainManager.CalculateDiscountAsync(placeOrder);

            Assert.AreEqual(10, orderDiscount);
        }

        [TestMethod()]
        public void CalculateDiscount_Regular_For_Multiple_Or_ReturnCorrectDiscount()
        {
            Random random = new Random();

            var orderDetails = new List<OrdersDetail>
            {
                new OrdersDetail
                {
                    OrderCompletedDateTime = DateTime.Now.AddHours(5),
                    OrderInitiateDateTime = DateTime.Now,
                    Status = OrderStatus.Delivered,
                    Code = $"Code-{random.Next(1000, 5000)}",
                    TotalAmount = 100
                },
                new OrdersDetail
                {
                    OrderCompletedDateTime = DateTime.Now.AddHours(3),
                    OrderInitiateDateTime = DateTime.Now.AddHours(1),
                    Status = OrderStatus.Pending,
                    Code = $"Code-{random.Next(1000, 5000)}",
                    TotalAmount = 150
                },
                new OrdersDetail
                {
                    OrderCompletedDateTime = DateTime.Now.AddHours(7),
                    OrderInitiateDateTime = DateTime.Now.AddMinutes(30),
                    Status = OrderStatus.Cancelled,
                    Code = $"Code-{random.Next(1000, 5000)}",
                    TotalAmount = 200
                },
                new OrdersDetail
                {
                    OrderCompletedDateTime = DateTime.Now.AddHours(4),
                    OrderInitiateDateTime = DateTime.Now.AddHours(-1),
                    Status = OrderStatus.Processing,
                    Code = $"Code-{random.Next(1000, 5000)}",
                    TotalAmount = 250
                },
                new OrdersDetail
                {
                    OrderCompletedDateTime = DateTime.Now.AddHours(2),
                    OrderInitiateDateTime = DateTime.Now.AddMinutes(15),
                    Status = OrderStatus.Delivered,
                    Code = $"Code-{random.Next(1000, 5000)}",
                    TotalAmount = 300
                }
            };

            var placeOrder = new CustomerOrder
            {
                CustomerSegment = Segment.Regular,
                OrderList = orderDetails
            };

            var orderDiscount = _domainManager.CalculateDiscountAsync(placeOrder);
            Assert.AreEqual(50, orderDiscount);
        }
    }
}
