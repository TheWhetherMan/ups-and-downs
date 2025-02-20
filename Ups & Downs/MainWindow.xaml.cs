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
            WeakReferenceMessenger.Default.Register<Messages.GoToConfigureGameMessage>(this, (r, m) =>
            {
                GoToGameConfiguration();
            });
            WeakReferenceMessenger.Default.Register<Messages.GoToStartNewGameMessage>(this, (r, m) =>
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
            });
        }

        private void GoToGameHome()
        {
            Dispatcher.Invoke(() =>
            {
                ParentGrid.Children.Clear();
                ParentGrid.Children.Add(new Controls.HomeScreen());
            });
        }
    }
}