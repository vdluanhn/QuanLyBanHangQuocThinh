namespace AccountingLiabilities
{
    partial class FrmCheckDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckDon));
            this.cbCheckCondition = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnImportData = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbPartner = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaDonHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.datePickStart = new System.Windows.Forms.DateTimePicker();
            this.lbKQTK = new System.Windows.Forms.Label();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mã_đơn_hàng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Số_tiền = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiền_thu_hộ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Số_tiền_chênh_lêch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phí_hoàn_trả = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mã_sub_đơn_hoàn_thực_tế = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tên_khách_hàng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trạng_thái_đơn_hàng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trạng_thái_hoàn_trả = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trạng_thái_đối_soát = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngày_đối_soát = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Đối_tác = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mô_tả = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQLDanhMuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCheckCondition
            // 
            this.cbCheckCondition.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbCheckCondition.FormattingEnabled = true;
            this.cbCheckCondition.Items.AddRange(new object[] {
            "Tất cả",
            "Đơn đã hoàn thành",
            "Đơn đã hoàn thành có lệch tiền",
            "Đơn đã hoàn thành không lệch tiền",
            "Đơn hoàn trả",
            "Đơn hoàn trả và có phí thu hộ",
            "Đơn hoàn trả và không phí thu hộ",
            "Đơn chưa hoàn trả thực tế",
            "Đơn đã hoàn trả thực tế",
            "Đơn hàng chưa đối soát"});
            this.cbCheckCondition.Location = new System.Drawing.Point(134, 19);
            this.cbCheckCondition.Name = "cbCheckCondition";
            this.cbCheckCondition.Size = new System.Drawing.Size(332, 21);
            this.cbCheckCondition.TabIndex = 0;
            this.cbCheckCondition.Text = "Tất cả";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Location = new System.Drawing.Point(265, 93);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
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
            this.STT,
            this.Mã_đơn_hàng,
            this.Số_tiền,
            this.Tiền_thu_hộ,
            this.Số_tiền_chênh_lêch,
            this.Phí_hoàn_trả,
            this.Mã_sub_đơn_hoàn_thực_tế,
            this.Tên_khách_hàng,
            this.Trạng_thái_đơn_hàng,
            this.Trạng_thái_hoàn_trả,
            this.Trạng_thái_đối_soát,
            this.Ngày_đối_soát,
            this.Đối_tác,
            this.Mô_tả});
            this.dataGridView1.Location = new System.Drawing.Point(13, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1031, 299);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnImportData
            // 
            this.btnImportData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnImportData.Location = new System.Drawing.Point(404, 93);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(115, 23);
            this.btnImportData.TabIndex = 1;
            this.btnImportData.Text = "Nhập dữ liệu";
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExport.Location = new System.Drawing.Point(543, 93);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(115, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbbPartner);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMaDonHang);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.datePickerEnd);
            this.groupBox1.Controls.Add(this.datePickStart);
            this.groupBox1.Controls.Add(this.cbCheckCondition);
            this.groupBox1.Location = new System.Drawing.Point(15, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 81);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // cbbPartner
            // 
            this.cbbPartner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbbPartner.FormattingEnabled = true;
            this.cbbPartner.Items.AddRange(new object[] {
            "Tất cả",
            "GHTK",
            "Thailan"});
            this.cbbPartner.Location = new System.Drawing.Point(656, 19);
            this.cbbPartner.Name = "cbbPartner";
            this.cbbPartner.Size = new System.Drawing.Size(332, 21);
            this.cbbPartner.TabIndex = 8;
            this.cbbPartner.Text = "GHTK";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(537, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tên đối tác đối soát";
            // 
            // txtMaDonHang
            // 
            this.txtMaDonHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaDonHang.Location = new System.Drawing.Point(656, 51);
            this.txtMaDonHang.Name = "txtMaDonHang";
            this.txtMaDonHang.Size = new System.Drawing.Size(332, 20);
            this.txtMaDonHang.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Từ";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Trạng thái đối soát";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã đơn hàng";
            this.label5.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ngày đối soát";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.datePickerEnd.CustomFormat = "dd/MM/yyyy";
            this.datePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerEnd.Location = new System.Drawing.Point(334, 51);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(132, 20);
            this.datePickerEnd.TabIndex = 2;
            // 
            // datePickStart
            // 
            this.datePickStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.datePickStart.CustomFormat = "dd/MM/yyyy";
            this.datePickStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickStart.Location = new System.Drawing.Point(134, 51);
            this.datePickStart.Name = "datePickStart";
            this.datePickStart.Size = new System.Drawing.Size(132, 20);
            this.datePickStart.TabIndex = 2;
            // 
            // lbKQTK
            // 
            this.lbKQTK.AutoSize = true;
            this.lbKQTK.BackColor = System.Drawing.Color.Transparent;
            this.lbKQTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKQTK.ForeColor = System.Drawing.Color.Crimson;
            this.lbKQTK.Location = new System.Drawing.Point(17, 120);
            this.lbKQTK.Name = "lbKQTK";
            this.lbKQTK.Size = new System.Drawing.Size(0, 13);
            this.lbKQTK.TabIndex = 4;
            // 
            // STT
            // 
            this.STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Format = "#,#";
            this.STT.DefaultCellStyle = dataGridViewCellStyle2;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 70;
            // 
            // Mã_đơn_hàng
            // 
            this.Mã_đơn_hàng.DataPropertyName = "Mã_đơn_hàng";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mã_đơn_hàng.DefaultCellStyle = dataGridViewCellStyle3;
            this.Mã_đơn_hàng.FillWeight = 137.7333F;
            this.Mã_đơn_hàng.HeaderText = "Mã đơn hàng";
            this.Mã_đơn_hàng.Name = "Mã_đơn_hàng";
            // 
            // Số_tiền
            // 
            this.Số_tiền.DataPropertyName = "Số_tiền";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.Số_tiền.DefaultCellStyle = dataGridViewCellStyle4;
            this.Số_tiền.FillWeight = 44.53376F;
            this.Số_tiền.HeaderText = "Số tiền";
            this.Số_tiền.Name = "Số_tiền";
            // 
            // Tiền_thu_hộ
            // 
            this.Tiền_thu_hộ.DataPropertyName = "Tiền_thu_hộ";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.Tiền_thu_hộ.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tiền_thu_hộ.FillWeight = 44.53376F;
            this.Tiền_thu_hộ.HeaderText = "Tiền thu hộ";
            this.Tiền_thu_hộ.Name = "Tiền_thu_hộ";
            // 
            // Số_tiền_chênh_lêch
            // 
            this.Số_tiền_chênh_lêch.DataPropertyName = "Số_tiền_chênh_lêch";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.Số_tiền_chênh_lêch.DefaultCellStyle = dataGridViewCellStyle6;
            this.Số_tiền_chênh_lêch.FillWeight = 44.53376F;
            this.Số_tiền_chênh_lêch.HeaderText = "Số tiền chênh lệch";
            this.Số_tiền_chênh_lêch.Name = "Số_tiền_chênh_lêch";
            // 
            // Phí_hoàn_trả
            // 
            this.Phí_hoàn_trả.DataPropertyName = "Phí_hoàn_trả";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.Phí_hoàn_trả.DefaultCellStyle = dataGridViewCellStyle7;
            this.Phí_hoàn_trả.FillWeight = 44.53376F;
            this.Phí_hoàn_trả.HeaderText = "Phí hoàn trả";
            this.Phí_hoàn_trả.Name = "Phí_hoàn_trả";
            // 
            // Mã_sub_đơn_hoàn_thực_tế
            // 
            this.Mã_sub_đơn_hoàn_thực_tế.DataPropertyName = "Mã_sub_đơn_hoàn_thực_tế";
            this.Mã_sub_đơn_hoàn_thực_tế.FillWeight = 44.53376F;
            this.Mã_sub_đơn_hoàn_thực_tế.HeaderText = "Mã đơn hoàn thực tế";
            this.Mã_sub_đơn_hoàn_thực_tế.Name = "Mã_sub_đơn_hoàn_thực_tế";
            // 
            // Tên_khách_hàng
            // 
            this.Tên_khách_hàng.DataPropertyName = "Tên_khách_hàng";
            this.Tên_khách_hàng.HeaderText = "Tên khách hàng";
            this.Tên_khách_hàng.Name = "Tên_khách_hàng";
            this.Tên_khách_hàng.Visible = false;
            // 
            // Trạng_thái_đơn_hàng
            // 
            this.Trạng_thái_đơn_hàng.DataPropertyName = "Trạng_thái_đơn_hàng";
            this.Trạng_thái_đơn_hàng.FillWeight = 44.53376F;
            this.Trạng_thái_đơn_hàng.HeaderText = "Trạng thái đơn hàng";
            this.Trạng_thái_đơn_hàng.Name = "Trạng_thái_đơn_hàng";
            // 
            // Trạng_thái_hoàn_trả
            // 
            this.Trạng_thái_hoàn_trả.DataPropertyName = "Trạng_thái_hoàn_trả";
            this.Trạng_thái_hoàn_trả.FillWeight = 44.53376F;
            this.Trạng_thái_hoàn_trả.HeaderText = "Trạng thái hoàn trả";
            this.Trạng_thái_hoàn_trả.Name = "Trạng_thái_hoàn_trả";
            // 
            // Trạng_thái_đối_soát
            // 
            this.Trạng_thái_đối_soát.DataPropertyName = "Trạng_thái_đối_soát";
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Purple;
            this.Trạng_thái_đối_soát.DefaultCellStyle = dataGridViewCellStyle8;
            this.Trạng_thái_đối_soát.FillWeight = 44.53376F;
            this.Trạng_thái_đối_soát.HeaderText = "Trạng thái đối soát";
            this.Trạng_thái_đối_soát.Name = "Trạng_thái_đối_soát";
            // 
            // Ngày_đối_soát
            // 
            this.Ngày_đối_soát.DataPropertyName = "Ngày_đối_soát";
            this.Ngày_đối_soát.FillWeight = 44.53376F;
            this.Ngày_đối_soát.HeaderText = "Ngày đối soát";
            this.Ngày_đối_soát.Name = "Ngày_đối_soát";
            // 
            // Đối_tác
            // 
            this.Đối_tác.DataPropertyName = "Đối_tác";
            this.Đối_tác.FillWeight = 44.53376F;
            this.Đối_tác.HeaderText = "Đối tác";
            this.Đối_tác.Name = "Đối_tác";
            // 
            // Mô_tả
            // 
            this.Mô_tả.DataPropertyName = "Mô_tả";
            this.Mô_tả.HeaderText = "Mô tả";
            this.Mô_tả.Name = "Mô_tả";
            this.Mô_tả.Visible = false;
            // 
            // btnQLDanhMuc
            // 
            this.btnQLDanhMuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQLDanhMuc.Location = new System.Drawing.Point(676, 93);
            this.btnQLDanhMuc.Name = "btnQLDanhMuc";
            this.btnQLDanhMuc.Size = new System.Drawing.Size(115, 23);
            this.btnQLDanhMuc.TabIndex = 1;
            this.btnQLDanhMuc.Text = "QL danh mục đơn";
            this.btnQLDanhMuc.UseVisualStyleBackColor = true;
            this.btnQLDanhMuc.Click += new System.EventHandler(this.btnQLDanhMuc_Click);
            // 
            // FrmCheckDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1056, 450);
            this.Controls.Add(this.lbKQTK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnImportData);
            this.Controls.Add(this.btnQLDanhMuc);
            this.Controls.Add(this.btnExport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCheckDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đối soát vận đơn";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCheckCondition;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
        private System.Windows.Forms.DateTimePicker datePickStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaDonHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbKQTK;
        private System.Windows.Forms.ComboBox cbbPartner;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mã_đơn_hàng;
        private System.Windows.Forms.DataGridViewTextBoxColumn Số_tiền;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiền_thu_hộ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Số_tiền_chênh_lêch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phí_hoàn_trả;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mã_sub_đơn_hoàn_thực_tế;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tên_khách_hàng;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trạng_thái_đơn_hàng;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trạng_thái_hoàn_trả;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trạng_thái_đối_soát;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngày_đối_soát;
        private System.Windows.Forms.DataGridViewTextBoxColumn Đối_tác;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mô_tả;
        private System.Windows.Forms.Button btnQLDanhMuc;
    }
}