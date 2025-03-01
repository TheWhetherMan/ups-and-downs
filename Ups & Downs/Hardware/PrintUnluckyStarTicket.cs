using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Media.Imaging;

namespace UpsAndDowns.Hardware
{
    public class PrintUnluckyStarTicket : IPrintableTicket
    {
        private TicketSettings _ticketSettings = new();

        public void PrintTicket(TicketSettings ticketSettings)
        {
            _ticketSettings = ticketSettings;
            PrintDocument printDoc = new();
            printDoc.PrinterSettings.PrinterName = PrinterManager.PrinterName;
            printDoc.PrintPage += PrintTicket;
            printDoc.Print();
        }

        private void PrintTicket(object sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null)
                return;

            BitmapImage bitmapImage = new(new Uri("pack://application:,,,/Resources/Images/star_dark.png", UriKind.Absolute));
            Image imageToPrint = PrinterManager.BitmapImageToBitmap(bitmapImage);
            if (imageToPrint == null) 
                return;

            int yPos = PrinterManager.InitialY;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.DrawString("Unlucky Star Ticket", 
                PrinterManager.LargeFont, PrinterManager.Brush, new Point(15, yPos));
            yPos += PrinterManager.StandardLineHeight;
            e.Graphics.DrawString($"Player #{_ticketSettings.PlayerNumber}",
                PrinterManager.MediumFont, PrinterManager.Brush, new Point(70, yPos));
            yPos += PrinterManager.StandardLineHeight * 2;

            PrintImageSection(e, imageToPrint, yPos);
            if (_ticketSettings.Quantity == 3)
                yPos += PrinterManager.StandardLineHeight * 10;
            else if (_ticketSettings.Quantity == 2)
                yPos += PrinterManager.StandardLineHeight * 7;
            else
                yPos += PrinterManager.StandardLineHeight * 6;

            e.Graphics.DrawString($"Value: {_ticketSettings.Quantity} Unlucky Star(s)!", 
                PrinterManager.MediumFont, PrinterManager.Brush, new Point(20, yPos));
            yPos += PrinterManager.StandardLineHeight * 3;
            e.Graphics.DrawString("Must be redeemed entirely at", 
                PrinterManager.MediumFont, PrinterManager.Brush, new Point(10, yPos));
            yPos += PrinterManager.StandardLineHeight;
            e.Graphics.DrawString("the first opportunity!",
                PrinterManager.MediumFont, PrinterManager.Brush, new Point(40, yPos));
            yPos += PrinterManager.StandardLineHeight;
            e.Graphics.DrawString("No cash value", 
                PrinterManager.MediumFont, PrinterManager.Brush, new Point(55, yPos));
        }
        
        private void PrintImageSection(PrintPageEventArgs e, Image image, int yOffset)
        {
            if (_ticketSettings.Quantity == 3)
            {
                e.Graphics?.DrawImage(image, new Rectangle(50, yOffset, 100, 100));
                e.Graphics?.DrawImage(image, new Rectangle(00, yOffset + 70, 100, 100));
                e.Graphics?.DrawImage(image, new Rectangle(100, yOffset + 70, 100, 100));
            }
            else if (_ticketSettings.Quantity == 2)
            {
                e.Graphics?.DrawImage(image, new Rectangle(10, yOffset, 100, 100));
                e.Graphics?.DrawImage(image, new Rectangle(90, yOffset + 20, 100, 100));
            }
            else
            {
                e.Graphics?.DrawImage(image, new Rectangle(50, yOffset, 100, 100));
            }
        }
    }
}
