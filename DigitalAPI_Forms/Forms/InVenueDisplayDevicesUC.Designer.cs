namespace DigitalAPI_Forms
{
    partial class InVenueDisplayDevicesUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.getNonCommissionedBTN = new System.Windows.Forms.Button();
            this.serialNoTB = new System.Windows.Forms.TextBox();
            this.getVenueCachesBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CommissionByVenueId = new System.Windows.Forms.Button();
            this.wageringTerminalsBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.venueIdTB = new System.Windows.Forms.TextBox();
            this.getAllDevicesBTN = new System.Windows.Forms.Button();
            this.filterByAssetSerialNoBTN = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.filterByAssetSerialNoBTN);
            this.groupBox2.Controls.Add(this.getAllDevicesBTN);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.getNonCommissionedBTN);
            this.groupBox2.Controls.Add(this.serialNoTB);
            this.groupBox2.Controls.Add(this.getVenueCachesBTN);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 200);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Serial No / Asset Id:";
            // 
            // getNonCommissionedBTN
            // 
            this.getNonCommissionedBTN.Location = new System.Drawing.Point(9, 19);
            this.getNonCommissionedBTN.Name = "getNonCommissionedBTN";
            this.getNonCommissionedBTN.Size = new System.Drawing.Size(106, 48);
            this.getNonCommissionedBTN.TabIndex = 8;
            this.getNonCommissionedBTN.Text = "Get  Non-Commissioned Devices";
            this.getNonCommissionedBTN.UseVisualStyleBackColor = true;
            this.getNonCommissionedBTN.Click += new System.EventHandler(this.getNonCommissionedBTN_Click);
            // 
            // serialNoTB
            // 
            this.serialNoTB.Location = new System.Drawing.Point(9, 108);
            this.serialNoTB.Name = "serialNoTB";
            this.serialNoTB.Size = new System.Drawing.Size(226, 20);
            this.serialNoTB.TabIndex = 14;
            // 
            // getVenueCachesBTN
            // 
            this.getVenueCachesBTN.Location = new System.Drawing.Point(121, 134);
            this.getVenueCachesBTN.Name = "getVenueCachesBTN";
            this.getVenueCachesBTN.Size = new System.Drawing.Size(106, 48);
            this.getVenueCachesBTN.TabIndex = 8;
            this.getVenueCachesBTN.Text = "Find Device By Serial No.";
            this.getVenueCachesBTN.UseVisualStyleBackColor = true;
            this.getVenueCachesBTN.Click += new System.EventHandler(this.getVenueCachesBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CommissionByVenueId);
            this.groupBox1.Controls.Add(this.wageringTerminalsBTN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.venueIdTB);
            this.groupBox1.Location = new System.Drawing.Point(250, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 98);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // CommissionByVenueId
            // 
            this.CommissionByVenueId.Location = new System.Drawing.Point(152, 53);
            this.CommissionByVenueId.Name = "CommissionByVenueId";
            this.CommissionByVenueId.Size = new System.Drawing.Size(94, 37);
            this.CommissionByVenueId.TabIndex = 14;
            this.CommissionByVenueId.Text = "Commission by VenueID";
            this.CommissionByVenueId.UseVisualStyleBackColor = true;
            this.CommissionByVenueId.Click += new System.EventHandler(this.CommissionByVenueId_Click_1);
            // 
            // wageringTerminalsBTN
            // 
            this.wageringTerminalsBTN.Location = new System.Drawing.Point(152, 23);
            this.wageringTerminalsBTN.Name = "wageringTerminalsBTN";
            this.wageringTerminalsBTN.Size = new System.Drawing.Size(94, 24);
            this.wageringTerminalsBTN.TabIndex = 13;
            this.wageringTerminalsBTN.Text = "List by Venue ID";
            this.wageringTerminalsBTN.UseVisualStyleBackColor = true;
            this.wageringTerminalsBTN.Click += new System.EventHandler(this.wageringTerminalsBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Venue Id:";
            // 
            // venueIdTB
            // 
            this.venueIdTB.Location = new System.Drawing.Point(74, 26);
            this.venueIdTB.Name = "venueIdTB";
            this.venueIdTB.Size = new System.Drawing.Size(61, 20);
            this.venueIdTB.TabIndex = 11;
            this.venueIdTB.Text = "1";
            // 
            // getAllDevicesBTN
            // 
            this.getAllDevicesBTN.Location = new System.Drawing.Point(121, 19);
            this.getAllDevicesBTN.Name = "getAllDevicesBTN";
            this.getAllDevicesBTN.Size = new System.Drawing.Size(106, 48);
            this.getAllDevicesBTN.TabIndex = 16;
            this.getAllDevicesBTN.Text = "Get All Devices";
            this.getAllDevicesBTN.UseVisualStyleBackColor = true;
            this.getAllDevicesBTN.Click += new System.EventHandler(this.getAllDevicesBTN_Click);
            // 
            // filterByAssetSerialNoBTN
            // 
            this.filterByAssetSerialNoBTN.Location = new System.Drawing.Point(9, 134);
            this.filterByAssetSerialNoBTN.Name = "filterByAssetSerialNoBTN";
            this.filterByAssetSerialNoBTN.Size = new System.Drawing.Size(106, 48);
            this.filterByAssetSerialNoBTN.TabIndex = 17;
            this.filterByAssetSerialNoBTN.Text = "Filter By Asset/Serial No.";
            this.filterByAssetSerialNoBTN.UseVisualStyleBackColor = true;
            this.filterByAssetSerialNoBTN.Click += new System.EventHandler(this.filterByAssetSerialNoBTN_Click);
            // 
            // InVenueDisplayDevicesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "InVenueDisplayDevicesUC";
            this.Size = new System.Drawing.Size(670, 223);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button getNonCommissionedBTN;
        private System.Windows.Forms.Button getVenueCachesBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button wageringTerminalsBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox venueIdTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serialNoTB;
        private System.Windows.Forms.Button CommissionByVenueId;
        private System.Windows.Forms.Button getAllDevicesBTN;
        private System.Windows.Forms.Button filterByAssetSerialNoBTN;
    }
}
