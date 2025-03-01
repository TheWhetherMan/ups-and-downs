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
            if (GameManager.Instance.GameHasStarted is false)
                return;

            if (GameManager.Instance.CurrentState == GameStates.AtHomeScreen)
            {
                if (GameManager.Instance.AllPlayersHaveMoved)
                {
                    CenterButton.Content = "End Of Year";
                }
                else
                {
                    CenterButton.Content = "Back To Player Turn";
                    CenterButton.IsEnabled = true;
                }
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
            if (GameManager.Instance.AllPlayersHaveMoved)
            {
                CenterButton.IsEnabled = false;
                GameManager.Instance.CurrentState = GameStates.EndOfYear;
                WeakReferenceMessenger.Default.Send(new Messages.AdvanceYearMessage());
            }
            else
            {
                CenterButton.IsEnabled = true;
                GameManager.Instance.CurrentState = GameStates.PlayerTurn;
            }
        }
    }

    private void EndGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Logger.Log("EndGameButton_Click");
        System.Windows.Application.Current.Shutdown();
    }
}
