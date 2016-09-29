using Sample.Core;
using Sample.Domain;
using Sample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper = AutoMapper;
namespace Sample.AutoMapper
{
    public class AutoMapperOrderConverter : IConvert<Order, OrderDto>
    {
        public AutoMapperOrderConverter()
        {
            Mapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<OrderDetail, OrderDetailDto>();

                cfg.CreateMap<Order, OrderDto>();
            });
        }
        public OrderDto Convert(Order source)
        {
            return Mapper.Mapper.Instance.Map<OrderDto>(source);
        }
    }
}
