using System.Threading.Tasks;

namespace Elements.Services
{
    internal static class Content
    {
        public static async Task Update()
            => await Persistence.Content.Update();
    }
}