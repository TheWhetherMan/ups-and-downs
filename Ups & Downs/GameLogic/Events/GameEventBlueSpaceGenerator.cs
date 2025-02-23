using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic.Events;

public class GameEventBlueSpaceGenerator
{
	/// <summary>
	/// Generates a list of events that can occur when a player lands on a blue (i.e. career) space.
	/// </summary>
	public static List<GameEvent> GenerateBlueSpaceEvents()
	{
		List<GameEvent> blueEvents = new()
		{
			new GameEvent
			{
				Description = "Your boss didn't laugh at your joke during the meeting.",
				LifePointsChange = -30
			},
			new GameEvent
			{
				Description = "The donuts you brought to work went over well!",
				LifePointsChange = 25
			},
			new GameEvent
			{
				Description = "Your hard work on the project was recognized by your boss!",
				LifePointsChange = 50,
				CareerChange = 1,
				CashMoneyChange = 1000
			},
			new GameEvent
			{
				Description = "The code you pushed to production had a bug, and the client isn't happy.",
				LifePointsChange = -20,
				CareerChange = -1
			},
			new GameEvent
			{
				Description = "There was a pizza party at work, but they ran out of plain cheese before you got there.",
				LifePointsChange = -10
			},
			new GameEvent
			{
				Description = "You did consistently well on your performance reviews this year!",
				CareerChange = 1,
				CashMoneyChange = 5000
			},
		};

		return blueEvents;
	}
}