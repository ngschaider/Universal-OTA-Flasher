using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading;

namespace Universal_OTA_Flasher {
    class Device {

        public string Ip;
        public string DisplayName;
        public DeviceType Type = DeviceType.Unknown;
        public DeviceStatus Status = DeviceStatus.Idle;

        public virtual async Task FlashAsync(string fileName, CancellationToken token, Action successCallback, Action<string> errorCallback) {
            if (Type == DeviceType.Tasmota) {
                await Tasmota.FlashAsync(this, fileName, token, successCallback, errorCallback);
            } else if (Type == DeviceType.Shelly) {

            }
        }

    }
}

