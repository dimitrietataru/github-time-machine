using GitHubTimeMachine.Interfaces;
using GitHubTimeMachine.Services;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Actions
{
    internal sealed class HistoryRandomizer
    {
        private readonly IConfigurationService configurationService;

        public HistoryRandomizer()
        {
            configurationService = new ConfigurationService();
        }

        public async Task RunAsync()
        {
            var config = await configurationService.ReadConfigAsync();
            if (!config.HistoryRandomizer.ShouldRun())
            {
                return;
            }
        }
    }
}
