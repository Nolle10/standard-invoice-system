using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace standard_invoice_system
{
    internal class Invoice
    {
        private Company company = Company.Instance;
        private string companyName;
        private string companyAddress;
        private string companyNumber;
        private long invoiceNumber;
        private DateTime invoiceDate;
        private DateTime deliveryDate;
        private DateTime paymentDate;

        public Invoice(long invoiceNumber, DateTime invoiceDate, DateTime deliveryDate, DateTime paymentDate)
        {
            companyName = company.CompanyName;
            companyAddress = company.CompanyAddress;
            companyNumber = company.CompanyNumber;
            this.invoiceNumber = invoiceNumber;
            this.invoiceDate = invoiceDate;
            this.deliveryDate = deliveryDate;
            this.paymentDate = paymentDate;
        }

        public string CompanyName { get => companyName; set => companyName = value; }
        public string CompanyAddress { get => companyAddress; set => companyAddress = value; }
        public string CompanyNumber { get => companyNumber; set => companyNumber = value; }
        public long InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public DateTime InvoiceDate { get => invoiceDate; set => invoiceDate = value; }
        public DateTime DeliveryDate { get => deliveryDate; set => deliveryDate = value; }
        public DateTime PaymentDate { get => paymentDate; set => paymentDate = value; }
    }
}