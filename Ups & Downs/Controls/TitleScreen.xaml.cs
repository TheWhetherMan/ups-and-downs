using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Controls;
using UpsAndDowns.Hardware;

namespace UpsAndDowns.Controls;

public partial class TitleScreen : UserControl
{
    public TitleScreen()
    {
        InitializeComponent();
    }

    private void StartButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        WeakReferenceMessenger.Default.Send(new Messages.GoToConfigureGameMessage());
    }

    private void PrintTestButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        PrinterManager.RunTest();
    }
}
