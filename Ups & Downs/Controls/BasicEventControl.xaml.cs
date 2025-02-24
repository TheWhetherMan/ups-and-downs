using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using System.Windows.Controls;
using UpsAndDowns.GameLogic.Events;

namespace UpsAndDowns.Controls
{
    public partial class BasicEventControl : UserControl
    {
        private int _luckyStars = 0;

        public BasicEventControl()
        {
            InitializeComponent();
        }

        internal void UpdateForEvent(GameEvent gameEvent)
        {

        }

        private void RemoveLuckButton_Click(object sender, RoutedEventArgs e)
        {
            _luckyStars--;
        }

        private void AddLuckButton_Click(object sender, RoutedEventArgs e)
        {
            _luckyStars++;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            // [TODO] => Go to the event results screen
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new Messages.BackToPlayerTurnScreenMessage());
        }
    }
}
