using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace standard_invoice_system
{
    internal class PDF
    {
        private string fileName;
        private Invoice invoice;

        //FONTS
        XFont nameFont = new XFont("Arial", 20, XFontStyle.Bold);
        XFont streetFont = new XFont("Arial", 11);
        XFont infoFont = new XFont("Arial", 11, XFontStyle.Bold);

        PdfDocument pdf;
        XGraphics gfx;
        PdfPage page;

        public PDF(string fileName, Invoice invoice)
        {
            this.fileName = fileName;

            this.invoice = invoice;

            pdf = new PdfDocument();

            page = pdf.AddPage();

            gfx = XGraphics.FromPdfPage(page);
        }

        private void SetCompanyInfo()
        {
            //TITLE OF INVOICE
            gfx.DrawString(invoice.CompanyName, nameFont, XBrushes.Black, new XRect(20, 15, page.Width, page.Height), XStringFormat.TopLeft);


            //COMPANY INFO
            gfx.DrawString("Insert Street", streetFont, XBrushes.Black, new XRect(20, 45, page.Width, page.Height), XStringFormat.TopLeft);
            gfx.DrawString("Insert City and Zip", streetFont, XBrushes.Black, new XRect(20, 60, page.Width, page.Height), XStringFormat.TopLeft);
            gfx.DrawString(invoice.CompanyNumber, streetFont, XBrushes.Black, new XRect(20, 75, page.Width, page.Height), XStringFormat.TopLeft);
        }


        public void GenerateInvoiceTable()
        {
            //Pen for overhead
            XPen pen = new XPen(XColor.FromArgb(0, 0, 0));
            pen.Width = 2;


            gfx.DrawLine(pen, new XPoint(50, 350), new XPoint(550, 350));
            gfx.DrawString("BESKRIVELSE", infoFont, XBrushes.Black, new XPoint(50, 365));
            gfx.DrawString("ANTAL", infoFont, XBrushes.Black, new XPoint(250, 365));
            gfx.DrawString("PRIS", infoFont, XBrushes.Black, new XPoint(350, 365));
            gfx.DrawString("SUM", infoFont, XBrushes.Black, new XPoint(450, 365));
            gfx.DrawLine(new XPen(XColor.FromArgb(0, 0, 0)), new XPoint(50, 375), new XPoint(550, 375));


            gfx.DrawString("Arbejdstid", streetFont, XBrushes.Black, new XPoint(50, 390));
            gfx.DrawString("12", streetFont, XBrushes.Black, new XPoint(250, 390));
            gfx.DrawString("DKK 100,00", streetFont, XBrushes.Black, new XPoint(350, 390));
            gfx.DrawString("DKK 1200,00", streetFont, XBrushes.Black, new XPoint(450, 390));

            gfx.DrawLine(pen, new XPoint(300, 600), new XPoint(550, 600));
            gfx.DrawString("SUBTOTAL", infoFont, XBrushes.Black, new XPoint(300, 615));
            gfx.DrawString("MOMS", infoFont, XBrushes.Black, new XPoint(300, 630));
            gfx.DrawString("TOTAL", infoFont, XBrushes.Black, new XPoint(300, 645));

            gfx.DrawString("DKK 1200,00", streetFont, XBrushes.Black, new XPoint(400, 615));
            gfx.DrawString("DKK 300,00", streetFont, XBrushes.Black, new XPoint(400, 630));
            gfx.DrawString("DKK 1500,00", streetFont, XBrushes.Black, new XPoint(400, 645));

        }


        public void GeneratePDF()
        {
            SetCompanyInfo();

            //INVOICE INFO
            gfx.DrawString("FAKTURANUMMER", infoFont, XBrushes.Black, new XRect((page.Width / 2) - 196, -195, page.Width, page.Height), XStringFormat.Center);
            gfx.DrawString("FAKTURADATO", infoFont, XBrushes.Black, new XRect((page.Width / 2) - 205, -180, page.Width, page.Height), XStringFormat.Center);
            gfx.DrawString("LEVERINGSDATO", infoFont, XBrushes.Black, new XRect((page.Width / 2) - 200, -165, page.Width, page.Height), XStringFormat.Center);
            gfx.DrawString("BETALINGSDATO", infoFont, XBrushes.Black, new XRect((page.Width / 2) - 200, -150, page.Width, page.Height), XStringFormat.Center);

            gfx.DrawString(invoice.InvoiceNumber.ToString(), streetFont, XBrushes.Black, new XRect((page.Width / 2) - 121, -195, page.Width, page.Height), XStringFormat.Center);
            gfx.DrawString(invoice.InvoiceDate.ToString(), streetFont, XBrushes.Black, new XRect((page.Width / 2) - 80, -180, page.Width, page.Height), XStringFormat.Center);
            gfx.DrawString(invoice.DeliveryDate.ToString(), streetFont, XBrushes.Black, new XRect((page.Width / 2) - 80, -165, page.Width, page.Height), XStringFormat.Center);
            gfx.DrawString(invoice.PaymentDate.ToString(), streetFont, XBrushes.Black, new XRect((page.Width / 2) - 89, -150, page.Width, page.Height), XStringFormat.Center);


            GenerateInvoiceTable();

            SavePDF();
        }

        public void SavePDF()
        {
            pdf.Save(@"..\..\..\Invoices\" + fileName + ".pdf");
        }
    }
}
