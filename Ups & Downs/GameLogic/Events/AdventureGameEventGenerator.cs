using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Events;

public class AdventureGameEventGenerator
{
	private static List<GameEvent>? _yellowEvents;

    public static GameEvent GetRandomYellowSpaceEvent()
    {
        List<GameEvent> yellowEvents = GenerateYellowSpaceEvents();
        return yellowEvents[new Random().Next(0, yellowEvents.Count)];
    }

    /// <summary>
    /// Generates a list of events that can occur when a player lands on a yellow (i.e. adventure) space.
    /// </summary>
    public static List<GameEvent> GenerateYellowSpaceEvents()
	{
		if (_yellowEvents is not null)
            return _yellowEvents;

        List<GameEvent> yellows = new()
		{
			new GameEvent
			{
				Description = "You zigged when you should've zagged and broke your leg in a freak snowboarding accident!",
				LifePointsChange = -20,
                CashMoneyChange = -5000,
                LuckyStarsChange = -1
            },
            new GameEvent
            {
                Description = "You were hit by a car while running in a marathon event! Fortunately, they have good insurance.",
                LifePointsChange = -30,
                CashMoneyChange = 100000
            },
            new GameEvent
            {
                Description = "While sky-diving your parachute failed to deploy, but you were able to land safely with your reserve chute!",
                LifePointsChange = 200,
                LuckyStarsChange = 2
            },
            new GameEvent
            {
                Description = "You set a new track record with the hot rod you've been building in your spare time!",
                LifePointsChange = 60,
                CashMoneyChange = 5000,
                LuckyStarsChange = 1
            },
            new GameEvent
            {
                Description = "You caught a record smallmouth bass in a fish competition!",
                LifePointsChange = 40,
                CashMoneyChange = 2000
            },
            new GameEvent
            {
                Description = "While deer hunting you accidently shoot an endangered animal, now you must pay the steep fine!",
                LifePointsChange = -20,
                CashMoneyChange = -50000,
                LuckyStarsChange = -1
            },
        };

		_yellowEvents = yellows;
        return _yellowEvents;
	}
}