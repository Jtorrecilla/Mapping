using Sample.Core;
using Sample.Domain;
using Sample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmitMapper;

namespace Sample.Emit
{
    public class OrderEmitMapper : IConvert<Order, OrderDto>
    {
        private ObjectsMapper<Order, OrderDto> mapper;

        public OrderEmitMapper()
        {
            this.mapper = EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<Order, OrderDto>();
        }
        public OrderDto Convert(Order source)
        {
            return mapper.Map(source);
        }
    }
}
