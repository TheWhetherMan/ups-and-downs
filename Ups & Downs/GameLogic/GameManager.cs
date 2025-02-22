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
				_instance ??= new GameManager();
				return _instance;
			}
		}

        private GameStates _currentState = GameStates.WaitingToStart;
        public GameStates CurrentState 
		{ 
			get => _currentState;
			set 
			{ 
				_currentState = value; 
				Debug.WriteLine($"GameManager.CurrentState -> {_currentState}");
                WeakReferenceMessenger.Default.Send(new GameStateChangedMessage()); 
			}
		}

        public List<Player> Players { get; private set; } = new();
		public Player CurrentPlayer { get; private set; } = new(0);
		public int GameLengthYears { get; private set; } = 10;
		public int CurrentYear { get; private set; } = 0;
		public int PlayerCount { get; private set; } = 0;
		public bool GameHasStarted { get; internal set; } = false;

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
			WeakReferenceMessenger.Default.Register<StartNewGameMessage>(this, (r, m) => StartNewGame(m.PlayerCount));
        }

        public void StartNewGame(int playerCount)
		{
			Debug.WriteLine($"GameManager.StartNewGame: {playerCount}");
            PlayerCount = playerCount;
            for (int i = 1; i <= playerCount; i++)
                Players.Add(new Player(i));
			WeakReferenceMessenger.Default.Send(new GameStartReadyMessage());
        }

		public Player GetPlayer(int playerNumber)
		{
			return Players.FirstOrDefault(player => player.PlayerNumber == playerNumber)!;
        }

		public void SelectNextRandomPlayer()
		{
			// Reset the list of unselected players if there are none left
			if (_unselectedPlayers.Count == 0)
				_unselectedPlayers = new List<Player>(Players);

			int index = _random.Next(_unselectedPlayers.Count);
            CurrentPlayer = _unselectedPlayers[index];
			_unselectedPlayers.RemoveAt(index);
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