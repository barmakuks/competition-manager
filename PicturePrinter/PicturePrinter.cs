using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PicturePrinter
{
    public class Printer
    {
        private static PrintDocument FPrintDoc = new PrintDocument();
        private static PrintPreviewDialog FPreviewDlg = new PrintPreviewDialog();
        private static int FCurrentPage = 1;
        private static Image FImage = null;
        static Printer()
        {
            FPreviewDlg.Document = FPrintDoc;
            FPrintDoc.BeginPrint += new PrintEventHandler(FPrintDoc_BeginPrint);
            FPrintDoc.PrintPage += new PrintPageEventHandler(FPrintDoc_PrintPage);
        }

        static void FPrintDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            FCurrentPage = 0;
        }
        /// <summary>
        /// Печатает очередную страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void FPrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            if (FImage == null)
            {
                e.HasMorePages = false;
                return;
            }
            int hCount = (FImage.Width / e.MarginBounds.Width + 1);
            int vCount = (FImage.Height / e.MarginBounds.Height + 1);
            int pageCount = hCount * vCount;

            FCurrentPage++;

            int x = (FCurrentPage + hCount - 1) % hCount;
            int y = (FCurrentPage - 1) / hCount;

            e.HasMorePages = FCurrentPage < pageCount;


            Rectangle source = new Rectangle(x * e.MarginBounds.Width, y * e.MarginBounds.Height, e.MarginBounds.Width, e.MarginBounds.Height);
            g.DrawImage(FImage, e.MarginBounds, source, GraphicsUnit.Pixel);
        }

        public static void Preview(Image picture)
        {
            FImage = picture;
            if (FImage == null)
                return;
            
            FPrintDoc.DefaultPageSettings.Landscape = (FImage.Width > FImage.Height);
            FPreviewDlg.ShowDialog();
            FImage = null;
        }
        public static void Print(Image picture)
        {
            //FCurrentPage = 1;
            FPrintDoc.Print();
        }
    }
}
