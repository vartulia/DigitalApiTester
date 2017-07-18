namespace DigitalAPI_Forms
{
    partial class AccountUnlockUC
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
            this.AccountNo_DOB = new System.Windows.Forms.TextBox();
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
            this.loopDOB = new System.Windows.Forms.TextBox();
            this.callAPI_dobBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dobLBL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.accountNumberTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Surname_DOB = new System.Windows.Forms.TextBox();
            this.Channel_DOB = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.challengeAnswer2TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DOB_DOB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.challengeAnswer1TB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.password1TB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.password2TB = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccountNo_DOB
            // 
            this.AccountNo_DOB.Location = new System.Drawing.Point(86, 30);
            this.AccountNo_DOB.Name = "AccountNo_DOB";
            this.AccountNo_DOB.Size = new System.Drawing.Size(81, 20);
            this.AccountNo_DOB.TabIndex = 0;
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
            this.loopLBL.Location = new System.Drawing.Point(248, 151);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 10;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(289, 148);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 9;
            this.loopTB.Text = "1";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(257, 174);
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
            // loopDOB
            // 
            this.loopDOB.Location = new System.Drawing.Point(303, 148);
            this.loopDOB.Name = "loopDOB";
            this.loopDOB.Size = new System.Drawing.Size(36, 20);
            this.loopDOB.TabIndex = 9;
            this.loopDOB.Text = "1";
            // 
            // callAPI_dobBTN
            // 
            this.callAPI_dobBTN.Location = new System.Drawing.Point(271, 174);
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
            // accountNumberTB
            // 
            this.accountNumberTB.Location = new System.Drawing.Point(86, 30);
            this.accountNumberTB.Name = "accountNumberTB";
            this.accountNumberTB.Size = new System.Drawing.Size(81, 20);
            this.accountNumberTB.TabIndex = 0;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.password2TB);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.challengeAnswer2TB);
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
            this.groupBox2.Location = new System.Drawing.Point(365, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 200);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Challenge A.:";
            // 
            // challengeAnswer2TB
            // 
            this.challengeAnswer2TB.Location = new System.Drawing.Point(84, 121);
            this.challengeAnswer2TB.Name = "challengeAnswer2TB";
            this.challengeAnswer2TB.Size = new System.Drawing.Size(151, 20);
            this.challengeAnswer2TB.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Loop:";
            // 
            // DOB_DOB
            // 
            this.DOB_DOB.Location = new System.Drawing.Point(86, 53);
            this.DOB_DOB.Name = "DOB_DOB";
            this.DOB_DOB.Size = new System.Drawing.Size(81, 20);
            this.DOB_DOB.TabIndex = 1;
            this.DOB_DOB.Text = "1985-04-13";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.password1TB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.challengeAnswer1TB);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 200);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Challenge A.:";
            // 
            // challengeAnswer1TB
            // 
            this.challengeAnswer1TB.Location = new System.Drawing.Point(87, 121);
            this.challengeAnswer1TB.Name = "challengeAnswer1TB";
            this.challengeAnswer1TB.Size = new System.Drawing.Size(151, 20);
            this.challengeAnswer1TB.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Password:";
            // 
            // password1TB
            // 
            this.password1TB.Location = new System.Drawing.Point(244, 30);
            this.password1TB.Name = "password1TB";
            this.password1TB.Size = new System.Drawing.Size(81, 20);
            this.password1TB.TabIndex = 16;
            this.password1TB.Text = "password02";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Password:";
            // 
            // password2TB
            // 
            this.password2TB.Location = new System.Drawing.Point(253, 32);
            this.password2TB.Name = "password2TB";
            this.password2TB.Size = new System.Drawing.Size(81, 20);
            this.password2TB.TabIndex = 18;
            this.password2TB.Text = "password02";
            // 
            // AccountUnlockUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AccountUnlockUC";
            this.Size = new System.Drawing.Size(783, 210);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox AccountNo_DOB;
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
        private System.Windows.Forms.TextBox loopDOB;
        private System.Windows.Forms.Button callAPI_dobBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dobLBL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox accountNumberTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Surname_DOB;
        private System.Windows.Forms.ComboBox Channel_DOB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DOB_DOB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox challengeAnswer2TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox challengeAnswer1TB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox password2TB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox password1TB;
    }
}
