using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace standard_invoice_system
{
    internal class Company
    {
        private static Company instance = null;
        private static readonly object padlock = new object();
        private string companyName;
        private string companyAddress;
        private string companyNumber;


        Company(string companyName, string companyAddress, string companyNumber) {
            this.companyName = companyName;
            this.companyAddress = companyAddress;
            this.companyNumber = companyNumber;
        }

        public static Company Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) 
                    {
                        //TODO: Read from CompanyInfo.csv and insert into columns
                        instance = new Company("Det Danske Firma A/S", "Danmarks Allé 43","CVR: " + "55345234");
                    }
                    return instance;
                }

            }

        }

        public string CompanyName { get => companyName; set => companyName = value; }
        public string CompanyAddress { get => companyAddress; set => companyAddress = value; }
        public string CompanyNumber { get => companyNumber; set => companyNumber = value; }
    }
}
