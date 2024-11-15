namespace UpsAndDowns.GameLogic
{
	public class GameManager
	{
		public Enums.GameStates CurrentState = Enums.GameStates.NotStarted;
		public int GameLengthYears = 10;
		public int CurrentYear = 0;
		
		private List<Player> _players = new();

		public void AddPlayer(Player player)
		{
			if (CurrentState == Enums.GameStates.NotStarted)
			{
				_players.Add(player);
				Console.WriteLine($"Player {player} added.");
			}
			else
			{
				Console.WriteLine("Players cannot be added after the game has started.");
			}
		}
	}
}