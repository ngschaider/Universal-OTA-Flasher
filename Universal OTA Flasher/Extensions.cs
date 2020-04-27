using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Universal_OTA_Flasher
{
    static class Extensions
    {

        public static uint ToInteger(this IPAddress ip)
        {
            byte[] bytes = ip.GetAddressBytes();

            // flip big-endian(network order) to little-endian
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt32(bytes, 0);
        }

        public static IPAddress ToIP(this uint num)
        {
            byte[] bytes = BitConverter.GetBytes(num);

            // flip little-endian to big-endian(network order)
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return new IPAddress(bytes);
        }

    }
}
