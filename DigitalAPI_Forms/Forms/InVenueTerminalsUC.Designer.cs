namespace DigitalAPI_Forms
{
    partial class InVenueTerminalsUC
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
            this.pollBTN = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.terminalNoTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.termVersionTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.osTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.memoryTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hardwareVerTB = new System.Windows.Forms.TextBox();
            this.cacheBTN = new System.Windows.Forms.Button();
            this.connectBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.venueIdTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.pollBTN);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.terminalNoTB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.termVersionTB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.osTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.memoryTB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.hardwareVerTB);
            this.groupBox1.Controls.Add(this.cacheBTN);
            this.groupBox1.Controls.Add(this.connectBTN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.venueIdTB);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 200);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect";
            // 
            // pollBTN
            // 
            this.pollBTN.Location = new System.Drawing.Point(9, 153);
            this.pollBTN.Name = "pollBTN";
            this.pollBTN.Size = new System.Drawing.Size(78, 41);
            this.pollBTN.TabIndex = 24;
            this.pollBTN.Text = "Poll";
            this.pollBTN.UseVisualStyleBackColor = true;
            this.pollBTN.Click += new System.EventHandler(this.pollBTN_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Terminal No:";
            // 
            // terminalNoTB
            // 
            this.terminalNoTB.Location = new System.Drawing.Point(258, 23);
            this.terminalNoTB.Name = "terminalNoTB";
            this.terminalNoTB.Size = new System.Drawing.Size(32, 20);
            this.terminalNoTB.TabIndex = 22;
            this.terminalNoTB.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "terminalVersion:";
            // 
            // termVersionTB
            // 
            this.termVersionTB.Location = new System.Drawing.Point(85, 127);
            this.termVersionTB.Name = "termVersionTB";
            this.termVersionTB.Size = new System.Drawing.Size(107, 20);
            this.termVersionTB.TabIndex = 20;
            this.termVersionTB.Text = "9.50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "O/S:";
            // 
            // osTB
            // 
            this.osTB.Location = new System.Drawing.Point(85, 101);
            this.osTB.Name = "osTB";
            this.osTB.Size = new System.Drawing.Size(221, 20);
            this.osTB.TabIndex = 18;
            this.osTB.Text = "Microsoft Windows 5.1 Service Pack 3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Memory:";
            // 
            // memoryTB
            // 
            this.memoryTB.Location = new System.Drawing.Point(85, 75);
            this.memoryTB.Name = "memoryTB";
            this.memoryTB.Size = new System.Drawing.Size(107, 20);
            this.memoryTB.TabIndex = 16;
            this.memoryTB.Text = "1736MB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Hardware Ver:";
            // 
            // hardwareVerTB
            // 
            this.hardwareVerTB.Location = new System.Drawing.Point(85, 49);
            this.hardwareVerTB.Name = "hardwareVerTB";
            this.hardwareVerTB.Size = new System.Drawing.Size(107, 20);
            this.hardwareVerTB.TabIndex = 14;
            this.hardwareVerTB.Text = "41";
            // 
            // cacheBTN
            // 
            this.cacheBTN.Location = new System.Drawing.Point(98, 153);
            this.cacheBTN.Name = "cacheBTN";
            this.cacheBTN.Size = new System.Drawing.Size(78, 41);
            this.cacheBTN.TabIndex = 13;
            this.cacheBTN.Text = "Cache";
            this.cacheBTN.UseVisualStyleBackColor = true;
            this.cacheBTN.Click += new System.EventHandler(this.cacheBTN_Click);
            // 
            // connectBTN
            // 
            this.connectBTN.Location = new System.Drawing.Point(182, 153);
            this.connectBTN.Name = "connectBTN";
            this.connectBTN.Size = new System.Drawing.Size(124, 41);
            this.connectBTN.TabIndex = 13;
            this.connectBTN.Text = "Connect";
            this.connectBTN.UseVisualStyleBackColor = true;
            this.connectBTN.Click += new System.EventHandler(this.connectBTN_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Venue Id:";
            // 
            // venueIdTB
            // 
            this.venueIdTB.Location = new System.Drawing.Point(85, 23);
            this.venueIdTB.Name = "venueIdTB";
            this.venueIdTB.Size = new System.Drawing.Size(32, 20);
            this.venueIdTB.TabIndex = 11;
            this.venueIdTB.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(277, 127);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(32, 20);
            this.loopTB.TabIndex = 25;
            this.loopTB.Text = "1";
            // 
            // InVenueTerminalsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "InVenueTerminalsUC";
            this.Size = new System.Drawing.Size(808, 244);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button pollBTN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox terminalNoTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox termVersionTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox osTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox memoryTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hardwareVerTB;
        private System.Windows.Forms.Button cacheBTN;
        private System.Windows.Forms.Button connectBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox venueIdTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox loopTB;
    }
}
