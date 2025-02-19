using UpsAndDowns.GameLogic.Effects;
using UpsAndDowns.GameLogic.Enums;
using UpsAndDowns.GameLogic.Misc;

namespace UpsAndDowns.GameLogic
{
	public class GameManager
	{
		private static GameManager? _instance;
		public static GameManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new GameManager();
				return _instance;
			}
		}

		public GameStates CurrentState = GameStates.NotStarted;
		public int GameLengthYears { get; private set; } = 10;
		public int CurrentYear { get; private set; } = 0;
		
		public List<Player> Players { get; private set; } = new();
		private List<Player> _unselectedPlayers = new();
		private Random _random = new();
		
		public void StartNewGame(int playerCount)
		{
			CurrentState = GameStates.InProgress;
			// TODO
			Console.WriteLine($"Game started for {playerCount} players.");
		}

		public Player GetPlayer(int playerNumber)
		{
			return Players.FirstOrDefault(player => player.PlayerNumber == playerNumber)!;
        }

		public Player SelectNextRandomPlayer()
		{
			// Reset the list of unselected players if there are none left
			if (_unselectedPlayers.Count == 0)
				_unselectedPlayers = new List<Player>(Players);

			int index = _random.Next(_unselectedPlayers.Count);
			Player selectedPlayer = _unselectedPlayers[index];
			_unselectedPlayers.RemoveAt(index);
			return selectedPlayer;
		}
		
		public void AdvanceGameByOneYear()
		{
			Console.WriteLine($"Year {CurrentYear} has ended.");
			CurrentYear++;
			foreach (Player player in Players)
				player.AdvanceYear();

			if (CurrentYear >= GameLengthYears)
				Console.WriteLine($"Game over!");
			else
				Console.WriteLine($"Starting year {CurrentYear}...");
		}

		public void ApplyGameEvent(GameEvent eve, ModifierLevel modLevel, Player affectedPlayer)
		{
			affectedPlayer.ApplyGameEvent(eve, modLevel);
		}
    }
}