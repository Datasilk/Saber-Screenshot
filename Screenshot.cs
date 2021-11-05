using System;
using Saber.Vendor;
using Saber.Core.Extensions.Strings;
using OpenQA.Selenium;

namespace Saber.Vendors.Screenshot
{
    public class Screenshot: Core.Service, IVendorService
    {
        private string OutputPath = "/Content/screenshots/";
        public string Take (string url, int width, int height)
        {
            var id = DateTime.Now.ToString("yyyyMMdd-hhmm-") + url.ReplaceOnlyAlphaNumeric().Replace("/", "-").Replace(" ", "-");
            WebDriver.Chrome.Navigate().GoToUrl(App.Host + "/" + url);
            WebDriver.Chrome.Manage().Window.Size = new System.Drawing.Size(width, height);
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver.Chrome;
            js.ExecuteScript(@"document.body.style.overflow = 'hidden';");
            var screenshot = ((ITakesScreenshot)WebDriver.Chrome).GetScreenshot();
            screenshot.SaveAsFile(App.MapPath(OutputPath + id + ".jpg"), ScreenshotImageFormat.Jpeg);
            return OutputPath + id + ".jpg";
        }
    }
}
