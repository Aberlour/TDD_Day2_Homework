using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart.Lib;

namespace PotterShoppingCart.Tests
{
    /// <summary>
    /// Summary description for PaymentTest
    /// </summary>
    [TestClass]
    public class PaymentTest
    {
        public PaymentTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            
        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PaymentTest_第一集買了一本_其他都沒買_價格應為100元()
        {
            //arrange
            var shoppingList = new List<BookInfo>
                                   {
                                       new BookInfo()
                                           {
                                               Name = "哈利波特第一集",
                                               Price = 100
                                           }
                                   };
            var target = BookShop.GetBookShop();

            //act
            int acctual = target.CheckCart(shoppingList);

            //assert
            var expected = 100;
            Assert.AreEqual(expected, acctual);
        }
    }
}
