namespace DigitalAPI_Forms
{
    partial class cashoutUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.partialAmountTB = new System.Windows.Forms.TextBox();
            this.cashoutOfferBTN = new System.Windows.Forms.Button();
            this.getOfferIdBTN = new System.Windows.Forms.Button();
            this.Request_BTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.serial_numberLBL = new System.Windows.Forms.Label();
            this.OfferAmountTB = new System.Windows.Forms.TextBox();
            this.serialTB = new System.Windows.Forms.TextBox();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.Accept = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.partialAmountTB);
            this.groupBox1.Controls.Add(this.cashoutOfferBTN);
            this.groupBox1.Controls.Add(this.getOfferIdBTN);
            this.groupBox1.Controls.Add(this.Request_BTN);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.serial_numberLBL);
            this.groupBox1.Controls.Add(this.OfferAmountTB);
            this.groupBox1.Controls.Add(this.serialTB);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.Accept);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 242);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Partial Amount:";
            // 
            // partialAmountTB
            // 
            this.partialAmountTB.Location = new System.Drawing.Point(103, 91);
            this.partialAmountTB.Name = "partialAmountTB";
            this.partialAmountTB.Size = new System.Drawing.Size(59, 20);
            this.partialAmountTB.TabIndex = 32;
            // 
            // cashoutOfferBTN
            // 
            this.cashoutOfferBTN.Location = new System.Drawing.Point(496, 39);
            this.cashoutOfferBTN.Name = "cashoutOfferBTN";
            this.cashoutOfferBTN.Size = new System.Drawing.Size(90, 47);
            this.cashoutOfferBTN.TabIndex = 10;
            this.cashoutOfferBTN.Text = "View Bets Available to be cashed Out.";
            this.cashoutOfferBTN.UseVisualStyleBackColor = true;
            this.cashoutOfferBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // getOfferIdBTN
            // 
            this.getOfferIdBTN.Location = new System.Drawing.Point(363, 189);
            this.getOfferIdBTN.Name = "getOfferIdBTN";
            this.getOfferIdBTN.Size = new System.Drawing.Size(75, 23);
            this.getOfferIdBTN.TabIndex = 31;
            this.getOfferIdBTN.Text = "Get OfferId";
            this.getOfferIdBTN.UseVisualStyleBackColor = true;
            this.getOfferIdBTN.Click += new System.EventHandler(this.getOfferIdBTN_Click);
            // 
            // Request_BTN
            // 
            this.Request_BTN.Location = new System.Drawing.Point(179, 189);
            this.Request_BTN.Name = "Request_BTN";
            this.Request_BTN.Size = new System.Drawing.Size(75, 23);
            this.Request_BTN.TabIndex = 30;
            this.Request_BTN.Text = "Request";
            this.Request_BTN.UseVisualStyleBackColor = true;
            this.Request_BTN.Click += new System.EventHandler(this.Request_BTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Cash Out Amount:";
            // 
            // serial_numberLBL
            // 
            this.serial_numberLBL.AutoSize = true;
            this.serial_numberLBL.Location = new System.Drawing.Point(6, 50);
            this.serial_numberLBL.Name = "serial_numberLBL";
            this.serial_numberLBL.Size = new System.Drawing.Size(53, 13);
            this.serial_numberLBL.TabIndex = 21;
            this.serial_numberLBL.Text = "Serial No:";
            // 
            // OfferAmountTB
            // 
            this.OfferAmountTB.Location = new System.Drawing.Point(103, 66);
            this.OfferAmountTB.Name = "OfferAmountTB";
            this.OfferAmountTB.Size = new System.Drawing.Size(59, 20);
            this.OfferAmountTB.TabIndex = 15;
            // 
            // serialTB
            // 
            this.serialTB.Location = new System.Drawing.Point(103, 42);
            this.serialTB.Name = "serialTB";
            this.serialTB.Size = new System.Drawing.Size(167, 20);
            this.serialTB.TabIndex = 14;
            this.serialTB.Text = "xxxxxxxxxxxxxx901";
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(193, 166);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 12;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(234, 163);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(20, 20);
            this.loopTB.TabIndex = 11;
            this.loopTB.Text = "1";
            // 
            // Accept
            // 
            this.Accept.Location = new System.Drawing.Point(260, 189);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(75, 23);
            this.Accept.TabIndex = 8;
            this.Accept.Text = "Accept";
            this.Accept.UseVisualStyleBackColor = true;
            this.Accept.Click += new System.EventHandler(this.CallApiBTN_Click);
            // 
            // cashoutUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "cashoutUC";
            this.Size = new System.Drawing.Size(595, 291);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.TextBox OfferAmountTB;
        private System.Windows.Forms.TextBox serialTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label serial_numberLBL;
        private System.Windows.Forms.Button Request_BTN;
        private System.Windows.Forms.Button getOfferIdBTN;
        private System.Windows.Forms.Button cashoutOfferBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox partialAmountTB;
    }
}
