using System;
using System.IO;
using Saber.Core;
using Saber.Vendor;
using Saber.Core.Extensions.Strings;
using OpenQA.Selenium;

namespace Saber.Vendors.Screenshot
{
    public class Screenshot: Service, IVendorService
    {
        private static string OutputPath = "/Content/screenshots/";

        public string Take (string url, int width, int height)
        {
            return Take(this, url, width, height);
        }

        public static string Take(IRequest request, string url, int width, int height)
        {
            var id = DateTime.Now.ToString("yyyyMMdd-hhmm-") + url.ReplaceOnlyAlphaNumeric().Replace("/", "-").Replace(" ", "-");
            if (id.Length > 28)
            {
                id = id.Substring(0, 28);
            }
            try
            {
                WebDriver.Chrome.Navigate().GoToUrl(App.Host + "/" + url);
                WebDriver.Chrome.Manage().Window.Size = new System.Drawing.Size(width, height);
                IJavaScriptExecutor js = WebDriver.Chrome;
                if(js != null)
                {
                    js.ExecuteScript(@"document.body.style.overflow = 'hidden';");
                }
                var screenshot = ((ITakesScreenshot)WebDriver.Chrome).GetScreenshot();
                screenshot.SaveAsFile(App.MapPath(OutputPath + id + ".png"), ScreenshotImageFormat.Png);
            }
            catch (Exception ex)
            {
                Log.Error(ex, request, "api/Screenshot/Take");
                throw new Exception("Error saving screenshot", ex);
                
            }
            return id + ".png";
        }
    }
}
