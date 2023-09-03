using System.Threading;
using System.Threading.Tasks;

namespace Elements.Common.Extensions
{
    public static class Threading
    {
        /// <summary>
        /// Suspends the current thread in seconds 
        /// </summary>
        /// <param name="value"></param>
        public static void Sleep(int value)
            => Thread.Sleep(value * 1000);

        public static Task SleepOne()
            => Task.Run(() => Sleep(1));
    }
}