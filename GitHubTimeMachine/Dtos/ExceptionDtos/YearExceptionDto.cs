using System;
using System.Collections.Generic;

namespace GitHubTimeMachine.Dtos.ExceptionDtos
{
    internal sealed class YearExceptionDto
    {
        public int Year { get; set; }
        public IEnumerable<DateTime> BankDays { get; set; }
        public IEnumerable<DateRangeDto> Vacations { get; set; } = new List<DateRangeDto>();
    }
}
