using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Customers.Framework.Core.Selenium
{
    public class WebDriverOptions
    {
        public ChromeOptions GetChromeOptions()
        {
            ChromeOptions chromeOption = new ChromeOptions();
            chromeOption.AddArguments("disable-extensions");
            chromeOption.AddArguments("start-maximized");
            chromeOption.AddArguments("incognito");
            chromeOption.AddArguments("test-type");
            return chromeOption;
        }

        public FirefoxOptions GetFireFoxOptions()
        {
            FirefoxOptions fireFoxOption = new FirefoxOptions();
            fireFoxOption.AddArguments("--disable-extensions");
            return fireFoxOption;
        }

        public InternetExplorerOptions GetInternetExplorerOptions()
        {
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
            return ieOptions;
        }

        public EdgeOptions GetEdgeOptions()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddAdditionalCapability("InPrivate", true);
            return edgeOptions;
        }
    }
}
