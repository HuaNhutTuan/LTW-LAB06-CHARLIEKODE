using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Lab06.Models;
using Lab06.Services;

namespace Lab06
{

    public partial class Form1 : Form
    {

        private enum FormMode
        {
            View,
            Add,
            Edit
        }

        private FormMode _currentMode = FormMode.View;

        private string _duongDanAnhHienTai = string.Empty;

        private readonly BindingList<Product> _danhSachGoc = new BindingList<Product>();

        private readonly BindingSource _bindingSource = new BindingSource();

        private bool _isDataBinding = false;

        public Form1()
        {
            InitializeComponent();
        }

        #region Form Load & Khởi tạo

        private void Form1_Load(object sender, EventArgs e)
        {

            cboLoaiSP.SelectedIndex = 0;
            cboLocLoai.SelectedIndex = 0;

            KhoiTaoDuLieuMau();

            dgvSanPham.AutoGenerateColumns = false;
            KiemTraVaKhoiTaoCotDataGridView();

            _bindingSource.DataSource = _danhSachGoc;
            dgvSanPham.DataSource = _bindingSource;

            ThietLapTrangThaiForm(FormMode.View);

            if (_bindingSource.Count > 0)
            {
                dgvSanPham_SelectionChanged(sender, e);
            }

            CapNhatThongKeStatusStrip("Sẵn sàng | Đã nạp thành công 5 sản phẩm mẫu");

            timerDongHo_Tick(sender, e);
        }

        private void KhoiTaoDuLieuMau()
        {
            _danhSachGoc.Clear();
            List<Product> sampleData = SampleDataHelper.GetSampleProducts();
            foreach (var item in sampleData)
            {
                _danhSachGoc.Add(item);
            }
        }

