using GitHubTimeMachine.Interfaces;
using GitHubTimeMachine.Services;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Actions
{
    internal sealed class HistoryRandomizer
    {
        private readonly IConfigReaderService configReader;

        public HistoryRandomizer()
        {
            configReader = new ConfigReaderService();
        }

        public async Task ExecuteAsync()
        {
            var config = await configReader.GetConfigAsync();
            if (!config.HistoryRandomizer.ShouldRun())
            {
                return;
            }
        }
    }
}
