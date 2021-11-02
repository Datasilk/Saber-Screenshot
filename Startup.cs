using System.Reflection;
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
            var options = new ChromeOptions();
            options.AddArgument("headless");
            WebDriver.Chrome = new ChromeDriver(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Vendors\\Screenshot\\", options);
        }
    }
}
