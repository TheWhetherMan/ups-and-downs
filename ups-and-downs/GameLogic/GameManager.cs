namespace UpsAndDowns.GameLogic
{
	public class GameManager
	{
		public Enums.GameStates CurrentState = Enums.GameStates.NotStarted;
		public int GameLengthYears { get; private set; } = 10;
		public int CurrentYear { get; private set; } = 0;
		
		private List<Player> _players = new();
		
		public void StartGame()
		{
			CurrentState = Enums.GameStates.InProgress;
			Console.WriteLine("Game started");
		}

		public void AddPlayer(Player player)
		{
			_players.Add(player);
			Console.WriteLine($"Player {player} added.");
		}
		
		
	}
}