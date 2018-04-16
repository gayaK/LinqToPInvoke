# LinqToPInvoke
This library enables LINQ query in P/Invoke methods which are using callbacks (e.g. [EnumWindos](https://www.pinvoke.net/default.aspx/user32/EnumWindows.html)).

# Example
## Define
```csharp
delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

[DllImport("user32.dll")]
[return: MarshalAs(UnmanagedType.Bool)]
static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

static void EnumWindows(Func<IPInvokeObservable<IntPtr>, IPInvokeQueryEndNode> query)
{
    var startNode = new PInvokeQueryStartNode<IntPtr>();
    var endNode = query(startNode);
    EnumWindows((hwnd, _) => startNode.OnNext(hwnd), IntPtr.Zero);
}

static T EnumWindows<T>(Func<IPInvokeObservable<IntPtr>, IPInvokeQueryEndNode<T>> query)
{
    var startNode = new PInvokeQueryStartNode<IntPtr>();
    var endNode = query(startNode);
    EnumWindows((hwnd, _) => startNode.OnNext(hwnd), IntPtr.Zero);

    return endNode.ProvideResult();
}
```
## Usage
```csharp
// method chain + ToList()
var list = EnumWindows(x => x
    .Where(y => IsWindowVisible(y))
    .Select(y => y.ToInt32().ToString("X8"))
    .Take(10)
    .ToList());

// query syntax + ForEach()
EnumWindows(x => (from y in x
                  where IsWindowVisible(y)
                  select y.ToInt32().ToString("X8"))
                  .Take(10)
                  .ForEach(y => list.Add(y)));
```