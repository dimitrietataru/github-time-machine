using System.Management.Automation;
using System.Threading.Tasks;

namespace GitHubTimeMachine.Extensions
{
    internal static class PowerShellExtension
    {
        public static PowerShell AddCommands(this PowerShell powerShell, params string[] commands)
        {
            foreach (string command in commands)
            {
                powerShell.AddScript(command);
            }

            return powerShell;
        }

        public static async Task<PowerShell> ThenInvokeAndClearCommandsAsync(this PowerShell powerShell)
        {
            _ = await powerShell.InvokeAsync();
            powerShell.Commands.Clear();

            return powerShell;
        }
    }
}
