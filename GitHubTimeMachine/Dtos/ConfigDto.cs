using GitHubTimeMachine.Dtos.CommitArtDtos;
using GitHubTimeMachine.Dtos.HistoryRandomizerDtos;

namespace GitHubTimeMachine.Dtos
{
    internal sealed class ConfigDto
    {
        public CommitArtDto CommitArt { get; set; }
        public HistoryRandomizerDto HistoryRandomizer { get; set; }
    }
}
