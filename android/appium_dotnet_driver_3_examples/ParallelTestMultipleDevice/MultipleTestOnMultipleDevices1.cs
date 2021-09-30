using System;
using System.Threading;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using android.local;

namespace android.ParallelTestMultipleDevice
{
    [TestFixture("parallel", "pixel-3")]
    [TestFixture("parallel", "samsung-note21")]
    [TestFixture("parallel", "samsung-note20")]
    [Parallelizable(ParallelScope.All)]
    public class MultipleTestOnMultipleDevices1 : BrowserStackNUnitTest
    {
        public MultipleTestOnMultipleDevices1(string profile, string device) : base(profile, device) { }

        [Test]
        public void searchWikipedia()
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Search Wikipedia")));
            searchElement.Click();
            AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
            insertTextElement.SendKeys("Browserstack");
            Thread.Sleep(8000);

            //ReadOnlyCollection<AndroidElement> allProductsName = driver.FindElements(By.ClassName("android.widget.TextView"));
            //Assert.True(allProductsName.Count > 0);
        }

        /*
        [Test]
        public void searchWikipedia1()
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Search Wikipedia")));
            searchElement.Click();
            AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
            insertTextElement.SendKeys("Browserstack");
            Thread.Sleep(8000);

            //ReadOnlyCollection<AndroidElement> allProductsName = driver.FindElements(By.ClassName("android.widget.TextView"));
            //Assert.True(allProductsName.Count > 0);
        }
        */
    }
}
