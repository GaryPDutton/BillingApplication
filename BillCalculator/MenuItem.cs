using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingApplication
{
    //Class representing a item on the menu
    public class MenuItem
    {
        public string Product { get; set; }
        public string Temperature { get; set; }
        public double Cost { get; set; }
        public string Category { get; set; }
    }
}