        private void KiemTraVaKhoiTaoCotDataGridView()
        {
            if (dgvSanPham.Columns.Count > 0) return;

            colMaSP = new DataGridViewTextBoxColumn { DataPropertyName = "MaSP", HeaderText = "Mã SP", Width = 90 };
            colTenSP = new DataGridViewTextBoxColumn { DataPropertyName = "TenSP", HeaderText = "Tên Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            colLoaiSP = new DataGridViewTextBoxColumn { DataPropertyName = "LoaiSP", HeaderText = "Loại SP", Width = 120 };
            colDonGia = new DataGridViewTextBoxColumn { DataPropertyName = "DonGia", HeaderText = "Đơn Giá (VNĐ)", Width = 130 };
            colDonGia.DefaultCellStyle.Format = "N0";
            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            colSoLuong = new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "SL Tồn", Width = 90 };
            colSoLuong.DefaultCellStyle.Format = "N0";
            colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            colThanhTien = new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTien", HeaderText = "Thành Tiền (VNĐ)", Width = 140 };
            colThanhTien.DefaultCellStyle.Format = "N0";
            colThanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            colNgayNhap = new DataGridViewTextBoxColumn { DataPropertyName = "NgayNhap", HeaderText = "Ngày Nhập", Width = 110 };
            colNgayNhap.DefaultCellStyle.Format = "dd/MM/yyyy";
            colNgayNhap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            colConKinhDoanh = new DataGridViewCheckBoxColumn { DataPropertyName = "ConKinhDoanh", HeaderText = "Kinh Doanh", Width = 90 };

            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] {
                colMaSP, colTenSP, colLoaiSP, colDonGia, colSoLuong, colThanhTien, colNgayNhap, colConKinhDoanh
            });
        }

        #endregion

        #region Quản lý Luồng Trạng Thái Form (Form State Management)

        private void ThietLapTrangThaiForm(FormMode mode)
        {
            _currentMode = mode;

            switch (mode)
            {
                case FormMode.View:

                    txtMaSP.ReadOnly = true;
                    txtTenSP.ReadOnly = true;
                    cboLoaiSP.Enabled = false;
                    numDonGia.Enabled = false;
                    numSoLuong.Enabled = false;
                    dtpNgayNhap.Enabled = false;
                    chkConKinhDoanh.Enabled = false;
                    btnChonAnh.Enabled = false;

                    btnCapNhat.Enabled = false;
                    btnHuy.Enabled = false;

                    btnThem.Enabled = true;
                    btnChinhSua.Enabled = (_bindingSource.Current != null);
                    btnXoa.Enabled = (_bindingSource.Current != null);
                    btnLamMoi.Enabled = true;
                    btnXuatFile.Enabled = true;

                    dgvSanPham.Enabled = true;
                    pnlSearch.Enabled = true;
                    break;

                case FormMode.Add:

                    txtMaSP.ReadOnly = false;
                    txtTenSP.ReadOnly = false;
                    cboLoaiSP.Enabled = true;
                    numDonGia.Enabled = true;
                    numSoLuong.Enabled = true;
                    dtpNgayNhap.Enabled = true;
                    chkConKinhDoanh.Enabled = true;
                    btnChonAnh.Enabled = true;

                    btnCapNhat.Enabled = true;
                    btnHuy.Enabled = true;

                    btnThem.Enabled = false;
                    btnChinhSua.Enabled = false;
                    btnXoa.Enabled = false;

                    dgvSanPham.Enabled = false;
                    pnlSearch.Enabled = false;
                    break;

                case FormMode.Edit:

                    txtMaSP.ReadOnly = true;
                    txtTenSP.ReadOnly = false;
                    cboLoaiSP.Enabled = true;
                    numDonGia.Enabled = true;
                    numSoLuong.Enabled = true;
                    dtpNgayNhap.Enabled = true;
                    chkConKinhDoanh.Enabled = true;
                    btnChonAnh.Enabled = true;

                    btnCapNhat.Enabled = true;
                    btnHuy.Enabled = true;

                    btnThem.Enabled = false;
                    btnChinhSua.Enabled = false;
                    btnXoa.Enabled = false;

                    dgvSanPham.Enabled = false;
                    pnlSearch.Enabled = false;
                    break;
            }
        }

        #endregion

        #region Chuyên sâu NHÓM 3: StatusStrip Real-time & Thống kê tồn kho

        private void CapNhatThongKeStatusStrip(string? thongDiepTrangThai = null)
        {
            if (!string.IsNullOrEmpty(thongDiepTrangThai))
            {
                lblTrangThai.Text = thongDiepTrangThai;
            }
            int soMatHang = _bindingSource.Count;
            int tongSoLuongTon = 0;
            decimal tongGiaTriTonKho = 0;

            foreach (Product sp in _bindingSource)
            {
                tongSoLuongTon += sp.SoLuong;
                decimal thanhTien = sp.SoLuong * sp.DonGia;
                tongGiaTriTonKho += thanhTien;
            }

            lblTongSanPham.Text = $"{soMatHang} mặt hàng | SL: {tongSoLuongTon:N0}";
            lblTongGiaTriTonKho.Text = $"Tồn kho: {tongGiaTriTonKho:N0} VNĐ";
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            lblDongHo.Text = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        #endregion

        #region Xử lý các Nút Thao tác: Thêm SP, Chỉnh sửa, Cập nhật, Hủy, Xóa, Làm mới

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaTrangFormNhapLieu();
            ThietLapTrangThaiForm(FormMode.Add);
            txtMaSP.Focus();
            CapNhatThongKeStatusStrip("Đang ở chế độ Thêm mới SP. Nhập thông tin rồi bấm 'Cập nhật' để lưu");
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not Product spDangChon)
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng trong danh sách trước khi bấm 'Chỉnh sửa'!", "Chưa chọn sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThietLapTrangThaiForm(FormMode.Edit);
            txtTenSP.Focus();
            CapNhatThongKeStatusStrip($"Đang chỉnh sửa SP [{spDangChon.MaSP} - {spDangChon.TenSP}]. Chỉnh sửa xong bấm 'Cập nhật' để lưu lại");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (_currentMode == FormMode.Add)
            {

                string maSP = txtMaSP.Text.Trim();
                string tenSP = txtTenSP.Text.Trim();
                string loaiSP = cboLoaiSP.Text;
                decimal donGia = numDonGia.Value;
                int soLuong = (int)numSoLuong.Value;
                DateTime ngayNhap = dtpNgayNhap.Value;
                bool conKinhDoanh = chkConKinhDoanh.Checked;
                string duongDanAnh = _duongDanAnhHienTai;

                if (string.IsNullOrEmpty(maSP))
                {
                    MessageBox.Show("Vui lòng nhập Mã sản phẩm!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSP.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(tenSP))
                {
                    MessageBox.Show("Vui lòng nhập Tên sản phẩm!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenSP.Focus();
                    return;
                }

                foreach (var sp in _danhSachGoc)
                {
                    if (sp.MaSP.Equals(maSP, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Mã sản phẩm [{maSP}] đã tồn tại trong hệ thống. Vui lòng chọn mã khác!", "Trùng mã sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMaSP.Focus();
                        return;
                    }
                }

                if (donGia <= 0)
                {
                    MessageBox.Show("Đơn giá sản phẩm phải lớn hơn 0 VNĐ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numDonGia.Focus();
                    return;
                }

                Product spMoi = new Product(maSP, tenSP, loaiSP, donGia, soLuong, ngayNhap, conKinhDoanh, duongDanAnh);
                _danhSachGoc.Add(spMoi);

                if (_bindingSource.DataSource != _danhSachGoc)
                {
                    ResetBoLocTimKiem();
                }

                _bindingSource.Position = _danhSachGoc.IndexOf(spMoi);

                ThietLapTrangThaiForm(FormMode.View);

                CapNhatThongKeStatusStrip($"Đã thêm mới SP [{spMoi.MaSP} - {spMoi.TenSP}] thành công");
                MessageBox.Show($"Đã thêm mới sản phẩm [{spMoi.TenSP}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_currentMode == FormMode.Edit)
            {

                if (_bindingSource.Current is not Product spDangChon)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tenSP = txtTenSP.Text.Trim();
                if (string.IsNullOrEmpty(tenSP))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenSP.Focus();
                    return;
                }

                if (numDonGia.Value <= 0)
                {
                    MessageBox.Show("Đơn giá sản phẩm phải lớn hơn 0 VNĐ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numDonGia.Focus();
                    return;
                }

                spDangChon.TenSP = tenSP;
                spDangChon.LoaiSP = cboLoaiSP.Text;
                spDangChon.DonGia = numDonGia.Value;
                spDangChon.SoLuong = (int)numSoLuong.Value;
                spDangChon.NgayNhap = dtpNgayNhap.Value;
                spDangChon.ConKinhDoanh = chkConKinhDoanh.Checked;
                spDangChon.DuongDanAnh = _duongDanAnhHienTai;

                _bindingSource.ResetBindings(false);

                ThietLapTrangThaiForm(FormMode.View);

                CapNhatThongKeStatusStrip($"Đã cập nhật SP [{spDangChon.MaSP} - {spDangChon.TenSP}] thành công");
                MessageBox.Show($"Đã cập nhật thông tin sản phẩm [{spDangChon.MaSP}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ThietLapTrangThaiForm(FormMode.View);

            if (_bindingSource.Current is Product sp)
            {
                HienThiThongTinSanPhamLenForm(sp);
            }
            else
            {
                XoaTrangFormNhapLieu();
            }

            CapNhatThongKeStatusStrip("Đã hủy thao tác, quay về chế độ chỉ xem");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not Product spDangChon)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ danh sách!", "Chưa chọn sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm:\nMã SP: {spDangChon.MaSP}\nTên SP: {spDangChon.TenSP}\n\nThao tác này không thể hoàn tác!",
                "Xác nhận xóa sản phẩm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string maSPDaXoa = spDangChon.MaSP;
                string tenSPDaXoa = spDangChon.TenSP;

                _danhSachGoc.Remove(spDangChon);

                if (_bindingSource.DataSource is BindingList<Product> danhSachLoc && danhSachLoc != _danhSachGoc)
                {
                    danhSachLoc.Remove(spDangChon);
                }

                if (_bindingSource.Count > 0)
                {
                    dgvSanPham_SelectionChanged(sender, e);
                }
                else
                {
                    XoaTrangFormNhapLieu();
                }

                ThietLapTrangThaiForm(FormMode.View);
                CapNhatThongKeStatusStrip($"Đã xóa sản phẩm [{maSPDaXoa} - {tenSPDaXoa}] khỏi hệ thống");
                MessageBox.Show($"Đã xóa sản phẩm [{maSPDaXoa}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetBoLocTimKiem();
            ThietLapTrangThaiForm(FormMode.View);

            if (_bindingSource.Count > 0)
            {
                dgvSanPham_SelectionChanged(sender, e);
            }
            else
            {
                XoaTrangFormNhapLieu();
            }

            CapNhatThongKeStatusStrip("Đã làm mới các trường và hiển thị toàn bộ danh sách");
        }

        private void XoaTrangFormNhapLieu()
        {
            _isDataBinding = true;
            try
            {
                txtMaSP.Clear();
                txtTenSP.Clear();
                if (cboLoaiSP.Items.Count > 0)
                {
                    cboLoaiSP.SelectedIndex = 0;
                }
                numDonGia.Value = 0;
                numSoLuong.Value = 0;
                dtpNgayNhap.Value = DateTime.Now;
                chkConKinhDoanh.Checked = true;
                _duongDanAnhHienTai = string.Empty;

                GiaiPhongVaXoaHinhAnh();
                dgvSanPham.ClearSelection();
            }
            finally
            {
                _isDataBinding = false;
            }
        }

        #endregion

        #region DataGridView Events & Hiển thị Chi tiết

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (_isDataBinding) return;

            if (_currentMode != FormMode.View) return;

            if (_bindingSource.Current is Product sp)
            {
                HienThiThongTinSanPhamLenForm(sp);
                btnChinhSua.Enabled = true;
                btnXoa.Enabled = true;
                lblTrangThai.Text = $"Xem chi tiết SP: [{sp.MaSP}] - {sp.TenSP}";
            }
            else
            {
                btnChinhSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void HienThiThongTinSanPhamLenForm(Product sp)
        {
            _isDataBinding = true;
            try
            {
                txtMaSP.Text = sp.MaSP;
                txtTenSP.Text = sp.TenSP;
                cboLoaiSP.Text = sp.LoaiSP;
                numDonGia.Value = sp.DonGia;
                numSoLuong.Value = sp.SoLuong;
                dtpNgayNhap.Value = sp.NgayNhap;
                chkConKinhDoanh.Checked = sp.ConKinhDoanh;
                _duongDanAnhHienTai = sp.DuongDanAnh;

                HienThiHinhAnh(_duongDanAnhHienTai);
            }
            finally
            {
                _isDataBinding = false;
            }
        }

        #endregion

        #region Tìm kiếm & Lọc sản phẩm Real-time

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ThucHienLocVaTimKiem();
        }

        private void cboLocLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThucHienLocVaTimKiem();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            ResetBoLocTimKiem();
            CapNhatThongKeStatusStrip("Đã bỏ lọc, hiển thị toàn bộ sản phẩm");
        }

        private void ThucHienLocVaTimKiem()
        {

            if (_currentMode != FormMode.View) return;

            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            string loaiLoc = cboLocLoai.SelectedItem?.ToString() ?? "-- Tất cả loại sản phẩm --";

            if (string.IsNullOrEmpty(tuKhoa) && (loaiLoc == "-- Tất cả loại sản phẩm --" || cboLocLoai.SelectedIndex == 0))
            {
                if (_bindingSource.DataSource != _danhSachGoc)
                {
                    _bindingSource.DataSource = _danhSachGoc;
                    CapNhatThongKeStatusStrip("Đang hiển thị toàn bộ danh sách sản phẩm");
                }
                return;
            }

            BindingList<Product> ketQuaLoc = new BindingList<Product>();

            foreach (var sp in _danhSachGoc)
            {
                bool matchLoai = (loaiLoc == "-- Tất cả loại sản phẩm --") ||
                                 sp.LoaiSP.Equals(loaiLoc, StringComparison.OrdinalIgnoreCase);

                bool matchTuKhoa = string.IsNullOrEmpty(tuKhoa) ||
                                   sp.TenSP.ToLower().Contains(tuKhoa) ||
                                   sp.MaSP.ToLower().Contains(tuKhoa);

                if (matchLoai && matchTuKhoa)
                {
                    ketQuaLoc.Add(sp);
                }
            }

            _bindingSource.DataSource = ketQuaLoc;
            CapNhatThongKeStatusStrip($"Tìm thấy {ketQuaLoc.Count} sản phẩm phù hợp");
        }

        private void ResetBoLocTimKiem()
        {
            txtTimKiem.Clear();
            if (cboLocLoai.Items.Count > 0)
            {
                cboLocLoai.SelectedIndex = 0;
            }
            _bindingSource.DataSource = _danhSachGoc;
            CapNhatThongKeStatusStrip();
        }

        #endregion

        #region Xử lý Hình ảnh sản phẩm (PictureBox)

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn hình ảnh cho sản phẩm";
                ofd.Filter = "File hình ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả file (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _duongDanAnhHienTai = ofd.FileName;
                    HienThiHinhAnh(_duongDanAnhHienTai);
                    lblTrangThai.Text = "Đã chọn ảnh minh họa cho sản phẩm";
                }
            }
        }

        private void HienThiHinhAnh(string duongDanAnh)
        {
            GiaiPhongVaXoaHinhAnh();

            if (!string.IsNullOrEmpty(duongDanAnh) && File.Exists(duongDanAnh))
            {
                try
                {

                    byte[] imageBytes = File.ReadAllBytes(duongDanAnh);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        picHinhAnh.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    picHinhAnh.Image = null;
                }
            }
        }

        private void GiaiPhongVaXoaHinhAnh()
        {
            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }
        }

        #endregion

        #region Chuyên sâu NHÓM 3: Xuất File với SaveFileDialog và StreamWriter

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Count == 0)
            {
                MessageBox.Show("Hiện không có sản phẩm nào trong danh sách để xuất file!", "Danh sách rỗng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách sản phẩm ra File - Nhóm 3";
                sfd.Filter = "File văn bản báo cáo (*.txt)|*.txt|File bảng tính Excel (*.csv)|*.csv";
                sfd.FilterIndex = 1;
                sfd.DefaultExt = "txt";
                sfd.FileName = $"BaoCaoTonKho_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string duongDanLuu = sfd.FileName;
                        string duoiFile = Path.GetExtension(duongDanLuu).ToLower();

                        var danhSachXuat = new List<Product>();
                        foreach (Product item in _bindingSource)
                        {
                            danhSachXuat.Add(item);
                        }

                        if (duoiFile == ".csv")
                        {
                            ProductFileService.ExportToCsv(duongDanLuu, danhSachXuat);
                        }
                        else
                        {
                            ProductFileService.ExportToTxt(duongDanLuu, danhSachXuat);
                        }

                        CapNhatThongKeStatusStrip($"Đã xuất file thành công: {Path.GetFileName(duongDanLuu)}");

                        DialogResult hoiMoFile = MessageBox.Show(
                            $"Xuất dữ liệu thành công!\n\nĐường dẫn: {duongDanLuu}\nTổng số mặt hàng đã xuất: {danhSachXuat.Count}\n\nBạn có muốn mở file vừa xuất ngay bây giờ không?",
                            "Xuất file thành công",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (hoiMoFile == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo(duongDanLuu) { UseShellExecute = true });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi ghi file: {ex.Message}", "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CapNhatThongKeStatusStrip($"Lỗi xuất file: {ex.Message}");
                    }
                }
            }
        }

        #endregion

        private void picHinhAnh_Click(object sender, EventArgs e)
        {

        }

        private void lblTongGiaTriTonKho_Click(object sender, EventArgs e)
        {

        }

        private void picHinhAnh_Click_1(object sender, EventArgs e)
        {

        }

        private void lblHeaderSubtitle_Click(object sender, EventArgs e)
        {

        }

        private void lblHeaderTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTrangThai_Click(object sender, EventArgs e)
        {

        }
    }
}
