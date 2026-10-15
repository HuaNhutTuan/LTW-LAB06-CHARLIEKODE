namespace Lab06
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblHeaderSubtitle = new Label();
            lblHeaderTitle = new Label();
            grpThongTin = new GroupBox();
            pnlButtons = new FlowLayoutPanel();
            btnThem = new Button();
            btnChinhSua = new Button();
            btnCapNhat = new Button();
            btnHuy = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnXuatFile = new Button();
            pnlHinhAnh = new Panel();
            lblAnhSP = new Label();
            picHinhAnh = new PictureBox();
            btnChonAnh = new Button();
            chkConKinhDoanh = new CheckBox();
            dtpNgayNhap = new DateTimePicker();
            lblNgayNhap = new Label();
            numSoLuong = new NumericUpDown();
            lblSoLuong = new Label();
            numDonGia = new NumericUpDown();
            lblDonGia = new Label();
            cboLoaiSP = new ComboBox();
            lblLoaiSP = new Label();
            txtTenSP = new TextBox();
            lblTenSP = new Label();
            txtMaSP = new TextBox();
            lblMaSP = new Label();
            grpDanhSach = new GroupBox();
            dgvSanPham = new DataGridView();
            pnlSearch = new Panel();
            btnBoLoc = new Button();
            cboLocLoai = new ComboBox();
            lblLocLoai = new Label();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            lblTongSanPham = new ToolStripStatusLabel();
            lblTongGiaTriTonKho = new ToolStripStatusLabel();
            lblDongHo = new ToolStripStatusLabel();
            timerDongHo = new System.Windows.Forms.Timer(components);
            bindingSource1 = new BindingSource(components);
            pnlHeader.SuspendLayout();
            grpThongTin.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlHinhAnh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            pnlSearch.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Control;
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1220, 65);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9F);
            lblHeaderSubtitle.ForeColor = Color.DimGray;
            lblHeaderSubtitle.Location = new Point(18, 36);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(0, 20);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Click += lblHeaderSubtitle_Click;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = SystemColors.ControlText;
            lblHeaderTitle.Location = new Point(13, 9);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(652, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "HỆ THỐNG QUẢN LÝ SẢN PHẨM (PRODUCT MANAGER)";
            lblHeaderTitle.Click += lblHeaderTitle_Click;
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(pnlButtons);
            grpThongTin.Controls.Add(pnlHinhAnh);
            grpThongTin.Controls.Add(chkConKinhDoanh);
            grpThongTin.Controls.Add(dtpNgayNhap);
            grpThongTin.Controls.Add(lblNgayNhap);
            grpThongTin.Controls.Add(numSoLuong);
            grpThongTin.Controls.Add(lblSoLuong);
            grpThongTin.Controls.Add(numDonGia);
            grpThongTin.Controls.Add(lblDonGia);
            grpThongTin.Controls.Add(cboLoaiSP);
            grpThongTin.Controls.Add(lblLoaiSP);
            grpThongTin.Controls.Add(txtTenSP);
            grpThongTin.Controls.Add(lblTenSP);
            grpThongTin.Controls.Add(txtMaSP);
            grpThongTin.Controls.Add(lblMaSP);
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            grpThongTin.ForeColor = SystemColors.ControlText;
            grpThongTin.Location = new Point(0, 65);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(1220, 245);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "THÔNG TIN CHI TIẾT SẢN PHẨM";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnThem);
            pnlButtons.Controls.Add(btnChinhSua);
            pnlButtons.Controls.Add(btnCapNhat);
            pnlButtons.Controls.Add(btnHuy);
            pnlButtons.Controls.Add(btnXoa);
            pnlButtons.Controls.Add(btnLamMoi);
            pnlButtons.Controls.Add(btnXuatFile);
            pnlButtons.Location = new Point(18, 110);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(860, 52);
            pnlButtons.TabIndex = 13;
            // 
            // btnThem
            // 
            btnThem.Cursor = Cursors.Hand;
            btnThem.Font = new Font("Segoe UI", 9F);
            btnThem.Location = new Point(3, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(95, 36);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnChinhSua
            // 
            btnChinhSua.Cursor = Cursors.Hand;
            btnChinhSua.Font = new Font("Segoe UI", 9F);
            btnChinhSua.Location = new Point(104, 3);
            btnChinhSua.Name = "btnChinhSua";
            btnChinhSua.Size = new Size(95, 36);
            btnChinhSua.TabIndex = 1;
            btnChinhSua.Text = "Sửa";
            btnChinhSua.UseVisualStyleBackColor = true;
            btnChinhSua.Click += btnChinhSua_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.Cursor = Cursors.Hand;
            btnCapNhat.Enabled = false;
            btnCapNhat.Font = new Font("Segoe UI", 9F);
            btnCapNhat.Location = new Point(205, 3);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(95, 36);
            btnCapNhat.TabIndex = 2;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnHuy
            // 
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.Enabled = false;
            btnHuy.Font = new Font("Segoe UI", 9F);
            btnHuy.Location = new Point(306, 3);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(85, 36);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnXoa
            // 
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.Font = new Font("Segoe UI", 9F);
            btnXoa.Location = new Point(397, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(85, 36);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.Font = new Font("Segoe UI", 9F);
            btnLamMoi.Location = new Point(488, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(95, 36);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXuatFile
            // 
            btnXuatFile.Cursor = Cursors.Hand;
            btnXuatFile.Font = new Font("Segoe UI", 9F);
            btnXuatFile.Location = new Point(589, 3);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(100, 36);
            btnXuatFile.TabIndex = 6;
            btnXuatFile.Text = "Xuất file";
            btnXuatFile.UseVisualStyleBackColor = true;
            btnXuatFile.Click += btnXuatFile_Click;
            // 
            // pnlHinhAnh
            // 
            pnlHinhAnh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            pnlHinhAnh.Controls.Add(lblAnhSP);
            pnlHinhAnh.Controls.Add(picHinhAnh);
            pnlHinhAnh.Controls.Add(btnChonAnh);
            pnlHinhAnh.Location = new Point(888, 18);
            pnlHinhAnh.Name = "pnlHinhAnh";
            pnlHinhAnh.Size = new Size(320, 218);
            pnlHinhAnh.TabIndex = 14;
            // 
            // lblAnhSP
            // 
            lblAnhSP.AutoSize = true;
            lblAnhSP.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblAnhSP.ForeColor = Color.Gray;
            lblAnhSP.Location = new Point(6, 4);
            lblAnhSP.Name = "lblAnhSP";
            lblAnhSP.Size = new Size(145, 20);
            lblAnhSP.TabIndex = 0;
            lblAnhSP.Text = "Hình ảnh minh họa:";
            // 
            // picHinhAnh
            // 
            picHinhAnh.BackColor = Color.White;
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            picHinhAnh.Location = new Point(8, 22);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(302, 155);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.TabIndex = 1;
            picHinhAnh.TabStop = false;
            picHinhAnh.Click += picHinhAnh_Click_1;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Cursor = Cursors.Hand;
            btnChonAnh.Enabled = false;
            btnChonAnh.Font = new Font("Segoe UI", 9F);
            btnChonAnh.Location = new Point(8, 182);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(302, 29);
            btnChonAnh.TabIndex = 2;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // chkConKinhDoanh
            // 
            chkConKinhDoanh.AutoSize = true;
            chkConKinhDoanh.Checked = true;
            chkConKinhDoanh.CheckState = CheckState.Checked;
            chkConKinhDoanh.Enabled = false;
            chkConKinhDoanh.Font = new Font("Segoe UI", 9.5F);
            chkConKinhDoanh.ForeColor = SystemColors.ControlText;
            chkConKinhDoanh.Location = new Point(680, 68);
            chkConKinhDoanh.Name = "chkConKinhDoanh";
            chkConKinhDoanh.Size = new Size(151, 25);
            chkConKinhDoanh.TabIndex = 12;
            chkConKinhDoanh.Text = "Đang kinh doanh";
            chkConKinhDoanh.UseVisualStyleBackColor = true;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhap.Enabled = false;
            dtpNgayNhap.Font = new Font("Segoe UI", 9.5F);
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.Location = new Point(540, 66);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(125, 29);
            dtpNgayNhap.TabIndex = 11;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Font = new Font("Segoe UI", 9.25F);
            lblNgayNhap.ForeColor = Color.FromArgb(40, 40, 40);
            lblNgayNhap.Location = new Point(460, 70);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(89, 21);
            lblNgayNhap.TabIndex = 10;
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // numSoLuong
            // 
            numSoLuong.Enabled = false;
            numSoLuong.Font = new Font("Segoe UI", 9.5F);
            numSoLuong.Location = new Point(335, 66);
            numSoLuong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(110, 29);
            numSoLuong.TabIndex = 9;
            numSoLuong.TextAlign = HorizontalAlignment.Right;
            numSoLuong.ThousandsSeparator = true;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI", 9.25F);
            lblSoLuong.ForeColor = Color.FromArgb(40, 40, 40);
            lblSoLuong.Location = new Point(270, 70);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(76, 21);
            lblSoLuong.TabIndex = 8;
            lblSoLuong.Text = "Số lượng:";
            // 
            // numDonGia
            // 
            numDonGia.Enabled = false;
            numDonGia.Font = new Font("Segoe UI", 9.5F);
            numDonGia.Location = new Point(92, 66);
            numDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(160, 29);
            numDonGia.TabIndex = 7;
            numDonGia.TextAlign = HorizontalAlignment.Right;
            numDonGia.ThousandsSeparator = true;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Font = new Font("Segoe UI", 9.25F);
            lblDonGia.ForeColor = Color.FromArgb(40, 40, 40);
            lblDonGia.Location = new Point(18, 70);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(68, 21);
            lblDonGia.TabIndex = 6;
            lblDonGia.Text = "Đơn giá:";
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.Enabled = false;
            cboLoaiSP.Font = new Font("Segoe UI", 9.5F);
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Items.AddRange(new object[] { "Điện thoại", "Laptop", "Máy tính bảng", "Phụ kiện", "Linh kiện", "Thiết bị mạng", "Khác" });
            cboLoaiSP.Location = new Point(678, 26);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(180, 29);
            cboLoaiSP.TabIndex = 5;
            // 
            // lblLoaiSP
            // 
            lblLoaiSP.AutoSize = true;
            lblLoaiSP.Font = new Font("Segoe UI", 9.25F);
            lblLoaiSP.ForeColor = Color.FromArgb(40, 40, 40);
            lblLoaiSP.Location = new Point(615, 30);
            lblLoaiSP.Name = "lblLoaiSP";
            lblLoaiSP.Size = new Size(64, 21);
            lblLoaiSP.TabIndex = 4;
            lblLoaiSP.Text = "Loại SP:";
            // 
            // txtTenSP
            // 
            txtTenSP.Font = new Font("Segoe UI", 9.5F);
            txtTenSP.Location = new Point(335, 26);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.PlaceholderText = "VD: iPhone 15 Pro Max...";
            txtTenSP.ReadOnly = true;
            txtTenSP.Size = new Size(260, 29);
            txtTenSP.TabIndex = 3;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Segoe UI", 9.25F);
            lblTenSP.ForeColor = Color.FromArgb(40, 40, 40);
            lblTenSP.Location = new Point(270, 30);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(58, 21);
            lblTenSP.TabIndex = 2;
            lblTenSP.Text = "Tên SP:";
            // 
            // txtMaSP
            // 
            txtMaSP.Font = new Font("Segoe UI", 9.5F);
            txtMaSP.Location = new Point(92, 26);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.PlaceholderText = "VD: SP01";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(160, 29);
            txtMaSP.TabIndex = 1;
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Font = new Font("Segoe UI", 9.25F);
            lblMaSP.ForeColor = Color.FromArgb(40, 40, 40);
            lblMaSP.Location = new Point(18, 30);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(57, 21);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã SP:";
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(dgvSanPham);
            grpDanhSach.Controls.Add(pnlSearch);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            grpDanhSach.ForeColor = SystemColors.ControlText;
            grpDanhSach.Location = new Point(0, 310);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(1220, 363);
            grpDanhSach.TabIndex = 2;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "DANH SÁCH SẢN PHẨM TRONG HỆ THỐNG";
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.AllowUserToResizeRows = false;
            dgvSanPham.BackgroundColor = Color.White;
            dgvSanPham.BorderStyle = BorderStyle.Fixed3D;
            dgvSanPham.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSanPham.ColumnHeadersHeight = 35;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.GridColor = SystemColors.ControlLight;
            dgvSanPham.Location = new Point(3, 69);
            dgvSanPham.MultiSelect = false;
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.RowHeadersWidth = 30;
            dgvSanPham.RowTemplate.Height = 28;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(1214, 291);
            dgvSanPham.TabIndex = 1;
            dgvSanPham.SelectionChanged += dgvSanPham_SelectionChanged;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(btnBoLoc);
            pnlSearch.Controls.Add(cboLocLoai);
            pnlSearch.Controls.Add(lblLocLoai);
            pnlSearch.Controls.Add(txtTimKiem);
            pnlSearch.Controls.Add(lblTimKiem);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(3, 25);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1214, 44);
            pnlSearch.TabIndex = 0;
            // 
            // btnBoLoc
            // 
            btnBoLoc.Cursor = Cursors.Hand;
            btnBoLoc.Font = new Font("Segoe UI", 8.75F);
            btnBoLoc.Location = new Point(780, 8);
            btnBoLoc.Name = "btnBoLoc";
            btnBoLoc.Size = new Size(100, 28);
            btnBoLoc.TabIndex = 4;
            btnBoLoc.Text = "Bỏ lọc";
            btnBoLoc.UseVisualStyleBackColor = true;
            btnBoLoc.Click += btnBoLoc_Click;
            // 
            // cboLocLoai
            // 
            cboLocLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoai.Font = new Font("Segoe UI", 9.5F);
            cboLocLoai.FormattingEnabled = true;
            cboLocLoai.Items.AddRange(new object[] { "-- Tất cả loại sản phẩm --", "Điện thoại", "Laptop", "Máy tính bảng", "Phụ kiện", "Linh kiện", "Thiết bị mạng", "Khác" });
            cboLocLoai.Location = new Point(578, 10);
            cboLocLoai.Name = "cboLocLoai";
            cboLocLoai.Size = new Size(190, 29);
            cboLocLoai.TabIndex = 3;
            cboLocLoai.SelectedIndexChanged += cboLocLoai_SelectedIndexChanged;
            // 
            // lblLocLoai
            // 
            lblLocLoai.AutoSize = true;
            lblLocLoai.Font = new Font("Segoe UI", 9.25F);
            lblLocLoai.ForeColor = Color.FromArgb(40, 40, 40);
            lblLocLoai.Location = new Point(480, 13);
            lblLocLoai.Name = "lblLocLoai";
            lblLocLoai.Size = new Size(99, 21);
            lblLocLoai.TabIndex = 2;
            lblLocLoai.Text = "Phân loại SP:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 9.5F);
            txtTimKiem.Location = new Point(134, 10);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Gõ tên hoặc mã sản phẩm để tìm tức thời...";
            txtTimKiem.Size = new Size(320, 29);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 9.25F);
            lblTimKiem.ForeColor = Color.FromArgb(40, 40, 40);
            lblTimKiem.Location = new Point(15, 13);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(125, 21);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm nhanh:";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(240, 243, 246);
            statusStrip1.Font = new Font("Segoe UI", 9.25F);
            statusStrip1.ImageScalingSize = new Size(18, 18);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTrangThai, lblTongSanPham, lblTongGiaTriTonKho, lblDongHo });
            statusStrip1.Location = new Point(0, 673);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1220, 31);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTrangThai
            // 
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(705, 25);
            lblTrangThai.Spring = true;
            lblTrangThai.Text = "Sẵn sàng";
            lblTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            lblTrangThai.Click += lblTrangThai_Click;
            // 
            // lblTongSanPham
            // 
            lblTongSanPham.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblTongSanPham.BorderStyle = Border3DStyle.Etched;
            lblTongSanPham.Font = new Font("Segoe UI", 9F);
            lblTongSanPham.Name = "lblTongSanPham";
            lblTongSanPham.Padding = new Padding(4, 0, 4, 0);
            lblTongSanPham.Size = new Size(216, 25);
            lblTongSanPham.Text = "Số mặt hàng: 0 | SL tồn kho: 0";
            // 
            // lblTongGiaTriTonKho
            // 
            lblTongGiaTriTonKho.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblTongGiaTriTonKho.BorderStyle = Border3DStyle.Etched;
            lblTongGiaTriTonKho.Font = new Font("Segoe UI", 9F);
            lblTongGiaTriTonKho.Name = "lblTongGiaTriTonKho";
            lblTongGiaTriTonKho.Padding = new Padding(6, 0, 6, 0);
            lblTongGiaTriTonKho.Size = new Size(163, 25);
            lblTongGiaTriTonKho.Text = "Tổng tồn kho: 0 VNĐ";
            // 
            // lblDongHo
            // 
            lblDongHo.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblDongHo.BorderStyle = Border3DStyle.Etched;
            lblDongHo.Name = "lblDongHo";
            lblDongHo.Padding = new Padding(4, 0, 4, 0);
            lblDongHo.Size = new Size(82, 25);
            lblDongHo.Text = "00:00:00";
            // 
            // timerDongHo
            // 
            timerDongHo.Enabled = true;
            timerDongHo.Interval = 1000;
            timerDongHo.Tick += timerDongHo_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1220, 704);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            Controls.Add(pnlHeader);
            Controls.Add(statusStrip1);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(1020, 620);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Sản Phẩm - ProductManager (Nhóm 3)";
            Load += Form1_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            pnlButtons.ResumeLayout(false);
            pnlHinhAnh.ResumeLayout(false);
            pnlHinhAnh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.CheckBox chkConKinhDoanh;

        private System.Windows.Forms.Panel pnlHinhAnh;
        private System.Windows.Forms.Label lblAnhSP;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;

        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnChinhSua;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatFile;

        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLocLoai;
        private System.Windows.Forms.ComboBox cboLocLoai;
        private System.Windows.Forms.Button btnBoLoc;

        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayNhap;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colConKinhDoanh;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel lblTongSanPham;
        private System.Windows.Forms.ToolStripStatusLabel lblTongGiaTriTonKho;
        private System.Windows.Forms.ToolStripStatusLabel lblDongHo;

        private System.Windows.Forms.Timer timerDongHo;
        private BindingSource bindingSource1;
    }
}
