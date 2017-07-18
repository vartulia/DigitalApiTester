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
            this.bundlePriceBTN = new System.Windows.Forms.Button();
            this.propositionIdLBL = new System.Windows.Forms.Label();
            this.propositionIdTB = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
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
            // bundlePriceBTN
            // 
            this.bundlePriceBTN.Location = new System.Drawing.Point(371, 154);
            this.bundlePriceBTN.Name = "bundlePriceBTN";
            this.bundlePriceBTN.Size = new System.Drawing.Size(132, 35);
            this.bundlePriceBTN.TabIndex = 8;
            this.bundlePriceBTN.Text = "Bundle Price";
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
    }
}
