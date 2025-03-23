using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Media.Imaging;
using UpsAndDowns.BusinessLogic;

namespace UpsAndDowns.Hardware
{
    public class PrintLuckyStarTicket : IPrintableTicket
    {
        private TicketSettings _ticketSettings = new();

        public void PrintTicket(TicketSettings ticketSettings)
        {
            try
            {
                _ticketSettings = ticketSettings;
                PrintDocument printDoc = new();
                printDoc.PrinterSettings.PrinterName = PrinterManager.GetPrinterName();
                printDoc.PrintPage += PrintTicket;
                printDoc.Print();
            }
            catch (Exception ex)
            {
                Logger.Log("PrintTicket exception", ex);
            }
        }

        private void PrintTicket(object sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null)
                return;

            BitmapImage bitmapImage = new(new Uri("pack://application:,,,/Resources/Images/star_gold.png", UriKind.Absolute));
            Image imageToPrint = PrinterManager.BitmapImageToBitmap(bitmapImage);
            if (imageToPrint == null) 
                return;

            int yPos = PrinterManager.InitialY;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.DrawString("Lucky Star Ticket", 
                PrinterManager.LargeFont, PrinterManager.Brush, new Point(20, yPos));
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

            e.Graphics.DrawString($"Value: {_ticketSettings.Quantity} Lucky Star(s)!", 
                PrinterManager.MediumFont, PrinterManager.Brush, new Point(35, yPos));
            yPos += PrinterManager.StandardLineHeight;
            e.Graphics.DrawString($"Event: {_ticketSettings.CurrentEvent?.ShortName ?? "?"}",
                PrinterManager.MediumFont, PrinterManager.Brush, new Point(25, yPos));
            yPos += PrinterManager.StandardLineHeight * 2;
            e.Graphics.DrawString("May be redeemed at any time,", 
                PrinterManager.MediumFont, PrinterManager.Brush, new Point(10, yPos));
            yPos += PrinterManager.StandardLineHeight;
            e.Graphics.DrawString("but must be all at once!",
                PrinterManager.MediumFont, PrinterManager.Brush, new Point(35, yPos));
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
