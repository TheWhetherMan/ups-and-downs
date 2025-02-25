using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Controls;
using UpsAndDowns.BusinessLogic;
using UpsAndDowns.GameLogic;
using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.Controls;

public partial class ControlBar : UserControl
{
    public ControlBar()
    {
        InitializeComponent();
        RegisterMessages();
        GameManager.Instance.OnYearAdvanced += GameManager_OnYearAdvanced;
    }

    private void RegisterMessages()
    {
        WeakReferenceMessenger.Default.Register<Messages.GameStateChangedMessage>(this, (r, m) =>
        {
            if (GameManager.Instance.CurrentState == GameStates.AtHomeScreen && 
                GameManager.Instance.GameHasStarted)
            {
                CenterButton.Content = "Back To Player Turn";
            }
        });
    }

    private void GameManager_OnYearAdvanced()
    {
        ControlBarLabel.Text = $"Current Year: {GameManager.Instance.CurrentYear}";
    }

    private void OptionsButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Logger.Log("OptionsButton_Click");
    }

    private void CenterButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Logger.Log("CenterButton_Click");
        if (GameManager.Instance.GameHasStarted is false)
        {
            GameManager.Instance.GameHasStarted = true;
            WeakReferenceMessenger.Default.Send(new Messages.ReadyForFirstPlayerTurnMessage());
        }
        else if (GameManager.Instance.CurrentState == GameStates.AtHomeScreen)
        {
            // TODO :: CHECK IF ALL PLAYERS HAVE GONE. IF SO, DO END OF YEAR EVENT

            GameManager.Instance.CurrentState = GameStates.PlayerTurn;
        }
    }

    private void EndGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Logger.Log("EndGameButton_Click");
        System.Windows.Application.Current.Shutdown();
    }
}
