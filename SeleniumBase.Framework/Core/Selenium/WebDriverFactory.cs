﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumBase.Framework.Core.Selenium
{
    public class WebDriverFactory
    {
        IWebDriver Driver;
        /// <summary>
        /// Initilizes IWebDriver based on the given WebBrowser name.
        /// </summary>
        /// <param name="name">Browser name i.e.: Chrome</param>
        /// <returns></returns>
        public IWebDriver CreateWebDriver(string name, string remoteURL = "")
        {
            switch (name)
            {
                case "Firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    Driver = new FirefoxDriver();
                    return Driver;
                case "Edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    Driver = new EdgeDriver();
                    return Driver;
                case "InternetExplorer":
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    Driver = new InternetExplorerDriver();
                    return Driver;
                case "Remote":
                    ChromeOptions Options = new WebDriverOptions().GetRemoteOptions();
                    Driver = new RemoteWebDriver(new Uri(remoteURL), Options.ToCapabilities());
                    return Driver;
                case "Chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions options = new WebDriverOptions().GetChromeOptions();
                    Driver = new ChromeDriver(options);
                    return Driver;
                default:
                    Assert.Fail("Unable to select valid browser");
                    return null;
            }
        }
    }
}
