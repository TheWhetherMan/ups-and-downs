using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using UpsAndDowns.GameLogic;
using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.Controls;

public partial class HomeScreen : UserControl
{
    private ObservableCollection<Player> _players = [];
    public ObservableCollection<Player> Players
    {
        get { return _players; }
        set { _players = value; }
    }

    public HomeScreen()
    {
        InitializeComponent();
        DataContext = this;
        RegisterMessages();
        Players = new ObservableCollection<Player>(GameManager.Instance.Players);
    }

    private void RegisterMessages()
    {
        WeakReferenceMessenger.Default.Register<Messages.GameStateChangedMessage>(this, (r, m) =>
        {
            if (GameManager.Instance.CurrentState == GameStates.PlayerTurn)
            {
                ShowPlayerTurnScreen();
            }
            else if (GameManager.Instance.CurrentState == GameStates.AtHomeScreen)
            {
                HidePlayerTurnScreen();
            }
        });
        WeakReferenceMessenger.Default.Register<Messages.ReturnToHomeScreenMessage>(this, (r, m) =>
        {
            GameManager.Instance.CurrentState = GameStates.AtHomeScreen;
        });
        WeakReferenceMessenger.Default.Register<Messages.ReadyForFirstPlayerTurnMessage>(this, (r, m) =>
        {
            StartFirstTurn();
        });
        WeakReferenceMessenger.Default.Register<Messages.GameStartReadyMessage>(this, (r, m) =>
        {
            //Players = new ObservableCollection<Player>(GameManager.Instance.Players);
        });
    }

    private void HidePlayerTurnScreen()
    {
        PlayerTurnScreenElement.Visibility = System.Windows.Visibility.Collapsed;
    }

    private void ShowPlayerTurnScreen()
    {
        PlayerTurnScreenElement.Visibility = System.Windows.Visibility.Visible;
    }

    private void StartFirstTurn()
    {
        Debug.WriteLine("HomeScreen.StartFirstTurn");
        StartNextPlayersTurn();
        GameManager.Instance.CurrentState = GameStates.PlayerTurn;
    }

    private void StartNextPlayersTurn()
    {
        Debug.WriteLine("HomeScreen.StartNextPlayersTurn");
        GameManager.Instance.SelectNextRandomPlayer();
        PlayerTurnScreenElement.Visibility = System.Windows.Visibility.Visible;
        Debug.WriteLine($"HomeScreen.StartNextPlayersTurn -> {GameManager.Instance.CurrentPlayer.PlayerNumber}");
    }

    private void PlayerCard_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (sender is PlayerCard card)
        {
            if (card.DataContext is Player player)
            {
                Debug.WriteLine($"PlayerCard_MouseDown: {player.PlayerNumber}");
            }
        }
    }
}