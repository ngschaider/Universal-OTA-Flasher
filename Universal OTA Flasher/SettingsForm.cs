using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universal_OTA_Flasher {
    public partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();
            LoadSettings();
        }

        private void btn_cancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btn_save_Click(object sender, EventArgs e) {
            SaveSettings();
            Close();
        }

        private void LoadSettings() {
            // Scanning
            nup_scan_concurrent_requests.Value = Properties.Settings.Default.scanConcurrentRequests;
            nup_scan_timeout.Value = Properties.Settings.Default.scanTimeout;
            txt_scanStartIPAddress.Text = Properties.Settings.Default.scanIPAdressStart;
            txt_scanEndIPAdress.Text = Properties.Settings.Default.scanIPAdressEnd;

            // Flashing
            nup_flash_concurrent_requests.Value = Properties.Settings.Default.flashConcurrentRequests;
        }

        private void SaveSettings() {
            // Scanning
            Properties.Settings.Default.scanConcurrentRequests = (int) nup_scan_concurrent_requests.Value;
            Properties.Settings.Default.scanTimeout = (int) nup_scan_timeout.Value;
            Properties.Settings.Default.scanIPAdressStart = txt_scanStartIPAddress.Text;
            Properties.Settings.Default.scanIPAdressEnd = txt_scanEndIPAdress.Text;

            // Flashing
            Properties.Settings.Default.flashConcurrentRequests = (int)nup_flash_concurrent_requests.Value;

            Properties.Settings.Default.Save();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) {

        }

        private void label5_Click(object sender, EventArgs e) {

        }
    }
}
