using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMExample.PageObjects
{
    class HomePage
    {
		private IWebDriver driver;
		private WebDriverWait wait;

		[FindsBy(How = How.CssSelector, Using = "div.header-links>ul>li>a[href='/login']")]
		private IWebElement loginButton;

		[FindsBy(How = How.CssSelector, Using = "div.header-links>ul>li>a[href='/logout']")]
		private IWebElement logoutButton;

		[FindsBy(How = How.CssSelector, Using = "div.search-box>form[action='/search']>input[type='text']")]
		private IWebElement searchBar;

		[FindsBy(How = How.CssSelector, Using = "div.search-box form[action='/search'] input[type='submit']")]
		private IWebElement searchButton;

		public HomePage(IWebDriver driver)
        {
            this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
			PageFactory.InitElements(driver, this);
        }

        public void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
        }

		public LoginPage GoToLoginPage()
		{
			loginButton.Click();
			return new LoginPage(driver);
		}

		public void Logout()
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(logoutButton));
			logoutButton.Click();
		}

		public SearchResultPage Search(string text)
		{
			searchBar.SendKeys(text);
			searchButton.Click();
			return new SearchResultPage(driver);
		}
	}
}
