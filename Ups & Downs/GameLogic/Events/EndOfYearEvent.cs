using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Events;

public record EndOfYearEvent
{
    public string Title { get; init; } = string.Empty;
    public EndOfYearEvents EndOfEventType { get; init; }
}