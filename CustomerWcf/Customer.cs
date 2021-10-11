using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerWcf
{
    public class Customer
    {
        public int id { get; set; }

        public string name { get; set; }

        public string accountNo { get; set; }

        public string activeData { get; set; }

        public string customerRank { get; set; }

        public string customerType { get; set; }
        
        public string customerStatus { get; set; }
        
        public string gender { get; set; }
        
        public string DOB { get; set; }
        
        public string ntn { get; set; }
    }
}