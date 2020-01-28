namespace GitHubTimeMachine.Dtos
{
    internal sealed class CommitArtDto
    {
        public bool Enabled { private get; set; }
        public int Year { get; set; }
        public string RepositoryPath { get; set; }
        public string ExcelPath { get; set; }
        public int SheetNumber { get; set; } = 0;

        public bool ShouldRun()
        {
            return Enabled && IsValid();
        }

        private bool IsValid()
        {
            return Year >= 2006
                && !string.IsNullOrWhiteSpace(RepositoryPath)
                && !string.IsNullOrWhiteSpace(ExcelPath);
        }
    }
}
