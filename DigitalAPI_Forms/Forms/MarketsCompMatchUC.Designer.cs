namespace DigitalAPI_Forms
{
    partial class MarketsCompMatchUC
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
            this.MatchNameLBL = new System.Windows.Forms.Label();
            this.MatchNameTB = new System.Windows.Forms.TextBox();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.competitionNameLBL = new System.Windows.Forms.Label();
            this.competitionNameTB = new System.Windows.Forms.TextBox();
            this.SportNameLBL = new System.Windows.Forms.Label();
            this.SportNameTB = new System.Windows.Forms.TextBox();
            this.jurisdictionCB = new System.Windows.Forms.ComboBox();
            this.JurisdictionLBL = new System.Windows.Forms.Label();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MatchNameLBL
            // 
            this.MatchNameLBL.AutoSize = true;
            this.MatchNameLBL.Location = new System.Drawing.Point(4, 86);
            this.MatchNameLBL.Name = "MatchNameLBL";
            this.MatchNameLBL.Size = new System.Drawing.Size(71, 13);
            this.MatchNameLBL.TabIndex = 23;
            this.MatchNameLBL.Text = "Match Name:";
            // 
            // MatchNameTB
            // 
            this.MatchNameTB.Location = new System.Drawing.Point(101, 84);
            this.MatchNameTB.Name = "MatchNameTB";
            this.MatchNameTB.Size = new System.Drawing.Size(118, 20);
            this.MatchNameTB.TabIndex = 22;
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(141, 108);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 21;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(182, 105);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 20;
            this.loopTB.Text = "1";
            // 
            // competitionNameLBL
            // 
            this.competitionNameLBL.AutoSize = true;
            this.competitionNameLBL.Location = new System.Drawing.Point(4, 65);
            this.competitionNameLBL.Name = "competitionNameLBL";
            this.competitionNameLBL.Size = new System.Drawing.Size(96, 13);
            this.competitionNameLBL.TabIndex = 19;
            this.competitionNameLBL.Text = "Competition Name:";
            // 
            // competitionNameTB
            // 
            this.competitionNameTB.Location = new System.Drawing.Point(101, 63);
            this.competitionNameTB.Name = "competitionNameTB";
            this.competitionNameTB.Size = new System.Drawing.Size(118, 20);
            this.competitionNameTB.TabIndex = 18;
            // 
            // SportNameLBL
            // 
            this.SportNameLBL.AutoSize = true;
            this.SportNameLBL.Location = new System.Drawing.Point(25, 45);
            this.SportNameLBL.Name = "SportNameLBL";
            this.SportNameLBL.Size = new System.Drawing.Size(66, 13);
            this.SportNameLBL.TabIndex = 15;
            this.SportNameLBL.Text = "Sport Name:";
            // 
            // SportNameTB
            // 
            this.SportNameTB.Location = new System.Drawing.Point(101, 40);
            this.SportNameTB.Name = "SportNameTB";
            this.SportNameTB.Size = new System.Drawing.Size(118, 20);
            this.SportNameTB.TabIndex = 14;
            // 
            // jurisdictionCB
            // 
            this.jurisdictionCB.FormattingEnabled = true;
            this.jurisdictionCB.Items.AddRange(new object[] {
            "VIC",
            "NSW"});
            this.jurisdictionCB.Location = new System.Drawing.Point(101, 18);
            this.jurisdictionCB.Name = "jurisdictionCB";
            this.jurisdictionCB.Size = new System.Drawing.Size(118, 21);
            this.jurisdictionCB.TabIndex = 13;
            // 
            // JurisdictionLBL
            // 
            this.JurisdictionLBL.AutoSize = true;
            this.JurisdictionLBL.Location = new System.Drawing.Point(28, 21);
            this.JurisdictionLBL.Name = "JurisdictionLBL";
            this.JurisdictionLBL.Size = new System.Drawing.Size(62, 13);
            this.JurisdictionLBL.TabIndex = 12;
            this.JurisdictionLBL.Text = "Jurisdiction:";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(139, 159);
            this.CallApiBTN.Name = "CallApiBTN";
            this.CallApiBTN.Size = new System.Drawing.Size(75, 23);
            this.CallApiBTN.TabIndex = 9;
            this.CallApiBTN.Text = "Call API";
            this.CallApiBTN.UseVisualStyleBackColor = true;
            this.CallApiBTN.Click += new System.EventHandler(this.CallApiBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MatchNameLBL);
            this.groupBox1.Controls.Add(this.MatchNameTB);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.competitionNameLBL);
            this.groupBox1.Controls.Add(this.competitionNameTB);
            this.groupBox1.Controls.Add(this.SportNameLBL);
            this.groupBox1.Controls.Add(this.SportNameTB);
            this.groupBox1.Controls.Add(this.jurisdictionCB);
            this.groupBox1.Controls.Add(this.JurisdictionLBL);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 200);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // MarketsCompMatchUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MarketsCompMatchUC";
            this.Size = new System.Drawing.Size(252, 212);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MatchNameLBL;
        private System.Windows.Forms.TextBox MatchNameTB;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.Label competitionNameLBL;
        private System.Windows.Forms.TextBox competitionNameTB;
        private System.Windows.Forms.Label SportNameLBL;
        private System.Windows.Forms.TextBox SportNameTB;
        private System.Windows.Forms.ComboBox jurisdictionCB;
        private System.Windows.Forms.Label JurisdictionLBL;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
