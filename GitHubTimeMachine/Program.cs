using GitHubTimeMachine.Actions;
using System.Text;
using System.Threading.Tasks;

namespace GitHubTimeMachine
{
    public class Program
    {
        private static readonly CommitArt commitArt = new CommitArt();
        private static readonly HistoryRandomizer historyRandomizer = new HistoryRandomizer();

        static async Task Main(string[] _)
        {
            Encoding.RegisterProvider(provider: CodePagesEncodingProvider.Instance);

            await commitArt.RunAsync().ConfigureAwait(continueOnCapturedContext: false);
            await historyRandomizer.RunAsync().ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
