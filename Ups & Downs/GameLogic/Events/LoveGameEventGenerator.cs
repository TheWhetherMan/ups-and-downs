using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Events;

public class LoveGameEventGenerator
{
	private static List<GameEvent>? _PinkEvents;

    public static GameEvent GetRandomPinkSpaceEvent()
    {
        List<GameEvent> PinkEvents = GeneratePinkSpaceEvents();
        return PinkEvents[new Random().Next(0, PinkEvents.Count)];
    }

    /// <summary>
    /// Generates a list of events that can occur when a player lands on a Pink (i.e. family & friends) space.
    /// </summary>
    public static List<GameEvent> GeneratePinkSpaceEvents()
	{
		if (_PinkEvents is not null)
            return _PinkEvents;

        List<GameEvent> pinks = new()
		{
			new GameEvent
			{
				Description = "Your sibling told on you.",
				LifePointsChange = -10
			},
			new GameEvent
			{
				Description = "It's allowance day!",
				CashMoneyChange = 100
			},
            new GameEvent
            {
                Description = "Your surprise Mother's Day gift was appreciated!",
                LifePointsChange = 30
            },
            new GameEvent
            {
                Description = "Your surprise Father's Day gift was appreciated!",
                LifePointsChange = 30
            },
            new GameEvent
            {
                Description = "You forgot about Valentine's Day!",
                LifePointsChange = -40
            },
            new GameEvent
            {
                Description = "You forgot about your significant other's birthday!",
                LifePointsChange = -80
            },
            new GameEvent
            {
                Description = "You forgot about your anniversary with your significant other!",
                LifePointsChange = -120
            },
            new GameEvent
            {
                Description = "Your thoughtful birthday present for your signifant other was well-received!",
                LifePointsChange = 60
            },
            new GameEvent
            {
                Description = "While trying to surprise your significant other with breakfast in bed, you accidently put a spoon in the microwave and made it explode!",
                LifePointsChange = -5,
                CashMoneyChange = -100
            },
        };

		_PinkEvents = pinks;
        return _PinkEvents;
	}
}