using UpsAndDowns.GameLogic.Effects;
using UpsAndDowns.GameLogic.Enums;

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
		
		private List<Player> _players = new();
		private List<Player> _unselectedPlayers = new();
		private Random _random = new();
		
		public void StartNewGame(int playerCount)
		{
			CurrentState = GameStates.InProgress;
			Console.WriteLine("Game started");
		}

		// public void AddPlayer(Player player)
		// {
		// 	_players.Add(player);
		// 	Console.WriteLine($"Player {player.PlayerNumber} added.");
		// }

		public Player GetPlayer(int playerNumber)
		{
			return _players.FirstOrDefault(player => player.PlayerNumber == playerNumber)!;
        }

		public Player SelectNextRandomPlayer()
		{
			// Reset the list of unselected players if there are none left
			if (_unselectedPlayers.Count == 0)
				_unselectedPlayers = new List<Player>(_players);

			int index = _random.Next(_unselectedPlayers.Count);
			Player selectedPlayer = _unselectedPlayers[index];
			_unselectedPlayers.RemoveAt(index);
			return selectedPlayer;
		}
		
		public void SetPlayerLandedSpace(Player player, SpaceTypes space)
		{
			Console.WriteLine($"Player {player.PlayerNumber} landed on {space}");
			player.CurrentSpace = space;
		}

		public void ApplyGameEvent(GameEvent eve, ModifierLevel modLevel, Player affectedPlayer)
		{
			affectedPlayer.ApplyGameEvent(eve, modLevel);
		}
    }
}