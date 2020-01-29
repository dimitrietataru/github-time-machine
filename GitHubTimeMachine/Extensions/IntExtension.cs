using System;

namespace GitHubTimeMachine.Extensions
{
    internal static class IntExtension
    {
        public static bool IsInInterval(
            this int value, int leftBound = int.MinValue, int rightBound = int.MaxValue)
        {
            return (value >= leftBound) && (value <= rightBound);
        }

        public static int TotalDays(this int year)
        {
            return (int)new DateTime(year + 1, 1, 1).Subtract(new DateTime(year, 1, 1)).TotalDays;
        }
    }
}
