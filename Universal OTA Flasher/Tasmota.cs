using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Http;
using System.IO;

namespace Universal_OTA_Flasher {
    static class Tasmota {

        private static readonly HttpClient uploadClient = new HttpClient();
        private static HttpClient scanClient = new HttpClient();

        public static Device CreateDevice(IPAddress ip, string content) {
            Device device = new Device();
            device.Type = DeviceType.Tasmota;
            device.DisplayName = "Device0";
            device.Ip = ip.ToString();

            return device;
        }

        public static async Task Scan(CancellationToken token, Action<Device> deviceFoundCallback, Action finishedCallback) {
            TimeSpan timeout = TimeSpan.FromMilliseconds(Properties.Settings.Default.scanTimeout);
            if (scanClient.Timeout != timeout) {
                scanClient.Dispose();
                scanClient = new HttpClient();
                scanClient.Timeout = TimeSpan.FromMilliseconds(Properties.Settings.Default.scanTimeout);
            }

            IPAddress ip;
            try {
                ip = IPAddress.Parse(Properties.Settings.Default.scanIPAdressStart);
            } catch (FormatException) {
                MainForm.instance.Log("Scan Start IP Address has wrong format");
                return;
            }

            IPAddress ipEnd;
            try {
                ipEnd = IPAddress.Parse(Properties.Settings.Default.scanIPAdressEnd);
            } catch (FormatException) {
                MainForm.instance.Log("Scan End IP Address has wrong format");
                return;
            }


            while (true) {
                MainForm.instance.Log("Scanning IP " + ip.ToString());
                string content = await GetTasmotaInfo(ip, token);
                if (IsTasmotaDevice(content)) {
                    deviceFoundCallback(CreateDevice(ip, content));
                }

                if (token.IsCancellationRequested) {
                    return;
                }

                if (ip.Equals(ipEnd)) {
                    break;
                }

                ip = (ip.ToInteger() + 1).ToIP();
            }

            finishedCallback.Invoke();
        }

        private static bool IsTasmotaDevice(string content) {
            if (content == null) {
                return false;
            }

            return content.Contains("<title>Tasmota");
        }

        private static async Task<string> GetTasmotaInfo(IPAddress ip, CancellationToken token) {
            try {
                HttpResponseMessage resp = await scanClient.GetAsync("http://" + ip.ToString(), token);
                if (resp.IsSuccessStatusCode) {
                    string content = await resp.Content.ReadAsStringAsync();
                    return content;
                }
            } catch (TaskCanceledException) {
                // HttpClient.GetAsync throws TaskCanceledException on Timeout
                return null;
            }
            return null;
        }

        public static async Task FlashAsync(Device device, string fileName, CancellationToken token, Action successCallback, Action<string> errorCallback) {
            try {
                device.Status = DeviceStatus.Flashing;
                MultipartFormDataContent formData = new MultipartFormDataContent();
                StreamContent content = new StreamContent(new FileStream(fileName, FileMode.Open));

                formData.Add(content, "u2", "file");
                var response = await uploadClient.PostAsync("http://" + device.Ip + "/u2", formData);
                if (response.IsSuccessStatusCode) {
                    string respContent = await response.Content.ReadAsStringAsync();

                    if (respContent.Contains("<font color='#ff5661'>")) { // red color
                        errorCallback.Invoke(null);
                        return;
                    }

                    if (respContent.Contains("<font color='#008000'>")) { // green color
                        successCallback.Invoke();
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }

        }

    }
}