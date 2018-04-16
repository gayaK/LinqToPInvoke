using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PInvoke.Linq
{
    public class PInvokeQueryStartNode<T> : IPinvokeObserver<T>, IPInvokeObservable<T>
    {
        private IPinvokeObserver<T> observer;

        public bool OnNext(T value)
            => observer?.OnNext(value) ?? false;

        public void Subscribe(IPinvokeObserver<T> observer)
            => this.observer = observer;
    }
}
