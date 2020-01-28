using System.Data;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IExcelService
    {
        DataTable ReadSheet(string excelFilePath, int sheetNumber = 0);
        int[][] ParseSheet(DataTable dataTable);
    }
}
