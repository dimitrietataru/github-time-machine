using GitHubTimeMachine.Dtos;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IConfigurationService
    {
        Task<ConfigDto> ReadConfigAsync();
    }
}
