using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingApplication
{
   
    //MOCK service to return list of current menu items
    class Menu
    {
         public static IEnumerable<MenuItem> get()
         {
             //Define hard coded menu list
             MenuItem[] items = new[]
                {
                    new MenuItem {
                    Product= "Cola",
                    Temperature= "Cold",  
                    Cost= 0.5
                }, new MenuItem {
                    Product= "Coffee",
                    Temperature= "Hot",  
                    Cost= 1
                }, new MenuItem {
                    Product= "Cheese Sandwich",
                    Temperature= "Cold",  
                    Cost= 2
                }, new MenuItem {
                    Product= "Steak Sandwich",
                    Temperature= "Hot",  
                    Cost= 4.5
                }};

             //Return menu items
             return items;
         }
    }
}
