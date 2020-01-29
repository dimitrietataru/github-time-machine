using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubTimeMachine.Dtos.HistoryRandomizerDtos
{
    internal sealed class YearExceptionDto
    {
        public int Year { get; set; }
        public IEnumerable<DateTime> BankDays { get; set; }
        public IEnumerable<DateRangeDto> Vacations { get; set; } = new List<DateRangeDto>();

        public IEnumerable<DateTime> AggregateFreeDays()
        {
            return Vacations
                .SelectMany(vacation =>
                    {
                        return Enumerable
                            .Range(0, vacation.DaysCount)
                            .Select(dayOffset => vacation.StartDate.AddDays(dayOffset));
                    })
                .Concat(BankDays)
                .Where(day => day.Year.Equals(Year))
                .OrderBy(day => day)
                .ToList();
        }
    }
}
