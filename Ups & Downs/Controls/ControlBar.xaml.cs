using CommunityToolkit.Mvvm.Messaging;
using System.Diagnostics;
using System.Windows.Controls;
using UpsAndDowns.GameLogic;
using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.Controls;

public partial class ControlBar : UserControl
{
    public ControlBar()
    {
        InitializeComponent();
        RegisterMessages();
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
            GameManager.Instance.CurrentState = GameStates.PlayerTurn;
        }
    }

    private void EndGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Logger.Log("EndGameButton_Click");
        System.Windows.Application.Current.Shutdown();
    }
}
