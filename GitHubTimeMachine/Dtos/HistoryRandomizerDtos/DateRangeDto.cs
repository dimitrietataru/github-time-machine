using System;

namespace GitHubTimeMachine.Dtos.HistoryRandomizerDtos
{
    internal sealed class DateRangeDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int DaysCount => (EndDate.DayOfYear - StartDate.DayOfYear) + 1;
    }
}
