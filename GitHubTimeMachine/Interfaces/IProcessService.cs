using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IProcessService
    {
        Task ExecuteCommitsAsync(IEnumerable<KeyValuePair<string, string>> commits, int year, string repositoryPath);
    }
}
