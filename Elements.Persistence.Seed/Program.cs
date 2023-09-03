using System.Threading.Tasks;

namespace Elements.Persistence.Seed
{
    internal class Program
    {
        private static async Task Main()
        {
            await Content.Add();
        }
    }
}