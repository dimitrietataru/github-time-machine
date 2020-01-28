using GitHubTimeMachine.Interfaces;
using GitHubTimeMachine.Services;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Actions
{
    internal sealed class CommitArt
    {
        private readonly IConfigurationService configurationService;
        private readonly IExcelReaderService excelReader;
        private readonly IDateTimeEnumeratorService dateTimeEnumerator;
        private readonly IProcessService processService;

        public CommitArt()
        {
            configurationService = new ConfigurationService();
            excelReader = new ExcelReaderService();
            dateTimeEnumerator = new DateTimeEnumeratorService();
            processService = new ProcessService();
        }

        public async Task RunAsync()
        {
            var config = await configurationService.ReadConfigAsync();
            if (!config.CommitArt.ShouldRun())
            {
                return;
            }

            var sheet = excelReader.OpenSheet(config.CommitArt.ExcelPath, sheetNumber: 0);
            var matrix = excelReader.ParseSheet(sheet);
            var days = dateTimeEnumerator.GetDays(config.CommitArt.Year, matrix);

            await processService.ExecuteCommitsAsync(days, config.CommitArt.Year, config.CommitArt.RepositoryPath);
        }
    }
}
