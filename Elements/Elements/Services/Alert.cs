using System.Threading.Tasks;
using Acr.UserDialogs;
using Elements.Common.Types;

namespace Elements.Services
{
    public static class Alert
    {
        public static async Task Display(
            string message)
            => await Display("Alert", message);

        public static async Task Display(
            Result result)
            => await Display(result.Value);

        private static async Task Display(
            string title,
            string message)
        {
            var config =
                new AlertConfig
                {
                    Title = title,
                    Message = message,
                    OkText = "OK",
                };

            await UserDialogs.Instance.AlertAsync(config);
        }
    }
}