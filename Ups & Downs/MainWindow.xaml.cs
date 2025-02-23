using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using UpsAndDowns.GameLogic;

namespace UpsAndDowns;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        RegisterMessages();
    }

    private void RegisterMessages()
    {
        WeakReferenceMessenger.Default.Register<Messages.GoToConfigureGameMessage>(this, (r, m) =>
        {
            GoToGameConfiguration();
        });
        WeakReferenceMessenger.Default.Register<Messages.StartNewGameMessage>(this, (r, m) =>
        {
            GoToGameHome();
        });
    }

    private void GoToGameConfiguration()
    {
        Dispatcher.Invoke(() =>
        {
            ParentGrid.Children.Clear();
            ParentGrid.Children.Add(new Controls.GameConfigurationScreen());
            GameManager.Instance.CurrentState = GameLogic.Enums.GameStates.ConfiguringGame;
        });
    }

    private void GoToGameHome()
    {
        Dispatcher.Invoke(() =>
        {
            ParentGrid.Children.Clear();
            ParentGrid.Children.Add(new Controls.HomeScreen());
            GameManager.Instance.CurrentState = GameLogic.Enums.GameStates.AtHomeScreen;
        });
    }
}