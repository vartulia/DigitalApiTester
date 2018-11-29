namespace DigitalAPI_Forms
{
    partial class BundleBetPricingUC
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.oddsCountLBL = new System.Windows.Forms.Label();
            this.addLegBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.oddsTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.typeCB = new System.Windows.Forms.ComboBox();
            this.bundlePriceBTN = new System.Windows.Forms.Button();
            this.propositionIdLBL = new System.Windows.Forms.Label();
            this.propositionIdTB = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.oddsCountLBL);
            this.groupBox2.Controls.Add(this.addLegBTN);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.oddsTB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.typeCB);
            this.groupBox2.Controls.Add(this.bundlePriceBTN);
            this.groupBox2.Controls.Add(this.propositionIdLBL);
            this.groupBox2.Controls.Add(this.propositionIdTB);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 200);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request";
            // 
            // oddsCountLBL
            // 
            this.oddsCountLBL.AutoSize = true;
            this.oddsCountLBL.Location = new System.Drawing.Point(449, 80);
            this.oddsCountLBL.Name = "oddsCountLBL";
            this.oddsCountLBL.Size = new System.Drawing.Size(42, 13);
            this.oddsCountLBL.TabIndex = 23;
            this.oddsCountLBL.Text = "0 Legs.";
            // 
            // addLegBTN
            // 
            this.addLegBTN.Location = new System.Drawing.Point(377, 75);
            this.addLegBTN.Name = "addLegBTN";
            this.addLegBTN.Size = new System.Drawing.Size(66, 23);
            this.addLegBTN.TabIndex = 13;
            this.addLegBTN.Text = "Add Leg";
            this.addLegBTN.UseVisualStyleBackColor = true;
            this.addLegBTN.Click += new System.EventHandler(this.addLegBTN_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Odds:";
            // 
            // oddsTB
            // 
            this.oddsTB.Location = new System.Drawing.Point(104, 75);
            this.oddsTB.Name = "oddsTB";
            this.oddsTB.Size = new System.Drawing.Size(267, 20);
            this.oddsTB.TabIndex = 11;
            this.oddsTB.Text = "1.20,1.30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Type:";
            // 
            // typeCB
            // 
            this.typeCB.FormattingEnabled = true;
            this.typeCB.Items.AddRange(new object[] {
            "SAME_GAME_MULTI",
            "BUNDLE"});
            this.typeCB.Location = new System.Drawing.Point(104, 50);
            this.typeCB.Name = "typeCB";
            this.typeCB.Size = new System.Drawing.Size(137, 21);
            this.typeCB.TabIndex = 9;
            this.typeCB.Text = "SAME_GAME_MULTI";
            // 
            // bundlePriceBTN
            // 
            this.bundlePriceBTN.Location = new System.Drawing.Point(371, 154);
            this.bundlePriceBTN.Name = "bundlePriceBTN";
            this.bundlePriceBTN.Size = new System.Drawing.Size(132, 35);
            this.bundlePriceBTN.TabIndex = 8;
            this.bundlePriceBTN.Text = "Get Price";
            this.bundlePriceBTN.UseVisualStyleBackColor = true;
            this.bundlePriceBTN.Click += new System.EventHandler(this.bundlePriceBTN_Click);
            // 
            // propositionIdLBL
            // 
            this.propositionIdLBL.AutoSize = true;
            this.propositionIdLBL.Location = new System.Drawing.Point(21, 31);
            this.propositionIdLBL.Name = "propositionIdLBL";
            this.propositionIdLBL.Size = new System.Drawing.Size(74, 13);
            this.propositionIdLBL.TabIndex = 4;
            this.propositionIdLBL.Text = "Proposition Id:";
            // 
            // propositionIdTB
            // 
            this.propositionIdTB.Location = new System.Drawing.Point(104, 24);
            this.propositionIdTB.Name = "propositionIdTB";
            this.propositionIdTB.Size = new System.Drawing.Size(302, 20);
            this.propositionIdTB.TabIndex = 1;
            this.propositionIdTB.Text = "451541,451542";
            // 
            // BundleBetPricingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "BundleBetPricingUC";
            this.Size = new System.Drawing.Size(526, 220);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bundlePriceBTN;
        private System.Windows.Forms.Label propositionIdLBL;
        private System.Windows.Forms.TextBox propositionIdTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oddsTB;
        private System.Windows.Forms.Button addLegBTN;
        private System.Windows.Forms.Label oddsCountLBL;
    }
}
