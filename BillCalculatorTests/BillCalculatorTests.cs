using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillingApplication;
using System.Collections.Generic;

namespace BillApplicationTests
{

    // Decribe BillCalculator
    [TestClass]
    public class BillCalculatorTests
    {
        // It returns the correct total when calculateBill is called with the default values
        [TestMethod]
        public void Test_calculateBill_Basic()
        {
            string[] testBill = new string[]{"Cola", "Coffee", "Cheese Sandwich"};
            double expected = 3.5;
            double actual = BillCalculator.calculateBill(testBill);

            Assert.AreEqual(expected, actual);
        }

        //It returns the correct total when calculateBill is called with an order containing duplicate value
        [TestMethod]
        public void Test_calculateBill_WithDuplicates()
        {
            string[] testBill = new string[] { "Cola", "Coffee", "Cola" };
            double expected = 2;
            double actual = BillCalculator.calculateBill(testBill);

            Assert.AreEqual(expected, actual);
        }

        //It returns the correct total when calculateBill is called with an order which is empty
        [TestMethod]
        public void Test_calculateBill_WithEmpty()
        {
            string[] testBill = new string[]{};
            double expected = 0;
            double actual = BillCalculator.calculateBill(testBill);

            Assert.AreEqual(expected, actual);
        }

        //It returns true when containsHot is called when an item is Hot Food
        [TestMethod]
        public void Test_containsHot_WithHotFood()
        {
            string[] testBill = new string[] { "Cola", "Coffee","Steak Sandwich" };
            bool result = BillCalculator.containsHotFood(testBill);

            Assert.IsTrue(result);
        }

        //It returns true when containsHot is called when no items are Hot Food
        [TestMethod]
        public void Test_containsHot_WithoutHot()
        {
            string[] testBill = new string[] { "Cola", "Cheese Sandwich" };
            bool result = BillCalculator.containsHotFood(testBill);

            Assert.IsFalse(result);
        }

        //It returns true when containsFood is called when an item is Food
        [TestMethod]
        public void Test_containsFood_WithFood()
        {
            string[] testBill = new string[] { "Cola", "Cheese Sandwich" };
            bool result = BillCalculator.containsFood(testBill);

            Assert.IsTrue(result);
        }

        //It returns true when containsFood is called when no items are Food
        [TestMethod]
        public void Test_containsFood_WithoutFood()
        {
            string[] testBill = new string[] { "Cola", "Coffee" };
            bool result = BillCalculator.containsFood(testBill);

            Assert.IsFalse(result);
        }

        // It returns the correct service charge when calculateServiceCharge is called with an order containing Hot food
        [TestMethod]
        public void Test_calculateServiceCharge_HotFood()
        {
            string[] testBill = new string[] { "Cola", "Coffee", "Cheese Sandwich", "Steak Sandwich" };
            double expected = 1.6;
            double actual = BillCalculator.calculateServiceCharge(testBill);

            Assert.AreEqual(expected, actual);
        }


        // It returns the correct service charge when calculateServiceCharge is called with an order containing food but none is cold
        [TestMethod]
        public void Test_calculateServiceCharge_ColdFood()
        {
            string[] testBill = new string[] { "Cola", "Coffee", "Cheese Sandwich" };
            double expected = 0.35;
            double actual = BillCalculator.calculateServiceCharge(testBill);

            Assert.AreEqual(expected, actual);
        }

        // It returns the correct service charge when calculateServiceCharge is called with an order without any food
        [TestMethod]
        public void Test_calculateServiceCharge_NoFood()
        {
            string[] testBill = new string[] { "Cola", "Coffee", "Cola", "Coffee" };
            double expected = 0;
            double actual = BillCalculator.calculateServiceCharge(testBill);

            Assert.AreEqual(expected, actual);
        }

        // It returns the maximum service charge of 20 when calculateServiceCharge is called with an order is very large 
        [TestMethod]
        public void Test_calculateServiceCharge_Maximum()
        {
            List<string> testBill = new List<string>();

            //Create very large bill 
            for (int a = 0; a < 40; a = a + 1)
            {
                testBill.Add("Steak Sandwich");
            }

            double expected = 20;
            double actual = BillCalculator.calculateServiceCharge(testBill);

            Assert.AreEqual(expected, actual);
        }

        
    }
}
