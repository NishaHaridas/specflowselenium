namespace specflowselenium.Bindings
{
    using FluentAssertions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using specflowselenium.Extensions;
    using TechTalk.SpecFlow;

    [Binding]
    class SpecflowBindings
    {
        private IWebDriver Driver;

        [When(@"I start the browser")]
        public void WhenIStartTheBrowser()
        {
            Driver = new FirefoxDriver();
        }

        [When(@"I navigate to '(.*)'")]
        public void WhenINavigateToHttpExample_Com(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }


        [When(@"I click on the '(.*)'")]
        public void WhenIClickOnThe(string moreInfoLink)
        {
            Driver.FindElement(By.LinkText(moreInfoLink)).Click();
        }

        [Then(@"a link with text '(.*)' must be present")]
        public void ThenALinkWithTextMustBePresent(string linkText)
        {
            Driver.FindElement(By.LinkText(linkText)).Displayed.Should().BeTrue();
        }

        [Then(@"the '(.*)' box must contain '(.*)' at index '(.*)'")]
        public void ThenTheBoxMustContainAtIndex(string domainNameBox, string linkName, int index)
        {
            
            var domainNameListBoxElement = Driver.FindElement(By.XPath($"//div[@id='sidebar_left']/div[@class='navigation_box']/h2"), 5);
            domainNameListBoxElement.Text.Should().Be(domainNameBox);

            var domainNameList2ndElement = Driver.FindElement(By.XPath($"//div[@id='sidebar_left']/div[@class='navigation_box']/ul/li[{index}]"), 5);
            domainNameList2ndElement.Text.Should().Be(linkName);
        }
    }
}
