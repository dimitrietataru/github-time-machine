namespace GitHubTimeMachine.Interfaces
{
    internal interface IFileService
    {
        void Create(string filePath);
        void Update(string filePath);
        void Delete(string filePath);
    }
}
