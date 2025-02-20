using CommunityToolkit.Mvvm.Messaging;
using System.Diagnostics;
using UpsAndDowns.GameLogic.Effects;
using UpsAndDowns.GameLogic.Enums;
using UpsAndDowns.Messages;

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
		public List<Player> Players { get; private set; } = new();
		public int GameLengthYears { get; private set; } = 10;
		public int CurrentYear { get; private set; } = 0;
		public int PlayerCount { get; private set; } = 0;

        private List<Player> _unselectedPlayers = new();
		private Random _random = new();

        private GameManager() 
		{	
			Debug.WriteLine("GameManager.Constructor");
        }

		internal void InitializeGame()
        {
            Debug.WriteLine("GameManager.InitializeGame");
            RegisterMessages();
        }

        private void RegisterMessages()
        {
			WeakReferenceMessenger.Default.Register<GoToStartNewGameMessage>(this, (r, m) => StartNewGame(m.PlayerCount));
        }

        public void StartNewGame(int playerCount)
		{
			Debug.WriteLine($"GameManager.StartNewGame: {playerCount}");
            CurrentState = GameStates.InProgress;
            PlayerCount = playerCount;
            for (int i = 1; i <= playerCount; i++)
                Players.Add(new Player(i));
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
			Debug.WriteLine($"Year {CurrentYear} has ended.");
			CurrentYear++;
			foreach (Player player in Players)
				player.AdvanceYear();

			if (CurrentYear >= GameLengthYears)
				Debug.WriteLine($"Game over!");
			else
				Debug.WriteLine($"Starting year {CurrentYear}...");
		}

		public void ApplyGameEvent(GameEvent eve, ModifierLevel modLevel, Player affectedPlayer)
		{
			affectedPlayer.ApplyGameEvent(eve, modLevel);
		}
    }
}