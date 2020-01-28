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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            await commitArt.ExecuteAsync();
            await historyRandomizer.ExecuteAsync();
        }
    }
}
