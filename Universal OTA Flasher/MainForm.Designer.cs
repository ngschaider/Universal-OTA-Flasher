namespace Universal_OTA_Flasher
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unviersalOTAFlasherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_scan = new System.Windows.Forms.Button();
            this.lv_devices = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.cb_deviceType = new System.Windows.Forms.ComboBox();
            this.lbl_selected_file = new System.Windows.Forms.Label();
            this.btn_select_file = new System.Windows.Forms.Button();
            this.btn_flash = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unviersalOTAFlasherToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.hilfeToolStripMenuItem.Text = "About";
            // 
            // unviersalOTAFlasherToolStripMenuItem
            // 
            this.unviersalOTAFlasherToolStripMenuItem.Name = "unviersalOTAFlasherToolStripMenuItem";
            this.unviersalOTAFlasherToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.unviersalOTAFlasherToolStripMenuItem.Text = "Universal OTA Flasher";
            this.unviersalOTAFlasherToolStripMenuItem.Click += new System.EventHandler(this.unviersalOTAFlasherToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // btn_scan
            // 
            this.btn_scan.Location = new System.Drawing.Point(13, 122);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(108, 23);
            this.btn_scan.TabIndex = 2;
            this.btn_scan.Text = "Start Scanning";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // lv_devices
            // 
            this.lv_devices.CheckBoxes = true;
            this.lv_devices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.ip,
            this.status});
            this.lv_devices.HideSelection = false;
            this.lv_devices.Location = new System.Drawing.Point(13, 152);
            this.lv_devices.MultiSelect = false;
            this.lv_devices.Name = "lv_devices";
            this.lv_devices.Size = new System.Drawing.Size(775, 286);
            this.lv_devices.TabIndex = 3;
            this.lv_devices.UseCompatibleStateImageBehavior = false;
            this.lv_devices.View = System.Windows.Forms.View.Details;
            this.lv_devices.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_devices_ItemChecked);
            // 
            // name
            // 
            this.name.Tag = "";
            this.name.Text = "Name";
            this.name.Width = 300;
            // 
            // ip
            // 
            this.ip.Text = "IP-Address";
            this.ip.Width = 150;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 100;
            // 
            // rtb_log
            // 
            this.rtb_log.Location = new System.Drawing.Point(13, 28);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(363, 88);
            this.rtb_log.TabIndex = 4;
            this.rtb_log.Text = "";
            // 
            // cb_deviceType
            // 
            this.cb_deviceType.FormattingEnabled = true;
            this.cb_deviceType.Location = new System.Drawing.Point(474, 28);
            this.cb_deviceType.Name = "cb_deviceType";
            this.cb_deviceType.Size = new System.Drawing.Size(121, 21);
            this.cb_deviceType.TabIndex = 6;
            // 
            // lbl_selected_file
            // 
            this.lbl_selected_file.AutoSize = true;
            this.lbl_selected_file.Location = new System.Drawing.Point(402, 103);
            this.lbl_selected_file.Name = "lbl_selected_file";
            this.lbl_selected_file.Size = new System.Drawing.Size(82, 13);
            this.lbl_selected_file.TabIndex = 7;
            this.lbl_selected_file.Text = "lbl_selected_file";
            // 
            // btn_select_file
            // 
            this.btn_select_file.Location = new System.Drawing.Point(403, 77);
            this.btn_select_file.Name = "btn_select_file";
            this.btn_select_file.Size = new System.Drawing.Size(75, 23);
            this.btn_select_file.TabIndex = 8;
            this.btn_select_file.Text = "Select File";
            this.btn_select_file.UseVisualStyleBackColor = true;
            this.btn_select_file.Click += new System.EventHandler(this.btn_select_file_Click);
            // 
            // btn_flash
            // 
            this.btn_flash.Location = new System.Drawing.Point(127, 122);
            this.btn_flash.Name = "btn_flash";
            this.btn_flash.Size = new System.Drawing.Size(108, 23);
            this.btn_flash.TabIndex = 9;
            this.btn_flash.Text = "Start Flashing";
            this.btn_flash.UseVisualStyleBackColor = true;
            this.btn_flash.Click += new System.EventHandler(this.btn_flash_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Device Type";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_flash);
            this.Controls.Add(this.btn_select_file);
            this.Controls.Add(this.lbl_selected_file);
            this.Controls.Add(this.cb_deviceType);
            this.Controls.Add(this.rtb_log);
            this.Controls.Add(this.lv_devices);
            this.Controls.Add(this.btn_scan);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Universal OTA Flasher";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.ListView lv_devices;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.ToolStripMenuItem unviersalOTAFlasherToolStripMenuItem;
        private System.Windows.Forms.ComboBox cb_deviceType;
        private System.Windows.Forms.ColumnHeader ip;
        private System.Windows.Forms.Label lbl_selected_file;
        private System.Windows.Forms.Button btn_select_file;
        private System.Windows.Forms.Button btn_flash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

