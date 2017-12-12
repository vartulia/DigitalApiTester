namespace DigitalAPI_Forms
{
    partial class PariSellUC
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
            this.BetTypeCB = new System.Windows.Forms.ComboBox();
            this.loopLBL = new System.Windows.Forms.Label();
            this.loopTB = new System.Windows.Forms.TextBox();
            this.scheduledTypeLBL = new System.Windows.Forms.Label();
            this.scheduledTypeTB = new System.Windows.Forms.TextBox();
            this.CallApiBTN = new System.Windows.Forms.Button();
            this.meetingCodeLBL = new System.Windows.Forms.Label();
            this.stakeLBL = new System.Windows.Forms.Label();
            this.BettypeLBL = new System.Windows.Forms.Label();
            this.meetingCodeTB = new System.Windows.Forms.TextBox();
            this.stakeTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MultiplierCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.selections6CB = new System.Windows.Forms.ComboBox();
            this.selections5CB = new System.Windows.Forms.ComboBox();
            this.selections4CB = new System.Windows.Forms.ComboBox();
            this.selections3CB = new System.Windows.Forms.ComboBox();
            this.selections2CB = new System.Windows.Forms.ComboBox();
            this.selections1CB = new System.Windows.Forms.ComboBox();
            this.selectionsCB = new System.Windows.Forms.ComboBox();
            this.copyTSNBTN = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.bonusBetTokenTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.getBonusBetTokensCmd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outletTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.secondaryStakeTB = new System.Windows.Forms.TextBox();
            this.selectionsLBL = new System.Windows.Forms.Label();
            this.flexiCB = new System.Windows.Forms.ComboBox();
            this.flexiLBL = new System.Windows.Forms.Label();
            this.meetingDateLBL = new System.Windows.Forms.Label();
            this.meetingDateTB = new System.Windows.Forms.TextBox();
            this.raceNumberLBL = new System.Windows.Forms.Label();
            this.raceNumberTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BetTypeCB
            // 
            this.BetTypeCB.FormattingEnabled = true;
            this.BetTypeCB.Items.AddRange(new object[] {
            "WIN",
            "PLACE",
            "EACH_WAY",
            "QUINELLA",
            "DUET",
            "TRIFECTA",
            "FIRST_FOUR",
            "EXACTA",
            "RUNNING_DOUBLE",
            "DAILY_DOUBLE",
            "QUADDIE",
            "EARLY_QUADDIE",
            "BIG6",
            "TRIO"});
            this.BetTypeCB.Location = new System.Drawing.Point(105, 23);
            this.BetTypeCB.Name = "BetTypeCB";
            this.BetTypeCB.Size = new System.Drawing.Size(113, 21);
            this.BetTypeCB.TabIndex = 13;
            this.BetTypeCB.Text = "WIN";
            this.BetTypeCB.SelectedIndexChanged += new System.EventHandler(this.BetTypeCB_SelectedIndexChanged);
            // 
            // loopLBL
            // 
            this.loopLBL.AutoSize = true;
            this.loopLBL.Location = new System.Drawing.Point(752, 149);
            this.loopLBL.Name = "loopLBL";
            this.loopLBL.Size = new System.Drawing.Size(34, 13);
            this.loopLBL.TabIndex = 12;
            this.loopLBL.Text = "Loop:";
            // 
            // loopTB
            // 
            this.loopTB.Location = new System.Drawing.Point(793, 146);
            this.loopTB.Name = "loopTB";
            this.loopTB.Size = new System.Drawing.Size(36, 20);
            this.loopTB.TabIndex = 11;
            this.loopTB.Text = "1";
            // 
            // scheduledTypeLBL
            // 
            this.scheduledTypeLBL.AutoSize = true;
            this.scheduledTypeLBL.Location = new System.Drawing.Point(11, 100);
            this.scheduledTypeLBL.Name = "scheduledTypeLBL";
            this.scheduledTypeLBL.Size = new System.Drawing.Size(88, 13);
            this.scheduledTypeLBL.TabIndex = 10;
            this.scheduledTypeLBL.Text = "Scheduled Type:";
            // 
            // scheduledTypeTB
            // 
            this.scheduledTypeTB.Location = new System.Drawing.Point(105, 97);
            this.scheduledTypeTB.Name = "scheduledTypeTB";
            this.scheduledTypeTB.Size = new System.Drawing.Size(50, 20);
            this.scheduledTypeTB.TabIndex = 9;
            this.scheduledTypeTB.Text = "R";
            // 
            // CallApiBTN
            // 
            this.CallApiBTN.Location = new System.Drawing.Point(755, 169);
            this.CallApiBTN.Name = "CallApiBTN";
            this.CallApiBTN.Size = new System.Drawing.Size(75, 23);
            this.CallApiBTN.TabIndex = 8;
            this.CallApiBTN.Text = "Call API";
            this.CallApiBTN.UseVisualStyleBackColor = true;
            this.CallApiBTN.Click += new System.EventHandler(this.CallApiBTN_Click);
            // 
            // meetingCodeLBL
            // 
            this.meetingCodeLBL.AutoSize = true;
            this.meetingCodeLBL.Location = new System.Drawing.Point(18, 76);
            this.meetingCodeLBL.Name = "meetingCodeLBL";
            this.meetingCodeLBL.Size = new System.Drawing.Size(76, 13);
            this.meetingCodeLBL.TabIndex = 5;
            this.meetingCodeLBL.Text = "Meeting Code:";
            // 
            // stakeLBL
            // 
            this.stakeLBL.AutoSize = true;
            this.stakeLBL.Location = new System.Drawing.Point(41, 50);
            this.stakeLBL.Name = "stakeLBL";
            this.stakeLBL.Size = new System.Drawing.Size(38, 13);
            this.stakeLBL.TabIndex = 4;
            this.stakeLBL.Text = "Stake:";
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
            // meetingCodeTB
            // 
            this.meetingCodeTB.Location = new System.Drawing.Point(106, 73);
            this.meetingCodeTB.Name = "meetingCodeTB";
            this.meetingCodeTB.Size = new System.Drawing.Size(50, 20);
            this.meetingCodeTB.TabIndex = 2;
            this.meetingCodeTB.Text = "M";
            // 
            // stakeTB
            // 
            this.stakeTB.Location = new System.Drawing.Point(106, 47);
            this.stakeTB.Name = "stakeTB";
            this.stakeTB.Size = new System.Drawing.Size(50, 20);
            this.stakeTB.TabIndex = 1;
            this.stakeTB.Text = "$1.00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MultiplierCB);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.selections6CB);
            this.groupBox1.Controls.Add(this.selections5CB);
            this.groupBox1.Controls.Add(this.selections4CB);
            this.groupBox1.Controls.Add(this.selections3CB);
            this.groupBox1.Controls.Add(this.selections2CB);
            this.groupBox1.Controls.Add(this.selections1CB);
            this.groupBox1.Controls.Add(this.selectionsCB);
            this.groupBox1.Controls.Add(this.copyTSNBTN);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.bonusBetTokenTB);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.getBonusBetTokensCmd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.outletTB);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.secondaryStakeTB);
            this.groupBox1.Controls.Add(this.selectionsLBL);
            this.groupBox1.Controls.Add(this.flexiCB);
            this.groupBox1.Controls.Add(this.flexiLBL);
            this.groupBox1.Controls.Add(this.meetingDateLBL);
            this.groupBox1.Controls.Add(this.meetingDateTB);
            this.groupBox1.Controls.Add(this.BetTypeCB);
            this.groupBox1.Controls.Add(this.raceNumberLBL);
            this.groupBox1.Controls.Add(this.raceNumberTB);
            this.groupBox1.Controls.Add(this.loopLBL);
            this.groupBox1.Controls.Add(this.loopTB);
            this.groupBox1.Controls.Add(this.scheduledTypeLBL);
            this.groupBox1.Controls.Add(this.scheduledTypeTB);
            this.groupBox1.Controls.Add(this.CallApiBTN);
            this.groupBox1.Controls.Add(this.meetingCodeLBL);
            this.groupBox1.Controls.Add(this.stakeLBL);
            this.groupBox1.Controls.Add(this.BettypeLBL);
            this.groupBox1.Controls.Add(this.meetingCodeTB);
            this.groupBox1.Controls.Add(this.stakeTB);
            this.groupBox1.Location = new System.Drawing.Point(3, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 206);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // MultiplierCB
            // 
            this.MultiplierCB.FormattingEnabled = true;
            this.MultiplierCB.Items.AddRange(new object[] {
            "false",
            "true"});
            this.MultiplierCB.Location = new System.Drawing.Point(341, 145);
            this.MultiplierCB.Name = "MultiplierCB";
            this.MultiplierCB.Size = new System.Drawing.Size(57, 21);
            this.MultiplierCB.TabIndex = 124;
            this.MultiplierCB.Text = "false";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 123;
            this.label10.Text = "Multiplier:";
            // 
            // selections6CB
            // 
            this.selections6CB.Enabled = false;
            this.selections6CB.FormattingEnabled = true;
            this.selections6CB.Items.AddRange(new object[] {
            "1,2,3,4",
            "FIELD",
            "MYSTERY"});
            this.selections6CB.Location = new System.Drawing.Point(599, 149);
            this.selections6CB.Name = "selections6CB";
            this.selections6CB.Size = new System.Drawing.Size(100, 21);
            this.selections6CB.TabIndex = 122;
            this.selections6CB.Text = "1,2,3,4";
            // 
            // selections5CB
            // 
            this.selections5CB.Enabled = false;
            this.selections5CB.FormattingEnabled = true;
            this.selections5CB.Items.AddRange(new object[] {
            "1,2,3,4",
            "FIELD",
            "MYSTERY"});
            this.selections5CB.Location = new System.Drawing.Point(599, 125);
            this.selections5CB.Name = "selections5CB";
            this.selections5CB.Size = new System.Drawing.Size(100, 21);
            this.selections5CB.TabIndex = 121;
            this.selections5CB.Text = "1,2,3,4";
            // 
            // selections4CB
            // 
            this.selections4CB.Enabled = false;
            this.selections4CB.FormattingEnabled = true;
            this.selections4CB.Items.AddRange(new object[] {
            "1,2,3,4",
            "FIELD",
            "MYSTERY"});
            this.selections4CB.Location = new System.Drawing.Point(599, 101);
            this.selections4CB.Name = "selections4CB";
            this.selections4CB.Size = new System.Drawing.Size(100, 21);
            this.selections4CB.TabIndex = 120;
            this.selections4CB.Text = "1,2,3,4";
            // 
            // selections3CB
            // 
            this.selections3CB.Enabled = false;
            this.selections3CB.FormattingEnabled = true;
            this.selections3CB.Items.AddRange(new object[] {
            "1,2,3,4",
            "FIELD",
            "MYSTERY"});
            this.selections3CB.Location = new System.Drawing.Point(599, 76);
            this.selections3CB.Name = "selections3CB";
            this.selections3CB.Size = new System.Drawing.Size(100, 21);
            this.selections3CB.TabIndex = 119;
            this.selections3CB.Text = "1,2,3,4";
            // 
            // selections2CB
            // 
            this.selections2CB.Enabled = false;
            this.selections2CB.FormattingEnabled = true;
            this.selections2CB.Items.AddRange(new object[] {
            "1,2,3,4",
            "FIELD",
            "MYSTERY"});
            this.selections2CB.Location = new System.Drawing.Point(599, 51);
            this.selections2CB.Name = "selections2CB";
            this.selections2CB.Size = new System.Drawing.Size(100, 21);
            this.selections2CB.TabIndex = 118;
            this.selections2CB.Text = "1,2,3,4";
            // 
            // selections1CB
            // 
            this.selections1CB.Enabled = false;
            this.selections1CB.FormattingEnabled = true;
            this.selections1CB.Items.AddRange(new object[] {
            "1,2,3,4",
            "FIELD",
            "MYSTERY"});
            this.selections1CB.Location = new System.Drawing.Point(599, 24);
            this.selections1CB.Name = "selections1CB";
            this.selections1CB.Size = new System.Drawing.Size(100, 21);
            this.selections1CB.TabIndex = 117;
            this.selections1CB.Text = "1,2,3,4";
            // 
            // selectionsCB
            // 
            this.selectionsCB.FormattingEnabled = true;
            this.selectionsCB.Items.AddRange(new object[] {
            "1,2,3,4",
            "FIELD",
            "MYSTERY"});
            this.selectionsCB.Location = new System.Drawing.Point(341, 26);
            this.selectionsCB.Name = "selectionsCB";
            this.selectionsCB.Size = new System.Drawing.Size(121, 21);
            this.selectionsCB.TabIndex = 116;
            this.selectionsCB.Text = "1,2,3,4";
            // 
            // copyTSNBTN
            // 
            this.copyTSNBTN.Location = new System.Drawing.Point(705, 74);
            this.copyTSNBTN.Name = "copyTSNBTN";
            this.copyTSNBTN.Size = new System.Drawing.Size(121, 30);
            this.copyTSNBTN.TabIndex = 19;
            this.copyTSNBTN.Text = "Copy TSN";
            this.copyTSNBTN.UseVisualStyleBackColor = true;
            this.copyTSNBTN.Click += new System.EventHandler(this.copyTSNBTN_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 115;
            this.label9.Text = "Bonus Bet Token:";
            // 
            // bonusBetTokenTB
            // 
            this.bonusBetTokenTB.Location = new System.Drawing.Point(341, 121);
            this.bonusBetTokenTB.Name = "bonusBetTokenTB";
            this.bonusBetTokenTB.Size = new System.Drawing.Size(149, 20);
            this.bonusBetTokenTB.TabIndex = 114;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(514, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 113;
            this.label8.Text = "Selections:";
            // 
            // getBonusBetTokensCmd
            // 
            this.getBonusBetTokensCmd.Location = new System.Drawing.Point(705, 24);
            this.getBonusBetTokensCmd.Name = "getBonusBetTokensCmd";
            this.getBonusBetTokensCmd.Size = new System.Drawing.Size(121, 46);
            this.getBonusBetTokensCmd.TabIndex = 16;
            this.getBonusBetTokensCmd.Text = "getBonusBetTokens";
            this.getBonusBetTokensCmd.UseVisualStyleBackColor = true;
            this.getBonusBetTokensCmd.Click += new System.EventHandler(this.getBonusBetTokensCmd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(514, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 111;
            this.label6.Text = "Selections:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 109;
            this.label5.Text = "Selections:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(514, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 107;
            this.label4.Text = "Selections:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "Selections:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Selections:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(724, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Outlet";
            // 
            // outletTB
            // 
            this.outletTB.Location = new System.Drawing.Point(765, 118);
            this.outletTB.Name = "outletTB";
            this.outletTB.Size = new System.Drawing.Size(61, 20);
            this.outletTB.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Secondary Stake:";
            // 
            // secondaryStakeTB
            // 
            this.secondaryStakeTB.Enabled = false;
            this.secondaryStakeTB.Location = new System.Drawing.Point(341, 50);
            this.secondaryStakeTB.Name = "secondaryStakeTB";
            this.secondaryStakeTB.Size = new System.Drawing.Size(100, 20);
            this.secondaryStakeTB.TabIndex = 29;
            this.secondaryStakeTB.Text = "$2.00";
            // 
            // selectionsLBL
            // 
            this.selectionsLBL.AutoSize = true;
            this.selectionsLBL.Location = new System.Drawing.Point(256, 31);
            this.selectionsLBL.Name = "selectionsLBL";
            this.selectionsLBL.Size = new System.Drawing.Size(59, 13);
            this.selectionsLBL.TabIndex = 28;
            this.selectionsLBL.Text = "Selections:";
            // 
            // flexiCB
            // 
            this.flexiCB.FormattingEnabled = true;
            this.flexiCB.Items.AddRange(new object[] {
            "false",
            "true"});
            this.flexiCB.Location = new System.Drawing.Point(105, 163);
            this.flexiCB.Name = "flexiCB";
            this.flexiCB.Size = new System.Drawing.Size(51, 21);
            this.flexiCB.TabIndex = 24;
            this.flexiCB.Text = "false";
            // 
            // flexiLBL
            // 
            this.flexiLBL.AutoSize = true;
            this.flexiLBL.Location = new System.Drawing.Point(63, 166);
            this.flexiLBL.Name = "flexiLBL";
            this.flexiLBL.Size = new System.Drawing.Size(31, 13);
            this.flexiLBL.TabIndex = 23;
            this.flexiLBL.Text = "Flexi:";
            // 
            // meetingDateLBL
            // 
            this.meetingDateLBL.AutoSize = true;
            this.meetingDateLBL.Location = new System.Drawing.Point(21, 147);
            this.meetingDateLBL.Name = "meetingDateLBL";
            this.meetingDateLBL.Size = new System.Drawing.Size(74, 13);
            this.meetingDateLBL.TabIndex = 21;
            this.meetingDateLBL.Text = "Meeting Date:";
            // 
            // meetingDateTB
            // 
            this.meetingDateTB.Location = new System.Drawing.Point(106, 140);
            this.meetingDateTB.Name = "meetingDateTB";
            this.meetingDateTB.Size = new System.Drawing.Size(100, 20);
            this.meetingDateTB.TabIndex = 20;
            // 
            // raceNumberLBL
            // 
            this.raceNumberLBL.AutoSize = true;
            this.raceNumberLBL.Location = new System.Drawing.Point(59, 121);
            this.raceNumberLBL.Name = "raceNumberLBL";
            this.raceNumberLBL.Size = new System.Drawing.Size(36, 13);
            this.raceNumberLBL.TabIndex = 19;
            this.raceNumberLBL.Text = "Race:";
            // 
            // raceNumberTB
            // 
            this.raceNumberTB.Location = new System.Drawing.Point(105, 118);
            this.raceNumberTB.Name = "raceNumberTB";
            this.raceNumberTB.Size = new System.Drawing.Size(36, 20);
            this.raceNumberTB.TabIndex = 17;
            this.raceNumberTB.Text = "1";
            // 
            // PariSellUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PariSellUC";
            this.Size = new System.Drawing.Size(841, 283);
            this.Load += new System.EventHandler(this.PariSellUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox BetTypeCB;
        private System.Windows.Forms.Label loopLBL;
        private System.Windows.Forms.TextBox loopTB;
        private System.Windows.Forms.Label scheduledTypeLBL;
        private System.Windows.Forms.TextBox scheduledTypeTB;
        private System.Windows.Forms.Button CallApiBTN;
        private System.Windows.Forms.Label meetingCodeLBL;
        private System.Windows.Forms.Label stakeLBL;
        private System.Windows.Forms.Label BettypeLBL;
        private System.Windows.Forms.TextBox meetingCodeTB;
        private System.Windows.Forms.TextBox stakeTB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label meetingDateLBL;
        private System.Windows.Forms.TextBox meetingDateTB;
        private System.Windows.Forms.Label raceNumberLBL;
        private System.Windows.Forms.TextBox raceNumberTB;
        private System.Windows.Forms.Label flexiLBL;
        private System.Windows.Forms.ComboBox flexiCB;
        private System.Windows.Forms.Label selectionsLBL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox secondaryStakeTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outletTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button getBonusBetTokensCmd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox bonusBetTokenTB;
        private System.Windows.Forms.Button copyTSNBTN;
        private System.Windows.Forms.ComboBox selections1CB;
        private System.Windows.Forms.ComboBox selectionsCB;
        private System.Windows.Forms.ComboBox selections6CB;
        private System.Windows.Forms.ComboBox selections5CB;
        private System.Windows.Forms.ComboBox selections4CB;
        private System.Windows.Forms.ComboBox selections3CB;
        private System.Windows.Forms.ComboBox selections2CB;
        private System.Windows.Forms.ComboBox MultiplierCB;
        private System.Windows.Forms.Label label10;
    }
}
