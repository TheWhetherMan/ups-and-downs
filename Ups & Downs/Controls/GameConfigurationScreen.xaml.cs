using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Controls;
using UpsAndDowns.GameLogic;

namespace UpsAndDowns.Controls;

public partial class GameConfigurationScreen : UserControl
{
    private int _playerCount;
    public int PlayerCount
    {
        get { return _playerCount; }
        set 
        {
            _playerCount = Math.Clamp(value, 1, 6); 
            PlayerCountText.Text = _playerCount.ToString(); 
        }
    }

    public GameConfigurationScreen()
    {
        InitializeComponent();
    }

    private void MinusOneButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        PlayerCount -= 1;
    }

    private void PlusOneButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        PlayerCount += 1;
    }

    private void StartButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        WeakReferenceMessenger.Default.Send(new Messages.StartNewGameMessage() 
        { 
            PlayerCount = PlayerCount 
        });
    }
}