using System;
using System.Collections.Generic;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IGitCommandBuilder
    {
        string Add();
        IEnumerable<string> Commits(IEnumerable<DateTime> dates);
        string Push(string branchName = "master");
    }
}
