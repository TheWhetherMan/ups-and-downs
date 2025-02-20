using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using UpsAndDowns.GameLogic;
using UpsAndDowns.Messages;

namespace UpsAndDowns.Controls
{
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
            StartFirstTurn();
        }

        private void StartFirstTurn()
        {
            Debug.WriteLine("HomeScreen.StartFirstTurn");
            StartNextPlayersTurn();
        }

        private void StartNextPlayersTurn()
        {
            Debug.WriteLine("HomeScreen.StartNextPlayersTurn");
            Player nextPlayer = GameManager.Instance.SelectNextRandomPlayer();
            PlayerTurnScreenElement.Visibility = System.Windows.Visibility.Visible;
            PlayerTurnScreenElement.SetUpForPlayer(nextPlayer);
            Debug.WriteLine($"HomeScreen.StartNextPlayersTurn -> {nextPlayer.PlayerNumber}");
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
}
