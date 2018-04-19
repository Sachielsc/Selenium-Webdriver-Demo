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
	public class test
	{
		IWebDriver driver;

		[TestInitialize()]
		public void SyncDriver()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArguments("--start-maximized");
			options.AddArguments("disable-infobars");
			driver = new ChromeDriver(options);
		}

		[TestMethod]
		public void POMTestCase1()
		{
			// navigate to the website
			HomePage homePage = new HomePage(driver);
			homePage.NavigateToHomePage();

			// login
			LoginPage loginPage = homePage.GoToLoginPage();
			loginPage.TypeUserName("sachielsc@gmail.com");
			loginPage.TypePassword("scsgdtcy3");
			loginPage.ConfirmLoginAndGoBackToHomePage();

			// search for an item
			SearchResultPage searchResultPage = homePage.Search("blue");

			// put a searched item into cart
			searchResultPage.AddCertainItemToCart(1);

			// go to the shopping cart and accept the term of service
			ShoppingCartPage shoppingCartPage = searchResultPage.GoToShoppingCartPage();
			shoppingCartPage.AcceptTermOfService();

			// go to the checkout page and fill the info
			CheckoutPage checkoutPage = shoppingCartPage.GoToCheckoutPage();
			checkoutPage.FillInfo("Chris", "SHU", "sachielsc@gmail.com", "This is city", "This is address", "Postal code here", "111", "PO Number here");

			// go to thank you page
			ThankYouPage thankYouPage = checkoutPage.GoToThankYouPage();

			// finish purchase and go back to home page
			HomePage homePageBack = thankYouPage.FinishPurchaseAndGoToHomePage();

			// logout
			homePageBack.Logout();
		}

		[TestCleanup]
		public void TearDown()
		{
			driver.Close();
			Console.Out.Write("\nTest completed!\n\nPress ENTER to exit\n");
			Console.ReadLine();
			driver.Quit();
		}
	}
}