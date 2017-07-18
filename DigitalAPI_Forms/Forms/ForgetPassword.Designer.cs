namespace DigitalAPI_Forms
{
    partial class ForgetPassword
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
            this.surnameLBL = new System.Windows.Forms.Label();
            this.surnameTB = new System.Windows.Forms.TextBox();
            this.channelCB = new System.Windows.Forms.ComboBox();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.ChannelLB = new System.Windows.Forms.Label();
            this.pinLBL = new System.Windows.Forms.Label();
            this.accountNumberLBL = new System.Windows.Forms.Label();
            this.pinTB = new System.Windows.Forms.TextBox();
            this.accountNumberTB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Surname_DOB = new System.Windows.Forms.TextBox();
            this.Channel_DOB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loopDOB = new System.Windows.Forms.TextBox();
            this.callAPI_dobBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dobLBL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DOB_DOB = new System.Windows.Forms.TextBox();
            this.AccountNo_DOB = new System.Windows.Forms.TextBox();
            this.challengeA_TB = new System.Windows.Forms.TextBox();
            this.pwordTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.callAPIChallBTN = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chanChallengeCB = new System.Windows.Forms.ComboBox();
            this.acctNoChallTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.surnameLBL);
            this.groupBox1.Controls.Add(this.surnameTB);
            this.groupBox1.Controls.Add(this.channelCB);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Controls.Add(this.ChannelLB);
            this.groupBox1.Controls.Add(this.pinLBL);
            this.groupBox1.Controls.Add(this.accountNumberLBL);
            this.groupBox1.Controls.Add(this.pinTB);
            this.groupBox1.Controls.Add(this.accountNumberTB);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 200);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // surnameLBL
            // 
            this.surnameLBL.AutoSize = true;
            this.surnameLBL.Location = new System.Drawing.Point(24, 83);
            this.surnameLBL.Name = "surnameLBL";
            this.surnameLBL.Size = new System.Drawing.Size(52, 13);
            this.surnameLBL.TabIndex = 13;
            this.surnameLBL.Text = "Surname:";
            // 
            // surnameTB
            // 
            this.surnameTB.Location = new System.Drawing.Point(86, 76);
            this.surnameTB.Name = "surnameTB";
            this.surnameTB.Size = new System.Drawing.Size(81, 20);
            this.surnameTB.TabIndex = 12;
            // 
            // channelCB
            // 
            this.channelCB.FormattingEnabled = true;
            this.channelCB.Items.AddRange(new object[] {
            "WEB",
            "IPAD",
            "IPHONE",
            "ANDROID"});
            this.channelCB.Location = new System.Drawing.Point(86, 98);
            this.channelCB.Name = "channelCB";
            this.channelCB.Size = new System.Drawing.Size(81, 21);
            this.channelCB.TabIndex = 11;
            this.channelCB.Text = "WEB";
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(155, 132);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 10;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(196, 129);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 9;
            this.loopTB.Text = "1";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(164, 155);
            this.CallApiBTN.Name = "CallApiBTN";
            this.CallApiBTN.Size = new System.Drawing.Size(75, 23);
            this.CallApiBTN.TabIndex = 8;
            this.CallApiBTN.Text = "Call API";
            this.CallApiBTN.UseVisualStyleBackColor = true;
            this.CallApiBTN.Click += new System.EventHandler(this.CallApiBTN_Click);
            // 
            // ChannelLB
            // 
            this.ChannelLB.AutoSize = true;
            this.ChannelLB.Location = new System.Drawing.Point(31, 103);
            this.ChannelLB.Name = "ChannelLB";
            this.ChannelLB.Size = new System.Drawing.Size(49, 13);
            this.ChannelLB.TabIndex = 5;
            this.ChannelLB.Text = "Channel:";
            // 
            // pinLBL
            // 
            this.pinLBL.AutoSize = true;
            this.pinLBL.Location = new System.Drawing.Point(24, 60);
            this.pinLBL.Name = "pinLBL";
            this.pinLBL.Size = new System.Drawing.Size(25, 13);
            this.pinLBL.TabIndex = 4;
            this.pinLBL.Text = "Pin:";
            // 
            // accountNumberLBL
            // 
            this.accountNumberLBL.AutoSize = true;
            this.accountNumberLBL.Location = new System.Drawing.Point(12, 37);
            this.accountNumberLBL.Name = "accountNumberLBL";
            this.accountNumberLBL.Size = new System.Drawing.Size(67, 13);
            this.accountNumberLBL.TabIndex = 3;
            this.accountNumberLBL.Text = "Account No:";
            // 
            // pinTB
            // 
            this.pinTB.Location = new System.Drawing.Point(86, 53);
            this.pinTB.Name = "pinTB";
            this.pinTB.Size = new System.Drawing.Size(54, 20);
            this.pinTB.TabIndex = 1;
            this.pinTB.Text = "1122";
            // 
            // accountNumberTB
            // 
            this.accountNumberTB.Location = new System.Drawing.Point(86, 30);
            this.accountNumberTB.Name = "accountNumberTB";
            this.accountNumberTB.Size = new System.Drawing.Size(81, 20);
            this.accountNumberTB.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Surname_DOB);
            this.groupBox2.Controls.Add(this.Channel_DOB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.loopDOB);
            this.groupBox2.Controls.Add(this.callAPI_dobBTN);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dobLBL);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.DOB_DOB);
            this.groupBox2.Controls.Add(this.AccountNo_DOB);
            this.groupBox2.Location = new System.Drawing.Point(250, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 200);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Surname:";
            // 
            // Surname_DOB
            // 
            this.Surname_DOB.Location = new System.Drawing.Point(86, 76);
            this.Surname_DOB.Name = "Surname_DOB";
            this.Surname_DOB.Size = new System.Drawing.Size(81, 20);
            this.Surname_DOB.TabIndex = 12;
            // 
            // Channel_DOB
            // 
            this.Channel_DOB.FormattingEnabled = true;
            this.Channel_DOB.Items.AddRange(new object[] {
            "WEB",
            "IPAD",
            "IPHONE",
            "ANDROID"});
            this.Channel_DOB.Location = new System.Drawing.Point(86, 98);
            this.Channel_DOB.Name = "Channel_DOB";
            this.Channel_DOB.Size = new System.Drawing.Size(81, 21);
            this.Channel_DOB.TabIndex = 11;
            this.Channel_DOB.Text = "WEB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Loop:";
            // 
            // loopDOB
            // 
            this.loopDOB.Location = new System.Drawing.Point(196, 129);
            this.loopDOB.Name = "loopDOB";
            this.loopDOB.Size = new System.Drawing.Size(36, 20);
            this.loopDOB.TabIndex = 9;
            this.loopDOB.Text = "1";
            // 
            // callAPI_dobBTN
            // 
            this.callAPI_dobBTN.Location = new System.Drawing.Point(164, 155);
            this.callAPI_dobBTN.Name = "callAPI_dobBTN";
            this.callAPI_dobBTN.Size = new System.Drawing.Size(75, 23);
            this.callAPI_dobBTN.TabIndex = 8;
            this.callAPI_dobBTN.Text = "Call API";
            this.callAPI_dobBTN.UseVisualStyleBackColor = true;
            this.callAPI_dobBTN.Click += new System.EventHandler(this.callAPI_dobBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Channel:";
            // 
            // dobLBL
            // 
            this.dobLBL.AutoSize = true;
            this.dobLBL.Location = new System.Drawing.Point(24, 60);
            this.dobLBL.Name = "dobLBL";
            this.dobLBL.Size = new System.Drawing.Size(33, 13);
            this.dobLBL.TabIndex = 4;
            this.dobLBL.Text = "DOB:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Account No:";
            // 
            // DOB_DOB
            // 
            this.DOB_DOB.Location = new System.Drawing.Point(86, 53);
            this.DOB_DOB.Name = "DOB_DOB";
            this.DOB_DOB.Size = new System.Drawing.Size(81, 20);
            this.DOB_DOB.TabIndex = 1;
            this.DOB_DOB.Text = "1985-04-13";
            // 
            // AccountNo_DOB
            // 
            this.AccountNo_DOB.Location = new System.Drawing.Point(86, 30);
            this.AccountNo_DOB.Name = "AccountNo_DOB";
            this.AccountNo_DOB.Size = new System.Drawing.Size(81, 20);
            this.AccountNo_DOB.TabIndex = 0;
            // 
            // challengeA_TB
            // 
            this.challengeA_TB.Location = new System.Drawing.Point(110, 53);
            this.challengeA_TB.Name = "challengeA_TB";
            this.challengeA_TB.Size = new System.Drawing.Size(128, 20);
            this.challengeA_TB.TabIndex = 0;
            // 
            // pwordTB
            // 
            this.pwordTB.Location = new System.Drawing.Point(110, 79);
            this.pwordTB.Name = "pwordTB";
            this.pwordTB.Size = new System.Drawing.Size(81, 20);
            this.pwordTB.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Challenge Answer:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Channel:";
            // 
            // callAPIChallBTN
            // 
            this.callAPIChallBTN.Location = new System.Drawing.Point(164, 155);
            this.callAPIChallBTN.Name = "callAPIChallBTN";
            this.callAPIChallBTN.Size = new System.Drawing.Size(75, 23);
            this.callAPIChallBTN.TabIndex = 8;
            this.callAPIChallBTN.Text = "Call API";
            this.callAPIChallBTN.UseVisualStyleBackColor = true;
            this.callAPIChallBTN.Click += new System.EventHandler(this.callAPIChallBTN_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(196, 129);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(36, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Loop:";
            // 
            // chanChallengeCB
            // 
            this.chanChallengeCB.FormattingEnabled = true;
            this.chanChallengeCB.Items.AddRange(new object[] {
            "WEB",
            "IPAD",
            "IPHONE",
            "ANDROID"});
            this.chanChallengeCB.Location = new System.Drawing.Point(110, 102);
            this.chanChallengeCB.Name = "chanChallengeCB";
            this.chanChallengeCB.Size = new System.Drawing.Size(81, 21);
            this.chanChallengeCB.TabIndex = 11;
            this.chanChallengeCB.Text = "WEB";
            // 
            // acctNoChallTB
            // 
            this.acctNoChallTB.Location = new System.Drawing.Point(111, 28);
            this.acctNoChallTB.Name = "acctNoChallTB";
            this.acctNoChallTB.Size = new System.Drawing.Size(81, 20);
            this.acctNoChallTB.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Account No:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.acctNoChallTB);
            this.groupBox3.Controls.Add(this.chanChallengeCB);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.callAPIChallBTN);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.pwordTB);
            this.groupBox3.Controls.Add(this.challengeA_TB);
            this.groupBox3.Location = new System.Drawing.Point(500, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 200);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Challenge Answer";
            // 
            // ForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ForgetPassword";
            this.Size = new System.Drawing.Size(751, 210);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label surnameLBL;
        private System.Windows.Forms.TextBox surnameTB;
        private System.Windows.Forms.ComboBox channelCB;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.Label ChannelLB;
        private System.Windows.Forms.Label pinLBL;
        private System.Windows.Forms.Label accountNumberLBL;
        private System.Windows.Forms.TextBox pinTB;
        private System.Windows.Forms.TextBox accountNumberTB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Surname_DOB;
        private System.Windows.Forms.ComboBox Channel_DOB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loopDOB;
        private System.Windows.Forms.Button callAPI_dobBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dobLBL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DOB_DOB;
        private System.Windows.Forms.TextBox AccountNo_DOB;
        private System.Windows.Forms.TextBox challengeA_TB;
        private System.Windows.Forms.TextBox pwordTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button callAPIChallBTN;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox chanChallengeCB;
        private System.Windows.Forms.TextBox acctNoChallTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
