using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PInvoke.Linq
{
    public static partial class PInvokeQueryEx
    {
        internal static TObserver Observe<T, TObserver>(this IPInvokeObservable<T> @this, TObserver observer)
            where TObserver : IPinvokeObserver<T>
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));
            if (observer == null) throw new ArgumentNullException(nameof(observer));

            @this.Subscribe(observer);
            return observer;
        }

        public static IPInvokeObservable<T> Where<T>(this IPInvokeObservable<T> @this, Func<T, bool> func)
            => @this.Observe(new PInvokeQuery<T, T>((s, v) => func(v) || s.OnNext(v)));

        public static IPInvokeObservable<T> Where<T>(this IPInvokeObservable<T> @this, Func<T, int, bool> func)
        {
            int i = 0;
            return @this.Observe(new PInvokeQuery<T, T>((s, v) => func(v, i++) || s.OnNext(v)));
        }

        public static IPInvokeObservable<T2> Select<T1, T2>(this IPInvokeObservable<T1> @this, Func<T1, T2> func)
            => @this.Observe(new PInvokeQuery<T1, T2>((s, v) => s.OnNext(func(v))));

        public static IPInvokeObservable<T2> Select<T1, T2>(this IPInvokeObservable<T1> @this, Func<T1, int, T2> func)
        {
            int i = 0;
            return @this.Observe(new PInvokeQuery<T1, T2>((s, v) => s.OnNext(func(v, i++))));
        }

        public static IPInvokeObservable<T2> SelectMany<T1, T2>(this IPInvokeObservable<T1> @this, Func<T1, IEnumerable<T2>> func)
            => @this.Observe(new PInvokeQuery<T1, T2>((s, v) =>
            {
                foreach (var item in func(v))
                {
                    if (!s.OnNext(item))
                    {
                        return false;
                    }
                }
                return true;
            }));

        public static IPInvokeObservable<T2> SelectMany<T1, T2>(this IPInvokeObservable<T1> @this, Func<T1, int, IEnumerable<T2>> func)
            => @this.Observe(new PInvokeQuery<T1, T2>((s, v) =>
            {
                int i = 0;
                foreach (var item in func(v, i))
                {
                    if (!s.OnNext(item))
                    {
                        return false;
                    }
                }
                return true;
            }));

        public static IPInvokeObservable<T> Take<T>(this IPInvokeObservable<T> @this, int count)
        {
            int i = 0;
            return @this.Observe(new PInvokeQuery<T, T>((s, v) => (i++ < count) && s.OnNext(v)));
        }

        public static IPInvokeObservable<T> TakeWhile<T>(this IPInvokeObservable<T> @this, Func<T, bool> func)
        {
            bool flag = true;
            return @this.Observe(new PInvokeQuery<T, T>((s, v) => (flag &= func(v)) && s.OnNext(v)));
        }

        public static IPInvokeObservable<T> TakeWhile<T>(this IPInvokeObservable<T> @this, Func<T, int, bool> func)
        {
            bool flag = true;
            int i = 0;
            return @this.Observe(new PInvokeQuery<T, T>((s, v) => (flag &= func(v, i++)) && s.OnNext(v)));
        }

        public static IPInvokeObservable<T> Skip<T>(this IPInvokeObservable<T> @this, int count)
        {
            int i = 0;
            return @this.Observe(new PInvokeQuery<T, T>((s, v) => (i++ < count) || s.OnNext(v)));
        }

        public static IPInvokeObservable<T> SkipWhile<T>(this IPInvokeObservable<T> @this, Func<T, bool> func)
        {
            bool flag = true;
            return @this.Observe(new PInvokeQuery<T, T>((s, v) => (flag &= func(v)) || s.OnNext(v)));
        }

        public static IPInvokeObservable<T> SkipWhile<T>(this IPInvokeObservable<T> @this, Func<T, int, bool> func)
        {
            bool flag = true;
            int i = 0;
            return @this.Observe(new PInvokeQuery<T, T>((s, v) => (flag &= func(v, i++)) || s.OnNext(v)));
        }

        public static IPInvokeObservable<T> Distinct<T>(this IPInvokeObservable<T> @this)
            => @this.Distinct(EqualityComparer<T>.Default);

        public static IPInvokeObservable<T> Distinct<T>(this IPInvokeObservable<T> @this, IEqualityComparer<T> comparer)
        {
            var hashSet = new HashSet<T>(comparer);
            return @this.Observe(new PInvokeQuery<T, T>((s, v) => hashSet.Add(v) ? s.OnNext(v) : true));
        }

        public static IPInvokeObservable<T> Distinct<T, TKey>(this IPInvokeObservable<T> @this, Func<T, TKey> func)
            => @this.Distinct(func, EqualityComparer<TKey>.Default);

        public static IPInvokeObservable<T> Distinct<T, TKey>(this IPInvokeObservable<T> @this, Func<T, TKey> func, IEqualityComparer<TKey> comparer)
        {
            var hashSet = new HashSet<TKey>(comparer);
            return @this.Observe(new PInvokeQuery<T, T>((s, v) => hashSet.Add(func(v)) ? s.OnNext(v) : true));
        }

        public static IPInvokeQueryEndNode<bool> All<T>(this IPInvokeObservable<T> @this, Func<T, bool> func)
        {
            bool? flag = null;
            return @this.Observe(new PInvokeQueryEndpoint<T, bool>(
                v =>
                {
                    var f = flag ?? true;
                    f &= func(v);
                    flag = f;
                    return flag.Value;
                },
                () => flag ?? false));
        }

        public static IPInvokeQueryEndNode<bool> Any<T>(this IPInvokeObservable<T> @this)
        {
            bool flag = false;
            return @this.Observe(new PInvokeQueryEndpoint<T, bool>(
                v =>
                {
                    flag = true;
                    return false;
                },
                () => flag));
        }

        public static IPInvokeQueryEndNode<bool> Any<T>(this IPInvokeObservable<T> @this, Func<T, bool> func)
        {
            bool flag = false;
            return @this.Observe(new PInvokeQueryEndpoint<T, bool>(
                v => (flag |= func(v)),
                () => flag));
        }

        public static IPInvokeQueryEndNode<T> First<T>(this IPInvokeObservable<T> @this)
        {
            bool hasValue = false;
            T value = default(T);
            return @this.Observe(new PInvokeQueryEndpoint<T, T>(
                v =>
                {
                    hasValue = true;
                    value = v;
                    return false;
                },
                () => hasValue ? value : throw new InvalidOperationException()));
        }

        public static IPInvokeQueryEndNode<T> First<T>(this IPInvokeObservable<T> @this, Func<T, bool> func)
            => @this.Where(v => func(v)).First();

        public static IPInvokeQueryEndNode<T> FirstOrDefault<T>(this IPInvokeObservable<T> @this)
        {
            T value = default(T);
            return @this.Observe(new PInvokeQueryEndpoint<T, T>(
                v =>
                {
                    value = v;
                    return false;
                },
                () => value));
        }

        public static IPInvokeQueryEndNode<T> FirstOrDefault<T>(this IPInvokeObservable<T> @this, Func<T, bool> func)
            => @this.Where(v => func(v)).FirstOrDefault();

        public static IPInvokeQueryEndNode<T> Last<T>(this IPInvokeObservable<T> @this)
        {
            bool hasValue = false;
            T value = default(T);
            return @this.Observe(new PInvokeQueryEndpoint<T, T>(
                v =>
                {
                    hasValue = true;
                    value = v;
                },
                () => hasValue ? value : throw new InvalidOperationException()));
        }

        public static IPInvokeQueryEndNode<T> Last<T>(this IPInvokeObservable<T> @this, Func<T, bool> func)
            => @this.Where(v => func(v)).Last();

        public static IPInvokeQueryEndNode<T> LastOrDefault<T>(this IPInvokeObservable<T> @this)
        {
            T value = default(T);
            return @this.Observe(new PInvokeQueryEndpoint<T, T>(
                v => value = v,
                () => value));
        }

        public static IPInvokeQueryEndNode<T> LastOrDefault<T>(this IPInvokeObservable<T> @this, Func<T, bool> func)
            => @this.Where(v => func(v)).LastOrDefault();

        public static IPInvokeQueryEndNode<int> Count<T>(this IPInvokeObservable<T> @this)
        {
            int count = 0;
            return @this.Observe(new PInvokeQueryEndpoint<T, int>(
                v => count++,
                () => count));
        }

        public static IPInvokeQueryEndNode<int> Count<T>(this IPInvokeObservable<T> @this, Func<T, bool> func)
        {
            int count = 0;
            return @this.Observe(new PInvokeQueryEndpoint<T, int>(
                v =>
                {
                    if (func(v))
                    {
                        count++;
                    }
                },
                () => count));
        }

        public static IPInvokeQueryEndNode ForEach<T>(this IPInvokeObservable<T> @this, Action<T> action)
            => @this.Observe(new PInvokeQueryEndpoint<T>(v => action(v)));

        public static IPInvokeQueryEndNode ForEach<T>(this IPInvokeObservable<T> @this, Action<T, int> action)
        {
            int i = 0;
            return @this.Observe(new PInvokeQueryEndpoint<T>(v => action(v, i++)));
        }

        public static IPInvokeQueryEndNode<T> Aggregate<T>(this IPInvokeObservable<T> @this, Func<T, T, T> func)
            => @this.Aggregate(default(T), func);

        public static IPInvokeQueryEndNode<TAccumulate> Aggregate<T, TAccumulate>(this IPInvokeObservable<T> @this, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func)
            => @this.Aggregate(seed, func, x => x);

        public static IPInvokeQueryEndNode<TResult> Aggregate<T, TAccumulate, TResult>(this IPInvokeObservable<T> @this, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            TAccumulate accumulate = seed;
            return @this.Observe(new PInvokeQueryEndpoint<T, TResult>(
                v => accumulate = func(seed, v),
                () => resultSelector(accumulate)));
        }

        public static IPInvokeQueryEndNode<List<T>> ToList<T>(this IPInvokeObservable<T> @this)
            => @this.Aggregate(
                new List<T>(),
                (list, v) =>
                {
                    list.Add(v);
                    return list;
                });

        public static IPInvokeQueryEndNode<Dictionary<TKey, T>> ToDictionary<T, TKey>(this IPInvokeObservable<T> @this, Func<T, TKey> keySelector)
            => @this.ToDictionary(keySelector, EqualityComparer<TKey>.Default);

        public static IPInvokeQueryEndNode<Dictionary<TKey, T>> ToDictionary<T, TKey>(this IPInvokeObservable<T> @this, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer)
            => @this.ToDictionary(keySelector, x => x, comparer);

        public static IPInvokeQueryEndNode<Dictionary<TKey, TValue>> ToDictionary<T, TKey, TValue>(this IPInvokeObservable<T> @this, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)
            => @this.ToDictionary(keySelector, valueSelector, EqualityComparer<TKey>.Default);

        public static IPInvokeQueryEndNode<Dictionary<TKey, TValue>> ToDictionary<T, TKey, TValue>(this IPInvokeObservable<T> @this, Func<T, TKey> keySelector, Func<T, TValue> valueSelector, IEqualityComparer<TKey> comparer)
            => @this.Aggregate(
                new Dictionary<TKey, TValue>(comparer),
                (dict, v) =>
                {
                    dict.Add(keySelector(v), valueSelector(v));
                    return dict;
                });

        public static IPInvokeQueryEndNode<ILookup<TKey, T>> ToLookup<T, TKey>(this IPInvokeObservable<T> @this, Func<T, TKey> keySelector)
            => @this.ToLookup(keySelector, EqualityComparer<TKey>.Default);

        public static IPInvokeQueryEndNode<ILookup<TKey, T>> ToLookup<T, TKey>(this IPInvokeObservable<T> @this, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer)
            => @this.ToLookup(keySelector, x => x, comparer);

        public static IPInvokeQueryEndNode<ILookup<TKey, TValue>> ToLookup<T, TKey, TValue>(this IPInvokeObservable<T> @this, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)
            => @this.ToLookup(keySelector, valueSelector, EqualityComparer<TKey>.Default);

        public static IPInvokeQueryEndNode<ILookup<TKey, TValue>> ToLookup<T, TKey, TValue>(this IPInvokeObservable<T> @this, Func<T, TKey> keySelector, Func<T, TValue> valueSelector, IEqualityComparer<TKey> comparer)
            => @this.Aggregate(
                new Lookup<TKey, TValue>(comparer),
                (lookup, v) =>
                {
                    lookup.Add(keySelector(v), valueSelector(v));
                    return lookup;
                });
    }
}