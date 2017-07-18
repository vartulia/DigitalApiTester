namespace DigitalAPI_Forms
{
    partial class EmailVerification
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
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.channelCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.VerifyEmailCallAPIBTN = new System.Windows.Forms.Button();
            this.ChannelLB = new System.Windows.Forms.Label();
            this.emailTokenLBL = new System.Windows.Forms.Label();
            this.emailTokenTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 200);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send Verification Email";
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(155, 108);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 10;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(196, 105);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 9;
            this.loopTB.Text = "1";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(158, 155);
            this.CallApiBTN.Name = "CallApiBTN";
            this.CallApiBTN.Size = new System.Drawing.Size(75, 23);
            this.CallApiBTN.TabIndex = 8;
            this.CallApiBTN.Text = "Call API";
            this.CallApiBTN.UseVisualStyleBackColor = true;
            this.CallApiBTN.Click += new System.EventHandler(this.CallApiBTN_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.channelCB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.VerifyEmailCallAPIBTN);
            this.groupBox2.Controls.Add(this.ChannelLB);
            this.groupBox2.Controls.Add(this.emailTokenLBL);
            this.groupBox2.Controls.Add(this.emailTokenTB);
            this.groupBox2.Location = new System.Drawing.Point(253, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 200);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Verify Email Address";
            // 
            // channelCB
            // 
            this.channelCB.FormattingEnabled = true;
            this.channelCB.Items.AddRange(new object[] {
            "WEB",
            "IPAD",
            "IPHONE",
            "ANDROID"});
            this.channelCB.Location = new System.Drawing.Point(86, 45);
            this.channelCB.Name = "channelCB";
            this.channelCB.Size = new System.Drawing.Size(81, 21);
            this.channelCB.TabIndex = 11;
            this.channelCB.Text = "WEB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Loop:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(307, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "1";
            // 
            // VerifyEmailCallAPIBTN
            // 
            this.VerifyEmailCallAPIBTN.Location = new System.Drawing.Point(268, 155);
            this.VerifyEmailCallAPIBTN.Name = "VerifyEmailCallAPIBTN";
            this.VerifyEmailCallAPIBTN.Size = new System.Drawing.Size(75, 23);
            this.VerifyEmailCallAPIBTN.TabIndex = 8;
            this.VerifyEmailCallAPIBTN.Text = "Call API";
            this.VerifyEmailCallAPIBTN.UseVisualStyleBackColor = true;
            this.VerifyEmailCallAPIBTN.Click += new System.EventHandler(this.VerifyEmailCallAPIBTN_Click);
            // 
            // ChannelLB
            // 
            this.ChannelLB.AutoSize = true;
            this.ChannelLB.Location = new System.Drawing.Point(31, 50);
            this.ChannelLB.Name = "ChannelLB";
            this.ChannelLB.Size = new System.Drawing.Size(49, 13);
            this.ChannelLB.TabIndex = 5;
            this.ChannelLB.Text = "Channel:";
            // 
            // emailTokenLBL
            // 
            this.emailTokenLBL.AutoSize = true;
            this.emailTokenLBL.Location = new System.Drawing.Point(11, 24);
            this.emailTokenLBL.Name = "emailTokenLBL";
            this.emailTokenLBL.Size = new System.Drawing.Size(69, 13);
            this.emailTokenLBL.TabIndex = 4;
            this.emailTokenLBL.Text = "Email Token:";
            // 
            // emailTokenTB
            // 
            this.emailTokenTB.Location = new System.Drawing.Point(86, 21);
            this.emailTokenTB.Name = "emailTokenTB";
            this.emailTokenTB.Size = new System.Drawing.Size(257, 20);
            this.emailTokenTB.TabIndex = 1;
            // 
            // EmailVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EmailVerification";
            this.Size = new System.Drawing.Size(607, 212);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox channelCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button VerifyEmailCallAPIBTN;
        private System.Windows.Forms.Label ChannelLB;
        private System.Windows.Forms.Label emailTokenLBL;
        private System.Windows.Forms.TextBox emailTokenTB;
    }
}
