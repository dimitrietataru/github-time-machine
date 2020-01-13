namespace GitHubTimeMachine.Interfaces
{
    internal interface IExcelReaderService
    {
        object Parse(string filePath);
        object Parse(string filePath, int sheetNumber);
    }
}
