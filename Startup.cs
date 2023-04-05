using System.IO;
using OpenQA.Selenium.Chrome;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saber.Vendor;

namespace Saber.Vendors.Screenshot
{
    public class Startup : IVendorStartup
    {
        public void ConfigureServices(IServiceCollection services) 
        {
            
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfigurationRoot config) 
        {
            var path = App.MapPath("/Content/screenshots");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var options = new ChromeOptions();
            options.AddArgument("headless");
            options.BinaryLocation = App.MapPath("/Vendors/Screenshot/Chrome/chrome.exe");
            WebDriver.Chrome = new ChromeDriver(App.MapPath("/Vendors/Screenshot/"), options);
        }
    }
}
