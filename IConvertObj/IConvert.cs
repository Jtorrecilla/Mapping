using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core
{
    public interface IConvert<TSource, TTarget>
    {
        TTarget Convert(TSource source);
    }
}
