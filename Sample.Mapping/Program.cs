using Sample.Core;
using Sample.Domain;
using Sample.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Mapping
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var manualMapper = new ManualMapper.OrderConvert();
            var reflectionMapper = new ReflectionMapper.OrderReflectionMapper();
            var autoMapperMapper = new Sample.AutoMapper.AutoMapperOrderConverter();
            var emitOrderMapper = new Sample.Emit.OrderEmitMapper();

            GetTime(manualMapper,5000);
            GetTime(autoMapperMapper, 5000);
            GetTime(emitOrderMapper, 5000);
            GetTime(reflectionMapper, 5000);

            GetTime(manualMapper, 50000);
            GetTime(autoMapperMapper, 50000);
            GetTime(emitOrderMapper, 50000);
            GetTime(reflectionMapper, 50000);


            GetTime(manualMapper, 500000);
            GetTime(autoMapperMapper, 500000);
            GetTime(emitOrderMapper, 500000);
            GetTime(reflectionMapper, 500000);

            GetTime(manualMapper, 5000000);
            GetTime(autoMapperMapper, 5000000);
            GetTime(emitOrderMapper, 5000000);
            GetTime(reflectionMapper, 5000000);

            Console.ReadKey();

        }

        static List<Order> GetOrders(int numberOfItems)
        {
            var orders = new List<Order>();

            foreach (var i in Enumerable.Range(1, numberOfItems))
            {
                orders.Add(new Order()
                {
                    Id = i,
                    OrderDate = DateTime.Now,
                    Customer = new Customer()
                    {
                        Birthdate = new DateTime(1983, 8, 17),
                        Name = "JTorrecilla"
                    }

                });
            }
            return orders;
        }
        static void GetTime(IConvert<Order,OrderDto> mapper,int numberOfItems)
        {
            var watch = new Stopwatch();
            watch.Start();
            var ordersdto = new List<OrderDto>();
            foreach (var order in GetOrders(numberOfItems))
            {
                ordersdto.Add(mapper.Convert(order));
            }

            watch.Stop();
            Console.WriteLine($"Mapper {mapper.GetType().Name} done {numberOfItems} in {watch.ElapsedMilliseconds} ms");


        }
    }
}
