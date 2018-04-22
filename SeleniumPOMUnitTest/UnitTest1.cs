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
			// variable definitions
			string userName = "sachielsc@gmail.com";
			string passWord = "scsgdtcy3";
			string searchKeyWord = "blue";
			string firstName = "Chris";
			string lastName = "SHU";
			string emailAddress = "sachielsc@gmail.com";
			string city = "This is city";
			string address = "This is address";
			string postalCode = "Postal code here";
			string cellPhoneNumber = "111";
			string poNumber = "PO Number here";

			// navigate to the website
			HomePage homePage = new HomePage(driver);
			homePage.NavigateToHomePage();

			// login
			LoginPage loginPage = homePage.GoToLoginPage();
			loginPage.TypeUserName(userName); /* also confirm the username input*/
			loginPage.TypePassword(passWord); /* also confirm the password input*/
			loginPage.ConfirmLoginAndGoBackToHomePage();

			// search for an item
			SearchResultPage searchResultPage = homePage.Search(searchKeyWord);

			// put a searched item into cart
			searchResultPage.AddCertainItemToCart(1);

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
		}

		[TestCleanup]
		public void TearDown()
		{
			// driver.Close();
			driver.Quit();
		}
	}
}