namespace DigitalAPI_Forms
{
    partial class InVenueCommissionsUC
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
            this.addBTN = new System.Windows.Forms.Button();
            this.betTransactionNumbersTB = new System.Windows.Forms.TextBox();
            this.betTransactionNumbersLBL = new System.Windows.Forms.Label();
            this.beaconVenueIdTB = new System.Windows.Forms.TextBox();
            this.beaconVenueIdLBL = new System.Windows.Forms.Label();
            this.blueDotFenceTB = new System.Windows.Forms.TextBox();
            this.blueDotFenceLBL = new System.Windows.Forms.Label();
            this.uncertaintyTB = new System.Windows.Forms.TextBox();
            this.uncertaintyLBL = new System.Windows.Forms.Label();
            this.accountIdTB = new System.Windows.Forms.TextBox();
            this.typeCB = new System.Windows.Forms.ComboBox();
            this.longitudeTB = new System.Windows.Forms.TextBox();
            this.longitudeLBL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.latitudeTB = new System.Windows.Forms.TextBox();
            this.latitudeLBL = new System.Windows.Forms.Label();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.statusLBL = new System.Windows.Forms.Label();
            this.clearBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearBTN);
            this.groupBox1.Controls.Add(this.addBTN);
            this.groupBox1.Controls.Add(this.betTransactionNumbersTB);
            this.groupBox1.Controls.Add(this.betTransactionNumbersLBL);
            this.groupBox1.Controls.Add(this.beaconVenueIdTB);
            this.groupBox1.Controls.Add(this.beaconVenueIdLBL);
            this.groupBox1.Controls.Add(this.blueDotFenceTB);
            this.groupBox1.Controls.Add(this.blueDotFenceLBL);
            this.groupBox1.Controls.Add(this.uncertaintyTB);
            this.groupBox1.Controls.Add(this.uncertaintyLBL);
            this.groupBox1.Controls.Add(this.accountIdTB);
            this.groupBox1.Controls.Add(this.typeCB);
            this.groupBox1.Controls.Add(this.longitudeTB);
            this.groupBox1.Controls.Add(this.longitudeLBL);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimeTB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.latitudeTB);
            this.groupBox1.Controls.Add(this.latitudeLBL);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Controls.Add(this.statusLBL);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 200);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // addBTN
            // 
            this.addBTN.Location = new System.Drawing.Point(414, 98);
            this.addBTN.Name = "addBTN";
            this.addBTN.Size = new System.Drawing.Size(38, 23);
            this.addBTN.TabIndex = 36;
            this.addBTN.Text = "Add";
            this.addBTN.UseVisualStyleBackColor = true;
            this.addBTN.Click += new System.EventHandler(this.addBTN_Click);
            // 
            // betTransactionNumbersTB
            // 
            this.betTransactionNumbersTB.Enabled = false;
            this.betTransactionNumbersTB.Location = new System.Drawing.Point(280, 98);
            this.betTransactionNumbersTB.Name = "betTransactionNumbersTB";
            this.betTransactionNumbersTB.Size = new System.Drawing.Size(131, 20);
            this.betTransactionNumbersTB.TabIndex = 35;
            this.betTransactionNumbersTB.Text = "023717471719382901";
            // 
            // betTransactionNumbersLBL
            // 
            this.betTransactionNumbersLBL.AutoSize = true;
            this.betTransactionNumbersLBL.Enabled = false;
            this.betTransactionNumbersLBL.Location = new System.Drawing.Point(193, 101);
            this.betTransactionNumbersLBL.Name = "betTransactionNumbersLBL";
            this.betTransactionNumbersLBL.Size = new System.Drawing.Size(80, 13);
            this.betTransactionNumbersLBL.TabIndex = 34;
            this.betTransactionNumbersLBL.Text = "Bet Trans No\'s:";
            // 
            // beaconVenueIdTB
            // 
            this.beaconVenueIdTB.Location = new System.Drawing.Point(280, 75);
            this.beaconVenueIdTB.Name = "beaconVenueIdTB";
            this.beaconVenueIdTB.Size = new System.Drawing.Size(93, 20);
            this.beaconVenueIdTB.TabIndex = 33;
            this.beaconVenueIdTB.Text = "1";
            // 
            // beaconVenueIdLBL
            // 
            this.beaconVenueIdLBL.AutoSize = true;
            this.beaconVenueIdLBL.Location = new System.Drawing.Point(193, 78);
            this.beaconVenueIdLBL.Name = "beaconVenueIdLBL";
            this.beaconVenueIdLBL.Size = new System.Drawing.Size(87, 13);
            this.beaconVenueIdLBL.TabIndex = 32;
            this.beaconVenueIdLBL.Text = "BeaconVenueId:";
            // 
            // blueDotFenceTB
            // 
            this.blueDotFenceTB.Location = new System.Drawing.Point(280, 51);
            this.blueDotFenceTB.Name = "blueDotFenceTB";
            this.blueDotFenceTB.Size = new System.Drawing.Size(93, 20);
            this.blueDotFenceTB.TabIndex = 31;
            this.blueDotFenceTB.Text = "something";
            // 
            // blueDotFenceLBL
            // 
            this.blueDotFenceLBL.AutoSize = true;
            this.blueDotFenceLBL.Location = new System.Drawing.Point(196, 54);
            this.blueDotFenceLBL.Name = "blueDotFenceLBL";
            this.blueDotFenceLBL.Size = new System.Drawing.Size(78, 13);
            this.blueDotFenceLBL.TabIndex = 30;
            this.blueDotFenceLBL.Text = "BlueDotFence:";
            // 
            // uncertaintyTB
            // 
            this.uncertaintyTB.Location = new System.Drawing.Point(71, 142);
            this.uncertaintyTB.Name = "uncertaintyTB";
            this.uncertaintyTB.Size = new System.Drawing.Size(93, 20);
            this.uncertaintyTB.TabIndex = 29;
            this.uncertaintyTB.Text = "12.345";
            // 
            // uncertaintyLBL
            // 
            this.uncertaintyLBL.AutoSize = true;
            this.uncertaintyLBL.Location = new System.Drawing.Point(9, 145);
            this.uncertaintyLBL.Name = "uncertaintyLBL";
            this.uncertaintyLBL.Size = new System.Drawing.Size(64, 13);
            this.uncertaintyLBL.TabIndex = 28;
            this.uncertaintyLBL.Text = "Uncertainty:";
            // 
            // accountIdTB
            // 
            this.accountIdTB.Location = new System.Drawing.Point(72, 47);
            this.accountIdTB.Name = "accountIdTB";
            this.accountIdTB.Size = new System.Drawing.Size(93, 20);
            this.accountIdTB.TabIndex = 27;
            this.accountIdTB.Text = "100";
            // 
            // typeCB
            // 
            this.typeCB.FormattingEnabled = true;
            this.typeCB.Items.AddRange(new object[] {
            "ACCOUNT_SIGNUP",
            "PLACE_BET"});
            this.typeCB.Location = new System.Drawing.Point(72, 19);
            this.typeCB.Name = "typeCB";
            this.typeCB.Size = new System.Drawing.Size(123, 21);
            this.typeCB.TabIndex = 26;
            this.typeCB.Text = "ACCOUNT_SIGNUP";
            this.typeCB.SelectedIndexChanged += new System.EventHandler(this.typeCB_SelectedIndexChanged);
            // 
            // longitudeTB
            // 
            this.longitudeTB.Location = new System.Drawing.Point(71, 118);
            this.longitudeTB.Name = "longitudeTB";
            this.longitudeTB.Size = new System.Drawing.Size(93, 20);
            this.longitudeTB.TabIndex = 25;
            this.longitudeTB.Text = "40";
            // 
            // longitudeLBL
            // 
            this.longitudeLBL.AutoSize = true;
            this.longitudeLBL.Location = new System.Drawing.Point(9, 121);
            this.longitudeLBL.Name = "longitudeLBL";
            this.longitudeLBL.Size = new System.Drawing.Size(57, 13);
            this.longitudeLBL.TabIndex = 24;
            this.longitudeLBL.Text = "Longitude:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Account Id:";
            // 
            // dateTimeTB
            // 
            this.dateTimeTB.Location = new System.Drawing.Point(72, 71);
            this.dateTimeTB.Name = "dateTimeTB";
            this.dateTimeTB.Size = new System.Drawing.Size(93, 20);
            this.dateTimeTB.TabIndex = 21;
            this.dateTimeTB.Text = "2014-12-31T23:59:59.999Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Date/Time:";
            // 
            // latitudeTB
            // 
            this.latitudeTB.Location = new System.Drawing.Point(72, 94);
            this.latitudeTB.Name = "latitudeTB";
            this.latitudeTB.Size = new System.Drawing.Size(93, 20);
            this.latitudeTB.TabIndex = 19;
            this.latitudeTB.Text = "40";
            // 
            // latitudeLBL
            // 
            this.latitudeLBL.AutoSize = true;
            this.latitudeLBL.Location = new System.Drawing.Point(9, 97);
            this.latitudeLBL.Name = "latitudeLBL";
            this.latitudeLBL.Size = new System.Drawing.Size(48, 13);
            this.latitudeLBL.TabIndex = 18;
            this.latitudeLBL.Text = "Latitude:";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(377, 145);
            this.CallApiBTN.Name = "CallApiBTN";
            this.CallApiBTN.Size = new System.Drawing.Size(75, 23);
            this.CallApiBTN.TabIndex = 8;
            this.CallApiBTN.Text = "Call API";
            this.CallApiBTN.UseVisualStyleBackColor = true;
            this.CallApiBTN.Click += new System.EventHandler(this.CallApiBTN_Click);
            // 
            // statusLBL
            // 
            this.statusLBL.AutoSize = true;
            this.statusLBL.Location = new System.Drawing.Point(36, 23);
            this.statusLBL.Name = "statusLBL";
            this.statusLBL.Size = new System.Drawing.Size(34, 13);
            this.statusLBL.TabIndex = 4;
            this.statusLBL.Text = "Type:";
            // 
            // clearBTN
            // 
            this.clearBTN.Location = new System.Drawing.Point(452, 98);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(43, 23);
            this.clearBTN.TabIndex = 37;
            this.clearBTN.Text = "Clear";
            this.clearBTN.UseVisualStyleBackColor = true;
            this.clearBTN.Click += new System.EventHandler(this.clearBTN_Click);
            // 
            // InVenueCommissionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "InVenueCommissionsUC";
            this.Size = new System.Drawing.Size(742, 221);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox typeCB;
        private System.Windows.Forms.TextBox longitudeTB;
        private System.Windows.Forms.Label longitudeLBL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dateTimeTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox latitudeTB;
        private System.Windows.Forms.Label latitudeLBL;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.Label statusLBL;
        private System.Windows.Forms.TextBox accountIdTB;
        private System.Windows.Forms.TextBox uncertaintyTB;
        private System.Windows.Forms.Label uncertaintyLBL;
        private System.Windows.Forms.TextBox beaconVenueIdTB;
        private System.Windows.Forms.Label beaconVenueIdLBL;
        private System.Windows.Forms.TextBox blueDotFenceTB;
        private System.Windows.Forms.Label blueDotFenceLBL;
        private System.Windows.Forms.TextBox betTransactionNumbersTB;
        private System.Windows.Forms.Label betTransactionNumbersLBL;
        private System.Windows.Forms.Button addBTN;
        private System.Windows.Forms.Button clearBTN;
    }
}
