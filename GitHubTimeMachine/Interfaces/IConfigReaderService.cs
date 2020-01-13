using GitHubTimeMachine.Dtos;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IConfigReaderService
    {
        Task<ConfigDto> GetConfigAsync();
    }
}
