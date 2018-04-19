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
    class ThankYouPage
	{
        private IWebDriver driver;
        private WebDriverWait wait;

		[FindsBy(How = How.CssSelector, Using = "div.order-completed input.order-completed-continue-button")]
		private IWebElement continueButton;

		public ThankYouPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            PageFactory.InitElements(driver, this);
        }

		public HomePage FinishPurchaseAndGoToHomePage()
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(continueButton));
			continueButton.Click();
			return new HomePage(driver);
		}
	}
}