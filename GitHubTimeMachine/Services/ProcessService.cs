using GitHubTimeMachine.Extensions;
using GitHubTimeMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Services
{
    internal sealed class ProcessService : IProcessService
    {
        private const string FILE_PATH_BASE = @"{0}/{1}.txt";
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
            fileService.Create(filePath);

            using var powerShell = PowerShell.Create();
            int progressCount = 1;

            foreach (var date in dates)
            {
                await fileService.AppendAsync(filePath, date.ToString());

                await powerShell
                    .AddCommands(
                        gitCommand.CommitterDate(date),
                        gitCommand.ChangeDir(repositoryPath),
                        gitCommand.Checkout("master"),
                        gitCommand.Add(),
                        gitCommand.Commit(date))
                    .ThenInvokeAndClearCommandsAsync();

                Console.WriteLine($"Processed { progressCount++ } / { dates.Count() } commits");
            }

            await powerShell
                .AddCommands(gitCommand.Push())
                .ThenInvokeAndClearCommandsAsync();
        }
    }
}
