﻿using System;
using System.IO;
using Saber.Core;
using Saber.Vendor;
using Saber.Core.Extensions.Strings;
using OpenQA.Selenium;
using System.Linq;

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
            var urlparts = url.Replace("https://", "").Replace("http://", "").Split("/", 2);
            if (urlparts[1].Length > 14)
            {
                //trim URL part of ID so screenshot filename is 32 chars max (including extension)
                urlparts[1] = urlparts[1].Right(14);
            }
            var id = DateTime.Now.ToString("yyyyMMdd-hhmm-") + urlparts[1];
            try
            {
                WebDriver.Chrome.Navigate().GoToUrl(url);
                WebDriver.Chrome.Manage().Window.Size = new System.Drawing.Size(width, height);
                IJavaScriptExecutor js = WebDriver.Chrome;
                if(js != null)
                {
                    js.ExecuteScript(@"document.body.style.overflow = 'hidden';");
                }
                var screenshot = ((ITakesScreenshot)WebDriver.Chrome).GetScreenshot();
                Console.WriteLine("Extracted screenshot from " + url);
                screenshot.SaveAsFile(App.MapPath(OutputPath + id + ".png"), ScreenshotImageFormat.Png);
                Console.WriteLine("Saved screenshot to " + App.MapPath(OutputPath + id + ".png"));
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
