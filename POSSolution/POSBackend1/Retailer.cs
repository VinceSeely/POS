using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{   
    public class Retailer
    {
        private int supplierID;
        private List<Address> supplierAddress = new List<Address>();
        private string supplierEmail;
        private string supplierType;
        private string name;

        public Retailer(string name, int supplierID, string supplierType)
        {
            this.name = name;
            this.supplierID = supplierID;
            this.supplierType = supplierType;
        }

        public int ID()
        {
            return supplierID;
        }
    }
}
