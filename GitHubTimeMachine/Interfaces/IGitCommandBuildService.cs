using System;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IGitCommandBuildService
    {
        string Add();
        string Commit(DateTime date);
        string Push();
        string CreateTag();
        string DeleteTag();
    }
}
