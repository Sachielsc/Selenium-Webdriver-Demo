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
	class SearchResultPage
	{
		private IWebDriver driver;
		private WebDriverWait wait;

		[FindsBy(How = How.CssSelector, Using = "div.product-grid div.details input[value='Add to cart']")]
		private IList<IWebElement> addToCartButtons;

		[FindsBy(How = How.CssSelector, Using = "div.header-links li#topcartlink>a[href='/cart']")]
		private IWebElement shoppingCartButton;

		public SearchResultPage(IWebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
			PageFactory.InitElements(driver, this);
		}

		public void AddCertainItemToCart(int index)
		{
			addToCartButtons.ElementAt(index).Click();
		}

		public ShoppingCartPage GoToShoppingCartPage()
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(shoppingCartButton));
			shoppingCartButton.Click();
			return new ShoppingCartPage(driver);
		}
	}
}