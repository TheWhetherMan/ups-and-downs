using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.GameLogic;

public class Lottery
{
	public int WinningsCashAmount { get; private set; }
	public List<string> LotteryTickets = new();

	private Random _random = new();

	public Lottery()
	{
		SetLotteryWinnings();
	}

	public void SetLotteryWinnings()
	{
		// Randomly select a winnings amount  between 10,000 and 100,000
		int amount = 10000 * _random.Next(1, 11);
		WinningsCashAmount = amount;
	}

	public void GenerateLotteryTickets(int players)
	{
		LotteryTickets.Clear();
		for (int i = 0; i < players; i++)
		{
			LotteryTickets.Add(GenerateRandom4DigitNumber().ToString());
		}
	}

	public int GenerateRandom4DigitNumber()
	{
		// Generates a number between 1000 and 9999
		int number = _random.Next(1000, 10000); 
		return number;
	}

	// TODO: Change this to select a winner from the list of tickets
	public LotteryResults Draw(List<Player> players, out Player? winner)
	{
		winner = null;

		// No one wins if there are no players
		if (players.Count == 0)
			return LotteryResults.NoWinner;

		// Sometimes no one wins (1/N chance)
		if (_random.Next(0, players.Count) == 0)
			return LotteryResults.NoWinner;

		// Pick a random winner
		winner = players[_random.Next(0, players.Count)];
		return LotteryResults.Winner;
	}
}