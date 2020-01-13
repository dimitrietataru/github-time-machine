using System.Data;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IExcelReaderService
    {
        DataTable OpenSheet(string filePath, int sheetNumber = 0);
        int[][] ParseSheet(DataTable dataTable);
    }
}
