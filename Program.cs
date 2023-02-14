using standard_invoice_system;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);


Invoice sample = new Invoice("Sample Company LLC", "Non Street 3306 44453 New Land", "111222333", 10, DateTime.Now.Date, DateTime.Now.Date, DateTime.Now.Date.AddDays(10));

PDF pdf = new PDF("TestPDF", sample);

pdf.GeneratePDF();