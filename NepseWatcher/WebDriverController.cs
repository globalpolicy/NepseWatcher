using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace NepseWatcher
{
    public class WebDriverController
    {
        private IWebDriver webDriver;

        public WebDriverController()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument(
                "user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36");
            options.AddArgument("--remote-debugging-port=9222");

            webDriver = new ChromeDriver(options);
            NavigateTo("https://tradingview.systemxlite.com/systemxlite?tk=eyJ1c2VySWQiOjEwNzk3LCJ0b2tlbiI6Im9vbDJxZWs4ZXFzdGs5NmFmN2g2cXgzaHBqeTc1aHd4N2R4NzlneDFrdmowNmc4N2tpNTNzZDNkY2d0NCJ9");
        }

        private void NavigateTo(string URL)
        {
            webDriver.Navigate().GoToUrl(URL);
        }

        public void Close()
        {
            try
            {
                webDriver.Close();
            }
            catch (WebDriverException webdex)
            {
                //do nothing
            }
        }

        public bool IsBrowserOpen()
        {
            bool retVal = true;
            try
            {
                var _ = webDriver.Title;
            }
            catch(Exception ex)
            {
                retVal = false;
            }
            return retVal;
        }

        public void LoadChartOfCompany(string CompanySymbol)
        {
            try
            {
                webDriver.SwitchTo().DefaultContent();
                webDriver.SwitchTo().Frame(0); //switch to the first iframe
                IWebElement element = webDriver.FindElement(By.XPath("//*[@id='header-toolbar-symbol-search']/div/input"));
                element.Click();
                element.SendKeys(CompanySymbol);
                element.SendKeys(Keys.Return);
            }
            catch(Exception ex)
            {
                //do nothing
            }
            
        }


    }
}
