using Order.Management.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Repository.Interfaces
{
    public interface ICustomerHelper
    {
        Task<CustomerOrder> CreateCustomer(CustomerOrder order);
        Task<CustomerOrder> GetCustomerById(int orderId);
        Task<List<CustomerOrder>> RetrieveAll();
    }
}
