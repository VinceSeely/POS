using System;

namespace POSBackend
{
    public class Address
    {
        public string streetAddress { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public int zipCode { get; set; }

      public string GetRestOfAddress()
      {
         return $"{city}, {state}, {zipCode}, {country}";
      }
   }
}