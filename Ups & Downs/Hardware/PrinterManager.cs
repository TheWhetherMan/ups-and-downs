using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Media.Imaging;
using UpsAndDowns.BusinessLogic;

namespace UpsAndDowns.Hardware
{
    internal class PrinterManager
    {
        internal static string BasePrinterName = "POS-58";
        internal static int InitialY = 0;
        internal static int StandardLineHeight = 20;
        internal static Font MediumFont = new("Verdana", 8);
        internal static Font LargeFont = new("Verdana", 12);
        internal static Brush Brush = Brushes.Black;

        public static void RunTest()
        {
            new PrintLuckyStarTicket().PrintTicket(new TicketSettings() 
            { 
                Quantity = 1, 
                PlayerNumber = 1, 
                CurrentEvent = new GameLogic.Events.GameEvent() { Description = "TEST", ShortName = "TEST RECEIPT" } 
            });
        }

        internal static string GetPrinterName()
        {
            string? correctPrinterName = PrinterSettings.InstalledPrinters
                .Cast<string>()
                .FirstOrDefault(name => name.StartsWith(BasePrinterName, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(correctPrinterName))
                Logger.Log("GetPrinterName: Printer not found!");

            return correctPrinterName ?? "";
        }

        internal static Image BitmapImageToBitmap(BitmapImage bitmapImage)
        {
            if (bitmapImage == null)
                return null;

            using MemoryStream outStream = new();
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            encoder.Save(outStream);
            return Image.FromStream(outStream);
        }
    }
}
