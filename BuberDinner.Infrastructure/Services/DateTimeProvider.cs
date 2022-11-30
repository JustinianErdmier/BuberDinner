using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc />
    public DateTimeOffset Now => DateTimeOffset.UtcNow;
}
