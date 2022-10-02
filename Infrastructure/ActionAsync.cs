using System.Threading.Tasks;

namespace WPF_Test_PilotBrothersSafe.Infrastructure
{
    internal delegate Task ActionAsync();

    internal delegate Task ActionAsync<in T>(T parameter);
}
