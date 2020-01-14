using System;
using System.Collections.Generic;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IGitCommandBuilder
    {
        string ChangeDir(string path);
        string Add();
        IEnumerable<KeyValuePair<string, string>> Commits(IEnumerable<DateTime> dates);
        string Push(string branchName = "master");
    }
}
