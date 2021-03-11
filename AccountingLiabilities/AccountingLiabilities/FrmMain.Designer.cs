﻿namespace AccountingLiabilities
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnChoose = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportDonDi = new System.Windows.Forms.Button();
            this.btnImportDS = new System.Windows.Forms.Button();
            this.dtPickerDS = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChoose.Location = new System.Drawing.Point(358, 14);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 0;
            this.btnChoose.Text = "Chọn file";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbSheet
            // 
            this.cbSheet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbSheet.FormattingEnabled = true;
            this.cbSheet.Location = new System.Drawing.Point(96, 14);
            this.cbSheet.Name = "cbSheet";
            this.cbSheet.Size = new System.Drawing.Size(256, 21);
            this.cbSheet.TabIndex = 1;
            this.cbSheet.SelectedIndexChanged += new System.EventHandler(this.cbSheet_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(764, 359);
            this.dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn sheet";
            // 
            // btnImportDonDi
            // 
            this.btnImportDonDi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImportDonDi.Location = new System.Drawing.Point(230, 419);
            this.btnImportDonDi.Name = "btnImportDonDi";
            this.btnImportDonDi.Size = new System.Drawing.Size(75, 23);
            this.btnImportDonDi.TabIndex = 0;
            this.btnImportDonDi.Text = "Nhập đơn đi";
            this.btnImportDonDi.UseVisualStyleBackColor = true;
            this.btnImportDonDi.Click += new System.EventHandler(this.btnImportDonDi_Click);
            // 
            // btnImportDS
            // 
            this.btnImportDS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImportDS.Location = new System.Drawing.Point(369, 419);
            this.btnImportDS.Name = "btnImportDS";
            this.btnImportDS.Size = new System.Drawing.Size(182, 23);
            this.btnImportDS.TabIndex = 0;
            this.btnImportDS.Text = "Nhập đối soát bên vận chuyển";
            this.btnImportDS.UseVisualStyleBackColor = true;
            this.btnImportDS.Click += new System.EventHandler(this.btnImportDS_Click);
            // 
            // dtPickerDS
            // 
            this.dtPickerDS.CustomFormat = "dd/MM/yyyy";
            this.dtPickerDS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerDS.Location = new System.Drawing.Point(603, 17);
            this.dtPickerDS.Name = "dtPickerDS";
            this.dtPickerDS.Size = new System.Drawing.Size(113, 20);
            this.dtPickerDS.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn ngày đối soát";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtPickerDS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbSheet);
            this.Controls.Add(this.btnImportDS);
            this.Controls.Add(this.btnImportDonDi);
            this.Controls.Add(this.btnChoose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbSheet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportDonDi;
        private System.Windows.Forms.Button btnImportDS;
        private System.Windows.Forms.DateTimePicker dtPickerDS;
        private System.Windows.Forms.Label label2;
    }
}
