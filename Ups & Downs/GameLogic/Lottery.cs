using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic;

public class Lottery
{
	public int WinningsCashAmount { get; private set; };

	private Random _random = new();

	public Lottery()
	{

	}

	public void SetLotteryWinnings()
	{
		int amount = 10000 * _random.Next(1, 11)
		WinningsCashAmount = amount;
	}

	public LotteryResult Draw(List<Player> players, out Player winner)
	{
		winner = null;

		// No one wins if there are no players
		if (players.Count == 0)
			return LotteryResult.NoWinner;

		// Sometimes no one wins (1/N chance)
		if (_random.Next(0, players.Count) == 0)
			return LotteryResult.NoWinner;

		// Pick a random winner
		winner = players[_random.Next(0, players.Count)];
		return LotteryResult.Winner;
	}
}