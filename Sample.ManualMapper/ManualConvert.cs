using Sample.Core;
using Sample.Domain;
using Sample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.ManualMapper
{
    public class OrderConvert : IConvert<Order, OrderDto>
    {
        public OrderDto Convert(Order source)
        {
            return new OrderDto()
            {
                OrderDate = source.OrderDate,
                Customer = new CustomerConvert().Convert(source.Customer)
            };
        }
    }
    public class CustomerConvert : IConvert<Customer, CustomerDto>
    {
        public CustomerDto Convert(Customer source)
        {
            return new CustomerDto()
            {
                Name = source.Name
            };
        }
    }

}
