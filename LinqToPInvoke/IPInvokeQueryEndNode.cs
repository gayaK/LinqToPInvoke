using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PInvoke.Linq
{
    public interface IPInvokeQueryEndNode
    {
    }

    public interface IPInvokeQueryEndNode<out T> : IPInvokeQueryEndNode
    {
        T ProvideResult();
    }
}
