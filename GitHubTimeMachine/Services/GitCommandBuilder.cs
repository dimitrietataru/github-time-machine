using GitHubTimeMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubTimeMachine.Services
{
    internal sealed class GitCommandBuilder : IGitCommandBuilder
    {
        public string ChangeDir(string path)
        {
            return $"cd \"{ path }\"";
        }

        public string Add()
        {
            return "git add *";
        }

        public IEnumerable<KeyValuePair<string, string>> Commits(IEnumerable<DateTime> dates)
        {
            return dates
                .Select(date =>
                    {
                        string formattedDate = date.ToString("ddd, MMM dd HH:mm yyyy +0200");

                        return new KeyValuePair<string, string>(
                            key: formattedDate,
                            value: $"git commit -m \"{ formattedDate }\" --date=\"{ formattedDate }\"");
                    });
        }

        public string Push(string branchName = "master")
        {
            return $"git push origin { branchName }";
        }
    }
}
