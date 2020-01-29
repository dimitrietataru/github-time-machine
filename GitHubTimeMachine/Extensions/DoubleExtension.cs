using System;

namespace GitHubTimeMachine.Extensions
{
    internal static class DoubleExtension
    {
        public static bool IsInInterval(
            this double value, double leftBound = double.MinValue, double rightBound = double.MaxValue)
        {
            return (value >= leftBound) && (value <= rightBound);
        }

        public static bool FavorsWeekendCommits(this double value)
        {
            var rng = new Random().NextDouble();

            return value > rng;
        }
    }
}
