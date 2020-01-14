using System;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IGitCommandBuilder
    {
        string CommitterDate(DateTime date);
        string ChangeDir(string path);
        string Checkout(string branchName);
        string Add();
        string Commit(DateTime date);
        string Push(string branchName = "master");
    }
}
