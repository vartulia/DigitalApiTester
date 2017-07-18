namespace DigitalAPI_Forms
{
    partial class AccountStatement
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
            this.TypeCB = new System.Windows.Forms.ComboBox();
            this.StatusCB = new System.Windows.Forms.ComboBox();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.StatusStatementLBL = new System.Windows.Forms.Label();
            this.statusLBL = new System.Windows.Forms.Label();
            this.countLBL = new System.Windows.Forms.Label();
            this.countTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.TypeCB);
            this.groupBox1.Controls.Add(this.StatusCB);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Controls.Add(this.StatusStatementLBL);
            this.groupBox1.Controls.Add(this.statusLBL);
            this.groupBox1.Controls.Add(this.countLBL);
            this.groupBox1.Controls.Add(this.countTB);
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 200);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(142, 116);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 12;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(183, 113);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 11;
            this.loopTB.Text = "1";
            // 
            // TypeCB
            // 
            this.TypeCB.FormattingEnabled = true;
            this.TypeCB.Location = new System.Drawing.Point(99, 53);
            this.TypeCB.Name = "TypeCB";
            this.TypeCB.Size = new System.Drawing.Size(121, 21);
            this.TypeCB.TabIndex = 10;
            this.TypeCB.Tag = "";
            this.TypeCB.Text = "ALL";
            // 
            // StatusCB
            // 
            this.StatusCB.FormattingEnabled = true;
            this.StatusCB.Location = new System.Drawing.Point(99, 82);
            this.StatusCB.Name = "StatusCB";
            this.StatusCB.Size = new System.Drawing.Size(121, 21);
            this.StatusCB.TabIndex = 9;
            this.StatusCB.Tag = "";
            this.StatusCB.Text = "ALL";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(145, 162);
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
            this.StatusStatementLBL.Location = new System.Drawing.Point(53, 82);
            this.StatusStatementLBL.Name = "StatusStatementLBL";
            this.StatusStatementLBL.Size = new System.Drawing.Size(40, 13);
            this.StatusStatementLBL.TabIndex = 5;
            this.StatusStatementLBL.Text = "Status:";
            // 
            // statusLBL
            // 
            this.statusLBL.AutoSize = true;
            this.statusLBL.Location = new System.Drawing.Point(59, 60);
            this.statusLBL.Name = "statusLBL";
            this.statusLBL.Size = new System.Drawing.Size(34, 13);
            this.statusLBL.TabIndex = 4;
            this.statusLBL.Text = "Type:";
            // 
            // countLBL
            // 
            this.countLBL.AutoSize = true;
            this.countLBL.Location = new System.Drawing.Point(24, 32);
            this.countLBL.Name = "countLBL";
            this.countLBL.Size = new System.Drawing.Size(69, 13);
            this.countLBL.TabIndex = 3;
            this.countLBL.Text = "No. of Rows:";
            // 
            // countTB
            // 
            this.countTB.Location = new System.Drawing.Point(99, 27);
            this.countTB.Name = "countTB";
            this.countTB.Size = new System.Drawing.Size(39, 20);
            this.countTB.TabIndex = 0;
            this.countTB.Text = "20";
            // 
            // AccountStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "AccountStatement";
            this.Size = new System.Drawing.Size(251, 210);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox TypeCB;
        private System.Windows.Forms.ComboBox StatusCB;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.Label StatusStatementLBL;
        private System.Windows.Forms.Label statusLBL;
        private System.Windows.Forms.Label countLBL;
        private System.Windows.Forms.TextBox countTB;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
    }
}
