using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using POMExample.PageObjects;

namespace SeleniumNewDemo
{
	class Demo
	{
		static void Main(string[] args)
		{
			// set up
			ChromeOptions options = new ChromeOptions();
			options.AddArguments("--start-maximized");
			options.AddArguments("disable-infobars");
			IWebDriver driver = new ChromeDriver(options);

			// create the test cases
			void TestLocalDemo()
			{
				string appURL;
				Stopwatch timer = new Stopwatch();
				// absolute path (for test 1)
				// appURL = "file:///C:/Users/Admin/Desktop/repos/SeleniumNewDemo/SeleniumNewDemo/Resource/Demo.html";

				// relative path (for test 1)
				appURL = "file:///" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Resource\\Demo.html";

				// try to find by Id
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.Id("target"));
				timer.Stop();
				long elapsedTimeId = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by name
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.Name("target"));
				timer.Stop();
				long elapsedTimeName = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by class
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.ClassName("add-info")).FindElement(By.ClassName("buttons")).FindElement(By.ClassName("product-box-add-to-cart-button"));
				timer.Stop();
				long elapsedTimeClassName = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by partial link
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.PartialLinkText("Partial"));
				timer.Stop();
				long elapsedTimePartialLink = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by complete link
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.LinkText("Partial Link Test Here"));
				timer.Stop();
				long elapsedTimeLink = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by tag name
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.ClassName("add-info")).FindElement(By.ClassName("buttons")).FindElement(By.TagName("input"));
				timer.Stop();
				long elapsedTimeTagName = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by xPath
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.XPath("//a[@class='ico-register']"));
				timer.Stop();
				long elapsedTimeXPath = timer.ElapsedMilliseconds;
				timer.Reset();

				driver.Close();
				Console.Out.Write("\nFind the \"add to cart\" button by Id: " + elapsedTimeId + " Milliseconds\n");
				Console.Out.Write("\nFind the \"add to cart\" button by Name: " + elapsedTimeName + " Milliseconds\n");
				Console.Out.Write("\nFind the \"add to cart\" button by Class: " + elapsedTimeClassName + " Milliseconds\n");
				Console.Out.Write("\nFind the Link beside \"add to cart\" button by Partial Link: " + elapsedTimePartialLink + " Milliseconds\n");
				Console.Out.Write("\nFind the Link beside \"add to cart\" button by Complete Link: " + elapsedTimeLink + " Milliseconds\n");
				Console.Out.Write("\nFind the \"add to cart\" button by Tag: " + elapsedTimeTagName + " Milliseconds\n");
				Console.Out.Write("\nFind the Link beside \"add to cart\" button by XPath: " + elapsedTimeXPath + " Milliseconds\n");
			}

			void TestDemowebshopSite()
			{
				string appURL;
				// Demo website (for test 2)
				appURL = "http://demowebshop.tricentis.com/";

				Stopwatch timer = new Stopwatch();

				// try to find by Id
				timer.Start();
				driver.Navigate().GoToUrl(appURL);
				timer.Stop();
				long navigateTimeId = timer.ElapsedMilliseconds;
				timer.Reset();
				timer.Start();
				driver.FindElement(By.Id("newsletter-email"));
				timer.Stop();
				long elapsedTimeId = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by name
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.Name("NewsletterEmail"));
				timer.Stop();
				long elapsedTimeName = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by class name and tag name
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.ClassName("newsletter-subscribe-block")).FindElement(By.ClassName("newsletter-email")).FindElement(By.TagName("input"));
				timer.Stop();
				long elapsedTimeClassName = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by xPath
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.XPath("//*[@id='newsletter-email']"));
				timer.Stop();
				long elapsedTimeXPath = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by CSS
				driver.Navigate().GoToUrl(appURL);
				timer.Start();
				driver.FindElement(By.CssSelector("input[type='text']"));
				timer.Stop();
				long elapsedTimeCSS = timer.ElapsedMilliseconds;
				timer.Reset();

				driver.Close();
				Console.Out.Write("\nEntering the website firstly: " + navigateTimeId + " Milliseconds\n");
				Console.Out.Write("\nFind the element by Id: " + elapsedTimeId + " Milliseconds\n");
				Console.Out.Write("\nFind the element by Name: " + elapsedTimeName + " Milliseconds\n");
				Console.Out.Write("\nFind the element by Class name and Tag name: " + elapsedTimeClassName + " Milliseconds\n");
				Console.Out.Write("\nFind the element by Xpath: " + elapsedTimeXPath + " Milliseconds\n");
				Console.Out.Write("\nFind the element by CSS: " + elapsedTimeCSS + " Milliseconds\n");
			}

			void TestXpathLocator()
			{
				// Demo website
				string appURL = "http://demowebshop.tricentis.com/";
				Stopwatch timer = new Stopwatch();

				// navigate to the website
				timer.Start();
				driver.Navigate().GoToUrl(appURL);
				timer.Stop();
				long navigateTimeId = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by xPath1
				timer.Start();
				IWebElement elementFound1 = driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[4]/div[3]/div/div/div[3]/div[2]/div/div[2]/h2/a"));
				timer.Stop();
				string elementFound1text = elementFound1.Text;
				long elapsedTimeXPath1 = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by xPath2
				timer.Start();
				IWebElement elementFound2 = driver.FindElement(By.XPath("//h2[@class='product-title']/a[@href='/25-virtual-gift-card']"));
				timer.Stop();
				string elementFound2text = elementFound2.Text;
				long elapsedTimeXPath2 = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find by xPath3 (FindElements)
				timer.Start();
				IReadOnlyCollection<IWebElement> elementFound3 = driver.FindElements(By.XPath("//a[@href='/25-virtual-gift-card']"));
				timer.Stop();
				string elementFound3text = elementFound3.ElementAt(1).Text;
				long elapsedTimeXPath3 = timer.ElapsedMilliseconds;
				timer.Reset();

				driver.Close();
				Console.Out.Write("\nEntering the website firstly: " + navigateTimeId + " Milliseconds\n");
				Console.Out.Write("\nFind the element \"" + elementFound1text + "\" by Xpath: " + elapsedTimeXPath1 + " Milliseconds\n");
				Console.Out.Write("\nFind the element \"" + elementFound2text + "\" by Xpath: " + elapsedTimeXPath2 + " Milliseconds\n");
				Console.Out.Write("\nFind the element \"" + elementFound3text + "\" by Xpath: " + elapsedTimeXPath3 + " Milliseconds\n");
			}

			void TestCSSLocator()
			{
				// Demo website
				string appURL = "http://demowebshop.tricentis.com/";
				Stopwatch timer = new Stopwatch();

				// navigate to the website
				timer.Start();
				driver.Navigate().GoToUrl(appURL);
				timer.Stop();
				long navigateTimeId = timer.ElapsedMilliseconds;
				timer.Reset();
				
				/*
				 * Syntax:
				 * css=<HTML tag><. Or #><value of Class or ID attribute><[attribute=Value of attribute]>
				 * 
				 * Two or more attributes can also be furnished in the syntax. For example, “css=input#Passwd[type=’password’][name=’Passwd’]”.
				 */

				// try to find target by CSS1 (FindElements)
				timer.Start();
				IReadOnlyCollection<IWebElement> elementFoundByCss1 = driver.FindElements(By.CssSelector("a[href='/25-virtual-gift-card']"));
				timer.Stop();
				long elapsedTimeCSS1 = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find target by CSS2
				timer.Start();
				IWebElement elementFoundByCss2 = driver.FindElement(By.CssSelector("h2.product-title")).FindElement(By.CssSelector("a[href='/25-virtual-gift-card']"));
				timer.Stop();
				long elapsedTimeCSS2 = timer.ElapsedMilliseconds;
				timer.Reset();

				driver.Close();
				Console.Out.Write("\nEntering the website firstly: " + navigateTimeId + " Milliseconds\n");
				Console.Out.Write("\nFind the element by CSS: " + elapsedTimeCSS1 + " Milliseconds\n");
				Console.Out.Write("\nFind the element by CSS: " + elapsedTimeCSS2 + " Milliseconds\n");
			}

			void ProcessPhptravels()
			{
				// Phptravels website
				string appURL = "https://www.phptravels.net/";
				Stopwatch timer = new Stopwatch();

				// navigate to the website
				timer.Start();
				driver.Navigate().GoToUrl(appURL);
				timer.Stop();
				long navigateTimeId = timer.ElapsedMilliseconds;
				timer.Reset();

				// try to find my account button by xpath locator
				timer.Start();
				IWebElement elementFoundByCss1 = driver.FindElement(By.XPath("(//a[contains(text(),'My Account')])[2]"));
				timer.Stop();
				long elapsedTimeCSS1 = timer.ElapsedMilliseconds;
				timer.Reset();
				//WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
				//wait.Until(ExpectedConditions.ElementIsVisible(By.Id("li_myaccount")));
				elementFoundByCss1.Click();

				// driver.Close();
				Console.Out.Write("\nEntering the website firstly: " + navigateTimeId + " Milliseconds\n");
				Console.Out.Write("\nFind the element by CSS: " + elapsedTimeCSS1 + " Milliseconds\n");
			}

			void ProcessDemoWebShop()
			{
				// Demo website
				string appURL = "http://demowebshop.tricentis.com/";
				string logInAccount = "sachielsc@gmail.com";
				string logInPassword = "scsgdtcy3";
				string searchKey = "Computing and Internet";
				string FirstName = "Charles";
				string LastName = "Shu";
				string Email = "sachielsc@gmail.com";
				string City = "Wuhan";
				string Address = "This is the address.";
				string PostalCode = "This is the postcode";
				string PhoneNumber = "This is the phone number";
				string PONumber = "What is a PONumber?";

				Stopwatch timerNavigate = new Stopwatch();
				Stopwatch timerWholeProcess = new Stopwatch();
				int navigateTime;
				int processTime;

				void NavigateToWebsite()
				{
					// navigate to the website
					driver.Navigate().GoToUrl(appURL);
				}

				void LogIn()
				{
					// Log in
					driver.FindElement(By.CssSelector("div.header-links>ul>li>a[href='/login']")).Click();
					driver.FindElement(By.CssSelector("div.form-fields div.inputs>input#Email")).SendKeys(logInAccount);
					driver.FindElement(By.CssSelector("div.form-fields div.inputs>input#Password")).SendKeys(logInPassword);
					driver.FindElement(By.CssSelector("form[action='/login']>div.buttons>input[value='Log in']")).Click();
				}

				void ClickBooksTab()
				{
					// Click the BOOKS tab by CSS locator
					IWebElement bookTab = driver.FindElement(By.CssSelector("ul.top-menu")).FindElement(By.CssSelector("li")).FindElement(By.CssSelector("a"));
					bookTab.Click();
				}

				void UseTheSearchBar()
				{
					// Fill the search input field
					IWebElement inputField = driver.FindElement(By.CssSelector("div.search-box")).FindElement(By.CssSelector("form[action='/search']")).FindElement(By.CssSelector("input[type='text']"));
					inputField.SendKeys(searchKey);

					// Click the search button
					driver.FindElement(By.CssSelector("div.search-box")).FindElement(By.CssSelector("form[action='/search']")).FindElement(By.CssSelector("input[type='submit']")).Click();
				}

				void PutFirstItemIntoCart()
				{
					// Put the first item into cart
					IReadOnlyCollection<IWebElement> addToCartButtons = driver.FindElements(By.CssSelector("input[type='button'][value='Add to cart']"));
					addToCartButtons.ElementAt(0).Click();
				}

				void GoToShoppingCart()
				{
					// Go to the shopping cart page
					driver.FindElement(By.CssSelector("div.header-links li#topcartlink>a[href='/cart']")).Click();
				}

				void GoToCheckout()
				{
					// Go to the checkout page
					driver.FindElement(By.CssSelector("div.totals>div.terms-of-service>input#termsofservice")).Click();
					driver.FindElement(By.CssSelector("div.checkout-buttons button#checkout")).Click();
				}

				void FillInfo()
				{
					// Fill the info
					// billing address
					SelectElement selectAddress = new SelectElement(driver.FindElement(By.Id("billing-address-select")));
					selectAddress.SelectByText("New Address");
					driver.FindElement(By.Id("BillingNewAddress_FirstName")).Clear();
					driver.FindElement(By.Id("BillingNewAddress_FirstName")).SendKeys(FirstName);
					driver.FindElement(By.Id("BillingNewAddress_LastName")).Clear();
					driver.FindElement(By.Id("BillingNewAddress_LastName")).SendKeys(LastName);
					driver.FindElement(By.Id("BillingNewAddress_Email")).Clear();
					driver.FindElement(By.Id("BillingNewAddress_Email")).SendKeys(Email);
					SelectElement selectBillingCountry = new SelectElement(driver.FindElement(By.Id("BillingNewAddress_CountryId")));
					selectBillingCountry.SelectByText("China");
					driver.FindElement(By.Id("BillingNewAddress_City")).Clear();
					driver.FindElement(By.Id("BillingNewAddress_City")).SendKeys(City);
					driver.FindElement(By.Id("BillingNewAddress_Address1")).Clear();
					driver.FindElement(By.Id("BillingNewAddress_Address1")).SendKeys(Address);
					driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).Clear();
					driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).SendKeys(PostalCode);
					driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).Clear();
					driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).SendKeys(PhoneNumber);
					driver.FindElement(By.CssSelector("div#checkout-step-billing>div#billing-buttons-container>input.button-1")).Click();

					// shipping address
					WebDriverWait waitUntilShippingAddress = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
					waitUntilShippingAddress.Until(ExpectedConditions.ElementIsVisible(By.Id("shipping-address-select")));
					SelectElement select1 = new SelectElement(driver.FindElement(By.Id("shipping-address-select")));
					select1.SelectByText("New Address");
					driver.FindElement(By.Id("ShippingNewAddress_FirstName")).Clear();
					driver.FindElement(By.Id("ShippingNewAddress_FirstName")).SendKeys(FirstName);
					driver.FindElement(By.Id("ShippingNewAddress_LastName")).Clear();
					driver.FindElement(By.Id("ShippingNewAddress_LastName")).SendKeys(LastName);
					driver.FindElement(By.Id("ShippingNewAddress_Email")).Clear();
					driver.FindElement(By.Id("ShippingNewAddress_Email")).SendKeys(Email);
					SelectElement selectShippingCountry = new SelectElement(driver.FindElement(By.Id("ShippingNewAddress_CountryId")));
					selectShippingCountry.SelectByText("China");
					driver.FindElement(By.Id("ShippingNewAddress_City")).Clear();
					driver.FindElement(By.Id("ShippingNewAddress_City")).SendKeys(City);
					driver.FindElement(By.Id("ShippingNewAddress_Address1")).Clear();
					driver.FindElement(By.Id("ShippingNewAddress_Address1")).SendKeys(Address);
					driver.FindElement(By.Id("ShippingNewAddress_ZipPostalCode")).Clear();
					driver.FindElement(By.Id("ShippingNewAddress_ZipPostalCode")).SendKeys(PostalCode);
					driver.FindElement(By.Id("ShippingNewAddress_PhoneNumber")).Clear();
					driver.FindElement(By.Id("ShippingNewAddress_PhoneNumber")).SendKeys(PhoneNumber);
					driver.FindElement(By.CssSelector("div#shipping-buttons-container>input")).Click();

					// shipping method
					WebDriverWait waitUntilMethodList = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
					waitUntilMethodList.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.shipping-method>ul.method-list")));
					driver.FindElement(By.CssSelector("ul.method-list input#shippingoption_1")).Click();
					driver.FindElement(By.CssSelector("div#shipping-method-buttons-container>input.shipping-method-next-step-button")).Click();

					// payment method
					WebDriverWait waitUntilPaymentMethodList = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
					waitUntilPaymentMethodList.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.payment-method>ul.method-list")));
					driver.FindElement(By.CssSelector("div.payment-method div.payment-details>input#paymentmethod_3")).Click();
					driver.FindElement(By.CssSelector("div#payment-method-buttons-container>input.payment-method-next-step-button")).Click();

					// payment information
					WebDriverWait waitUntilPONumber = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
					waitUntilPONumber.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.payment-info table>tbody>tr")));
					driver.FindElement(By.CssSelector("div.payment-info tbody input#PurchaseOrderNumber")).Clear();
					driver.FindElement(By.CssSelector("div.payment-info tbody input#PurchaseOrderNumber")).SendKeys(PONumber);
					driver.FindElement(By.CssSelector("div#payment-info-buttons-container>input.payment-info-next-step-button")).Click();

					// confirm order
					WebDriverWait waitUntilConfirm = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
					waitUntilConfirm.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div#confirm-order-buttons-container>input.confirm-order-next-step-button")));
					driver.FindElement(By.CssSelector("div#confirm-order-buttons-container>input.confirm-order-next-step-button")).Click();

					// thank you page
					WebDriverWait waitUntilThankYou = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
					waitUntilThankYou.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.order-completed input.order-completed-continue-button")));
					driver.FindElement(By.CssSelector("div.order-completed input.order-completed-continue-button")).Click();
				}

				void Logout()
				{
					// log out the website
					driver.FindElement(By.CssSelector("div.header-links>ul>li>a[href='/logout']")).Click();
				}

				void ConsoleOutput()
				{
					navigateTime = (int)(timerNavigate.ElapsedMilliseconds / 1000);
					processTime = (int)(timerWholeProcess.ElapsedMilliseconds / 1000);
					Console.Out.Write("\n\n\nConsole output:\n\n");
					Console.Out.Write("Entering the website firstly takes " + navigateTime + " Seconds\n");
					Console.Out.Write("Whole process takes " + processTime + " Seconds\n");
				}

				// run the test steps
				timerNavigate.Start();
				timerWholeProcess.Start();
				NavigateToWebsite();
				timerNavigate.Stop();
				LogIn();
				// ClickBooksTab();
				UseTheSearchBar();
				PutFirstItemIntoCart();
				GoToShoppingCart();
				GoToCheckout();
				FillInfo();
				Logout();
				timerWholeProcess.Stop();
				ConsoleOutput();
			}

			void POMTestCase1()
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

			// run the test cases
			try
			{
				// ProcessDemoWebShop();
				POMTestCase1();
			}
			catch (Exception e)
			{
				// throw e;
				Console.Out.Write("\nError detected!\nError Message: \n" + e.Message);
			}
			finally
			{
				driver.Close();
				Console.Out.Write("\nTest completed!\n\nPress ENTER to exit\n");
				Console.ReadLine();
				driver.Quit();
			}
		}
	}
}