using standard_invoice_system;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
Thread.CurrentThread.Priority = ThreadPriority.Highest;

int i = 1;

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();


for (i = 0; i < 10000; i++)
{
    Invoice sample = new Invoice(10, DateTime.Now.Date, DateTime.Now.Date, DateTime.Now.Date.AddDays(10));
    PDF pdf = new PDF("TestPDF1", sample);
    pdf.GeneratePDF();
}

stopwatch.Stop();

Console.WriteLine("It took: " + stopwatch.ElapsedMilliseconds + " ms");

await File.AppendAllTextAsync(@"..\..\..\TimeLog.txt","\n" + DateTime.UtcNow + " : " + stopwatch.ElapsedMilliseconds.ToString() + "ms" + " (Amount of runs: " + i + ")");

