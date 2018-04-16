using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PInvoke.Linq
{
    internal class Lookup<TKey, TElement> : ILookup<TKey, TElement>
    {
        public Lookup() : this(EqualityComparer<TKey>.Default)
        {
        }

        public Lookup(IEqualityComparer<TKey> comparer)
        {
            dict = new Dictionary<TKey, Grouping<TKey, TElement>>(comparer);
        }

        private readonly Dictionary<TKey, Grouping<TKey, TElement>> dict;

        public IEnumerable<TElement> this[TKey key]
        {
            get
            {
                if (dict.TryGetValue(key, out var grouping))
                {
                    return grouping;
                }
                return Enumerable.Empty<TElement>();
            }
        }

        public int Count => dict.Count;

        public void Add(TKey key, TElement value)
        {
            if (dict.TryGetValue(key, out var grouping))
            {
                grouping.Add(value);
            }
        }

        public bool Contains(TKey key) => dict.ContainsKey(key);

        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
            => dict.Values
            .Cast<IGrouping<TKey, TElement>>()
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }

    internal class Grouping<TKey, TElement> : List<TElement>, IGrouping<TKey, TElement>
    {
        public Grouping(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            Key = key;
        }

        public TKey Key { get; }
    }
}
