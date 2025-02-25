using CommunityToolkit.Mvvm.Messaging;
using UpsAndDowns.BusinessLogic;
using UpsAndDowns.GameLogic.Enums;
using UpsAndDowns.GameLogic.Events;
using UpsAndDowns.Messages;

namespace UpsAndDowns.GameLogic;

public class GameManager
{
    public event Action OnYearAdvanced;

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
            if (_currentState == value)
                return;

            _currentState = value;
            Logger.Log($"GameManager.CurrentState -> {_currentState}");
            WeakReferenceMessenger.Default.Send(new GameStateChangedMessage());
        }
    }

    public List<Player> Players { get; private set; } = new();
    public Player CurrentPlayer { get; private set; } = new(0);
    public int GameLengthYears { get; private set; } = 10;
    public int CurrentYear { get; private set; } = 0;
    public int PlayerCount { get; private set; } = 0;
    public bool GameHasStarted { get; internal set; } = false;
    public bool PlayerTurnCompleted { get; internal set; } = false;

    private List<Player> _unselectedPlayers = new();
    private Random _random = new();

    private GameManager()
    {
        Logger.Log("GameManager.Constructor");
    }

    internal void InitializeGame()
    {
        Logger.Log("GameManager.InitializeGame");
        RegisterMessages();
    }

    private void RegisterMessages()
    {
        WeakReferenceMessenger.Default.Register<StartNewGameMessage>(this, (r, m)
            => StartNewGame(m.PlayerCount));
    }

    public void StartNewGame(int playerCount)
    {
        Logger.Log($"GameManager.StartNewGame: {playerCount}");

        PlayerCount = playerCount;
        for (int i = 1; i <= playerCount; i++)
        {
            Player newPlayer = new Player(i);
            Players.Add(newPlayer);
            newPlayer.CashMoney += 1000;
            newPlayer.LifePoints = 10;
        }

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
        PlayerTurnCompleted = false;
    }

    public void AdvanceGameByOneYear()
    {
        Logger.Log($"Year {CurrentYear} has ended.");
        CurrentYear++;
        foreach (Player player in Players)
            player.AdvanceYear();

        if (CurrentYear >= GameLengthYears)
            Logger.Log($"Game over!");
        else
            Logger.Log($"Starting year {CurrentYear}...");

        OnYearAdvanced?.Invoke();
    }

    public void ApplyGameEvent(GameEvent eve, LuckyStars luck, Player affectedPlayer)
    {
        affectedPlayer.ApplyGameEvent(eve, luck);
    }
}