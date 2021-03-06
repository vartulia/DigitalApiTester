﻿namespace DigitalAPI_Forms
{
    partial class CardOrdering
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
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.ChannelLB = new System.Windows.Forms.Label();
            this.passwordLBL = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.channelCB = new System.Windows.Forms.ComboBox();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.ChannelLB.Location = new System.Drawing.Point(31, 50);
            this.ChannelLB.Name = "ChannelLB";
            this.ChannelLB.Size = new System.Drawing.Size(49, 13);
            this.ChannelLB.TabIndex = 5;
            this.ChannelLB.Text = "Channel:";
            this.ChannelLB.Click += new System.EventHandler(this.ChannelLB_Click);
            // 
            // passwordLBL
            // 
            this.passwordLBL.AutoSize = true;
            this.passwordLBL.Location = new System.Drawing.Point(24, 28);
            this.passwordLBL.Name = "passwordLBL";
            this.passwordLBL.Size = new System.Drawing.Size(56, 13);
            this.passwordLBL.TabIndex = 4;
            this.passwordLBL.Text = "Password:";
            this.passwordLBL.Click += new System.EventHandler(this.passwordLBL_Click);
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(86, 21);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(146, 20);
            this.passwordTB.TabIndex = 1;
            this.passwordTB.Text = "password02";
            this.passwordTB.TextChanged += new System.EventHandler(this.passwordTB_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.channelCB);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Controls.Add(this.ChannelLB);
            this.groupBox1.Controls.Add(this.passwordLBL);
            this.groupBox1.Controls.Add(this.passwordTB);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 200);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.channelCB.SelectedIndexChanged += new System.EventHandler(this.channelCB_SelectedIndexChanged);
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(155, 108);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 10;
            this.loopLBL.Text = "Loop:";
            this.loopLBL.Click += new System.EventHandler(this.loopLBL_Click);
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(196, 105);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 9;
            this.loopTB.Text = "1";
            this.loopTB.TextChanged += new System.EventHandler(this.loopTB_TextChanged);
            // 
            // CardOrdering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CardOrdering";
            this.Size = new System.Drawing.Size(260, 213);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.Label ChannelLB;
        private System.Windows.Forms.Label passwordLBL;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox channelCB;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
    }
}
