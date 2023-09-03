using System.Threading.Tasks;

namespace Elements.Persistence.Runner
{
    internal class Program
    {
        private static async Task Main()
        {
            await Content.Add();
        }
    }
}