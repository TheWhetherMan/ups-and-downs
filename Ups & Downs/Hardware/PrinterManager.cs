using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Text;

namespace UpsAndDowns.Hardware
{
    internal class PrinterManager
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool OpenPrinter(string pPrinterName, out IntPtr hPrinter, IntPtr pDefault);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, ref DOCINFOA docInfo);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool WritePrinter(IntPtr hPrinter, byte[] pBytes, int dwCount, out int dwWritten);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            public int cbSize = Marshal.SizeOf(typeof(DOCINFOA));
            public string pDocName = "ESC/POS Test";
            public string pDataType = "RAW";
        }

        public static void SendToPrinter(string printerName, byte[] data)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.PrinterSettings.PrinterName = "POS-58";
            printDoc.Print();
        }

        private static void PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Hello, Printer!", new Font("Arial", 12), Brushes.Black, new PointF(100, 100));
        }

        private static void SimpleTest(string printerName)
        {
            if (OpenPrinter(printerName, out IntPtr hPrinter, IntPtr.Zero))
            {
                Console.WriteLine("Printer opened successfully!");
                ClosePrinter(hPrinter);
            }
            else
            {
                Console.WriteLine("Failed to open printer. Error: " + Marshal.GetLastWin32Error());
            }
        }

        public static void RunTest()
        {
            //foreach (string printer in System.Drawing.Printing.PrintingPermission.inst)
            //{
            //    Logger.Log("Printer available: ", printer);
            //}

            string printerName = "POS-58";
            byte[] escposCommands = Encoding.ASCII.GetBytes("\x1B\x40" + // Initialize printer
                                                            "Hello ESC/POS Printer!\n" +
                                                            "\x1B\x64\x02" + // Feed paper
                                                            "\x1D\x56\x41\x03"); // Cut paper

            SendToPrinter(printerName, escposCommands);
            //SimpleTest(printerName);
        }
    }
}
