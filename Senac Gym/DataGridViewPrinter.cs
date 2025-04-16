using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senac_Gym
{
    public class DataGridViewPrinter
    {
        private DataGridView dataGridView;
        private PrintDialog printDialog;
        private PrintDocument printDocument;
        private Bitmap bitmap;

        public DataGridViewPrinter(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            printDialog = new PrintDialog();
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPage;
        }

        public void Print()
        {
            try
            {
                // Capture the DataGridView as an image
                bitmap = new Bitmap(dataGridView.Width, dataGridView.Height);
                dataGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView.Width, dataGridView.Height));

                // Show the print dialog
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.PrinterSettings = printDialog.PrinterSettings;
                    printDocument.Print();
                }
            }
            finally
            {
                // Dispose the bitmap after printing
                bitmap?.Dispose();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            if (bitmap == null) return;

            // Calculate scaling to maintain aspect ratio
            float widthRatio = (float)e.MarginBounds.Width / bitmap.Width;
            float heightRatio = (float)e.MarginBounds.Height / bitmap.Height;
            float scale = Math.Min(widthRatio, heightRatio);

            // Calculate scaled dimensions
            int scaledWidth = (int)(bitmap.Width * scale);
            int scaledHeight = (int)(bitmap.Height * scale);

            // Center the image on the page
            int x = e.MarginBounds.Left + (e.MarginBounds.Width - scaledWidth) / 2;
            int y = e.MarginBounds.Top + (e.MarginBounds.Height - scaledHeight) / 2;

            // Draw the image with correct scaling and positioning
            e.Graphics.DrawImage(
                bitmap,
                new Rectangle(x, y, scaledWidth, scaledHeight),
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                GraphicsUnit.Pixel
            );

            e.HasMorePages = false; // No additional pages to print
        }
    }
}
