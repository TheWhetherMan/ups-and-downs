using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace UpsAndDowns.Hardware
{
    internal class PrinterManager
    {
        internal static string PrinterName = "POS-58";
        internal static int InitialY = 0;
        internal static int StandardLineHeight = 20;
        internal static Font MediumFont = new("Verdana", 8);
        internal static Font LargeFont = new("Verdana", 12);
        internal static Brush Brush = Brushes.Black;

        public static void RunTest()
        {
            new PrintLuckyStarTicket().PrintTicket(new TicketSettings() { Quantity = 1, PlayerNumber = 1 });
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
