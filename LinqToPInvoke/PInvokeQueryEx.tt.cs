using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PInvoke.Linq
{
    public static partial class PInvokeQueryEx
    {
        public static IPInvokeQueryEndNode<int> Max(this IPInvokeObservable<int> @this)
            => @this.Aggregate(
            default(int?),
            (accumulate, v) => (v > accumulate) ? v : accumulate,
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<int?> Max(this IPInvokeObservable<int?> @this)
            => @this.Aggregate(
            default(int?),
            (accumulate, v) => (v > accumulate) ? v : accumulate);

        public static IPInvokeQueryEndNode<int> Max<T>(this IPInvokeObservable<T> @this, Func<T, int> func)
            => @this.Aggregate(
            default(int?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value > accumulate) ? value : accumulate;
            },
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<int?> Max<T>(this IPInvokeObservable<T> @this, Func<T, int?> func)
            => @this.Aggregate(
            default(int?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value > accumulate) ? value : accumulate;
            });

        public static IPInvokeQueryEndNode<long> Max(this IPInvokeObservable<long> @this)
            => @this.Aggregate(
            default(long?),
            (accumulate, v) => (v > accumulate) ? v : accumulate,
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<long?> Max(this IPInvokeObservable<long?> @this)
            => @this.Aggregate(
            default(long?),
            (accumulate, v) => (v > accumulate) ? v : accumulate);

        public static IPInvokeQueryEndNode<long> Max<T>(this IPInvokeObservable<T> @this, Func<T, long> func)
            => @this.Aggregate(
            default(long?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value > accumulate) ? value : accumulate;
            },
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<long?> Max<T>(this IPInvokeObservable<T> @this, Func<T, long?> func)
            => @this.Aggregate(
            default(long?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value > accumulate) ? value : accumulate;
            });

        public static IPInvokeQueryEndNode<float> Max(this IPInvokeObservable<float> @this)
            => @this.Aggregate(
            default(float?),
            (accumulate, v) => (v > accumulate) ? v : accumulate,
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<float?> Max(this IPInvokeObservable<float?> @this)
            => @this.Aggregate(
            default(float?),
            (accumulate, v) => (v > accumulate) ? v : accumulate);

        public static IPInvokeQueryEndNode<float> Max<T>(this IPInvokeObservable<T> @this, Func<T, float> func)
            => @this.Aggregate(
            default(float?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value > accumulate) ? value : accumulate;
            },
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<float?> Max<T>(this IPInvokeObservable<T> @this, Func<T, float?> func)
            => @this.Aggregate(
            default(float?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value > accumulate) ? value : accumulate;
            });

        public static IPInvokeQueryEndNode<double> Max(this IPInvokeObservable<double> @this)
            => @this.Aggregate(
            default(double?),
            (accumulate, v) => (v > accumulate) ? v : accumulate,
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<double?> Max(this IPInvokeObservable<double?> @this)
            => @this.Aggregate(
            default(double?),
            (accumulate, v) => (v > accumulate) ? v : accumulate);

        public static IPInvokeQueryEndNode<double> Max<T>(this IPInvokeObservable<T> @this, Func<T, double> func)
            => @this.Aggregate(
            default(double?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value > accumulate) ? value : accumulate;
            },
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<double?> Max<T>(this IPInvokeObservable<T> @this, Func<T, double?> func)
            => @this.Aggregate(
            default(double?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value > accumulate) ? value : accumulate;
            });

        public static IPInvokeQueryEndNode<decimal> Max(this IPInvokeObservable<decimal> @this)
            => @this.Aggregate(
            default(decimal?),
            (accumulate, v) => (v > accumulate) ? v : accumulate,
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<decimal?> Max(this IPInvokeObservable<decimal?> @this)
            => @this.Aggregate(
            default(decimal?),
            (accumulate, v) => (v > accumulate) ? v : accumulate);

        public static IPInvokeQueryEndNode<decimal> Max<T>(this IPInvokeObservable<T> @this, Func<T, decimal> func)
            => @this.Aggregate(
            default(decimal?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value > accumulate) ? value : accumulate;
            },
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<decimal?> Max<T>(this IPInvokeObservable<T> @this, Func<T, decimal?> func)
            => @this.Aggregate(
            default(decimal?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value > accumulate) ? value : accumulate;
            });

        public static IPInvokeQueryEndNode<int> Min(this IPInvokeObservable<int> @this)
            => @this.Aggregate(
            default(int?),
            (accumulate, v) => (v < accumulate) ? v : accumulate,
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<int?> Min(this IPInvokeObservable<int?> @this)
            => @this.Aggregate(
            default(int?),
            (accumulate, v) => (v < accumulate) ? v : accumulate);

        public static IPInvokeQueryEndNode<int> Min<T>(this IPInvokeObservable<T> @this, Func<T, int> func)
            => @this.Aggregate(
            default(int?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value < accumulate) ? value : accumulate;
            },
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<int?> Min<T>(this IPInvokeObservable<T> @this, Func<T, int?> func)
            => @this.Aggregate(
            default(int?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value < accumulate) ? value : accumulate;
            });

        public static IPInvokeQueryEndNode<long> Min(this IPInvokeObservable<long> @this)
            => @this.Aggregate(
            default(long?),
            (accumulate, v) => (v < accumulate) ? v : accumulate,
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<long?> Min(this IPInvokeObservable<long?> @this)
            => @this.Aggregate(
            default(long?),
            (accumulate, v) => (v < accumulate) ? v : accumulate);

        public static IPInvokeQueryEndNode<long> Min<T>(this IPInvokeObservable<T> @this, Func<T, long> func)
            => @this.Aggregate(
            default(long?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value < accumulate) ? value : accumulate;
            },
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<long?> Min<T>(this IPInvokeObservable<T> @this, Func<T, long?> func)
            => @this.Aggregate(
            default(long?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value < accumulate) ? value : accumulate;
            });

        public static IPInvokeQueryEndNode<float> Min(this IPInvokeObservable<float> @this)
            => @this.Aggregate(
            default(float?),
            (accumulate, v) => (v < accumulate) ? v : accumulate,
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<float?> Min(this IPInvokeObservable<float?> @this)
            => @this.Aggregate(
            default(float?),
            (accumulate, v) => (v < accumulate) ? v : accumulate);

        public static IPInvokeQueryEndNode<float> Min<T>(this IPInvokeObservable<T> @this, Func<T, float> func)
            => @this.Aggregate(
            default(float?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value < accumulate) ? value : accumulate;
            },
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<float?> Min<T>(this IPInvokeObservable<T> @this, Func<T, float?> func)
            => @this.Aggregate(
            default(float?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value < accumulate) ? value : accumulate;
            });

        public static IPInvokeQueryEndNode<double> Min(this IPInvokeObservable<double> @this)
            => @this.Aggregate(
            default(double?),
            (accumulate, v) => (v < accumulate) ? v : accumulate,
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<double?> Min(this IPInvokeObservable<double?> @this)
            => @this.Aggregate(
            default(double?),
            (accumulate, v) => (v < accumulate) ? v : accumulate);

        public static IPInvokeQueryEndNode<double> Min<T>(this IPInvokeObservable<T> @this, Func<T, double> func)
            => @this.Aggregate(
            default(double?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value < accumulate) ? value : accumulate;
            },
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<double?> Min<T>(this IPInvokeObservable<T> @this, Func<T, double?> func)
            => @this.Aggregate(
            default(double?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value < accumulate) ? value : accumulate;
            });

        public static IPInvokeQueryEndNode<decimal> Min(this IPInvokeObservable<decimal> @this)
            => @this.Aggregate(
            default(decimal?),
            (accumulate, v) => (v < accumulate) ? v : accumulate,
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<decimal?> Min(this IPInvokeObservable<decimal?> @this)
            => @this.Aggregate(
            default(decimal?),
            (accumulate, v) => (v < accumulate) ? v : accumulate);

        public static IPInvokeQueryEndNode<decimal> Min<T>(this IPInvokeObservable<T> @this, Func<T, decimal> func)
            => @this.Aggregate(
            default(decimal?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value < accumulate) ? value : accumulate;
            },
            accumulate => accumulate ?? throw new InvalidOperationException());

        public static IPInvokeQueryEndNode<decimal?> Min<T>(this IPInvokeObservable<T> @this, Func<T, decimal?> func)
            => @this.Aggregate(
            default(decimal?),
            (accumulate, v) =>
            {
                var value = func(v);
                return (value < accumulate) ? value : accumulate;
            });

    }
}