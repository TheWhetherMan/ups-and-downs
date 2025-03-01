using UpsAndDowns.GameLogic.Enums;

namespace UpsAndDowns.Hardware
{
    public interface IPrintableTicket
    {
        public void PrintTicket(TicketSettings settings);
    }

    public class TicketSettings
    {
        public TicketTypes TicketType { get; set; } = TicketTypes.LuckyStars;
        public int Quantity { get; set; } = 1;
        public string? BodyText { get; set; }
    }
}
