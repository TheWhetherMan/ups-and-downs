using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using System.Windows.Controls;
using UpsAndDowns.BusinessLogic;
using UpsAndDowns.GameLogic;
using UpsAndDowns.GameLogic.Enums;
using UpsAndDowns.GameLogic.Events;

namespace UpsAndDowns.Controls;

public partial class PlayerTurnScreen : UserControl
{
    private SpaceHandler _spaceHandler;

    public PlayerTurnScreen()
    {
        InitializeComponent();
        _spaceHandler = new SpaceHandler();
        IsVisibleChanged += PlayerTurnScreen_IsVisibleChanged;
        RegisterMessages();
    }

    private void RegisterMessages()
    {
        WeakReferenceMessenger.Default.Register<Messages.BackToPlayerTurnScreenMessage>(this, (r, m) =>
        {
            BasicEventControlElement.Visibility = Visibility.Collapsed;
        });
    }

    private void PlayerTurnScreen_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        SetUpForPlayer(GameManager.Instance.CurrentPlayer);
    }

    private void SetUpForPlayer(Player player) 
    {
        if (Visibility != Visibility.Visible)
            return;

        PlayerTurnHeader.Text = $"Player {player.PlayerNumber}'s Turn";
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        Logger.Log("BackButton_Click");
        WeakReferenceMessenger.Default.Send(new Messages.ReturnToHomeScreenMessage());
    }

    // BASIC BUTTONS

    private void SpaceButton_Green(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpaceButton_Green");
        BasicEventControlElement.UpdateForEvent(EducationGameEventGenerator.GetRandomGreenSpaceEvent());
        BasicEventControlElement.Visibility = Visibility.Visible;
    }

    private void SpaceButton_Blue(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpaceButton_Blue");
        BasicEventControlElement.UpdateForEvent(CareerGameEventGenerator.GetRandomBlueSpaceEvent());
        BasicEventControlElement.Visibility = Visibility.Visible;
    }

    private void SpaceButton_Yellow(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpaceButton_Yellow");
        BasicEventControlElement.UpdateForEvent(AdventureGameEventGenerator.GetRandomYellowSpaceEvent());
        BasicEventControlElement.Visibility = Visibility.Visible;
    }

    private void SpaceButton_Pink(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpaceButton_Pink");
        BasicEventControlElement.UpdateForEvent(LoveGameEventGenerator.GetRandomPinkSpaceEvent());
        BasicEventControlElement.Visibility = Visibility.Visible;
    }

    // SPECIAL BUTTONS

    private void SpecialButton_Education(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpecialButton_Education");
        _spaceHandler.HandleSpecialSpace(SpaceTypes.Education);
    }

    private void SpecialButton_Promotion(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpecialButton_Promotion");
        _spaceHandler.HandleSpecialSpace(SpaceTypes.Promotion);
    }

    private void SpecialButton_Marriage(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpecialButton_Marriage");
        _spaceHandler.HandleSpecialSpace(SpaceTypes.Marriage);
    }

    private void SpecialButton_Children(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpecialButton_Children");
        _spaceHandler.HandleSpecialSpace(SpaceTypes.Children);
    }

    private void SpecialButton_SpecialEvent(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpecialButton_SpecialEvent");
        _spaceHandler.HandleSpecialSpace(SpaceTypes.Event);
    }

    private void SpecialButton_BuyCar(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpecialButton_BuyCar");
        _spaceHandler.HandleSpecialSpace(SpaceTypes.Car);
    }

    private void SpecialButton_BuyHouse(object sender, RoutedEventArgs e)
    {
        Logger.Log("SpecialButton_BuyHouse");
        _spaceHandler.HandleSpecialSpace(SpaceTypes.House);
    }
}
