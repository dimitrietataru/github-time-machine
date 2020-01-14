using System.Threading.Tasks;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IFileService
    {
        void Create(string filePath);
        Task AppendAsync(string filePath, string content);
        void Delete(string filePath);
    }
}
