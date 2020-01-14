using GitHubTimeMachine.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Services
{
    internal sealed class FileService : IFileService
    {
        public void Create(string filePath)
        {
            if (File.Exists(filePath))
            {
                return;
            }

            using var stream = File.CreateText(filePath);
            stream.Close();
        }

        public async Task AppendAsync(string filePath, string content)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            using var stream = File.AppendText(filePath);
            await stream.WriteLineAsync(content);

            stream.Close();
        }

        public void Delete(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            File.Delete(filePath);
        }
    }
}
