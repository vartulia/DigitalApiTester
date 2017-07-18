namespace DigitalAPI_Forms
{
    partial class AccountStatementEnhancedUC
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
            this.transFilterCB = new System.Windows.Forms.ComboBox();
            this.statementTypeCB = new System.Windows.Forms.ComboBox();
            this.btn_next = new System.Windows.Forms.Button();
            this.rowsCB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OldTimeTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NewTimeTB = new System.Windows.Forms.TextBox();
            this.NewTimeLBL = new System.Windows.Forms.Label();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.statusLBL = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.transFilterCB);
            this.groupBox1.Controls.Add(this.statementTypeCB);
            this.groupBox1.Controls.Add(this.btn_next);
            this.groupBox1.Controls.Add(this.rowsCB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.OldTimeTB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.NewTimeTB);
            this.groupBox1.Controls.Add(this.NewTimeLBL);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Controls.Add(this.statusLBL);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 200);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // transFilterCB
            // 
            this.transFilterCB.FormattingEnabled = true;
            this.transFilterCB.Items.AddRange(new object[] {
            "ALL",
            "WON",
            "OPEN"});
            this.transFilterCB.Location = new System.Drawing.Point(62, 47);
            this.transFilterCB.Name = "transFilterCB";
            this.transFilterCB.Size = new System.Drawing.Size(93, 21);
            this.transFilterCB.TabIndex = 27;
            this.transFilterCB.Text = "ALL";
            // 
            // statementTypeCB
            // 
            this.statementTypeCB.FormattingEnabled = true;
            this.statementTypeCB.Items.AddRange(new object[] {
            "SUMMARY",
            "FIXED_ODDS",
            "PARIMUTUEL",
            "ALL"});
            this.statementTypeCB.Location = new System.Drawing.Point(63, 20);
            this.statementTypeCB.Name = "statementTypeCB";
            this.statementTypeCB.Size = new System.Drawing.Size(93, 21);
            this.statementTypeCB.TabIndex = 26;
            this.statementTypeCB.Text = "SUMMARY";
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(63, 171);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(52, 23);
            this.btn_next.TabIndex = 11;
            this.btn_next.Text = ">>";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Visible = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // rowsCB
            // 
            this.rowsCB.Location = new System.Drawing.Point(62, 118);
            this.rowsCB.Name = "rowsCB";
            this.rowsCB.Size = new System.Drawing.Size(93, 20);
            this.rowsCB.TabIndex = 25;
            this.rowsCB.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Filter:";
            // 
            // OldTimeTB
            // 
            this.OldTimeTB.Location = new System.Drawing.Point(63, 71);
            this.OldTimeTB.Name = "OldTimeTB";
            this.OldTimeTB.Size = new System.Drawing.Size(93, 20);
            this.OldTimeTB.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "From Date:";
            // 
            // NewTimeTB
            // 
            this.NewTimeTB.Location = new System.Drawing.Point(63, 94);
            this.NewTimeTB.Name = "NewTimeTB";
            this.NewTimeTB.Size = new System.Drawing.Size(93, 20);
            this.NewTimeTB.TabIndex = 19;
            // 
            // NewTimeLBL
            // 
            this.NewTimeLBL.AutoSize = true;
            this.NewTimeLBL.Location = new System.Drawing.Point(9, 97);
            this.NewTimeLBL.Name = "NewTimeLBL";
            this.NewTimeLBL.Size = new System.Drawing.Size(49, 13);
            this.NewTimeLBL.TabIndex = 18;
            this.NewTimeLBL.Text = "To Date:";
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(248, 148);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 12;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(289, 145);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 11;
            this.loopTB.Text = "1";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(250, 171);
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
            this.statusLBL.Location = new System.Drawing.Point(9, 22);
            this.statusLBL.Name = "statusLBL";
            this.statusLBL.Size = new System.Drawing.Size(34, 13);
            this.statusLBL.TabIndex = 4;
            this.statusLBL.Text = "Type:";
            // 
            // AccountStatementEnhancedUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "AccountStatementEnhancedUC";
            this.Size = new System.Drawing.Size(456, 205);
            this.Load += new System.EventHandler(this.AccountStatementEnhancedUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.Label statusLBL;
        private System.Windows.Forms.TextBox rowsCB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OldTimeTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NewTimeTB;
        private System.Windows.Forms.Label NewTimeLBL;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.ComboBox statementTypeCB;
        private System.Windows.Forms.ComboBox transFilterCB;
    }
}
