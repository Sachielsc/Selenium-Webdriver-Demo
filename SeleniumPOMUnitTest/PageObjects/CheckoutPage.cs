using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMUnitTest.PageObjects
{
    class CheckoutPage
	{
        private IWebDriver driver;
        private WebDriverWait wait;

		[FindsBy(How = How.CssSelector, Using = "div#confirm-order-buttons-container>input.confirm-order-next-step-button")]
		private IWebElement confirmOrderButton;

		public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            PageFactory.InitElements(driver, this);
        }

		public void FillInfo(string FirstName, string LastName, string Email, string City, string Address, string PostalCode, string PhoneNumber, string PONumber)
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
			waitUntilPaymentMethodList.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.payment-method div.method-name img[alt='Purchase Order']")));
			driver.FindElement(By.CssSelector("div.payment-method div.payment-details>input#paymentmethod_3")).Click();
			driver.FindElement(By.CssSelector("div#payment-method-buttons-container>input.payment-method-next-step-button")).Click();

			// payment information
			WebDriverWait waitUntilPONumber = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			waitUntilPONumber.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.payment-info table>tbody>tr")));
			driver.FindElement(By.CssSelector("div.payment-info tbody input#PurchaseOrderNumber")).Clear();
			driver.FindElement(By.CssSelector("div.payment-info tbody input#PurchaseOrderNumber")).SendKeys(PONumber);
			driver.FindElement(By.CssSelector("div#payment-info-buttons-container>input.payment-info-next-step-button")).Click();
		}

		public ThankYouPage GoToThankYouPage()
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(confirmOrderButton));
			confirmOrderButton.Click();
			return new ThankYouPage(driver);
		}
	}
}