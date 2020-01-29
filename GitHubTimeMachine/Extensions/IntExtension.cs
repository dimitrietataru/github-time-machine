namespace GitHubTimeMachine.Extensions
{
    internal static class IntExtension
    {
        public static bool IsInInterval(this int value, int leftBound = int.MinValue, int rightBound = int.MaxValue)
        {
            return (value >= leftBound) && (value <= rightBound);
        }
    }
}
