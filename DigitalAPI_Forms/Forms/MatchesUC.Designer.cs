﻿namespace DigitalAPI_Forms
{
    partial class MatchesUC
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
            this.competitionNameLBL = new System.Windows.Forms.Label();
            this.competitionNameTB = new System.Windows.Forms.TextBox();
            this.SportNameLBL = new System.Windows.Forms.Label();
            this.SportNameTB = new System.Windows.Forms.TextBox();
            this.jurisdictionCB = new System.Windows.Forms.ComboBox();
            this.JurisdictionLBL = new System.Windows.Forms.Label();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(136, 112);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 21;
            this.loopLBL.Text = "Loop:";
            this.loopLBL.Click += new System.EventHandler(this.loopLBL_Click);
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(177, 109);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 20;
            this.loopTB.Text = "1";
            this.loopTB.TextChanged += new System.EventHandler(this.loopTB_TextChanged);
            // 
            // competitionNameLBL
            // 
            this.competitionNameLBL.AutoSize = true;
            this.competitionNameLBL.Location = new System.Drawing.Point(0, 89);
            this.competitionNameLBL.Name = "competitionNameLBL";
            this.competitionNameLBL.Size = new System.Drawing.Size(96, 13);
            this.competitionNameLBL.TabIndex = 19;
            this.competitionNameLBL.Text = "Competition Name:";
            this.competitionNameLBL.Click += new System.EventHandler(this.competitionNameLBL_Click);
            // 
            // competitionNameTB
            // 
            this.competitionNameTB.Location = new System.Drawing.Point(95, 87);
            this.competitionNameTB.Name = "competitionNameTB";
            this.competitionNameTB.Size = new System.Drawing.Size(118, 20);
            this.competitionNameTB.TabIndex = 18;
            this.competitionNameTB.TextChanged += new System.EventHandler(this.competitionNameTB_TextChanged);
            // 
            // SportNameLBL
            // 
            this.SportNameLBL.AutoSize = true;
            this.SportNameLBL.Location = new System.Drawing.Point(21, 69);
            this.SportNameLBL.Name = "SportNameLBL";
            this.SportNameLBL.Size = new System.Drawing.Size(66, 13);
            this.SportNameLBL.TabIndex = 15;
            this.SportNameLBL.Text = "Sport Name:";
            this.SportNameLBL.Click += new System.EventHandler(this.SportNameLBL_Click);
            // 
            // SportNameTB
            // 
            this.SportNameTB.Location = new System.Drawing.Point(95, 64);
            this.SportNameTB.Name = "SportNameTB";
            this.SportNameTB.Size = new System.Drawing.Size(118, 20);
            this.SportNameTB.TabIndex = 14;
            this.SportNameTB.TextChanged += new System.EventHandler(this.SportNameTB_TextChanged);
            // 
            // jurisdictionCB
            // 
            this.jurisdictionCB.FormattingEnabled = true;
            this.jurisdictionCB.Items.AddRange(new object[] {
            "VIC",
            "NSW"});
            this.jurisdictionCB.Location = new System.Drawing.Point(93, 39);
            this.jurisdictionCB.Name = "jurisdictionCB";
            this.jurisdictionCB.Size = new System.Drawing.Size(121, 21);
            this.jurisdictionCB.TabIndex = 13;
            this.jurisdictionCB.SelectedIndexChanged += new System.EventHandler(this.jurisdictionCB_SelectedIndexChanged);
            // 
            // JurisdictionLBL
            // 
            this.JurisdictionLBL.AutoSize = true;
            this.JurisdictionLBL.Location = new System.Drawing.Point(28, 43);
            this.JurisdictionLBL.Name = "JurisdictionLBL";
            this.JurisdictionLBL.Size = new System.Drawing.Size(62, 13);
            this.JurisdictionLBL.TabIndex = 12;
            this.JurisdictionLBL.Text = "Jurisdiction:";
            this.JurisdictionLBL.Click += new System.EventHandler(this.JurisdictionLBL_Click);
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
            // MatchesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MatchesUC";
            this.Size = new System.Drawing.Size(253, 210);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label competitionNameLBL;
        private System.Windows.Forms.TextBox competitionNameTB;
        private System.Windows.Forms.Label SportNameLBL;
        private System.Windows.Forms.TextBox SportNameTB;
        private System.Windows.Forms.ComboBox jurisdictionCB;
        private System.Windows.Forms.Label JurisdictionLBL;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
    }
}
