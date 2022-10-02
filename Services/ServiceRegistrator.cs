using Microsoft.Extensions.DependencyInjection;
using WPF_Test_PilotBrothersSafe.Services.Interfaces;

namespace WPF_Test_PilotBrothersSafe.Services
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
           .AddTransient<IDataService, DataService>()
           .AddTransient<IUserDialog, UserDialog>()
        ;
    }
}
