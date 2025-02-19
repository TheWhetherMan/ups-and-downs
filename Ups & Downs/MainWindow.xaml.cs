using CommunityToolkit.Mvvm.Messaging;
using System.Windows;

namespace UpsAndDowns
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            WeakReferenceMessenger.Default.Register<Messages.ConfigureGameMessage>(this, (r, m) =>
            {
                GoToGameConfiguration();
            });
        }

        private void GoToGameConfiguration()
        {
            Dispatcher.Invoke(() =>
            {
                ParentGrid.Children.Clear();
                ParentGrid.Children.Add(new Controls.GameConfigurationScreen());
            });
        }
    }
}