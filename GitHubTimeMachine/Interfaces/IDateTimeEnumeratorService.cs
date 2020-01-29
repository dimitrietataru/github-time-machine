using System;
using System.Collections.Generic;

namespace GitHubTimeMachine.Interfaces
{
    internal interface IDateTimeEnumeratorService
    {
        IEnumerable<DateTime> GetDays(int year, int[][] matrix);
        IEnumerable<DateTime> GetDays(int year, int maxCommitsPerDay, double weekendWeight, IEnumerable<DateTime> exceptions);
    }
}
