using CleanArchitecture.Application.Interfaces;
using System;

namespace CleanArchitecture.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
