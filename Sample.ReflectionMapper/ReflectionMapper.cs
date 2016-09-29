using Sample.Core;
using Sample.Domain;
using Sample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.ReflectionMapper
{
    public class OrderReflectionMapper : IConvert<Order, OrderDto>
    {

        public OrderDto Convert(Order source)
        {
            
            return (OrderDto)ReflectionHelper.Build(typeof(Order),typeof(OrderDto),source);
        }
    }
    public static class ReflectionHelper
    {
        internal static  bool IsMicrosoftType(Type type)
        {
            object[] attrs = type.Assembly.GetCustomAttributes
                (typeof(AssemblyCompanyAttribute), false);

            return attrs.OfType<AssemblyCompanyAttribute>()
                        .Any(attr => attr.Company == "Microsoft Corporation");
        }
        public static object Build(Type  sourceType,Type targetType,object source)
        {
            var type = targetType;
            var obj = type.GetConstructor(Type.EmptyTypes).Invoke(null);
            foreach (var property in source.GetType().GetProperties())

            {
                var prop = type.GetProperties().FirstOrDefault(p => p.Name == property.Name);
                if (prop != null)
                {
                    if (!IsMicrosoftType(property.PropertyType))
                    {
                        prop.SetValue(obj, ReflectionHelper.Build(property.PropertyType, prop.PropertyType, property.GetValue(source)));
                    }
                    else
                    {

                        prop.SetValue(obj, property.GetValue(source));
                    }
                }
            }
            return obj;

        }
        
    }
}
