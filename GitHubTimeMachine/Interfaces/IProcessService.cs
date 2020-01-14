using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IProcessService
    {
        Task ExecuteCommitsAsync(IEnumerable<DateTime> dates, int year, string repositoryPath);
    }
}
