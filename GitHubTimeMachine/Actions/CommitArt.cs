using GitHubTimeMachine.Interfaces;
using GitHubTimeMachine.Services;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Actions
{
    internal sealed class CommitArt
    {
        private readonly IConfigReaderService configReader;
        private readonly IExcelReaderService excelReader;
        private readonly IDateTimeEnumeratorService dateTimeEnumerator;
        private readonly IProcessService processService;

        public CommitArt()
        {
            configReader = new ConfigReaderService();
            excelReader = new ExcelReaderService();
            dateTimeEnumerator = new DateTimeEnumeratorService();
            processService = new ProcessService();
        }

        public async Task ExecuteAsync()
        {
            var config = await configReader.GetConfigAsync();

            var sheet = excelReader.OpenSheet(config.ExcelPath, sheetNumber: 0);
            var matrix = excelReader.ParseSheet(sheet);
            var days = dateTimeEnumerator.GetDays(config.Year, matrix);

            await processService.ExecuteCommitsAsync(days, config.Year, config.RepositoryPath);
        }
    }
}
