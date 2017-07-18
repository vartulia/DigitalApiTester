namespace DigitalAPI_Forms
{
    partial class InVenueVenueUC
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
            this.getVenueListBTN = new System.Windows.Forms.Button();
            this.getVenueCachesBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.venueIdTB = new System.Windows.Forms.TextBox();
            this.wageringTerminalsBTN = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.getVenueListBTN);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 200);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request";
            // 
            // getVenueListBTN
            // 
            this.getVenueListBTN.Location = new System.Drawing.Point(62, 109);
            this.getVenueListBTN.Name = "getVenueListBTN";
            this.getVenueListBTN.Size = new System.Drawing.Size(124, 48);
            this.getVenueListBTN.TabIndex = 8;
            this.getVenueListBTN.Text = "Get Venue List";
            this.getVenueListBTN.UseVisualStyleBackColor = true;
            this.getVenueListBTN.Click += new System.EventHandler(this.getVenueListBTN_Click);
            // 
            // getVenueCachesBTN
            // 
            this.getVenueCachesBTN.Location = new System.Drawing.Point(62, 109);
            this.getVenueCachesBTN.Name = "getVenueCachesBTN";
            this.getVenueCachesBTN.Size = new System.Drawing.Size(124, 48);
            this.getVenueCachesBTN.TabIndex = 8;
            this.getVenueCachesBTN.Text = "Get Venue Caches";
            this.getVenueCachesBTN.UseVisualStyleBackColor = true;
            this.getVenueCachesBTN.Click += new System.EventHandler(this.getVenueCachesBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.wageringTerminalsBTN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.venueIdTB);
            this.groupBox1.Controls.Add(this.getVenueCachesBTN);
            this.groupBox1.Location = new System.Drawing.Point(201, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 200);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Venue Id:";
            // 
            // venueIdTB
            // 
            this.venueIdTB.Location = new System.Drawing.Point(85, 23);
            this.venueIdTB.Name = "venueIdTB";
            this.venueIdTB.Size = new System.Drawing.Size(61, 20);
            this.venueIdTB.TabIndex = 11;
            // 
            // wageringTerminalsBTN
            // 
            this.wageringTerminalsBTN.Location = new System.Drawing.Point(62, 55);
            this.wageringTerminalsBTN.Name = "wageringTerminalsBTN";
            this.wageringTerminalsBTN.Size = new System.Drawing.Size(124, 48);
            this.wageringTerminalsBTN.TabIndex = 13;
            this.wageringTerminalsBTN.Text = "Get Wagering Terminals";
            this.wageringTerminalsBTN.UseVisualStyleBackColor = true;
            this.wageringTerminalsBTN.Click += new System.EventHandler(this.wageringTerminalsBTN_Click);
            // 
            // InVenueVenueUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "InVenueVenueUC";
            this.Size = new System.Drawing.Size(711, 229);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button getVenueListBTN;
        private System.Windows.Forms.Button getVenueCachesBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox venueIdTB;
        private System.Windows.Forms.Button wageringTerminalsBTN;
    }
}
