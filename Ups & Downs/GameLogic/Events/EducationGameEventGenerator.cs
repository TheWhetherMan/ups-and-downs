using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Events;

public class EducationGameEventGenerator
{
	private static List<GameEvent>? _greenEvents;

	public static GameEvent GetRandomGreenSpaceEvent()
	{
        List<GameEvent> greenEvents = GenerateGreenSpaceEvents();
        return greenEvents[new Random().Next(0, greenEvents.Count)];
    }

    /// <summary>
    /// Generates a list of events that can occur when a player lands on a green (i.e. education) space.
    /// </summary>
    public static List<GameEvent> GenerateGreenSpaceEvents()
	{
		if (_greenEvents is not null)
			return _greenEvents;

        List<GameEvent> greens = new()
		{
			new GameEvent
			{
				Description = "You found a $50 bill on the ground!",
                ShortName = "Found $50",
                CashMoneyChange = 50,
				LifePointsChange = 20,
                LuckyStarsChange = 1
            },
			new GameEvent
			{
				Description = "You did way better than expected on your biology exam!",
                ShortName = "Great Exam",
                LifePointsChange = 125
			},
			new GameEvent
			{
				Description = "You studied the wrong chapter for your calculus exam...",
                ShortName = "Wrong Chapter",
                LifePointsChange = -100,
                LuckyStarsChange = -1
            },
			new GameEvent
			{
				Description = "Your instructor complemented your answers in class!",
                ShortName = "Great Student",
                LifePointsChange = 75
			},
			new GameEvent
			{
				Description = "The friend you helped study did great on their exams!",
                ShortName = "Study Buddy",
                LifePointsChange = 150
			},
			new GameEvent
			{
				Description = "The students you tutored for chemistry paid up!",
                ShortName = "Tutor Tuition",
                CashMoneyChange = 500
			},
            new GameEvent
            {
                Description = "Your research trip to the museum ended when you knocked over a T-Rex skeleton.",
                ShortName = "T-Wrecked",
                LifePointsChange = -50,
                CashMoneyChange = -10000,
                LuckyStarsChange = -3
            },
        };

		_greenEvents = greens;
        return _greenEvents;
	}
}