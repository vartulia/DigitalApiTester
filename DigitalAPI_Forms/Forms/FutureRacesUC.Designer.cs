namespace DigitalAPI_Forms
{
    partial class FutureRacesUC
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MeetingDateCB = new System.Windows.Forms.ComboBox();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.VenueMmcTB = new System.Windows.Forms.TextBox();
            this.FLM = new System.Windows.Forms.Label();
            this.RealTypeCB = new System.Windows.Forms.ComboBox();
            this.RealTypeLB = new System.Windows.Forms.Label();
            this.jurisdictionCB = new System.Windows.Forms.ComboBox();
            this.JurisdictionLBL = new System.Windows.Forms.Label();
            this.MeetingDateLBL = new System.Windows.Forms.Label();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MeetingDateCB);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.VenueMmcTB);
            this.groupBox1.Controls.Add(this.FLM);
            this.groupBox1.Controls.Add(this.RealTypeCB);
            this.groupBox1.Controls.Add(this.RealTypeLB);
            this.groupBox1.Controls.Add(this.jurisdictionCB);
            this.groupBox1.Controls.Add(this.JurisdictionLBL);
            this.groupBox1.Controls.Add(this.MeetingDateLBL);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 200);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // MeetingDateCB
            // 
            this.MeetingDateCB.FormattingEnabled = true;
            this.MeetingDateCB.Items.AddRange(new object[] {
            "today",
            "tomorrow",
            "futures"});
            this.MeetingDateCB.Location = new System.Drawing.Point(92, 17);
            this.MeetingDateCB.Name = "MeetingDateCB";
            this.MeetingDateCB.Size = new System.Drawing.Size(121, 21);
            this.MeetingDateCB.TabIndex = 23;
            this.MeetingDateCB.Text = "today";
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(136, 140);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 22;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(177, 137);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 21;
            this.loopTB.Text = "1";
            // 
            // VenueMmcTB
            // 
            this.VenueMmcTB.Location = new System.Drawing.Point(93, 90);
            this.VenueMmcTB.Name = "VenueMmcTB";
            this.VenueMmcTB.Size = new System.Drawing.Size(121, 20);
            this.VenueMmcTB.TabIndex = 20;
            this.VenueMmcTB.Text = "FLM";
            // 
            // FLM
            // 
            this.FLM.AutoSize = true;
            this.FLM.Location = new System.Drawing.Point(11, 93);
            this.FLM.Name = "FLM";
            this.FLM.Size = new System.Drawing.Size(67, 13);
            this.FLM.TabIndex = 19;
            this.FLM.Text = "Venue Mmc:";
            // 
            // RealTypeCB
            // 
            this.RealTypeCB.FormattingEnabled = true;
            this.RealTypeCB.Items.AddRange(new object[] {
            "R",
            "H",
            "G"});
            this.RealTypeCB.Location = new System.Drawing.Point(93, 65);
            this.RealTypeCB.Name = "RealTypeCB";
            this.RealTypeCB.Size = new System.Drawing.Size(121, 21);
            this.RealTypeCB.TabIndex = 16;
            this.RealTypeCB.Text = "R";
            // 
            // RealTypeLB
            // 
            this.RealTypeLB.AutoSize = true;
            this.RealTypeLB.Location = new System.Drawing.Point(28, 69);
            this.RealTypeLB.Name = "RealTypeLB";
            this.RealTypeLB.Size = new System.Drawing.Size(59, 13);
            this.RealTypeLB.TabIndex = 15;
            this.RealTypeLB.Text = "Real Type:";
            // 
            // jurisdictionCB
            // 
            this.jurisdictionCB.FormattingEnabled = true;
            this.jurisdictionCB.Items.AddRange(new object[] {
            "VIC",
            "NSW"});
            this.jurisdictionCB.Location = new System.Drawing.Point(93, 39);
            this.jurisdictionCB.Name = "jurisdictionCB";
            this.jurisdictionCB.Size = new System.Drawing.Size(121, 21);
            this.jurisdictionCB.TabIndex = 13;
            this.jurisdictionCB.Text = "VIC";
            // 
            // JurisdictionLBL
            // 
            this.JurisdictionLBL.AutoSize = true;
            this.JurisdictionLBL.Location = new System.Drawing.Point(28, 39);
            this.JurisdictionLBL.Name = "JurisdictionLBL";
            this.JurisdictionLBL.Size = new System.Drawing.Size(62, 13);
            this.JurisdictionLBL.TabIndex = 12;
            this.JurisdictionLBL.Text = "Jurisdiction:";
            // 
            // MeetingDateLBL
            // 
            this.MeetingDateLBL.AutoSize = true;
            this.MeetingDateLBL.Location = new System.Drawing.Point(22, 20);
            this.MeetingDateLBL.Name = "MeetingDateLBL";
            this.MeetingDateLBL.Size = new System.Drawing.Size(74, 13);
            this.MeetingDateLBL.TabIndex = 11;
            this.MeetingDateLBL.Text = "Meeting Date:";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(139, 163);
            this.CallApiBTN.Name = "CallApiBTN";
            this.CallApiBTN.Size = new System.Drawing.Size(75, 23);
            this.CallApiBTN.TabIndex = 9;
            this.CallApiBTN.Text = "Call API";
            this.CallApiBTN.UseVisualStyleBackColor = true;
            this.CallApiBTN.Click += new System.EventHandler(this.CallApiBTN_Click);
            // 
            // FutureRacesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FutureRacesUC";
            this.Size = new System.Drawing.Size(250, 210);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox RealTypeCB;
        private System.Windows.Forms.Label RealTypeLB;
        private System.Windows.Forms.ComboBox jurisdictionCB;
        private System.Windows.Forms.Label JurisdictionLBL;
        private System.Windows.Forms.Label MeetingDateLBL;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.TextBox VenueMmcTB;
        private System.Windows.Forms.Label FLM;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.ComboBox MeetingDateCB;
    }
}
