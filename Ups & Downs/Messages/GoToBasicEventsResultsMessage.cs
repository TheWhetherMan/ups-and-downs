using UpsAndDowns.GameLogic.Events;

namespace UpsAndDowns.Messages
{
    internal class GoToBasicEventsResultsMessage
    {
        public GameEvent? ActiveEvent { get; set; }
        public int LuckyStars { get; set; }
    }
}
