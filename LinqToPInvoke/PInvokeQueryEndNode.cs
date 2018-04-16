using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PInvoke.Linq
{
    public class PInvokeQueryEndpoint<TIn> : IPinvokeObserver<TIn>, IPInvokeQueryEndNode
    {
        public PInvokeQueryEndpoint(Func<TIn, bool> onNext)
            => this.onNext = onNext ?? throw new ArgumentNullException(nameof(onNext));

        public PInvokeQueryEndpoint(Action<TIn> onNext)
        {
            if (onNext == null)
            {
                throw new ArgumentNullException(nameof(onNext));
            }
            this.onNext = (v) =>
            {
                onNext(v);
                return true;
            };
        }

        Func<TIn, bool> onNext;

        public bool OnNext(TIn value) => onNext(value);
    }

    public class PInvokeQueryEndpoint<TIn, TResult> : IPinvokeObserver<TIn>, IPInvokeQueryEndNode<TResult>
    {
        public PInvokeQueryEndpoint(Func<TIn, bool> onNext, Func<TResult> provideResult)
        {
            this.onNext = onNext ?? throw new ArgumentNullException(nameof(onNext));
            this.provideResult = provideResult ?? throw new ArgumentNullException(nameof(provideResult));
        }

        public PInvokeQueryEndpoint(Action<TIn> action, Func<TResult> provideResult)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            this.onNext = v =>
            {
                action(v);
                return true;
            };

            this.provideResult = provideResult ?? throw new ArgumentNullException(nameof(provideResult));
        }

        Func<TIn, bool> onNext;
        Func<TResult> provideResult;

        public bool OnNext(TIn value) => onNext(value);

        public TResult ProvideResult() => provideResult();
    }
}
