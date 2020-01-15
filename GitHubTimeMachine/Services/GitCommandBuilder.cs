using GitHubTimeMachine.Interfaces;
using System;

namespace GitHubTimeMachine.Services
{
    internal sealed class GitCommandBuilder : IGitCommandBuilder
    {
        private const string DATE_TIME_FORMAT = "ddd, MMM dd HH:mm yyyy +0200";

        public string CommitterDate(DateTime date)
        {
            return $"$env:GIT_COMMITTER_DATE = '{ date.ToString(DATE_TIME_FORMAT) }'";
        }

        public string ChangeDir(string path)
        {
            return $"cd \"{ path }\"";
        }

        public string Checkout(string branchName)
        {
            return $"git checkout -b { branchName }";
        }

        public string Add()
        {
            return "git add *";
        }

        public string Commit(DateTime date)
        {
            string formattedDate = date.ToString(DATE_TIME_FORMAT);

            return $"git commit -m \"{ formattedDate }\" --date=\"{ formattedDate }\"";
        }

        public string Push(string branchName = "master")
        {
            return $"git push --force origin { branchName }";
        }
    }
}
