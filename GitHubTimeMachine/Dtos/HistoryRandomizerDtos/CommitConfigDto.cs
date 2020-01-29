namespace GitHubTimeMachine.Dtos.HistoryRandomizerDtos
{
    internal sealed class CommitConfigDto
    {
        public double WeekendWeight { get; set; }
        public int MaxCommitsPerDay { get; set; }
    }
}
