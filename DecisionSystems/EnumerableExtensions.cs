using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecisionSystems
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TOut> Pairwise<TIn, TOut>(this IEnumerable<TIn> items, Func<TIn, TIn, TOut> merge)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            return items.Zip(items.Skip(1), merge);
        }
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> numbers)
        {
            var generator = new Random();
            return numbers.OrderBy(_ => generator.Next());
        }
    }
}
