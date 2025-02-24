using System.Windows;
using UpsAndDowns.BusinessLogic;
using UpsAndDowns.GameLogic;

namespace UpsAndDowns;

public partial class App : Application
{
    public GameHost Host { get; private set; }

    public App()
    {
        GameManager.Instance.InitializeGame();
    }
}
