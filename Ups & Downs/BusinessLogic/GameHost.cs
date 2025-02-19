using UpsAndDowns.GameLogic;

namespace UpsAndDowns.BusinessLogic
{
    public class GameHost
    {
        public void InitializeHost()
        {
            GameManager.Instance.InitializeGame();
        }
    }
}
