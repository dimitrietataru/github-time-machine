using GitHubTimeMachine.Dtos.ExceptionDtos;
using GitHubTimeMachine.Extensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace GitHubTimeMachine.Dtos
{
    internal sealed class HistoryRandomizerDto
    {
        public bool Enabled { private get; set; }
        public int Year { get; set; }
        public string RepositoryPath { get; set; }

        public int WeekendWeight { get; set; }
        public int MaxCommitsPerDay { get; set; }

        public IEnumerable<YearExceptionDto> Exceptions { get; set; } = new List<YearExceptionDto>();

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

            if (!WeekendWeight.IsInInterval(leftBound: 0, rightBound: 100))
            {
                Console.WriteLine($"History randomizer | Invalid weekend weight ({ WeekendWeight })");

                return false;
            }

            if (!MaxCommitsPerDay.IsInInterval(leftBound: 0))
            {
                Console.WriteLine($"History randomizer | Invalid weekend weight ({ WeekendWeight })");

                return false;
            }

            if (!Directory.Exists(RepositoryPath))
            {
                Console.WriteLine($"History randomizer | Invalid repository path");

                return false;
            }

            return true;
        }
    }
}
