using System;
using System.Collections.Generic;
using Saber.Core;
using Saber.Vendor;

namespace Saber.Vendors.Screenshot
{
    public class InternalApis : IVendorInteralApis
    {
        public List<InternalApi> Apis { get; set; } = new List<InternalApi>()
        {
            new InternalApi(){Key = "Take-Screenshot", Method = Delegates.TakeScreenshot }
        };

        public static string TakeScreenshot(IRequest request, Dictionary<string, object> data)
        {
            Console.WriteLine("Taking Screenshot...");
            var url = data.ContainsKey("url") ? (string)data["url"] : "";
            var width = data.ContainsKey("width") ? (int)data["width"] : 1920;
            var height = data.ContainsKey("height") ? (int)data["height"] : 1080;
            Console.WriteLine("data: url=" + url + ", width=" + width + ", height=" + height);
            return Screenshot.Take(request, url, width, height);
        }

        public static class Delegates
        {
            public static Func<IRequest, Dictionary<string, object>, string> TakeScreenshot { get; set; } = InternalApis.TakeScreenshot;
        }
    }
}
