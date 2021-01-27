using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace specflowselenium.Extensions
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Extension method to wait untill element is found.
        /// </summary>
        /// <param name="driver">Selenium web driver.</param>
        /// <param name="by">element to be found using by</param>
        /// <param name="timeoutInSeconds">time out in seconds</param>
        /// <returns></returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
