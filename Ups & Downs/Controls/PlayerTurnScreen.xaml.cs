using CommunityToolkit.Mvvm.Messaging;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using UpsAndDowns.GameLogic;
using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.Controls
{
    public partial class PlayerTurnScreen : UserControl
    {
        private SpaceHandler _spaceHandler;

        public PlayerTurnScreen()
        {
            InitializeComponent();
            _spaceHandler = new SpaceHandler();
            IsVisibleChanged += PlayerTurnScreen_IsVisibleChanged;
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
            Debug.WriteLine("BackButton_Click");
            WeakReferenceMessenger.Default.Send(new Messages.ReturnToHomeScreenMessage());
        }

        private void SpaceButton_Green(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpaceButton_Green");
            _spaceHandler.HandleNormalSpace(BoardZones.Green);
        }

        private void SpaceButton_Blue(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpaceButton_Blue");
            _spaceHandler.HandleNormalSpace(BoardZones.Blue);
        }

        private void SpaceButton_Yellow(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpaceButton_Yellow");
            _spaceHandler.HandleNormalSpace(BoardZones.Yellow);
        }

        private void SpaceButton_Pink(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpaceButton_Pink");
            _spaceHandler.HandleNormalSpace(BoardZones.Pink);
        }

        private void SpecialButton_Education(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_Education");
            _spaceHandler.HandleSpecialSpace(SpaceTypes.Education);
        }

        private void SpecialButton_Promotion(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_Promotion");
            _spaceHandler.HandleSpecialSpace(SpaceTypes.Promotion);
        }

        private void SpecialButton_Marriage(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_Marriage");
            _spaceHandler.HandleSpecialSpace(SpaceTypes.Marriage);
        }

        private void SpecialButton_Children(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_Children");
            _spaceHandler.HandleSpecialSpace(SpaceTypes.Children);
        }

        private void SpecialButton_SpecialEvent(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_SpecialEvent");
            _spaceHandler.HandleSpecialSpace(SpaceTypes.Event);
        }

        private void SpecialButton_BuyCar(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_BuyCar");
            _spaceHandler.HandleSpecialSpace(SpaceTypes.Car);
        }

        private void SpecialButton_BuyHouse(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_BuyHouse");
            _spaceHandler.HandleSpecialSpace(SpaceTypes.House);
        }
    }
}
