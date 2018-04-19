using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNewDemo.PageObjects
{
    class ShoppingCartPage
	{
        private IWebDriver driver;
        private WebDriverWait wait;

		[FindsBy(How = How.CssSelector, Using = "div.totals>div.terms-of-service>input#termsofservice")]
		private IWebElement termOfService;

		[FindsBy(How = How.CssSelector, Using = "div.checkout-buttons button#checkout")]
		private IWebElement checkoutButton;

		public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
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