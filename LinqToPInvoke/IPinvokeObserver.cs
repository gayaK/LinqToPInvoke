using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PInvoke.Linq
{
    public interface IPinvokeObserver<in T>
    {
        bool OnNext(T value);
    }
}
