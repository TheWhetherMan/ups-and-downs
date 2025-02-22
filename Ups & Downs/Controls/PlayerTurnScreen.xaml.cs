using CommunityToolkit.Mvvm.Messaging;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using UpsAndDowns.GameLogic;

namespace UpsAndDowns.Controls
{
    public partial class PlayerTurnScreen : UserControl
    {
        public PlayerTurnScreen()
        {
            InitializeComponent();
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
        }

        private void SpaceButton_Blue(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpaceButton_Blue");
        }

        private void SpaceButton_Yellow(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpaceButton_Yellow");
        }

        private void SpaceButton_Pink(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpaceButton_Pink");
        }

        private void SpecialButton_Education(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_Education");
        }

        private void SpecialButton_Promotion(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_Promotion");
        }

        private void SpecialButton_Marriage(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_Marriage");
        }

        private void SpecialButton_Children(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_Children");
        }

        private void SpecialButton_SpecialEvent(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_SpecialEvent");
        }

        private void SpecialButton_BuyCar(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_BuyCar");
        }

        private void SpecialButton_BuyHouse(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SpecialButton_BuyHouse");
        }
    }
}
