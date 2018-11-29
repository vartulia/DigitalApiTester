namespace DigitalAPI_Forms
{
    partial class BundleBetUC
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
            this.MultiplierCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.retainBetCKB = new System.Windows.Forms.CheckBox();
            this.propCountLBL = new System.Windows.Forms.Label();
            this.addLegBTN = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.BetTypeCB = new System.Windows.Forms.ComboBox();
            this.combinedPriceTB = new System.Windows.Forms.TextBox();
            this.InvestAmountLBL = new System.Windows.Forms.Label();
            this.StakeTB = new System.Windows.Forms.TextBox();
            this.SellBetBTN = new System.Windows.Forms.Button();
            this.oddsLBL = new System.Windows.Forms.Label();
            this.propositionIdLBL = new System.Windows.Forms.Label();
            this.BettypeLBL = new System.Windows.Forms.Label();
            this.OddsTB = new System.Windows.Forms.TextBox();
            this.propositionIdTB = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MultiplierCB);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.retainBetCKB);
            this.groupBox2.Controls.Add(this.propCountLBL);
            this.groupBox2.Controls.Add(this.addLegBTN);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.BetTypeCB);
            this.groupBox2.Controls.Add(this.combinedPriceTB);
            this.groupBox2.Controls.Add(this.InvestAmountLBL);
            this.groupBox2.Controls.Add(this.StakeTB);
            this.groupBox2.Controls.Add(this.SellBetBTN);
            this.groupBox2.Controls.Add(this.oddsLBL);
            this.groupBox2.Controls.Add(this.propositionIdLBL);
            this.groupBox2.Controls.Add(this.BettypeLBL);
            this.groupBox2.Controls.Add(this.OddsTB);
            this.groupBox2.Controls.Add(this.propositionIdTB);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 200);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request";
            // 
            // MultiplierCB
            // 
            this.MultiplierCB.FormattingEnabled = true;
            this.MultiplierCB.Items.AddRange(new object[] {
            "false",
            "true"});
            this.MultiplierCB.Location = new System.Drawing.Point(102, 124);
            this.MultiplierCB.Name = "MultiplierCB";
            this.MultiplierCB.Size = new System.Drawing.Size(57, 21);
            this.MultiplierCB.TabIndex = 128;
            this.MultiplierCB.Text = "false";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 127;
            this.label10.Text = "Multiplier:";
            // 
            // retainBetCKB
            // 
            this.retainBetCKB.AutoSize = true;
            this.retainBetCKB.Location = new System.Drawing.Point(419, 105);
            this.retainBetCKB.Name = "retainBetCKB";
            this.retainBetCKB.Size = new System.Drawing.Size(82, 17);
            this.retainBetCKB.TabIndex = 23;
            this.retainBetCKB.Text = "Retain Bet?";
            this.retainBetCKB.UseVisualStyleBackColor = true;
            // 
            // propCountLBL
            // 
            this.propCountLBL.AutoSize = true;
            this.propCountLBL.Location = new System.Drawing.Point(292, 104);
            this.propCountLBL.Name = "propCountLBL";
            this.propCountLBL.Size = new System.Drawing.Size(42, 13);
            this.propCountLBL.TabIndex = 22;
            this.propCountLBL.Text = "0 Legs.";
            // 
            // addLegBTN
            // 
            this.addLegBTN.Location = new System.Drawing.Point(224, 99);
            this.addLegBTN.Name = "addLegBTN";
            this.addLegBTN.Size = new System.Drawing.Size(62, 23);
            this.addLegBTN.TabIndex = 21;
            this.addLegBTN.Text = "Add Leg";
            this.addLegBTN.UseVisualStyleBackColor = true;
            this.addLegBTN.Click += new System.EventHandler(this.addLegBTN_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Combined Price:";
            // 
            // BetTypeCB
            // 
            this.BetTypeCB.FormattingEnabled = true;
            this.BetTypeCB.Items.AddRange(new object[] {
            "BUNDLE",
            "BUNDLE_MULTI",
            "SAME_GAME_MULTI"});
            this.BetTypeCB.Location = new System.Drawing.Point(105, 23);
            this.BetTypeCB.Name = "BetTypeCB";
            this.BetTypeCB.Size = new System.Drawing.Size(113, 21);
            this.BetTypeCB.TabIndex = 13;
            this.BetTypeCB.Text = "BUNDLE";
            this.BetTypeCB.SelectedIndexChanged += new System.EventHandler(this.BetTypeCB_SelectedIndexChanged);
            // 
            // combinedPriceTB
            // 
            this.combinedPriceTB.Location = new System.Drawing.Point(105, 101);
            this.combinedPriceTB.Name = "combinedPriceTB";
            this.combinedPriceTB.Size = new System.Drawing.Size(113, 20);
            this.combinedPriceTB.TabIndex = 19;
            this.combinedPriceTB.Text = "1.23";
            // 
            // InvestAmountLBL
            // 
            this.InvestAmountLBL.AutoSize = true;
            this.InvestAmountLBL.Location = new System.Drawing.Point(411, 131);
            this.InvestAmountLBL.Name = "InvestAmountLBL";
            this.InvestAmountLBL.Size = new System.Drawing.Size(38, 13);
            this.InvestAmountLBL.TabIndex = 10;
            this.InvestAmountLBL.Text = "Stake:";
            // 
            // StakeTB
            // 
            this.StakeTB.Location = new System.Drawing.Point(452, 128);
            this.StakeTB.Name = "StakeTB";
            this.StakeTB.Size = new System.Drawing.Size(47, 20);
            this.StakeTB.TabIndex = 9;
            this.StakeTB.Text = "5.00";
            // 
            // SellBetBTN
            // 
            this.SellBetBTN.Location = new System.Drawing.Point(371, 154);
            this.SellBetBTN.Name = "SellBetBTN";
            this.SellBetBTN.Size = new System.Drawing.Size(132, 35);
            this.SellBetBTN.TabIndex = 8;
            this.SellBetBTN.Text = "Sell Bet";
            this.SellBetBTN.UseVisualStyleBackColor = true;
            this.SellBetBTN.Click += new System.EventHandler(this.SellBetBTN_Click);
            // 
            // oddsLBL
            // 
            this.oddsLBL.AutoSize = true;
            this.oddsLBL.Location = new System.Drawing.Point(53, 76);
            this.oddsLBL.Name = "oddsLBL";
            this.oddsLBL.Size = new System.Drawing.Size(35, 13);
            this.oddsLBL.TabIndex = 5;
            this.oddsLBL.Text = "Odds:";
            // 
            // propositionIdLBL
            // 
            this.propositionIdLBL.AutoSize = true;
            this.propositionIdLBL.Location = new System.Drawing.Point(23, 54);
            this.propositionIdLBL.Name = "propositionIdLBL";
            this.propositionIdLBL.Size = new System.Drawing.Size(74, 13);
            this.propositionIdLBL.TabIndex = 4;
            this.propositionIdLBL.Text = "Proposition Id:";
            // 
            // BettypeLBL
            // 
            this.BettypeLBL.AutoSize = true;
            this.BettypeLBL.Location = new System.Drawing.Point(41, 26);
            this.BettypeLBL.Name = "BettypeLBL";
            this.BettypeLBL.Size = new System.Drawing.Size(53, 13);
            this.BettypeLBL.TabIndex = 3;
            this.BettypeLBL.Text = "Bet Type:";
            // 
            // OddsTB
            // 
            this.OddsTB.Location = new System.Drawing.Point(106, 73);
            this.OddsTB.Name = "OddsTB";
            this.OddsTB.Size = new System.Drawing.Size(112, 20);
            this.OddsTB.TabIndex = 2;
            this.OddsTB.Text = "1.01";
            // 
            // propositionIdTB
            // 
            this.propositionIdTB.Location = new System.Drawing.Point(106, 47);
            this.propositionIdTB.Name = "propositionIdTB";
            this.propositionIdTB.Size = new System.Drawing.Size(257, 20);
            this.propositionIdTB.TabIndex = 1;
            this.propositionIdTB.Text = "822335,822124";
            // 
            // BundleBetUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "BundleBetUC";
            this.Size = new System.Drawing.Size(523, 225);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox retainBetCKB;
        private System.Windows.Forms.Label propCountLBL;
        private System.Windows.Forms.Button addLegBTN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox BetTypeCB;
        private System.Windows.Forms.TextBox combinedPriceTB;
        private System.Windows.Forms.Label InvestAmountLBL;
        private System.Windows.Forms.TextBox StakeTB;
        private System.Windows.Forms.Button SellBetBTN;
        private System.Windows.Forms.Label oddsLBL;
        private System.Windows.Forms.Label propositionIdLBL;
        private System.Windows.Forms.Label BettypeLBL;
        private System.Windows.Forms.TextBox OddsTB;
        private System.Windows.Forms.TextBox propositionIdTB;
        private System.Windows.Forms.ComboBox MultiplierCB;
        private System.Windows.Forms.Label label10;
    }
}
