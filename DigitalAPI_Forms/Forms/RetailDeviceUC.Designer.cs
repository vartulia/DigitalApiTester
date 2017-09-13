namespace DigitalAPI_Forms
{
    partial class RetailDeviceUC
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
            this.getdeviceBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.window_idTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.venue_idTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteBTN = new System.Windows.Forms.Button();
            this.securityIdTB = new System.Windows.Forms.TextBox();
            this.setDeviceBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.getWindowsTB = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.LocationIdTB = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.getdeviceBTN);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.window_idTB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.venue_idTB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.deleteBTN);
            this.groupBox2.Controls.Add(this.securityIdTB);
            this.groupBox2.Controls.Add(this.setDeviceBTN);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 200);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request";
            // 
            // getdeviceBTN
            // 
            this.getdeviceBTN.Location = new System.Drawing.Point(19, 146);
            this.getdeviceBTN.Name = "getdeviceBTN";
            this.getdeviceBTN.Size = new System.Drawing.Size(67, 48);
            this.getdeviceBTN.TabIndex = 15;
            this.getdeviceBTN.Text = "GET Device";
            this.getdeviceBTN.UseVisualStyleBackColor = true;
            this.getdeviceBTN.Click += new System.EventHandler(this.getdeviceBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Window_id:";
            // 
            // window_idTB
            // 
            this.window_idTB.Location = new System.Drawing.Point(77, 73);
            this.window_idTB.Name = "window_idTB";
            this.window_idTB.Size = new System.Drawing.Size(100, 20);
            this.window_idTB.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Venue_id:";
            // 
            // venue_idTB
            // 
            this.venue_idTB.Location = new System.Drawing.Point(77, 51);
            this.venue_idTB.Name = "venue_idTB";
            this.venue_idTB.Size = new System.Drawing.Size(100, 20);
            this.venue_idTB.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Secuirty Id:";
            // 
            // deleteBTN
            // 
            this.deleteBTN.Location = new System.Drawing.Point(19, 97);
            this.deleteBTN.Name = "deleteBTN";
            this.deleteBTN.Size = new System.Drawing.Size(67, 48);
            this.deleteBTN.TabIndex = 8;
            this.deleteBTN.Text = "Delete ";
            this.deleteBTN.UseVisualStyleBackColor = true;
            this.deleteBTN.Click += new System.EventHandler(this.deleteBTN_Click);
            // 
            // securityIdTB
            // 
            this.securityIdTB.Location = new System.Drawing.Point(77, 28);
            this.securityIdTB.Name = "securityIdTB";
            this.securityIdTB.Size = new System.Drawing.Size(100, 20);
            this.securityIdTB.TabIndex = 9;
            // 
            // setDeviceBTN
            // 
            this.setDeviceBTN.Location = new System.Drawing.Point(92, 97);
            this.setDeviceBTN.Name = "setDeviceBTN";
            this.setDeviceBTN.Size = new System.Drawing.Size(94, 48);
            this.setDeviceBTN.TabIndex = 8;
            this.setDeviceBTN.Text = "Set Device";
            this.setDeviceBTN.UseVisualStyleBackColor = true;
            this.setDeviceBTN.Click += new System.EventHandler(this.setDeviceBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.getWindowsTB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.LocationIdTB);
            this.groupBox1.Location = new System.Drawing.Point(285, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 200);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // getWindowsTB
            // 
            this.getWindowsTB.Location = new System.Drawing.Point(99, 148);
            this.getWindowsTB.Name = "getWindowsTB";
            this.getWindowsTB.Size = new System.Drawing.Size(87, 46);
            this.getWindowsTB.TabIndex = 15;
            this.getWindowsTB.Text = "GET Windows By Location";
            this.getWindowsTB.UseVisualStyleBackColor = true;
            this.getWindowsTB.Click += new System.EventHandler(this.getWindowsTB_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Location Id:";
            // 
            // LocationIdTB
            // 
            this.LocationIdTB.Location = new System.Drawing.Point(77, 28);
            this.LocationIdTB.Name = "LocationIdTB";
            this.LocationIdTB.Size = new System.Drawing.Size(100, 20);
            this.LocationIdTB.TabIndex = 9;
            // 
            // RetailDeviceUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "RetailDeviceUC";
            this.Size = new System.Drawing.Size(762, 202);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteBTN;
        private System.Windows.Forms.TextBox securityIdTB;
        private System.Windows.Forms.Button setDeviceBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox window_idTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox venue_idTB;
        private System.Windows.Forms.Button getdeviceBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button getWindowsTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox LocationIdTB;
    }
}
