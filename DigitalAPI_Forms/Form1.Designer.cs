namespace DigitalAPI_Forms
{
    partial class DigitalAPItester
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ReponseLBL = new System.Windows.Forms.Label();
            this.addressLBL = new System.Windows.Forms.Label();
            this.ActManCallsLBL = new System.Windows.Forms.Label();
            this.ActManCallsCB = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ResponseTB = new System.Windows.Forms.TextBox();
            this.AddressCB = new System.Windows.Forms.ComboBox();
            this.RacingInfoCB = new System.Windows.Forms.ComboBox();
            this.RacingInfoLB = new System.Windows.Forms.Label();
            this.BettingCB = new System.Windows.Forms.ComboBox();
            this.bettingLBL = new System.Windows.Forms.Label();
            this.SportsInfoCB = new System.Windows.Forms.ComboBox();
            this.SportsInfoLB = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ResTimeLBL = new System.Windows.Forms.Label();
            this.LogMsgCKB = new System.Windows.Forms.CheckBox();
            this.requestTB = new System.Windows.Forms.TextBox();
            this.requestLBL = new System.Windows.Forms.Label();
            this.InVenueCB = new System.Windows.Forms.ComboBox();
            this.InVenueLBL = new System.Windows.Forms.Label();
            this.statusCodeLBL = new System.Windows.Forms.Label();
            this.enviornmentLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReponseLBL
            // 
            this.ReponseLBL.AutoSize = true;
            this.ReponseLBL.Location = new System.Drawing.Point(514, 241);
            this.ReponseLBL.Name = "ReponseLBL";
            this.ReponseLBL.Size = new System.Drawing.Size(58, 13);
            this.ReponseLBL.TabIndex = 1;
            this.ReponseLBL.Text = "Response:";
            // 
            // addressLBL
            // 
            this.addressLBL.AutoSize = true;
            this.addressLBL.Location = new System.Drawing.Point(21, 23);
            this.addressLBL.Name = "addressLBL";
            this.addressLBL.Size = new System.Drawing.Size(48, 13);
            this.addressLBL.TabIndex = 2;
            this.addressLBL.Text = "Address:";
            this.addressLBL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ActManCallsLBL
            // 
            this.ActManCallsLBL.AutoSize = true;
            this.ActManCallsLBL.Location = new System.Drawing.Point(21, 52);
            this.ActManCallsLBL.Name = "ActManCallsLBL";
            this.ActManCallsLBL.Size = new System.Drawing.Size(50, 13);
            this.ActManCallsLBL.TabIndex = 4;
            this.ActManCallsLBL.Text = "Acc Mgt:";
            this.ActManCallsLBL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ActManCallsCB
            // 
            this.ActManCallsCB.FormattingEnabled = true;
            this.ActManCallsCB.Location = new System.Drawing.Point(82, 46);
            this.ActManCallsCB.Name = "ActManCallsCB";
            this.ActManCallsCB.Size = new System.Drawing.Size(162, 21);
            this.ActManCallsCB.TabIndex = 5;
            this.ActManCallsCB.SelectedIndexChanged += new System.EventHandler(this.msgboxCB_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(247, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 217);
            this.panel1.TabIndex = 8;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ResponseTB
            // 
            this.ResponseTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResponseTB.BackColor = System.Drawing.SystemColors.Window;
            this.ResponseTB.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponseTB.Location = new System.Drawing.Point(514, 256);
            this.ResponseTB.Multiline = true;
            this.ResponseTB.Name = "ResponseTB";
            this.ResponseTB.ReadOnly = true;
            this.ResponseTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResponseTB.Size = new System.Drawing.Size(697, 461);
            this.ResponseTB.TabIndex = 0;
            // 
            // AddressCB
            // 
            this.AddressCB.FormattingEnabled = true;
            this.AddressCB.Items.AddRange(new object[] {
            "https://uat01.webapi.tab.com.au",
            "https://uat02.webapi.tab.com.au",
            "https://pre.webapi.tab.com.au",
            "http://10.26.128.209:8080",
            "https://uat01.beta.tab.com.au",
            "https://uat02.beta.tab.com.au",
            "https://pre-api.beta.tab.com.au"});
            this.AddressCB.Location = new System.Drawing.Point(82, 20);
            this.AddressCB.Name = "AddressCB";
            this.AddressCB.Size = new System.Drawing.Size(162, 21);
            this.AddressCB.TabIndex = 9;
            this.AddressCB.Text = "https://uat01.beta.tab.com.au";
            this.AddressCB.SelectedIndexChanged += new System.EventHandler(this.AddressCB_Leave);
            // 
            // RacingInfoCB
            // 
            this.RacingInfoCB.FormattingEnabled = true;
            this.RacingInfoCB.Items.AddRange(new object[] {
            "Meetings",
            "MeetingRaces",
            "FutureMeetings",
            "FutureRaces",
            "Races",
            "NextToGo"});
            this.RacingInfoCB.Location = new System.Drawing.Point(82, 73);
            this.RacingInfoCB.Name = "RacingInfoCB";
            this.RacingInfoCB.Size = new System.Drawing.Size(162, 21);
            this.RacingInfoCB.TabIndex = 11;
            this.RacingInfoCB.SelectedIndexChanged += new System.EventHandler(this.RacingInfoCB_SelectedIndexChanged);
            // 
            // RacingInfoLB
            // 
            this.RacingInfoLB.AutoSize = true;
            this.RacingInfoLB.Location = new System.Drawing.Point(19, 79);
            this.RacingInfoLB.Name = "RacingInfoLB";
            this.RacingInfoLB.Size = new System.Drawing.Size(65, 13);
            this.RacingInfoLB.TabIndex = 10;
            this.RacingInfoLB.Text = "Racing Info:";
            this.RacingInfoLB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BettingCB
            // 
            this.BettingCB.FormattingEnabled = true;
            this.BettingCB.Items.AddRange(new object[] {
            "FixedOddsSell",
            "FixedOddsSell_Multi",
            "PariSell",
            "BatchBetting",
            "CashOut",
            "FixedOddsSellLiveBet",
            "FixedOddsSellLiveBet_Multi",
            "CancelBet",
            "ScanRetailTicket",
            "BundleBet/SGM",
            "BundleBet/SGM-Pricing"});
            this.BettingCB.Location = new System.Drawing.Point(82, 129);
            this.BettingCB.Name = "BettingCB";
            this.BettingCB.Size = new System.Drawing.Size(162, 21);
            this.BettingCB.TabIndex = 13;
            this.BettingCB.SelectedIndexChanged += new System.EventHandler(this.BettingCB_SelectedIndexChanged);
            // 
            // bettingLBL
            // 
            this.bettingLBL.AutoSize = true;
            this.bettingLBL.Location = new System.Drawing.Point(19, 135);
            this.bettingLBL.Name = "bettingLBL";
            this.bettingLBL.Size = new System.Drawing.Size(43, 13);
            this.bettingLBL.TabIndex = 12;
            this.bettingLBL.Text = "Betting:";
            this.bettingLBL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SportsInfoCB
            // 
            this.SportsInfoCB.FormattingEnabled = true;
            this.SportsInfoCB.Items.AddRange(new object[] {
            "Sports",
            "Competitions",
            "Tournaments",
            "Matches",
            "MatchTournament",
            "MatchCompetition",
            "MatchCompTourn",
            "MarketsCompetition",
            "MarketsCompTourn",
            "MarketsCompMatch",
            "MarketsCompTournMatch",
            "NextToGo"});
            this.SportsInfoCB.Location = new System.Drawing.Point(82, 102);
            this.SportsInfoCB.Name = "SportsInfoCB";
            this.SportsInfoCB.Size = new System.Drawing.Size(162, 21);
            this.SportsInfoCB.TabIndex = 15;
            this.SportsInfoCB.SelectedIndexChanged += new System.EventHandler(this.SportsInfoCB_SelectedIndexChanged);
            // 
            // SportsInfoLB
            // 
            this.SportsInfoLB.AutoSize = true;
            this.SportsInfoLB.Location = new System.Drawing.Point(19, 108);
            this.SportsInfoLB.Name = "SportsInfoLB";
            this.SportsInfoLB.Size = new System.Drawing.Size(61, 13);
            this.SportsInfoLB.TabIndex = 14;
            this.SportsInfoLB.Text = "Sports Info:";
            this.SportsInfoLB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 720);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1223, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ResTimeLBL
            // 
            this.ResTimeLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResTimeLBL.AutoSize = true;
            this.ResTimeLBL.Location = new System.Drawing.Point(7, 725);
            this.ResTimeLBL.Name = "ResTimeLBL";
            this.ResTimeLBL.Size = new System.Drawing.Size(84, 13);
            this.ResTimeLBL.TabIndex = 17;
            this.ResTimeLBL.Text = "Response Time:";
            // 
            // LogMsgCKB
            // 
            this.LogMsgCKB.AutoSize = true;
            this.LogMsgCKB.Location = new System.Drawing.Point(177, 193);
            this.LogMsgCKB.Name = "LogMsgCKB";
            this.LogMsgCKB.Size = new System.Drawing.Size(67, 17);
            this.LogMsgCKB.TabIndex = 0;
            this.LogMsgCKB.Text = "Log Msg";
            this.LogMsgCKB.UseVisualStyleBackColor = true;
            // 
            // requestTB
            // 
            this.requestTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.requestTB.BackColor = System.Drawing.SystemColors.Window;
            this.requestTB.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestTB.Location = new System.Drawing.Point(15, 256);
            this.requestTB.Multiline = true;
            this.requestTB.Name = "requestTB";
            this.requestTB.ReadOnly = true;
            this.requestTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.requestTB.Size = new System.Drawing.Size(493, 461);
            this.requestTB.TabIndex = 18;
            // 
            // requestLBL
            // 
            this.requestLBL.AutoSize = true;
            this.requestLBL.Location = new System.Drawing.Point(13, 240);
            this.requestLBL.Name = "requestLBL";
            this.requestLBL.Size = new System.Drawing.Size(50, 13);
            this.requestLBL.TabIndex = 19;
            this.requestLBL.Text = "Request:";
            // 
            // InVenueCB
            // 
            this.InVenueCB.FormattingEnabled = true;
            this.InVenueCB.Items.AddRange(new object[] {
            "Commissions",
            "Configuration",
            "Venues",
            "Display-Devices",
            "Terminals",
            "AML Event",
            "Retail-Device"});
            this.InVenueCB.Location = new System.Drawing.Point(82, 157);
            this.InVenueCB.Name = "InVenueCB";
            this.InVenueCB.Size = new System.Drawing.Size(162, 21);
            this.InVenueCB.TabIndex = 21;
            this.InVenueCB.SelectedIndexChanged += new System.EventHandler(this.InVenueCB_SelectedIndexChanged);
            // 
            // InVenueLBL
            // 
            this.InVenueLBL.AutoSize = true;
            this.InVenueLBL.Location = new System.Drawing.Point(19, 163);
            this.InVenueLBL.Name = "InVenueLBL";
            this.InVenueLBL.Size = new System.Drawing.Size(50, 13);
            this.InVenueLBL.TabIndex = 20;
            this.InVenueLBL.Text = "InVenue:";
            this.InVenueLBL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statusCodeLBL
            // 
            this.statusCodeLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusCodeLBL.AutoSize = true;
            this.statusCodeLBL.Location = new System.Drawing.Point(523, 725);
            this.statusCodeLBL.Name = "statusCodeLBL";
            this.statusCodeLBL.Size = new System.Drawing.Size(86, 13);
            this.statusCodeLBL.TabIndex = 22;
            this.statusCodeLBL.Text = "Response Code:";
            // 
            // enviornmentLBL
            // 
            this.enviornmentLBL.AutoSize = true;
            this.enviornmentLBL.BackColor = System.Drawing.SystemColors.Highlight;
            this.enviornmentLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviornmentLBL.Location = new System.Drawing.Point(714, 238);
            this.enviornmentLBL.Name = "enviornmentLBL";
            this.enviornmentLBL.Size = new System.Drawing.Size(48, 18);
            this.enviornmentLBL.TabIndex = 23;
            this.enviornmentLBL.Text = "Yarra";
            // 
            // DigitalAPItester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 742);
            this.Controls.Add(this.enviornmentLBL);
            this.Controls.Add(this.statusCodeLBL);
            this.Controls.Add(this.InVenueCB);
            this.Controls.Add(this.InVenueLBL);
            this.Controls.Add(this.requestLBL);
            this.Controls.Add(this.requestTB);
            this.Controls.Add(this.LogMsgCKB);
            this.Controls.Add(this.ResTimeLBL);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.SportsInfoCB);
            this.Controls.Add(this.SportsInfoLB);
            this.Controls.Add(this.BettingCB);
            this.Controls.Add(this.bettingLBL);
            this.Controls.Add(this.RacingInfoCB);
            this.Controls.Add(this.RacingInfoLB);
            this.Controls.Add(this.AddressCB);
            this.Controls.Add(this.ResponseTB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ActManCallsCB);
            this.Controls.Add(this.ActManCallsLBL);
            this.Controls.Add(this.addressLBL);
            this.Controls.Add(this.ReponseLBL);
            this.Name = "DigitalAPItester";
            this.Text = "Digital API tester v2.21";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DigitalAPItester_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label ReponseLBL;
        private System.Windows.Forms.Label addressLBL;
        private System.Windows.Forms.Label ActManCallsLBL;
        private System.Windows.Forms.ComboBox ActManCallsCB;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox ResponseTB;
        private System.Windows.Forms.ComboBox AddressCB;
        private System.Windows.Forms.ComboBox RacingInfoCB;
        private System.Windows.Forms.Label RacingInfoLB;
        private System.Windows.Forms.ComboBox BettingCB;
        private System.Windows.Forms.Label bettingLBL;
        private System.Windows.Forms.ComboBox SportsInfoCB;
        private System.Windows.Forms.Label SportsInfoLB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label ResTimeLBL;
        private System.Windows.Forms.CheckBox LogMsgCKB;
        private System.Windows.Forms.TextBox requestTB;
        private System.Windows.Forms.Label requestLBL;
        private System.Windows.Forms.ComboBox InVenueCB;
        private System.Windows.Forms.Label InVenueLBL;
        private System.Windows.Forms.Label statusCodeLBL;
        private System.Windows.Forms.Label enviornmentLBL;
    }
}

