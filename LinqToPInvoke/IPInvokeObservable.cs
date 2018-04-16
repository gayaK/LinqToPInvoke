using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PInvoke.Linq
{
    public interface IPInvokeObservable<out T>
    {
        void Subscribe(IPinvokeObserver<T> observer);
    }
}
