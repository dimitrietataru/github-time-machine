using GitHubTimeMachine.Interfaces;
using GitHubTimeMachine.Services;

namespace GitHubTimeMachine.Actions
{
    internal sealed class CommitArt
    {
        private const string PATH = @"C:\Users\Myt\Desktop\Template.xlsx";
        private readonly IExcelReaderService excelReader;

        public CommitArt()
        {
            excelReader = new ExcelReader();
        }

        public void Execute()
        {
            var sheet = excelReader.OpenSheet(PATH, sheetNumber: 0);
            var matrix = excelReader.ParseSheet(sheet);
        }
    }
}
