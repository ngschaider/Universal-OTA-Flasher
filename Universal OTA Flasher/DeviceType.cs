using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_OTA_Flasher {

    public class DeviceTypeUtils {

        private static readonly string[] TypeTexts = {
            "Shelly (WIP)",
            "Tasmota",
            "Unknown",
        };

        public static string GetText(DeviceType deviceType) {
            return TypeTexts[(int)deviceType];
        }

        public static string[] GetDisplayTexts() {
            return TypeTexts.Where(x => x == GetText(DeviceType.Unknown)).ToArray();
        }

        public static string[] GetTexts() {
            return TypeTexts;
        }

    }

    public enum DeviceType {
        Shelly,
        Tasmota,
        Unknown,
    }

}
