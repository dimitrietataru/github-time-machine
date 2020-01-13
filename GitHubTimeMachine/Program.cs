using GitHubTimeMachine.Actions;
using System;
using System.Text;
using System.Threading.Tasks;

namespace GitHubTimeMachine
{
    public class Program
    {
        private static readonly CommitArt commitArt = new CommitArt();

        static async Task Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            commitArt.Execute();
        }
    }
}
