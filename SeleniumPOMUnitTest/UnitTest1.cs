using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using SeleniumPOMUnitTest.PageObjects;

namespace SeleniumPOMUnitTest

{
	[TestClass]
	public class UnitTest1
	{
		IWebDriver driver;
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public TestContext TestContext { get; set; }

		[TestInitialize()]
		public void SyncDriver()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArguments("--start-maximized");
			options.AddArguments("disable-infobars");
			driver = new ChromeDriver(options);
			log.Info("Test initialization finishes!");
		}

		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Data\\data.csv", "data#csv", DataAccessMethod.Sequential)] // Important tip: this is how I use a relative path in the annotation
		[TestMethod]
		public void POMTestCase1()
		{
			log.Info("Test execution starts!");

			// variable definitions (data-driven)
			string userName = Convert.ToString(this.TestContext.DataRow["userName"]);
			string passWord = Convert.ToString(this.TestContext.DataRow["passWord"]);
			string searchKeyWord = Convert.ToString(this.TestContext.DataRow["searchKeyWord"]);
			string firstName = Convert.ToString(this.TestContext.DataRow["firstName"]);
			string lastName = Convert.ToString(this.TestContext.DataRow["lastName"]);
			string emailAddress = Convert.ToString(this.TestContext.DataRow["emailAddress"]);
			string city = Convert.ToString(this.TestContext.DataRow["city"]);
			string address = Convert.ToString(this.TestContext.DataRow["address"]);
			string postalCode = Convert.ToString(this.TestContext.DataRow["postalCode"]);
			string cellPhoneNumber = Convert.ToString(this.TestContext.DataRow["cellPhoneNumber"]);
			string poNumber = Convert.ToString(this.TestContext.DataRow["poNumber"]);

			// navigate to the website
			HomePage homePage = new HomePage(driver);
			homePage.NavigateToHomePage();

			// login
			LoginPage loginPage = homePage.GoToLoginPage();
			loginPage.TypeUserName(userName); /* also has an assertion */
			loginPage.TypePassword(passWord); /* also has an assertion */
			loginPage.ConfirmLoginAndGoBackToHomePage();

			// search for an item
			SearchResultPage searchResultPage = homePage.Search(searchKeyWord);

			// put the first searched item into cart
			searchResultPage.AddCertainItemToCart(0);

			// go to the shopping cart and accept the term of service
			ShoppingCartPage shoppingCartPage = searchResultPage.GoToShoppingCartPage();
			shoppingCartPage.AcceptTermOfService();
			shoppingCartPage.AssertSubTotalPrice(); /*confirm the subtotal output*/

			// go to the checkout page and fill the info
			CheckoutPage checkoutPage = shoppingCartPage.GoToCheckoutPage();
			checkoutPage.FillInfo(firstName, lastName, emailAddress, city, address, postalCode, cellPhoneNumber, poNumber);

			// go to thank you page
			ThankYouPage thankYouPage = checkoutPage.GoToThankYouPage();

			// finish purchase and go back to home page
			HomePage homePageBack = thankYouPage.FinishPurchaseAndGoToHomePage();

			// logout
			homePageBack.Logout();
			log.Info("Test execution finishes!");
		}

		[TestCleanup]
		public void TearDown()
		{
			// driver.Close();
			driver.Quit();
			log.Info("Test all done! Task finished at " + DateTime.Now);
		}
	}
}