using System;

namespace GitHubTimeMachine.Extensions
{
    internal static class DateTimeExtension
    {
        public static DateTime WithRandomClock(this DateTime date)
        {
            int hour = new Random().Next(9, 18);
            int minute = new Random().Next(0, 60);
            int second = new Random().Next(0, 60);

            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
        }
    }
}
