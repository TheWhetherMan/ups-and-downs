using System.IO;
using System.Windows;
using UpsAndDowns.BusinessLogic;

namespace Ups___Downs
{
    public partial class App : Application
    {
        public GameHost Host { get; private set; }

        public App()
        {
            Host = new GameHost();
            Host.InitializeHost();
        }
    }
}
