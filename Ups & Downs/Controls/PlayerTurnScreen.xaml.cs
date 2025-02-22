using CommunityToolkit.Mvvm.Messaging;
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
            WeakReferenceMessenger.Default.Send(new Messages.ReturnToHomeScreenMessage());
        }
    }
}
