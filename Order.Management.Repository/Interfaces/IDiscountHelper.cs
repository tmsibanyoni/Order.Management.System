using Order.Management.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Repository.Interfaces
{
    public interface IDiscountHelper
    {
        decimal CalculateDiscount(CustomerOrder customer);
    }
}
