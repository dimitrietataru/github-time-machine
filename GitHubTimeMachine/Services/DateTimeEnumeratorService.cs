using GitHubTimeMachine.Extensions;
using GitHubTimeMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubTimeMachine.Services
{
    internal sealed class DateTimeEnumeratorService : IDateTimeEnumeratorService
    {
        public IEnumerable<DateTime> GetDays(int year, int[][] matrix)
        {
            var result = new List<DateTime>();
            var date = new DateTime(year, 1, 1);

            for (int column = 0; column < matrix[0].Length; ++column)
            {
                for (int row = 0; row < matrix.Length; ++row)
                {
                    if (date.Year > year)
                    {
                        break;
                    }

                    int commitCount = matrix[row][column];

                    if (commitCount.Equals(-1))
                    {
                        continue;
                    }

                    if (commitCount.Equals(0))
                    {
                        date = date.AddDays(1);

                        continue;
                    }

                    result.AddRange(
                        Enumerable
                            .Range(0, commitCount)
                            .Select(_ => date.WithRandomClock()));

                    date = date.AddDays(1);
                }
            }

            return result.Where(date => year.Equals(date.Year));
        }

        public IEnumerable<DateTime> GetDays(int year, int maxCommitsPerDay, double weekendWeight, IEnumerable<DateTime> exceptions)
        {
            var totalDays = year.TotalDays();

            return Enumerable
                .Range(0, year.TotalDays())
                .Select(offset => new DateTime(year, 1, 1).AddDays(offset))
                .Where(date => !exceptions.Contains(date))
                .SelectMany(date =>
                    {
                        int commitCount = new Random().Next(0, maxCommitsPerDay + 1);
                        if (date.IsWeekend())
                        {
                            commitCount = weekendWeight.FavorsWeekendCommits()
                                ? (int)Math.Ceiling(commitCount / 2.0D)
                                : 0;
                        }

                        return Enumerable
                            .Range(0, commitCount)
                            .Select(_ => date.WithRandomClock());
                    })
                .ToList();
        }
    }
}
