using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingApplication
{
    public static class BillCalculator
    {
        //Calculate the bill for the supplied order items
        public static double calculateBill(IEnumerable<string> orderItems)
        {

            double total = 0;

            //Get the menu items 
            var menuItems = Menu.get();

            //Loop through order adding cost for each item to the total
            foreach(var product in orderItems)
            {
                //Add the total for matching items
                //Todo: No requirement to handle erros for products not on menu 
                total += menuItems
                    .Where(item => item.Product == product)
                    .First()
                    .Cost;
            }

            return total;
        }

    }
}
