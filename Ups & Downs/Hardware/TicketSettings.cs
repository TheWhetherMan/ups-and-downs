using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.Hardware
{
    public class TicketSettings
    {
        public TicketTypes TicketType { get; set; } = TicketTypes.LuckyStars;
        public int Quantity { get; set; } = 1;
        public string? BodyText { get; set; }
        public int? PlayerNumber { get; set; }
    }
}
