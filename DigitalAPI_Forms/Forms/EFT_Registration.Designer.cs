namespace DigitalAPI_Forms
{
    partial class EFT_Registration
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
            this.bankAccountNameTB = new System.Windows.Forms.TextBox();
            this.bankAccountNoTB = new System.Windows.Forms.TextBox();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.bankAccountNameLBL = new System.Windows.Forms.Label();
            this.bankAccountNumberLBL = new System.Windows.Forms.Label();
            this.bsbLBL = new System.Windows.Forms.Label();
            this.bsbTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bankAccountNameTB);
            this.groupBox1.Controls.Add(this.bankAccountNoTB);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Controls.Add(this.bankAccountNameLBL);
            this.groupBox1.Controls.Add(this.bankAccountNumberLBL);
            this.groupBox1.Controls.Add(this.bsbLBL);
            this.groupBox1.Controls.Add(this.bsbTB);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 222);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // bankAccountNameTB
            // 
            this.bankAccountNameTB.Location = new System.Drawing.Point(136, 87);
            this.bankAccountNameTB.Name = "bankAccountNameTB";
            this.bankAccountNameTB.Size = new System.Drawing.Size(120, 20);
            this.bankAccountNameTB.TabIndex = 14;
            // 
            // bankAccountNoTB
            // 
            this.bankAccountNoTB.Location = new System.Drawing.Point(136, 61);
            this.bankAccountNoTB.Name = "bankAccountNoTB";
            this.bankAccountNoTB.Size = new System.Drawing.Size(100, 20);
            this.bankAccountNoTB.TabIndex = 13;
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(179, 128);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 12;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(220, 125);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 11;
            this.loopTB.Text = "1";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(182, 174);
            this.CallApiBTN.Name = "CallApiBTN";
            this.CallApiBTN.Size = new System.Drawing.Size(75, 23);
            this.CallApiBTN.TabIndex = 8;
            this.CallApiBTN.Text = "Call API";
            this.CallApiBTN.UseVisualStyleBackColor = true;
            this.CallApiBTN.Click += new System.EventHandler(this.CallApiBTN_Click);
            // 
            // bankAccountNameLBL
            // 
            this.bankAccountNameLBL.AutoSize = true;
            this.bankAccountNameLBL.Location = new System.Drawing.Point(21, 94);
            this.bankAccountNameLBL.Name = "bankAccountNameLBL";
            this.bankAccountNameLBL.Size = new System.Drawing.Size(109, 13);
            this.bankAccountNameLBL.TabIndex = 5;
            this.bankAccountNameLBL.Text = "Bank Account Name:";
            // 
            // bankAccountNumberLBL
            // 
            this.bankAccountNumberLBL.AutoSize = true;
            this.bankAccountNumberLBL.Location = new System.Drawing.Point(13, 68);
            this.bankAccountNumberLBL.Name = "bankAccountNumberLBL";
            this.bankAccountNumberLBL.Size = new System.Drawing.Size(118, 13);
            this.bankAccountNumberLBL.TabIndex = 4;
            this.bankAccountNumberLBL.Text = "Bank Account Number:";
            // 
            // bsbLBL
            // 
            this.bsbLBL.AutoSize = true;
            this.bsbLBL.Location = new System.Drawing.Point(95, 42);
            this.bsbLBL.Name = "bsbLBL";
            this.bsbLBL.Size = new System.Drawing.Size(31, 13);
            this.bsbLBL.TabIndex = 3;
            this.bsbLBL.Text = "BSB:";
            // 
            // bsbTB
            // 
            this.bsbTB.Location = new System.Drawing.Point(136, 39);
            this.bsbTB.Name = "bsbTB";
            this.bsbTB.Size = new System.Drawing.Size(65, 20);
            this.bsbTB.TabIndex = 0;
            this.bsbTB.Text = "062001";
            // 
            // EFT_Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "EFT_Registration";
            this.Size = new System.Drawing.Size(287, 233);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox bankAccountNameTB;
        private System.Windows.Forms.TextBox bankAccountNoTB;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.Label bankAccountNameLBL;
        private System.Windows.Forms.Label bankAccountNumberLBL;
        private System.Windows.Forms.Label bsbLBL;
        private System.Windows.Forms.TextBox bsbTB;
    }
}
