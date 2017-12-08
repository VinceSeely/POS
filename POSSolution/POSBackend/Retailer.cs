using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBackend
{
    public struct Address
    {
      public string houseAddStreet;
        public string state;
        public string zip;
        public string city;
        public string country;

        public Address (string houseAddStreet, string state, string zip, string city, string country)
        {
            this.houseAddStreet = houseAddStreet;
            this.state = state;
            this.zip = zip;
            this.city = city;
            this.country = country;
        }

    }
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
