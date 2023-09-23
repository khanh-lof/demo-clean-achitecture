using CabinetManagement.Application.Common.Interfaces;

namespace CabinetManagement.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
