namespace DigitalAPI_Forms
{
    partial class ScanRetailTicketUC
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
            this.EnquireTicketBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.infoLBL = new System.Windows.Forms.Label();
            this.jursidictionCB = new System.Windows.Forms.ComboBox();
            this.jurisdictionLBL = new System.Windows.Forms.Label();
            this.EnquireTicketNOTLoggedInBTN = new System.Windows.Forms.Button();
            this.pinLBL = new System.Windows.Forms.Label();
            this.pinTB = new System.Windows.Forms.TextBox();
            this.payTicketBTN = new System.Windows.Forms.Button();
            this.tsnLBL = new System.Windows.Forms.Label();
            this.tsnTB = new System.Windows.Forms.TextBox();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnquireTicketBTN
            // 
            this.EnquireTicketBTN.Location = new System.Drawing.Point(30, 154);
            this.EnquireTicketBTN.Name = "EnquireTicketBTN";
            this.EnquireTicketBTN.Size = new System.Drawing.Size(101, 40);
            this.EnquireTicketBTN.TabIndex = 9;
            this.EnquireTicketBTN.Text = "LOGGED IN Enquiry";
            this.EnquireTicketBTN.UseVisualStyleBackColor = true;
            this.EnquireTicketBTN.Click += new System.EventHandler(this.EnquireTicketBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.infoLBL);
            this.groupBox1.Controls.Add(this.jursidictionCB);
            this.groupBox1.Controls.Add(this.jurisdictionLBL);
            this.groupBox1.Controls.Add(this.EnquireTicketNOTLoggedInBTN);
            this.groupBox1.Controls.Add(this.pinLBL);
            this.groupBox1.Controls.Add(this.pinTB);
            this.groupBox1.Controls.Add(this.payTicketBTN);
            this.groupBox1.Controls.Add(this.tsnLBL);
            this.groupBox1.Controls.Add(this.tsnTB);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.EnquireTicketBTN);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 200);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // infoLBL
            // 
            this.infoLBL.AutoSize = true;
            this.infoLBL.Location = new System.Drawing.Point(175, 74);
            this.infoLBL.Name = "infoLBL";
            this.infoLBL.Size = new System.Drawing.Size(264, 13);
            this.infoLBL.TabIndex = 54;
            this.infoLBL.Text = "Jurisdiction only requried for NON LOGGED IN Enquiry";
            // 
            // jursidictionCB
            // 
            this.jursidictionCB.FormattingEnabled = true;
            this.jursidictionCB.Items.AddRange(new object[] {
            "VIC",
            "NSW",
            "ACT"});
            this.jursidictionCB.Location = new System.Drawing.Point(88, 71);
            this.jursidictionCB.Name = "jursidictionCB";
            this.jursidictionCB.Size = new System.Drawing.Size(81, 21);
            this.jursidictionCB.TabIndex = 53;
            this.jursidictionCB.Text = "VIC";
            // 
            // jurisdictionLBL
            // 
            this.jurisdictionLBL.AutoSize = true;
            this.jurisdictionLBL.Location = new System.Drawing.Point(6, 74);
            this.jurisdictionLBL.Name = "jurisdictionLBL";
            this.jurisdictionLBL.Size = new System.Drawing.Size(85, 13);
            this.jurisdictionLBL.TabIndex = 52;
            this.jurisdictionLBL.Text = "JURISDICTION:";
            // 
            // EnquireTicketNOTLoggedInBTN
            // 
            this.EnquireTicketNOTLoggedInBTN.ForeColor = System.Drawing.Color.Red;
            this.EnquireTicketNOTLoggedInBTN.Location = new System.Drawing.Point(30, 108);
            this.EnquireTicketNOTLoggedInBTN.Name = "EnquireTicketNOTLoggedInBTN";
            this.EnquireTicketNOTLoggedInBTN.Size = new System.Drawing.Size(101, 40);
            this.EnquireTicketNOTLoggedInBTN.TabIndex = 50;
            this.EnquireTicketNOTLoggedInBTN.Text = "NOT LOGGED IN Enquiry";
            this.EnquireTicketNOTLoggedInBTN.UseVisualStyleBackColor = true;
            this.EnquireTicketNOTLoggedInBTN.Click += new System.EventHandler(this.EnquireTicketNOTLoggedInBTN_Click);
            // 
            // pinLBL
            // 
            this.pinLBL.AutoSize = true;
            this.pinLBL.Location = new System.Drawing.Point(6, 48);
            this.pinLBL.Name = "pinLBL";
            this.pinLBL.Size = new System.Drawing.Size(28, 13);
            this.pinLBL.TabIndex = 49;
            this.pinLBL.Text = "PIN:";
            // 
            // pinTB
            // 
            this.pinTB.Location = new System.Drawing.Point(88, 45);
            this.pinTB.Name = "pinTB";
            this.pinTB.Size = new System.Drawing.Size(52, 20);
            this.pinTB.TabIndex = 48;
            // 
            // payTicketBTN
            // 
            this.payTicketBTN.Location = new System.Drawing.Point(137, 154);
            this.payTicketBTN.Name = "payTicketBTN";
            this.payTicketBTN.Size = new System.Drawing.Size(101, 40);
            this.payTicketBTN.TabIndex = 47;
            this.payTicketBTN.Text = "LOGGED IN     Pay Ticket";
            this.payTicketBTN.UseVisualStyleBackColor = true;
            this.payTicketBTN.Click += new System.EventHandler(this.payTicketBTN_Click);
            // 
            // tsnLBL
            // 
            this.tsnLBL.AutoSize = true;
            this.tsnLBL.Location = new System.Drawing.Point(6, 22);
            this.tsnLBL.Name = "tsnLBL";
            this.tsnLBL.Size = new System.Drawing.Size(32, 13);
            this.tsnLBL.TabIndex = 46;
            this.tsnLBL.Text = "TSN:";
            // 
            // tsnTB
            // 
            this.tsnTB.Location = new System.Drawing.Point(88, 19);
            this.tsnTB.Name = "tsnTB";
            this.tsnTB.Size = new System.Drawing.Size(144, 20);
            this.tsnTB.TabIndex = 45;
            this.tsnTB.TextChanged += new System.EventHandler(this.tsnTB_TextChanged);
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(156, 111);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 12;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(196, 108);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 11;
            this.loopTB.Text = "1";
            // 
            // ScanRetailTicketUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ScanRetailTicketUC";
            this.Size = new System.Drawing.Size(500, 205);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EnquireTicketBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.Label tsnLBL;
        private System.Windows.Forms.TextBox tsnTB;
        private System.Windows.Forms.Button payTicketBTN;
        private System.Windows.Forms.Label pinLBL;
        private System.Windows.Forms.TextBox pinTB;
        private System.Windows.Forms.Button EnquireTicketNOTLoggedInBTN;
        private System.Windows.Forms.Label jurisdictionLBL;
        private System.Windows.Forms.ComboBox jursidictionCB;
        private System.Windows.Forms.Label infoLBL;
    }
}
