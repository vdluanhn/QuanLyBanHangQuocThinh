namespace AccountingLiabilities
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnChoose = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportDonDi = new System.Windows.Forms.Button();
            this.btnImportDS = new System.Windows.Forms.Button();
            this.dtPickerDS = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDonHOanThucTe = new System.Windows.Forms.Button();
            this.lbTenFile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbPartner = new System.Windows.Forms.ComboBox();
            this.lbKQ = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChoose.Location = new System.Drawing.Point(26, 16);
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
            this.cbSheet.Location = new System.Drawing.Point(110, 50);
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
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT});
            this.dataGridView1.Location = new System.Drawing.Point(24, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(764, 315);
            this.dataGridView1.TabIndex = 2;
            // 
            // STT
            // 
            this.STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 70;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn sheet";
            // 
            // btnImportDonDi
            // 
            this.btnImportDonDi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImportDonDi.Location = new System.Drawing.Point(111, 419);
            this.btnImportDonDi.Name = "btnImportDonDi";
            this.btnImportDonDi.Size = new System.Drawing.Size(182, 23);
            this.btnImportDonDi.TabIndex = 0;
            this.btnImportDonDi.Text = "Nhập đơn đi";
            this.btnImportDonDi.UseVisualStyleBackColor = true;
            this.btnImportDonDi.Click += new System.EventHandler(this.btnImportDonDi_Click);
            // 
            // btnImportDS
            // 
            this.btnImportDS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImportDS.Location = new System.Drawing.Point(309, 419);
            this.btnImportDS.Name = "btnImportDS";
            this.btnImportDS.Size = new System.Drawing.Size(182, 23);
            this.btnImportDS.TabIndex = 0;
            this.btnImportDS.Text = "Nhập đối soát bên vận chuyển";
            this.btnImportDS.UseVisualStyleBackColor = true;
            this.btnImportDS.Click += new System.EventHandler(this.btnImportDS_Click);
            // 
            // dtPickerDS
            // 
            this.dtPickerDS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtPickerDS.CustomFormat = "dd/MM/yyyy";
            this.dtPickerDS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerDS.Location = new System.Drawing.Point(524, 17);
            this.dtPickerDS.Name = "dtPickerDS";
            this.dtPickerDS.Size = new System.Drawing.Size(254, 20);
            this.dtPickerDS.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn ngày đối soát";
            // 
            // btnDonHOanThucTe
            // 
            this.btnDonHOanThucTe.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDonHOanThucTe.Location = new System.Drawing.Point(507, 419);
            this.btnDonHOanThucTe.Name = "btnDonHOanThucTe";
            this.btnDonHOanThucTe.Size = new System.Drawing.Size(182, 23);
            this.btnDonHOanThucTe.TabIndex = 0;
            this.btnDonHOanThucTe.Text = "Nhập đơn hoàn thực tế";
            this.btnDonHOanThucTe.UseVisualStyleBackColor = true;
            this.btnDonHOanThucTe.Click += new System.EventHandler(this.btnDonHOanThucTe_Click);
            // 
            // lbTenFile
            // 
            this.lbTenFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTenFile.AutoSize = true;
            this.lbTenFile.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lbTenFile.Location = new System.Drawing.Point(107, 21);
            this.lbTenFile.Name = "lbTenFile";
            this.lbTenFile.Size = new System.Drawing.Size(42, 13);
            this.lbTenFile.TabIndex = 3;
            this.lbTenFile.Text = "Ten file";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên đối tác đối soát";
            // 
            // cbbPartner
            // 
            this.cbbPartner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbbPartner.FormattingEnabled = true;
            this.cbbPartner.Items.AddRange(new object[] {
            "GHTK",
            "Thailan"});
            this.cbbPartner.Location = new System.Drawing.Point(524, 50);
            this.cbbPartner.Name = "cbbPartner";
            this.cbbPartner.Size = new System.Drawing.Size(254, 21);
            this.cbbPartner.TabIndex = 6;
            this.cbbPartner.Text = "GHTK";
            // 
            // lbKQ
            // 
            this.lbKQ.AutoSize = true;
            this.lbKQ.BackColor = System.Drawing.Color.Transparent;
            this.lbKQ.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbKQ.Location = new System.Drawing.Point(23, 82);
            this.lbKQ.Name = "lbKQ";
            this.lbKQ.Size = new System.Drawing.Size(35, 13);
            this.lbKQ.TabIndex = 7;
            this.lbKQ.Text = "label4";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbKQ);
            this.Controls.Add(this.cbbPartner);
            this.Controls.Add(this.dtPickerDS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTenFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbSheet);
            this.Controls.Add(this.btnDonHOanThucTe);
            this.Controls.Add(this.btnImportDS);
            this.Controls.Add(this.btnImportDonDi);
            this.Controls.Add(this.btnChoose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thông tin đối soát";
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
        private System.Windows.Forms.Button btnDonHOanThucTe;
        private System.Windows.Forms.Label lbTenFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbPartner;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.Label lbKQ;
    }
}

