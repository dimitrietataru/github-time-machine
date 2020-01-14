using GitHubTimeMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Services
{
    internal sealed class ProcessService : IProcessService
    {
        private const string FILE_PATH_BASE = "{0}/{1}.txt";
        private readonly IFileService fileService;
        private readonly IGitCommandBuilder gitCommand;

        public ProcessService()
        {
            fileService = new FileService();
            gitCommand = new GitCommandBuilder();
        }

        public async Task ExecuteCommitsAsync(IEnumerable<DateTime> dates, int year, string repositoryPath)
        {
            string filePath = string.Format(FILE_PATH_BASE, repositoryPath, year);
            fileService.Create($"{ repositoryPath }/{ year }.txt");

            using var powerShell = PowerShell.Create();

            foreach (var date in dates)
            {
                await fileService.AppendAsync(filePath, date.ToString());

                powerShell.AddScript(gitCommand.CommitterDate(date));
                powerShell.AddScript(gitCommand.ChangeDir(repositoryPath));
                powerShell.AddScript(gitCommand.Checkout("master"));
                powerShell.AddScript(gitCommand.Add());
                powerShell.AddScript(gitCommand.Commit(date));

                _ = await powerShell.InvokeAsync();
                powerShell.Commands.Clear();
            }

            powerShell.AddScript(gitCommand.Push());

            _ = await powerShell.InvokeAsync();
            powerShell.Commands.Clear();

            powerShell.Dispose();
        }
    }
}
