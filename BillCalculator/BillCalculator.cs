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

        //Check if any items are Hot
        public static bool containsHotFood(IEnumerable<string> orderItems)
        {
            //Get the menu items 
            var menuItems = Menu.get();

            //Loop through order checking temperature
            foreach (var product in orderItems)
            {
                //Get temperature and return true if is a Hot item
                var menuItem = menuItems.Where(item => item.Product == product).First();
                if (menuItem.Temperature == "Hot" && menuItem.Category == "Food")
                {
                    return true;
                }
                    
            }

            return false;
        }

        //Check if any items are Food
        public static bool containsFood(IEnumerable<string> orderItems)
        {
            //Get the menu items 
            var menuItems = Menu.get();

            //Loop through order checking category
            foreach (var product in orderItems)
            {
                //Get category and return true if is a Food item
                var category = menuItems.Where(item => item.Product == product).First().Category;
                if(category == "Food")
                {
                    return true;
                }
                    
            }

            return false;
        }


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
                if (serviceCharge > MAX_SERVICE_CHARGE)
                {
                    serviceCharge = MAX_SERVICE_CHARGE;
                }
            }

            //Round the service charge to 2 decimal places and return
            return Math.Round(serviceCharge, 2);
            
        }

    }
}
