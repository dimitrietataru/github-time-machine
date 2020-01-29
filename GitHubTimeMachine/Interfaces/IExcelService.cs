using GitHubTimeMachine.Dtos.CommitArtDtos;
using System.Data;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IExcelService
    {
        DataTable ReadSheet(ExcelConfigDto config);
        int[][] ParseSheet(DataTable dataTable);
    }
}
