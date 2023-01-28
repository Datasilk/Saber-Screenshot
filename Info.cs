using Saber.Vendor;

namespace Saber.Vendors.Screenshot
{
    public class Info : IVendorInfo
    {
        public string Key { get; set; } = "Screenshot";
        public string Name { get; set; } = "Screenshot";
        public string Description { get; set; } = "Take screenshots of your Saber web pages";
        public string Icon { get; set; } = "";
        public Vendor.Version Version { get; set; } = "1.0.0.0";
    }
}
