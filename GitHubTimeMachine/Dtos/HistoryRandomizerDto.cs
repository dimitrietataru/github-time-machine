using System;
using System.Collections.Generic;

namespace GitHubTimeMachine.Dtos
{
    internal sealed class HistoryRandomizerDto
    {
        public bool Enabled { private get; set; }
        public int Year { get; set; }
        public string RepositoryPath { get; set; }
        public IEnumerable<DateTime> Exceptions { get; set; } = new List<DateTime>();

        public bool ShouldRun()
        {
            return Enabled && IsValid();
        }

        private bool IsValid()
        {
            return Year >= 2000 && !string.IsNullOrWhiteSpace(RepositoryPath);
        }
    }
}
