using Microsoft.Extensions.DependencyInjection;

namespace WPF_Test_PilotBrothersSafe.ViewModels
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection AddViews(this IServiceCollection services) => services
           .AddSingleton<MainWindowViewModel>()
        ;
    }
}