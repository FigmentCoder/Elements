using System.Threading.Tasks;

namespace Elements.Common.Constructors
{
    public static class TaskConstructor
    {
        public static TaskCompletionSource<T> TaskCompletionSource<T>() 
            => new();
    }
}