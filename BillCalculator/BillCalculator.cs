using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingApplication
{
    //Main class for calculating the bill and service charge
    public static class BillCalculator
    {
        //Constants
        private const double SERVICE_CHARGE = 0.1;
        private const double SERVICE_CHARGE_HOT = 0.2;
        private const double MAX_SERVICE_CHARGE = 20;

        public static IEnumerable<MenuItem> getMenuItems(IEnumerable<string> orderItems)
        {
            //Get menu items
            var menuItems = Menu.get().ToList(); ;

            //Build collection of menuItems matching the order
            var returnItems = orderItems.Select(product => menuItems.Find(item => item.Product == product)).ToList();

            return returnItems;
        }

        //Check if any items are Hot Food
        public static bool containsHotFood(IEnumerable<string> orderItems)
        {
            //Check if any items are Hot Food
           return getMenuItems(orderItems).Where(item => item.Category == "Food" && item.Temperature == "Hot").Count() > 0;
        }

        //Check if any items are Food
        public static bool containsFood(IEnumerable<string> orderItems)
        {
            //Check if any items are Food
            return getMenuItems(orderItems).Where(item => item.Category == "Food").Count() > 0;
        }


        //Calculate the bill for the supplied order items
        public static double calculateBill(IEnumerable<string> orderItems)
        {
            //Get the sum of all the items on the menu
            double total = getMenuItems(orderItems).Sum(item => item.Cost);

            return total;
        }

        //Calculate the service charge for the given order
        public static double calculateServiceCharge(IEnumerable<string> orderItems)
        {
            double serviceCharge = 0;
            
            //Check if orderItems conatin any Food items
            if (containsFood(orderItems))
            {
                double bill = calculateBill(orderItems);

                //Check if order items contain and Hot items
                if (containsHotFood(orderItems))
                {
                    serviceCharge = bill * SERVICE_CHARGE_HOT;
                }
                else
                {
                    serviceCharge = bill * SERVICE_CHARGE;
                }

                //If the service charge is above the maximum set it to the maximum
                serviceCharge = Math.Min(serviceCharge, MAX_SERVICE_CHARGE);
            }

            //Round the service charge to 2 decimal places and return
            return Math.Round(serviceCharge, 2);
            
        }

    }
}
