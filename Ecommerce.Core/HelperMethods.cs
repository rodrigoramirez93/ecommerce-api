using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core
{
    public static class HelperMethods
    {
        public static Task LoopAsync<T>(this IEnumerable<T> list, Func<T, Task> function)
        {
            return Task.WhenAll(list.Select(function));
        }

        public async static Task<IEnumerable<TOut>> LoopAsyncResult<TIn, TOut>(this IEnumerable<TIn> list, Func<TIn, Task<TOut>> function)
        {
            var loopResult = await Task.WhenAll(list.Select(function));

            return loopResult.ToList().AsEnumerable();
        }
    }
}
