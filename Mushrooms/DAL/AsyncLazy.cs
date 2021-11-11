using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Mushrooms.Data
{
  public class AsyncLazy<T>
  {
    readonly Lazy<Task<T>> _instance;

    public AsyncLazy(Func<T> factory)
    {
      _instance = new Lazy<Task<T>>(() => Task.Run(factory));
    }

    public AsyncLazy(Func<Task<T>> factory)
    {
      _instance = new Lazy<Task<T>>(() => Task.Run(factory));
    }

    public TaskAwaiter<T> GetAwaiter()
    {
      return _instance.Value.GetAwaiter();
    }

    public void Start()
    {
      var unused = _instance.Value;
    }
  }
}
