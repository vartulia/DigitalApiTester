namespace DigitalAPI_Forms
{
    partial class ActivateAccountUC
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
            this.challengeQuestionLBL = new System.Windows.Forms.Label();
            this.challengeAnswerTB = new System.Windows.Forms.TextBox();
            this.challengeQuestionTB = new System.Windows.Forms.TextBox();
            this.lastNameLBL = new System.Windows.Forms.Label();
            this.surnameTB = new System.Windows.Forms.TextBox();
            this.emailLBL = new System.Windows.Forms.Label();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.passwordLBL = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.channelCB = new System.Windows.Forms.ComboBox();
            this.ChannelLB = new System.Windows.Forms.Label();
            this.pinTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.accountNumberLBL = new System.Windows.Forms.Label();
            this.accountNumberTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.accountNumberLBL);
            this.groupBox1.Controls.Add(this.accountNumberTB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.challengeQuestionLBL);
            this.groupBox1.Controls.Add(this.challengeAnswerTB);
            this.groupBox1.Controls.Add(this.challengeQuestionTB);
            this.groupBox1.Controls.Add(this.lastNameLBL);
            this.groupBox1.Controls.Add(this.surnameTB);
            this.groupBox1.Controls.Add(this.emailLBL);
            this.groupBox1.Controls.Add(this.emailTB);
            this.groupBox1.Controls.Add(this.passwordLBL);
            this.groupBox1.Controls.Add(this.passwordTB);
            this.groupBox1.Controls.Add(this.channelCB);
            this.groupBox1.Controls.Add(this.ChannelLB);
            this.groupBox1.Controls.Add(this.pinTB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 200);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "challenge Answer:";
            // 
            // challengeQuestionLBL
            // 
            this.challengeQuestionLBL.AutoSize = true;
            this.challengeQuestionLBL.Location = new System.Drawing.Point(17, 144);
            this.challengeQuestionLBL.Name = "challengeQuestionLBL";
            this.challengeQuestionLBL.Size = new System.Drawing.Size(68, 13);
            this.challengeQuestionLBL.TabIndex = 41;
            this.challengeQuestionLBL.Text = "Challenge Q:";
            // 
            // challengeAnswerTB
            // 
            this.challengeAnswerTB.Location = new System.Drawing.Point(93, 162);
            this.challengeAnswerTB.Name = "challengeAnswerTB";
            this.challengeAnswerTB.Size = new System.Drawing.Size(100, 20);
            this.challengeAnswerTB.TabIndex = 40;
            this.challengeAnswerTB.Text = "Smith";
            // 
            // challengeQuestionTB
            // 
            this.challengeQuestionTB.Location = new System.Drawing.Point(93, 141);
            this.challengeQuestionTB.Name = "challengeQuestionTB";
            this.challengeQuestionTB.Size = new System.Drawing.Size(158, 20);
            this.challengeQuestionTB.TabIndex = 39;
            this.challengeQuestionTB.Text = "My mother\'s maiden name";
            // 
            // lastNameLBL
            // 
            this.lastNameLBL.AutoSize = true;
            this.lastNameLBL.Location = new System.Drawing.Point(35, 123);
            this.lastNameLBL.Name = "lastNameLBL";
            this.lastNameLBL.Size = new System.Drawing.Size(52, 13);
            this.lastNameLBL.TabIndex = 38;
            this.lastNameLBL.Text = "Surname:";
            // 
            // surnameTB
            // 
            this.surnameTB.Location = new System.Drawing.Point(93, 123);
            this.surnameTB.Name = "surnameTB";
            this.surnameTB.Size = new System.Drawing.Size(100, 20);
            this.surnameTB.TabIndex = 37;
            this.surnameTB.Text = "random";
            // 
            // emailLBL
            // 
            this.emailLBL.AutoSize = true;
            this.emailLBL.Location = new System.Drawing.Point(50, 100);
            this.emailLBL.Name = "emailLBL";
            this.emailLBL.Size = new System.Drawing.Size(35, 13);
            this.emailLBL.TabIndex = 35;
            this.emailLBL.Text = "Email:";
            // 
            // emailTB
            // 
            this.emailTB.Location = new System.Drawing.Point(93, 100);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(158, 20);
            this.emailTB.TabIndex = 34;
            this.emailTB.Text = "something@tab.com.au";
            // 
            // passwordLBL
            // 
            this.passwordLBL.AutoSize = true;
            this.passwordLBL.Location = new System.Drawing.Point(32, 77);
            this.passwordLBL.Name = "passwordLBL";
            this.passwordLBL.Size = new System.Drawing.Size(56, 13);
            this.passwordLBL.TabIndex = 31;
            this.passwordLBL.Text = "Password:";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(93, 74);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(146, 20);
            this.passwordTB.TabIndex = 30;
            this.passwordTB.Text = "password02";
            // 
            // channelCB
            // 
            this.channelCB.FormattingEnabled = true;
            this.channelCB.Items.AddRange(new object[] {
            "WEB",
            "IPAD",
            "IPHONE",
            "ANDROID"});
            this.channelCB.Location = new System.Drawing.Point(337, 29);
            this.channelCB.Name = "channelCB";
            this.channelCB.Size = new System.Drawing.Size(81, 21);
            this.channelCB.TabIndex = 29;
            this.channelCB.Text = "WEB";
            // 
            // ChannelLB
            // 
            this.ChannelLB.AutoSize = true;
            this.ChannelLB.Location = new System.Drawing.Point(282, 33);
            this.ChannelLB.Name = "ChannelLB";
            this.ChannelLB.Size = new System.Drawing.Size(49, 13);
            this.ChannelLB.TabIndex = 28;
            this.ChannelLB.Text = "Channel:";
            // 
            // pinTB
            // 
            this.pinTB.Location = new System.Drawing.Point(93, 53);
            this.pinTB.Name = "pinTB";
            this.pinTB.Size = new System.Drawing.Size(93, 20);
            this.pinTB.TabIndex = 21;
            this.pinTB.Text = "1122";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "PIN:";
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(417, 135);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 12;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(458, 132);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 11;
            this.loopTB.Text = "1";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(419, 158);
            this.CallApiBTN.Name = "CallApiBTN";
            this.CallApiBTN.Size = new System.Drawing.Size(75, 23);
            this.CallApiBTN.TabIndex = 8;
            this.CallApiBTN.Text = "Call API";
            this.CallApiBTN.UseVisualStyleBackColor = true;
            this.CallApiBTN.Click += new System.EventHandler(this.CallApiBTN_Click);
            // 
            // accountNumberLBL
            // 
            this.accountNumberLBL.AutoSize = true;
            this.accountNumberLBL.Location = new System.Drawing.Point(21, 33);
            this.accountNumberLBL.Name = "accountNumberLBL";
            this.accountNumberLBL.Size = new System.Drawing.Size(67, 13);
            this.accountNumberLBL.TabIndex = 44;
            this.accountNumberLBL.Text = "Account No:";
            // 
            // accountNumberTB
            // 
            this.accountNumberTB.Location = new System.Drawing.Point(94, 30);
            this.accountNumberTB.Name = "accountNumberTB";
            this.accountNumberTB.Size = new System.Drawing.Size(92, 20);
            this.accountNumberTB.TabIndex = 43;
            this.accountNumberTB.Text = "828319";
            // 
            // ActivateAccountUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ActivateAccountUC";
            this.Size = new System.Drawing.Size(654, 217);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox pinTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.ComboBox channelCB;
        private System.Windows.Forms.Label ChannelLB;
        private System.Windows.Forms.Label passwordLBL;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Label emailLBL;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.Label lastNameLBL;
        private System.Windows.Forms.TextBox surnameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label challengeQuestionLBL;
        private System.Windows.Forms.TextBox challengeAnswerTB;
        private System.Windows.Forms.TextBox challengeQuestionTB;
        private System.Windows.Forms.Label accountNumberLBL;
        private System.Windows.Forms.TextBox accountNumberTB;
    }
}
