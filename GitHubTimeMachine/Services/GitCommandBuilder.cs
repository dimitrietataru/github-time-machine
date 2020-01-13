using GitHubTimeMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubTimeMachine.Services
{
    internal sealed class GitCommandBuilder : IGitCommandBuilder
    {
        public string Add()
        {
            return "git add .";
        }

        public IEnumerable<string> Commits(IEnumerable<DateTime> dates)
        {
            return dates
                .Select(date =>
                    {
                        string formattedDate = date.ToString("ddd, MMM dd HH:mm yyyy +0200");

                        return $"GIT_COMMITTER_DATE=\"{ formattedDate }\" git commit -m \"{ formattedDate }\" --date=\"{ formattedDate }\"";
                    });
        }

        public string Push(string branchName = "master")
        {
            return $"git push origin { branchName }";
        }
    }
}
