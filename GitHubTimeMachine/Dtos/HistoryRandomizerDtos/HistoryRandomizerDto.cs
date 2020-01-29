using GitHubTimeMachine.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitHubTimeMachine.Dtos.HistoryRandomizerDtos
{
    internal sealed class HistoryRandomizerDto
    {
        public bool Enabled { private get; set; }
        public int Year { get; set; }
        public string RepositoryPath { get; set; }

        public IEnumerable<YearExceptionDto> Exceptions { get; set; } = new List<YearExceptionDto>();
        public CommitConfigDto CommitConfig { get; set; }

        public bool ShouldRun()
        {
            if (!Enabled)
            {
                Console.WriteLine("History randomizer | Status: OFF");

                return false;
            }

            if (!IsValid())
            {
                return false;
            }

            return true;
        }

        private bool IsValid()
        {
            if (Year < 2006)
            {
                Console.WriteLine($"History randomizer | Invalid year ({ Year })");

                return false;
            }

            if (!CommitConfig.WeekendWeight.IsInInterval(leftBound: 0.0D, rightBound: 1.0D))
            {
                Console.WriteLine($"History randomizer | Invalid weekend weight: { CommitConfig.WeekendWeight }");

                return false;
            }

            if (!CommitConfig.MaxCommitsPerDay.IsInInterval(leftBound: 0))
            {
                Console.WriteLine($"History randomizer | Invalid weekend weight: { CommitConfig.WeekendWeight }");

                return false;
            }

            if (!Directory.Exists(RepositoryPath))
            {
                Console.WriteLine($"History randomizer | Invalid repository path");

                return false;
            }

            return true;
        }

        public IEnumerable<DateTime> GetFreeDays()
        {
            return Exceptions
                .FirstOrDefault(exception => exception.Year.Equals(Year))
                .AggregateFreeDays();
        }
    }
}
