namespace DigitalAPI_Forms
{
    partial class InVenueConfigurationUC
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
            this.components = new System.ComponentModel.Container();
            this.getConfigBTN = new System.Windows.Forms.Button();
            this.getDistGroupsBTN = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteConfigBTN = new System.Windows.Forms.Button();
            this.idTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idGroupTB = new System.Windows.Forms.TextBox();
            this.deleteGroupBTN = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // getConfigBTN
            // 
            this.getConfigBTN.Location = new System.Drawing.Point(19, 97);
            this.getConfigBTN.Name = "getConfigBTN";
            this.getConfigBTN.Size = new System.Drawing.Size(67, 48);
            this.getConfigBTN.TabIndex = 8;
            this.getConfigBTN.Text = "Get Config";
            this.getConfigBTN.UseVisualStyleBackColor = true;
            this.getConfigBTN.Click += new System.EventHandler(this.CallApiBTN_Click);
            // 
            // getDistGroupsBTN
            // 
            this.getDistGroupsBTN.Location = new System.Drawing.Point(14, 97);
            this.getDistGroupsBTN.Name = "getDistGroupsBTN";
            this.getDistGroupsBTN.Size = new System.Drawing.Size(74, 48);
            this.getDistGroupsBTN.TabIndex = 9;
            this.getDistGroupsBTN.Text = "Get Distribution Groups";
            this.getDistGroupsBTN.UseVisualStyleBackColor = true;
            this.getDistGroupsBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // deleteConfigBTN
            // 
            this.deleteConfigBTN.Location = new System.Drawing.Point(92, 97);
            this.deleteConfigBTN.Name = "deleteConfigBTN";
            this.deleteConfigBTN.Size = new System.Drawing.Size(94, 48);
            this.deleteConfigBTN.TabIndex = 8;
            this.deleteConfigBTN.Text = "Delete Config";
            this.deleteConfigBTN.UseVisualStyleBackColor = true;
            this.deleteConfigBTN.Click += new System.EventHandler(this.deleteConfigBTN_Click);
            // 
            // idTB
            // 
            this.idTB.Location = new System.Drawing.Point(77, 43);
            this.idTB.Name = "idTB";
            this.idTB.Size = new System.Drawing.Size(100, 20);
            this.idTB.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Id:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.getConfigBTN);
            this.groupBox2.Controls.Add(this.idTB);
            this.groupBox2.Controls.Add(this.deleteConfigBTN);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 200);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.getDistGroupsBTN);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.idGroupTB);
            this.groupBox3.Controls.Add(this.deleteGroupBTN);
            this.groupBox3.Location = new System.Drawing.Point(201, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 200);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Id:";
            // 
            // idGroupTB
            // 
            this.idGroupTB.Location = new System.Drawing.Point(77, 43);
            this.idGroupTB.Name = "idGroupTB";
            this.idGroupTB.Size = new System.Drawing.Size(100, 20);
            this.idGroupTB.TabIndex = 9;
            // 
            // deleteGroupBTN
            // 
            this.deleteGroupBTN.Location = new System.Drawing.Point(94, 97);
            this.deleteGroupBTN.Name = "deleteGroupBTN";
            this.deleteGroupBTN.Size = new System.Drawing.Size(92, 48);
            this.deleteGroupBTN.TabIndex = 8;
            this.deleteGroupBTN.Text = "Delete Dist. Config";
            this.deleteGroupBTN.UseVisualStyleBackColor = true;
            this.deleteGroupBTN.Click += new System.EventHandler(this.deleteGroupBTN_Click);
            // 
            // InVenueConfigurationUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "InVenueConfigurationUC";
            this.Size = new System.Drawing.Size(405, 216);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button getConfigBTN;
        private System.Windows.Forms.Button getDistGroupsBTN;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button deleteConfigBTN;
        private System.Windows.Forms.TextBox idTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idGroupTB;
        private System.Windows.Forms.Button deleteGroupBTN;
    }
}
