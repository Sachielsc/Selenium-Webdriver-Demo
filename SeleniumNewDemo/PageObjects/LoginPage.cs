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
    class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

		[FindsBy(How = How.CssSelector, Using = "div.form-fields div.inputs>input#Email")]
		private IWebElement userNameInputField;

		[FindsBy(How = How.CssSelector, Using = "div.form-fields div.inputs>input#Password")]
		private IWebElement passwordInputField;

		[FindsBy(How = How.CssSelector, Using = "form[action='/login'] input[value='Log in']")]
		private IWebElement logInButton;

		public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            PageFactory.InitElements(driver, this);
        }

		public void TypeUserName(string text)
		{
			userNameInputField.SendKeys(text);
		}

		public void TypePassword(string text)
		{
			passwordInputField.SendKeys(text);
		}

		public HomePage ConfirmLoginAndGoBackToHomePage ()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(logInButton));
			logInButton.Click();
            return new HomePage(driver);
        }
    }
}