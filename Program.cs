using standard_invoice_system;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

Invoice sample = new Invoice(10, DateTime.Now.Date, DateTime.Now.Date, DateTime.Now.Date.AddDays(10));

PDF pdf = new PDF("TestPDF1", sample);



pdf.GeneratePDF();