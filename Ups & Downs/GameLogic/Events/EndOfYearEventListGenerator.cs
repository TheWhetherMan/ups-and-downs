using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Events;

public class EndOfYearEventListGenerator
{
	public static List<EndOfYearEvent> GenerateEndOfYearEventList()
	{
		List<EndOfYearEvent> endOfYearEvents =
        [
            new EndOfYearEvent
            {
                Title = "Party Pinata!",
                EndOfEventType = EndOfYearEvents.PartyPinata
            },
            new EndOfYearEvent
            {
                Title = "Dark Curse!",
                EndOfEventType = EndOfYearEvents.DarkCurse
            },
            new EndOfYearEvent
            {
                Title = "Lucky Break!",
                EndOfEventType = EndOfYearEvents.LuckyBreak
            },
            new EndOfYearEvent
            {
                Title = "Back To Start!",
                EndOfEventType = EndOfYearEvents.BackToStart
            },
        ];

		return endOfYearEvents;
	}
}