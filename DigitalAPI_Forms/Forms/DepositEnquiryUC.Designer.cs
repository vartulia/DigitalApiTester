namespace DigitalAPI_Forms
{
    partial class DepositEnquiryUC
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
            this.creditCardTokenTB = new System.Windows.Forms.TextBox();
            this.maskCreditCardTB = new System.Windows.Forms.TextBox();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.StatusStatementLBL = new System.Windows.Forms.Label();
            this.maskCreditCardLBL = new System.Windows.Forms.Label();
            this.amountLBL = new System.Windows.Forms.Label();
            this.amountTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.creditCardTokenTB);
            this.groupBox1.Controls.Add(this.maskCreditCardTB);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Controls.Add(this.StatusStatementLBL);
            this.groupBox1.Controls.Add(this.maskCreditCardLBL);
            this.groupBox1.Controls.Add(this.amountLBL);
            this.groupBox1.Controls.Add(this.amountTB);
            this.groupBox1.Location = new System.Drawing.Point(-47, -25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 222);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // creditCardTokenTB
            // 
            this.creditCardTokenTB.Location = new System.Drawing.Point(136, 87);
            this.creditCardTokenTB.Name = "creditCardTokenTB";
            this.creditCardTokenTB.Size = new System.Drawing.Size(120, 20);
            this.creditCardTokenTB.TabIndex = 14;
            this.creditCardTokenTB.TextChanged += new System.EventHandler(this.creditCardTokenTB_TextChanged);
            // 
            // maskCreditCardTB
            // 
            this.maskCreditCardTB.Location = new System.Drawing.Point(136, 61);
            this.maskCreditCardTB.Name = "maskCreditCardTB";
            this.maskCreditCardTB.Size = new System.Drawing.Size(100, 20);
            this.maskCreditCardTB.TabIndex = 13;
            this.maskCreditCardTB.TextChanged += new System.EventHandler(this.maskCreditCardTB_TextChanged);
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(179, 128);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 12;
            this.loopLBL.Text = "Loop:";
            this.loopLBL.Click += new System.EventHandler(this.loopLBL_Click);
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(220, 125);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 11;
            this.loopTB.Text = "1";
            this.loopTB.TextChanged += new System.EventHandler(this.loopTB_TextChanged);
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
            // StatusStatementLBL
            // 
            this.StatusStatementLBL.AutoSize = true;
            this.StatusStatementLBL.Location = new System.Drawing.Point(90, 94);
            this.StatusStatementLBL.Name = "StatusStatementLBL";
            this.StatusStatementLBL.Size = new System.Drawing.Size(41, 13);
            this.StatusStatementLBL.TabIndex = 5;
            this.StatusStatementLBL.Text = "Token:";
            this.StatusStatementLBL.Click += new System.EventHandler(this.StatusStatementLBL_Click);
            // 
            // maskCreditCardLBL
            // 
            this.maskCreditCardLBL.AutoSize = true;
            this.maskCreditCardLBL.Location = new System.Drawing.Point(58, 68);
            this.maskCreditCardLBL.Name = "maskCreditCardLBL";
            this.maskCreditCardLBL.Size = new System.Drawing.Size(72, 13);
            this.maskCreditCardLBL.TabIndex = 4;
            this.maskCreditCardLBL.Text = "Card Number:";
            this.maskCreditCardLBL.Click += new System.EventHandler(this.maskCreditCardLBL_Click);
            // 
            // amountLBL
            // 
            this.amountLBL.AutoSize = true;
            this.amountLBL.Location = new System.Drawing.Point(75, 42);
            this.amountLBL.Name = "amountLBL";
            this.amountLBL.Size = new System.Drawing.Size(55, 13);
            this.amountLBL.TabIndex = 3;
            this.amountLBL.Text = "Amount $:";
            this.amountLBL.Click += new System.EventHandler(this.amountLBL_Click);
            // 
            // amountTB
            // 
            this.amountTB.Location = new System.Drawing.Point(136, 39);
            this.amountTB.Name = "amountTB";
            this.amountTB.Size = new System.Drawing.Size(39, 20);
            this.amountTB.TabIndex = 0;
            this.amountTB.Text = "1000";
            this.amountTB.TextChanged += new System.EventHandler(this.amountTB_TextChanged);
            // 
            // DepositEnquiryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DepositEnquiryUC";
            this.Size = new System.Drawing.Size(233, 201);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox creditCardTokenTB;
        private System.Windows.Forms.TextBox maskCreditCardTB;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.Label StatusStatementLBL;
        private System.Windows.Forms.Label maskCreditCardLBL;
        private System.Windows.Forms.Label amountLBL;
        private System.Windows.Forms.TextBox amountTB;
    }
}
