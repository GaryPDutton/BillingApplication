using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillingApplication;

namespace BillApplicationTests
{

    // Decribe BillCalculator
    [TestClass]
    public class BillCalculatorTests
    {
        // It returns the correct total when calculateBill is called with the default values
        [TestMethod]
        public void TestBasic()
        {
            string[] testBill = new string[]{"Cola", "Coffee", "Cheese Sandwich"};
            double expected = 3.5;
            double actual = BillCalculator.calculateBill(testBill);

            Assert.AreEqual(expected, actual);
        }

        //It returns the correct total when calculateBill is called with an order containing duplicate value
        [TestMethod]
        public void TestWithDuplicates()
        {
            string[] testBill = new string[] { "Cola", "Coffee", "Cola" };
            double expected = 2;
            double actual = BillCalculator.calculateBill(testBill);

            Assert.AreEqual(expected, actual);
        }

        //It returns the correct total  calculateBill is called with an order which is empty
        [TestMethod]
        public void TestWithEmpty()
        {
            string[] testBill = new string[]{};
            double expected = 0;
            double actual = BillCalculator.calculateBill(testBill);

            Assert.AreEqual(expected, actual);
        }
    }
}
