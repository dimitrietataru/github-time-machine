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
                            .Select(_ =>
                                {
                                    int hour = new Random().Next(0, 24);
                                    int minute = new Random().Next(0, 60);
                                    int second = new Random().Next(0, 60);

                                    return new DateTime(
                                        date.Year, date.Month, date.Day, hour, minute, second);
                                }));

                    date = date.AddDays(1);
                }
            }

            return result.Where(date => year.Equals(date.Year));
        }

        public IEnumerable<DateTime> GetDays(int year, int maxCommits)
        {
            throw new NotImplementedException();
        }
    }
}
