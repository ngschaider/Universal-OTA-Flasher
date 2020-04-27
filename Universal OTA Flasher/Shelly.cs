using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Zeroconf;

namespace Universal_OTA_Flasher
{

    static class Shelly
    {

        private static Device CreateDevice(IZeroconfHost host, string name) {
            Device device = new Device();
            device.Ip = host.IPAddress;
            device.DisplayName = name;
            device.Type = DeviceType.Shelly;

            return device;
        }
        
        public static string GetShellyName(IZeroconfHost host)
        {
            foreach (var service in host.Services)
            {
                foreach (var set in service.Value.Properties)
                {
                    foreach (var kvp in set)
                    {
                        if (kvp.Key == "id" && kvp.Value.StartsWith("shelly"))
                        {
                            return kvp.Value;
                        }
                    }
                }
            }
            return null;
        }
        
        public static async Task Scan(CancellationToken token, Action<Device> deviceFoundCallback, Action finishedCallback)
        {
            ILookup<string, string> domains = await ZeroconfResolver.BrowseDomainsAsync();
            var responses = await ZeroconfResolver.ResolveAsync(domains.Select(g => g.Key), TimeSpan.FromMinutes(1), 2, 2000, host => {
                string name = GetShellyName(host);
                if (name != null)
                {
                    Device device = CreateDevice(host, name);
                    deviceFoundCallback.Invoke(device);
                }
            }, token);

            finishedCallback.Invoke();
        }

    }

}
