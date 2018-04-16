using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PInvoke.Linq
{
    public class PInvokeQuery<TIn, TOut> : IPinvokeObserver<TIn>, IPInvokeObservable<TOut>
    {
        public PInvokeQuery(Func<IPinvokeObserver<TOut>, TIn, bool> onNext)
            => this.onNext = onNext ?? throw new ArgumentNullException(nameof(onNext));

        public PInvokeQuery(Action<IPinvokeObserver<TOut>, TIn> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            this.onNext = (v, s) =>
            {
                action(v, s);
                return true;
            };
        }

        private readonly Func<IPinvokeObserver<TOut>, TIn, bool> onNext;
        private IPinvokeObserver<TOut> observer;

        public bool OnNext(TIn value)
        {
            if (observer == null)
            {
                return false;
            }
            return onNext(observer, value);
        }

        public void Subscribe(IPinvokeObserver<TOut> observer)
            => this.observer = observer;
    }
}
