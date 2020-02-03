using GitHubTimeMachine.Interfaces;
using GitHubTimeMachine.Services;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Actions
{
    internal sealed class HistoryRandomizer
    {
        private readonly IConfigurationService configurationService;
        private readonly IDateTimeEnumeratorService dateTimeEnumerator;
        private readonly IProcessService processService;

        public HistoryRandomizer()
        {
            configurationService = new ConfigurationService();
            dateTimeEnumerator = new DateTimeEnumeratorService();
            processService = new ProcessService();
        }

        public async Task RunAsync()
        {
            var config = await configurationService.ReadConfigAsync();
            if (!config.HistoryRandomizer.ShouldRun())
            {
                return;
            }

            var freeDays = config.HistoryRandomizer.GetFreeDays();
            var commitDates = dateTimeEnumerator.GetDays(
                year: config.HistoryRandomizer.Year,
                maxCommitsPerDay: config.HistoryRandomizer.CommitConfig.MaxCommitsPerDay,
                weekendWeight: config.HistoryRandomizer.CommitConfig.WeekendWeight,
                exceptions: freeDays);

            await processService.ExecuteCommitsAsync(
                commitDates, config.HistoryRandomizer.Year, config.HistoryRandomizer.RepositoryPath);
        }
    }
}
