using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Universal_OTA_Flasher {
    public partial class MainForm : System.Windows.Forms.Form {

        public static MainForm instance;

        public MainForm() {
            instance = this;
            InitializeComponent();

            lbl_selected_file.Text = "";
        }

        private bool checkboxesLocked = false;
        private CancellationTokenSource scanTokenSource;
        private CancellationTokenSource flashTokenSource;
        private string fileName = "";
        private bool IsScanning = false;
        private bool IsFlashing = false;

        private int flashesStarted = 0;
        private List<Task> currentlyFlashing = new List<Task>();

        private string SelectedDeviceType {
            get {
                return cb_deviceType.GetItemText(cb_deviceType.SelectedItem);
            }
        }

        private void btn_scan_Click(object sender, EventArgs e) {
            ToggleScanning();
        }

        public void Log(string str) {
            // We have to use Invoke if we call from another thread.
            rtb_log.Invoke((Action)(() => {
                rtb_log.Text += DateTime.Now.ToShortTimeString() + ": " + str + "\n";
                rtb_log.SelectionStart = rtb_log.Text.Length;
                rtb_log.ScrollToCaret();
            }));
        }

        private void ToggleScanning() {
            if (IsScanning) {
                scanTokenSource.Cancel();
                btn_scan.Text = "Start Scanning";
                IsScanning = false;

                Log("Scanning stopped. Found " + lv_devices.Items.Count + " devices.");
            } else {
                Log("Scanning started.");
                IsScanning = true;
                btn_scan.Text = "Stop Scanning";

                lv_devices.Items.Clear();
                scanTokenSource = new CancellationTokenSource();

                if (SelectedDeviceType == "Shelly") {
                    Task task = Shelly.Scan(scanTokenSource.Token, NewDeviceFound, ToggleScanning);
                } else if (SelectedDeviceType == "Tasmota") {
                    Task task = Tasmota.Scan(scanTokenSource.Token, NewDeviceFound, ToggleScanning);
                }
            }
        }

        private void unviersalOTAFlasherToolStripMenuItem_Click(object sender, EventArgs e) {
            string[] text = { "Universal OTA Flasher",
                              Properties.Settings.Default.programVersion + "\n\n",
                              "Author: Niklas Gschaider",
                              "License: CC BY-NC-SA 4.0" };


            TextForm form = new TextForm();
            form.SetTitle("Universal OTA Flasher");
            form.SetText(String.Join("\n\n", text));
            form.Show();
        }

        private void NewDeviceFound(Device device) {
            lv_devices.Invoke((Action)(() => {
                Log("Found new Device: " + device.DisplayName);
                ListViewItem item = new ListViewItem(new string[] { device.DisplayName, device.Ip, device.Status.ToString() });
                item.Tag = device;

                lv_devices.Items.Add(item);
            }));
        }


        private void btn_select_file_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                fileName = dialog.FileName;
                lbl_selected_file.Text = dialog.FileName;
            }
        }

        private void btn_flash_Click(object sender, EventArgs e) {
            if (IsScanning) {
                Log("Please stop scanning before flashing.");
                return;
            }
            if (IsFlashing) {
                Log("Already flashing.");
                return;
            }
            if (!File.Exists(fileName)) {
                Log("Selected File does not exist!");
                return;
            }

            IsFlashing = true;
            btn_flash.Text = "Stop Flashing";
            flashTokenSource = new CancellationTokenSource();

            for (int i=0; i < Properties.Settings.Default.flashConcurrentRequests; i++) {
                if (lv_devices.CheckedItems.Count < i) {
                    break;
                }
                Device device = (Device)lv_devices.CheckedItems[i].Tag;
                StartFlashingDevice(device);

                flashesStarted++;
            }
        }

        private void StartFlashingDevice(Device device) {
            device.Status = DeviceStatus.Flashing;
            Log("Started flashing '" + device.DisplayName + "'");
            Task task = device.FlashAsync(fileName, flashTokenSource.Token, () => {
                device.Status = DeviceStatus.Flashed;
                Log("Successfully flashed '" + device.DisplayName + "'");

                if (lv_devices.CheckedItems.Count > flashesStarted) {
                    Device nextDevice = (Device)lv_devices.CheckedItems[flashesStarted + 1].Tag;
                    StartFlashingDevice(nextDevice);
                }
            }, (string err) => {
                device.Status = DeviceStatus.Error;
                if (err != null) {
                    Log("Error while flashing '" + device.DisplayName + "': " + err);
                }
            });

            currentlyFlashing.Add(task);
        }

        private void lv_devices_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if(checkboxesLocked) {
                e.Item.Checked = !e.Item.Checked;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }
    }
}
