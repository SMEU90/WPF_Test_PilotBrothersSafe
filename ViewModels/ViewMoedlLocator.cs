using Microsoft.Extensions.DependencyInjection;

namespace WPF_Test_PilotBrothersSafe.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
