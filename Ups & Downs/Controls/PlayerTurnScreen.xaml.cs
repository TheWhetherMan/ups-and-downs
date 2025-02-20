using System.Windows.Controls;

namespace UpsAndDowns.Controls
{
    public partial class PlayerTurnScreen : UserControl
    {
        public PlayerTurnScreen()
        {
            InitializeComponent();
        }

        public void SetUpForPlayer(Player player) 
        {
            PlayerTurnHeader.Text = $"Player {player.PlayerNumber}'s Turn";
        }
    }
}
