using System.Threading.Tasks;
using static Elements.Persistence.DisclaimerRepository;

namespace Elements.Services
{
    internal static class Disclaimer
    {
        public static async Task Display()
        {
            var disclaimer =
                await Get();
            if (disclaimer.HasNotDisplayed)
            {
                await Alert.Display(disclaimer.Message);
                await Update(disclaimer.With(true));
            }
        }
    }
}