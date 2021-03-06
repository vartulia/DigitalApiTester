﻿namespace DigitalAPI_Forms
{
    partial class FOBettingUC
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
            this.MultiplierCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BetTypeCB = new System.Windows.Forms.ComboBox();
            this.BonusBetTokenTB = new System.Windows.Forms.TextBox();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.InvestAmountLBL = new System.Windows.Forms.Label();
            this.InvestAmtTB = new System.Windows.Forms.TextBox();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.oddsLBL = new System.Windows.Forms.Label();
            this.propositionIdLBL = new System.Windows.Forms.Label();
            this.BettypeLBL = new System.Windows.Forms.Label();
            this.OddsTB = new System.Windows.Forms.TextBox();
            this.propositionIdTB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EachWayMultiplierCB = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PLACEInvestAmtTB = new System.Windows.Forms.TextBox();
            this.secondaryOddsEW_LBL = new System.Windows.Forms.Label();
            this.secondaryOddsEW_TB = new System.Windows.Forms.TextBox();
            this.BetTypeEW_BTN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loopEW_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WINInvestAmtTB = new System.Windows.Forms.TextBox();
            this.CallApiEW_BTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OddsEW_TB = new System.Windows.Forms.TextBox();
            this.propositionIdEW_TB = new System.Windows.Forms.TextBox();
            this.costEnquiryCKBox = new System.Windows.Forms.CheckBox();
            this.getBonusBetTokensCmd = new System.Windows.Forms.Button();
            this.copyTSNBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MultiplierCB);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.BetTypeCB);
            this.groupBox1.Controls.Add(this.BonusBetTokenTB);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.InvestAmountLBL);
            this.groupBox1.Controls.Add(this.InvestAmtTB);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Controls.Add(this.oddsLBL);
            this.groupBox1.Controls.Add(this.propositionIdLBL);
            this.groupBox1.Controls.Add(this.BettypeLBL);
            this.groupBox1.Controls.Add(this.OddsTB);
            this.groupBox1.Controls.Add(this.propositionIdTB);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 200);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // MultiplierCB
            // 
            this.MultiplierCB.FormattingEnabled = true;
            this.MultiplierCB.Items.AddRange(new object[] {
            "false",
            "true"});
            this.MultiplierCB.Location = new System.Drawing.Point(105, 140);
            this.MultiplierCB.Name = "MultiplierCB";
            this.MultiplierCB.Size = new System.Drawing.Size(57, 21);
            this.MultiplierCB.TabIndex = 126;
            this.MultiplierCB.Text = "false";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 125;
            this.label10.Text = "Multiplier:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Token:";
            // 
            // BetTypeCB
            // 
            this.BetTypeCB.FormattingEnabled = true;
            this.BetTypeCB.Items.AddRange(new object[] {
            "WIN",
            "PLACE"});
            this.BetTypeCB.Location = new System.Drawing.Point(105, 23);
            this.BetTypeCB.Name = "BetTypeCB";
            this.BetTypeCB.Size = new System.Drawing.Size(113, 21);
            this.BetTypeCB.TabIndex = 13;
            this.BetTypeCB.Text = "WIN";
            // 
            // BonusBetTokenTB
            // 
            this.BonusBetTokenTB.Location = new System.Drawing.Point(105, 118);
            this.BonusBetTokenTB.Name = "BonusBetTokenTB";
            this.BonusBetTokenTB.Size = new System.Drawing.Size(113, 20);
            this.BonusBetTokenTB.TabIndex = 19;
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(3, 178);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 12;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(44, 175);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 11;
            this.loopTB.Text = "1";
            // 
            // InvestAmountLBL
            // 
            this.InvestAmountLBL.AutoSize = true;
            this.InvestAmountLBL.Location = new System.Drawing.Point(21, 100);
            this.InvestAmountLBL.Name = "InvestAmountLBL";
            this.InvestAmountLBL.Size = new System.Drawing.Size(78, 13);
            this.InvestAmountLBL.TabIndex = 10;
            this.InvestAmountLBL.Text = "Invest Amount:";
            // 
            // InvestAmtTB
            // 
            this.InvestAmtTB.Location = new System.Drawing.Point(105, 97);
            this.InvestAmtTB.Name = "InvestAmtTB";
            this.InvestAmtTB.Size = new System.Drawing.Size(112, 20);
            this.InvestAmtTB.TabIndex = 9;
            this.InvestAmtTB.Text = "5.00";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(143, 171);
            this.CallApiBTN.Name = "CallApiBTN";
            this.CallApiBTN.Size = new System.Drawing.Size(75, 23);
            this.CallApiBTN.TabIndex = 8;
            this.CallApiBTN.Text = "Call API";
            this.CallApiBTN.UseVisualStyleBackColor = true;
            this.CallApiBTN.Click += new System.EventHandler(this.CallApiBTN_Click);
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
            this.OddsTB.Text = "0.00";
            // 
            // propositionIdTB
            // 
            this.propositionIdTB.Location = new System.Drawing.Point(106, 47);
            this.propositionIdTB.Name = "propositionIdTB";
            this.propositionIdTB.Size = new System.Drawing.Size(112, 20);
            this.propositionIdTB.TabIndex = 1;
            this.propositionIdTB.Text = "823810";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EachWayMultiplierCB);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.PLACEInvestAmtTB);
            this.groupBox2.Controls.Add(this.secondaryOddsEW_LBL);
            this.groupBox2.Controls.Add(this.secondaryOddsEW_TB);
            this.groupBox2.Controls.Add(this.BetTypeEW_BTN);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.loopEW_TB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.WINInvestAmtTB);
            this.groupBox2.Controls.Add(this.CallApiEW_BTN);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.OddsEW_TB);
            this.groupBox2.Controls.Add(this.propositionIdEW_TB);
            this.groupBox2.Location = new System.Drawing.Point(253, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 200);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request";
            // 
            // EachWayMultiplierCB
            // 
            this.EachWayMultiplierCB.FormattingEnabled = true;
            this.EachWayMultiplierCB.Items.AddRange(new object[] {
            "false",
            "true"});
            this.EachWayMultiplierCB.Location = new System.Drawing.Point(120, 153);
            this.EachWayMultiplierCB.Name = "EachWayMultiplierCB";
            this.EachWayMultiplierCB.Size = new System.Drawing.Size(57, 21);
            this.EachWayMultiplierCB.TabIndex = 128;
            this.EachWayMultiplierCB.Text = "false";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 127;
            this.label8.Text = "Multiplier:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "PLACE Invest Amount:";
            // 
            // PLACEInvestAmtTB
            // 
            this.PLACEInvestAmtTB.Location = new System.Drawing.Point(119, 132);
            this.PLACEInvestAmtTB.Name = "PLACEInvestAmtTB";
            this.PLACEInvestAmtTB.Size = new System.Drawing.Size(112, 20);
            this.PLACEInvestAmtTB.TabIndex = 16;
            this.PLACEInvestAmtTB.Text = "5.00";
            // 
            // secondaryOddsEW_LBL
            // 
            this.secondaryOddsEW_LBL.AutoSize = true;
            this.secondaryOddsEW_LBL.Location = new System.Drawing.Point(18, 92);
            this.secondaryOddsEW_LBL.Name = "secondaryOddsEW_LBL";
            this.secondaryOddsEW_LBL.Size = new System.Drawing.Size(86, 13);
            this.secondaryOddsEW_LBL.TabIndex = 15;
            this.secondaryOddsEW_LBL.Text = "SecondaryOdds:";
            // 
            // secondaryOddsEW_TB
            // 
            this.secondaryOddsEW_TB.Location = new System.Drawing.Point(121, 87);
            this.secondaryOddsEW_TB.Name = "secondaryOddsEW_TB";
            this.secondaryOddsEW_TB.Size = new System.Drawing.Size(112, 20);
            this.secondaryOddsEW_TB.TabIndex = 14;
            this.secondaryOddsEW_TB.Text = "0.00";
            // 
            // BetTypeEW_BTN
            // 
            this.BetTypeEW_BTN.Location = new System.Drawing.Point(121, 23);
            this.BetTypeEW_BTN.Name = "BetTypeEW_BTN";
            this.BetTypeEW_BTN.Size = new System.Drawing.Size(112, 20);
            this.BetTypeEW_BTN.TabIndex = 13;
            this.BetTypeEW_BTN.Text = "EACH_WAY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Loop:";
            // 
            // loopEW_TB
            // 
            this.loopEW_TB.Location = new System.Drawing.Point(51, 172);
            this.loopEW_TB.Name = "loopEW_TB";
            this.loopEW_TB.Size = new System.Drawing.Size(36, 20);
            this.loopEW_TB.TabIndex = 11;
            this.loopEW_TB.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "WIN Invest Amount:";
            // 
            // WINInvestAmtTB
            // 
            this.WINInvestAmtTB.Location = new System.Drawing.Point(120, 110);
            this.WINInvestAmtTB.Name = "WINInvestAmtTB";
            this.WINInvestAmtTB.Size = new System.Drawing.Size(112, 20);
            this.WINInvestAmtTB.TabIndex = 9;
            this.WINInvestAmtTB.Text = "5.00";
            // 
            // CallApiEW_BTN
            // 
            this.CallApiEW_BTN.Location = new System.Drawing.Point(156, 174);
            this.CallApiEW_BTN.Name = "CallApiEW_BTN";
            this.CallApiEW_BTN.Size = new System.Drawing.Size(75, 23);
            this.CallApiEW_BTN.TabIndex = 8;
            this.CallApiEW_BTN.Text = "Call API";
            this.CallApiEW_BTN.UseVisualStyleBackColor = true;
            this.CallApiEW_BTN.Click += new System.EventHandler(this.CallApiEW_BTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Odds:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Proposition Id:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Bet Type:";
            // 
            // OddsEW_TB
            // 
            this.OddsEW_TB.Location = new System.Drawing.Point(121, 64);
            this.OddsEW_TB.Name = "OddsEW_TB";
            this.OddsEW_TB.Size = new System.Drawing.Size(112, 20);
            this.OddsEW_TB.TabIndex = 2;
            this.OddsEW_TB.Text = "0.00";
            // 
            // propositionIdEW_TB
            // 
            this.propositionIdEW_TB.Location = new System.Drawing.Point(121, 43);
            this.propositionIdEW_TB.Name = "propositionIdEW_TB";
            this.propositionIdEW_TB.Size = new System.Drawing.Size(112, 20);
            this.propositionIdEW_TB.TabIndex = 1;
            this.propositionIdEW_TB.Text = "823820";
            // 
            // costEnquiryCKBox
            // 
            this.costEnquiryCKBox.AutoSize = true;
            this.costEnquiryCKBox.Location = new System.Drawing.Point(503, 163);
            this.costEnquiryCKBox.Name = "costEnquiryCKBox";
            this.costEnquiryCKBox.Size = new System.Drawing.Size(61, 17);
            this.costEnquiryCKBox.TabIndex = 16;
            this.costEnquiryCKBox.Text = "Enquiry";
            this.costEnquiryCKBox.UseVisualStyleBackColor = true;
            // 
            // getBonusBetTokensCmd
            // 
            this.getBonusBetTokensCmd.Location = new System.Drawing.Point(517, 24);
            this.getBonusBetTokensCmd.Name = "getBonusBetTokensCmd";
            this.getBonusBetTokensCmd.Size = new System.Drawing.Size(121, 30);
            this.getBonusBetTokensCmd.TabIndex = 17;
            this.getBonusBetTokensCmd.Text = "getBonusBetTokens";
            this.getBonusBetTokensCmd.UseVisualStyleBackColor = true;
            this.getBonusBetTokensCmd.Click += new System.EventHandler(this.getBonusBetTokensCmd_Click);
            // 
            // copyTSNBTN
            // 
            this.copyTSNBTN.Location = new System.Drawing.Point(517, 58);
            this.copyTSNBTN.Name = "copyTSNBTN";
            this.copyTSNBTN.Size = new System.Drawing.Size(121, 30);
            this.copyTSNBTN.TabIndex = 18;
            this.copyTSNBTN.Text = "Copy TSN";
            this.copyTSNBTN.UseVisualStyleBackColor = true;
            this.copyTSNBTN.Click += new System.EventHandler(this.copyTSNBTN_Click);
            // 
            // FOBettingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.copyTSNBTN);
            this.Controls.Add(this.getBonusBetTokensCmd);
            this.Controls.Add(this.costEnquiryCKBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FOBettingUC";
            this.Size = new System.Drawing.Size(670, 207);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.Label oddsLBL;
        private System.Windows.Forms.Label propositionIdLBL;
        private System.Windows.Forms.Label BettypeLBL;
        private System.Windows.Forms.TextBox OddsTB;
        private System.Windows.Forms.TextBox propositionIdTB;
        private System.Windows.Forms.Label InvestAmountLBL;
        private System.Windows.Forms.TextBox InvestAmtTB;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.ComboBox BetTypeCB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label secondaryOddsEW_LBL;
        private System.Windows.Forms.TextBox secondaryOddsEW_TB;
        private System.Windows.Forms.TextBox BetTypeEW_BTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox loopEW_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WINInvestAmtTB;
        private System.Windows.Forms.Button CallApiEW_BTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OddsEW_TB;
        private System.Windows.Forms.TextBox propositionIdEW_TB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PLACEInvestAmtTB;
        private System.Windows.Forms.CheckBox costEnquiryCKBox;
        private System.Windows.Forms.Button getBonusBetTokensCmd;
        private System.Windows.Forms.TextBox BonusBetTokenTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button copyTSNBTN;
        private System.Windows.Forms.ComboBox MultiplierCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox EachWayMultiplierCB;
        private System.Windows.Forms.Label label8;
    }
}
