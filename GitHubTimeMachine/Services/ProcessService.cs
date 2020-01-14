using GitHubTimeMachine.Interfaces;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Services
{
    internal sealed class ProcessService : IProcessService
    {
        private const string FILE_PATH_BASE = "{0}/{1}.txt";
        private const string POWERSHELL_ENV_BASE = "$env:GIT_COMMITTER_DATE = '{0}'";
        private readonly IFileService fileService;
        private readonly IGitCommandBuilder gitCommand;

        public ProcessService()
        {
            fileService = new FileService();
            gitCommand = new GitCommandBuilder();
        }

        public async Task ExecuteCommitsAsync(IEnumerable<KeyValuePair<string, string>> commits, int year, string repositoryPath)
        {
            using var powerShell = PowerShell.Create();

            string filePath = string.Format(FILE_PATH_BASE, repositoryPath, year);
            fileService.Create($"{ repositoryPath }/{ year }.txt");

            foreach (var commit in commits)
            {
                await fileService.AppendAsync(filePath, commit.Value);

                string envCommitterDate = string.Format(POWERSHELL_ENV_BASE, commit.Key);
                powerShell.AddScript(envCommitterDate);

                powerShell.AddScript(gitCommand.ChangeDir(repositoryPath));
                powerShell.AddScript(gitCommand.Add());
                powerShell.AddScript(commit.Value);

                _ = await powerShell.InvokeAsync();
                powerShell.Commands.Clear();
            }

            powerShell.Dispose();
        }
    }
}
