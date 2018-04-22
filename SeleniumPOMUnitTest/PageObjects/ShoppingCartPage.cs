using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    class ShoppingCartPage
	{
        private IWebDriver driver;
        private WebDriverWait wait;

		[FindsBy(How = How.CssSelector, Using = "div.totals>div.terms-of-service>input#termsofservice")]
		private IWebElement termOfService;

		[FindsBy(How = How.CssSelector, Using = "div.checkout-buttons button#checkout")]
		private IWebElement checkoutButton;

		[FindsBy(How = How.CssSelector, Using = "td.unit-price>span.product-unit-price")]
		private IList<IWebElement> itemPrices;

		[FindsBy(How = How.CssSelector, Using = "td.qty>input[type='text']")]
		private IList<IWebElement> itemQuantity;

		[FindsBy(How = How.CssSelector, Using = "span.product-price")]
		private IList<IWebElement> productPrices;

		public double CalSubTotalPrice()
		{
			double subTotal = 0;
			for (int i = 0; i < itemPrices.Count; i++)
			{
				subTotal = subTotal + Convert.ToDouble(itemPrices.ElementAt(i).Text) * Convert.ToDouble(itemQuantity.ElementAt(i).GetAttribute("value"));
			}
			return subTotal;
		}

		public void AssertSubTotalPrice()
		{
			double subTotal = 0;
			for (int i = 0; i < itemPrices.Count; i++)
			{
				subTotal = subTotal + Convert.ToDouble(itemPrices.ElementAt(i).Text) * Convert.ToDouble(itemQuantity.ElementAt(i).GetAttribute("value"));
			}
			Assert.AreEqual(Convert.ToDouble(productPrices.ElementAt(0).Text), subTotal);
		}

		public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            PageFactory.InitElements(driver, this);
        }

		public void AcceptTermOfService()
		{
			termOfService.Click();
		}

		public CheckoutPage GoToCheckoutPage()
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(checkoutButton));
			checkoutButton.Click();
			return new CheckoutPage(driver);
		}
	}
}