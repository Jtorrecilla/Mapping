using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Dto
{
    public class OrderDto
    {
        public CustomerDto Customer { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderDetailDto> Details { get; set; }
    }
}
