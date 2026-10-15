# TỔNG HỢP TOÀN BỘ MÃ NGUỒN (SOURCE CODE) DỰ ÁN LAB 06
## MÔN HỌC: COMP1019 – LẬP TRÌNH TRÊN WINDOWS
### ĐỀ TÀI: PRODUCT MANAGER (WINDOWS FORMS NÂNG CAO & DATAGRIDVIEW)
### BÁO CÁO CHUYÊN SÂU NHÓM 3: STATUSSTRIP REAL-TIME, THỐNG KÊ TỒN KHO & ĐỌC/GHI FILE (SAVEFILEDIALOG)

---

## MỤC LỤC TÀI LIỆU MÃ NGUỒN

1. [Cấu trúc tệp tin trong Solution](#1-cấu-trúc-tệp-tin-trong-solution)
2. [Tệp 1: Models/Product.cs](#2-tệp-1-modelsproductcs) – Thực thể dữ liệu sản phẩm
3. [Tệp 2: Services/ProductFileService.cs](#3-tệp-2-servicesproductfileservicecs) – Dịch vụ xuất File (.txt, .csv UTF-8 BOM)
4. [Tệp 3: Services/SampleDataHelper.cs](#4-tệp-3-servicessampledatahelpercs) – Tạo dữ liệu mẫu & Vẽ ảnh tự động bằng GDI+
5. [Tệp 4: Form1.cs](#5-tệp-4-form1cs) – Logic điều phối sự kiện, Quản lý trạng thái Form & StatusStrip
6. [Tệp 5: Program.cs](#6-tệp-5-programcs) – Điểm khởi động ứng dụng
7. [Tệp 6: Lab06.csproj](#7-tệp-6-lab06csproj) – Cấu hình dự án .NET Windows Forms

---

## 1. Cấu trúc tệp tin trong Solution

```text
Lab06/
│
├── Models/
│   └── Product.cs             # Lớp thực thể Product (Data Model)
│
├── Services/
│   ├── ProductFileService.cs  # Xuất báo cáo TXT căn lề và CSV UTF-8 with BOM
│   └── SampleDataHelper.cs    # Khởi tạo dữ liệu mẫu và vẽ ảnh đồ họa GDI+ tự động
│
├── Form1.cs                   # Code-behind xử lý luồng trạng thái, sự kiện và StatusStrip
├── Form1.Designer.cs          # Mã thiết kế giao diện tự động của Windows Forms Designer
├── Program.cs                 # Điểm khởi chạy ứng dụng
└── Lab06.csproj               # Cấu hình project .NET Windows Forms
```

---

## 2. Tệp 1: `Models/Product.cs`

**Đường dẫn:** `Lab06/Models/Product.cs`  
**Chức năng:** Lớp biểu diễn dữ liệu của một mặt hàng trong hệ thống. Bao gồm các thuộc tính nghiệp vụ, attribute ẩn đối với DataGridView, thuộc tính tính toán động và phương thức Clone bản sao.

```csharp
using System;

namespace Lab06.Models
{
    /// <summary>
    /// Lớp biểu diễn thông tin một sản phẩm trong hệ thống
    /// Đáp ứng đúng yêu cầu của Bài Lab 06 - COMP1019
    /// </summary>
    public class Product
    {
        // 1. Mã sản phẩm (Khóa chính định danh duy nhất)
        public string MaSP { get; set; } = string.Empty;

        // 2. Tên sản phẩm
        public string TenSP { get; set; } = string.Empty;

        // 3. Loại sản phẩm (Điện thoại, Laptop, Phụ kiện, Máy tính bảng...)
        public string LoaiSP { get; set; } = string.Empty;

        // 4. Đơn giá sản phẩm (đơn vị: VNĐ)
        public decimal DonGia { get; set; }

        // 5. Số lượng tồn kho
        public int SoLuong { get; set; }

        // 6. Ngày nhập hàng vào kho
        public DateTime NgayNhap { get; set; } = DateTime.Now;

        // 7. Trạng thái còn tiếp tục kinh doanh hay ngừng bán
        public bool ConKinhDoanh { get; set; } = true;

        // 8. Đường dẫn file hình ảnh minh họa của sản phẩm
        // [Browsable(false)]: Lưu ngầm trong bộ nhớ, không hiển thị thành cột trên DataGridView
        [System.ComponentModel.Browsable(false)]
        public string DuongDanAnh { get; set; } = string.Empty;

        // Thuộc tính tiện ích tính thành tiền tồn kho của từng sản phẩm (Expression-bodied Property)
        public decimal ThanhTien => DonGia * SoLuong;

        // Hàm khởi tạo mặc định (Parameterless constructor)
        public Product()
        {
        }

        // Hàm khởi tạo đầy đủ tham số
        public Product(string maSP, string tenSP, string loaiSP, decimal donGia, int soLuong, DateTime ngayNhap, bool conKinhDoanh, string duongDanAnh = "")
        {
            MaSP = maSP;
            TenSP = tenSP;
            LoaiSP = loaiSP;
            DonGia = donGia;
            SoLuong = soLuong;
            NgayNhap = ngayNhap;
            ConKinhDoanh = conKinhDoanh;
            DuongDanAnh = duongDanAnh;
        }

        /// <summary>
        /// Tạo bản sao đối tượng để phục vụ thao tác sửa an toàn
        /// </summary>
        public Product Clone()
        {
            return new Product(MaSP, TenSP, LoaiSP, DonGia, SoLuong, NgayNhap, ConKinhDoanh, DuongDanAnh);
        }
    }
}
```

---

## 3. Tệp 2: `Services/ProductFileService.cs`

**Đường dẫn:** `Lab06/Services/ProductFileService.cs`  
**Chức năng:** Tầng dịch vụ xử lý I/O xuất file dữ liệu.
* `ExportToTxt`: Xuất báo cáo bảng văn bản căn lề thẳng hàng chuẩn xác bằng `string.Format`.
* `ExportToCsv`: Xuất file CSV hỗ trợ tiếng Việt có dấu hoàn hảo trên Microsoft Excel bằng `new UTF8Encoding(true)` (BOM).

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Lab06.Models;

namespace Lab06.Services
{
    /// <summary>
    /// Lớp dịch vụ xử lý xuất/nhập file dữ liệu sản phẩm
    /// Thuộc nội dung chuyên sâu của NHÓM 3: Đọc/Ghi File với StreamWriter và SaveFileDialog
    /// </summary>
    public static class ProductFileService
    {
        /// <summary>
        /// Xuất danh sách sản phẩm ra file văn bản (.txt) dạng báo cáo thống kê kho
        /// </summary>
        /// <param name="filePath">Đường dẫn file cần lưu</param>
        /// <param name="products">Danh sách sản phẩm</param>
        public static void ExportToTxt(string filePath, IEnumerable<Product> products)
        {
            // Sử dụng Encoding.UTF8 để hỗ trợ tiếng Việt có dấu chuẩn xác
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // 1. Ghi phần Header của báo cáo
                writer.WriteLine("====================================================================================================");
                writer.WriteLine("                         BÁO CÁO THỐNG KÊ TỒN KHO VÀ DANH SÁCH SẢN PHẨM                            ");
                writer.WriteLine("                              (Phần mềm Quản lý sản phẩm - Nhóm 3)                                  ");
                writer.WriteLine("====================================================================================================");
                writer.WriteLine($"Ngày xuất báo cáo : {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                writer.WriteLine($"Người lập báo cáo : Quản trị viên hệ thống");
                writer.WriteLine("----------------------------------------------------------------------------------------------------");

                // 2. Ghi tiêu đề các cột với căn lề thẳng hàng
                // {0,-8}: Căn trái 8 ký tự, {3,18}: Căn phải 18 ký tự
                writer.WriteLine(string.Format("{0,-8} | {1,-26} | {2,-18} | {3,18} | {4,12} | {5,-16} | {6,-14}",
                    "Mã SP", "Tên Sản Phẩm", "Loại SP", "Đơn Giá (VNĐ)", "SL Tồn Kho", "Ngày Nhập", "Kinh Doanh"));
                writer.WriteLine("----------------------------------------------------------------------------------------------------");

                int tongSoLuongSP = 0;
                decimal tongGiaTriTonKho = 0;
                int demSanPham = 0;

                // 3. Duyệt từng sản phẩm và ghi dòng dữ liệu
                foreach (var p in products)
                {
                    demSanPham++;
                    tongSoLuongSP += p.SoLuong;
                    decimal thanhTien = p.SoLuong * p.DonGia;
                    tongGiaTriTonKho += thanhTien;

                    string trangThaiKD = p.ConKinhDoanh ? "Đang bán" : "Ngừng bán";

                    // Cắt ngắn tên nếu quá dài để bảng báo cáo luôn ngay ngắn
                    string tenHienThi = p.TenSP.Length > 24 ? p.TenSP.Substring(0, 21) + "..." : p.TenSP;

                    writer.WriteLine(string.Format("{0,-8} | {1,-26} | {2,-18} | {3,18} | {4,12} | {5,-16:dd/MM/yyyy} | {6,-14}",
                        p.MaSP,
                        tenHienThi,
                        p.LoaiSP,
                        p.DonGia,
                        p.SoLuong,
                        p.NgayNhap,
                        trangThaiKD));
                }

                // 4. Ghi phần chân trang thống kê tổng kết
                writer.WriteLine("====================================================================================================");
                writer.WriteLine("TỔNG KẾT BÁO CÁO:");
                writer.WriteLine($"- Tổng số mặt hàng (mã sản phẩm) : {demSanPham} mặt hàng");
                writer.WriteLine($"- Tổng số lượng sản phẩm tồn kho : {tongSoLuongSP:N0} cái/chiếc");
                writer.WriteLine($"- TỔNG GIÁ TRỊ TỒN KHO            : {tongGiaTriTonKho:N0} VNĐ");
                writer.WriteLine("====================================================================================================");
                writer.WriteLine("Ghi chú: Báo cáo được trích xuất tự động từ phần mềm ProductManager - Windows Forms Nâng cao.");
            }
        }

        /// <summary>
        /// Xuất danh sách sản phẩm ra file CSV (.csv) mở được trực tiếp bằng Microsoft Excel
        /// </summary>
        /// <param name="filePath">Đường dẫn file</param>
        /// <param name="products">Danh sách sản phẩm</param>
        public static void ExportToCsv(string filePath, IEnumerable<Product> products)
        {
            // Thêm Encoding UTF8 with BOM để Microsoft Excel tự động nhận diện tiếng Việt không bị lỗi font
            using (StreamWriter writer = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {
                // Ghi dòng tiêu đề cột CSV (không chứa cột đường dẫn ảnh)
                writer.WriteLine("MaSP,TenSP,LoaiSP,DonGia,SoLuong,NgayNhap,ConKinhDoanh,ThanhTien");

                foreach (var p in products)
                {
                    // Escape tên sản phẩm nếu có dấu phẩy hoặc ngoặc kép theo chuẩn RFC 4180
                    string tenSP = p.TenSP.Replace("\"", "\"\"");
                    if (tenSP.Contains(",") || tenSP.Contains("\""))
                    {
                        tenSP = $"\"{tenSP}\"";
                    }

                    string dongData = string.Format("{0},{1},{2},{3},{4},{5:yyyy-MM-dd},{6},{7}",
                        p.MaSP,
                        tenSP,
                        p.LoaiSP,
                        p.DonGia,
                        p.SoLuong,
                        p.NgayNhap,
                        p.ConKinhDoanh ? "1" : "0",
                        p.ThanhTien);

                    writer.WriteLine(dongData);
                }
            }
        }
    }
}
```

---

## 4. Tệp 3: `Services/SampleDataHelper.cs`

**Đường dẫn:** `Lab06/Services/SampleDataHelper.cs`  
**Chức năng:** Tự động tạo 5 sản phẩm mẫu và sử dụng thư viện GDI+ để vẽ các file ảnh thẻ sản phẩm chất lượng cao, giúp phần mềm chạy độc lập trên mọi máy tính mà không phụ thuộc vào việc chép ảnh thủ công.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Lab06.Models;

namespace Lab06.Services
{
    /// <summary>
    /// Lớp tiện ích hỗ trợ tạo dữ liệu mẫu và tạo hình ảnh mẫu tự động
    /// Giúp ứng dụng chạy độc lập, hiển thị ảnh trực quan trên mọi máy tính mà không lo thiếu file ảnh
    /// </summary>
    public static class SampleDataHelper
    {
        private static readonly string ImagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleImages");

        /// <summary>
        /// Tạo các hình ảnh mẫu trực quan nếu chưa tồn tại
        /// </summary>
        public static void EnsureSampleImagesExist()
        {
            try
            {
                if (!Directory.Exists(ImagesFolder))
                {
                    Directory.CreateDirectory(ImagesFolder);
                }

                CreatePlaceholderImage("SP01.png", "iPhone 15 Pro", "ĐIỆN THOẠI", Color.FromArgb(41, 128, 185));
                CreatePlaceholderImage("SP02.png", "MacBook Air M3", "LAPTOP", Color.FromArgb(39, 174, 96));
                CreatePlaceholderImage("SP03.png", "Logitech MX Mech", "PHỤ KIỆN", Color.FromArgb(142, 68, 173));
                CreatePlaceholderImage("SP04.png", "Galaxy S24 Ultra", "ĐIỆN THOẠI", Color.FromArgb(230, 126, 34));
                CreatePlaceholderImage("SP05.png", "Sony WH-1000XM5", "PHỤ KIỆN", Color.FromArgb(192, 57, 43));
            }
            catch
            {
                // Bỏ qua nếu có lỗi quyền ghi thư mục, chương trình vẫn hoạt động bình thường
            }
        }

        private static void CreatePlaceholderImage(string fileName, string title, string category, Color bgColor)
        {
            string fullPath = Path.Combine(ImagesFolder, fileName);
            if (File.Exists(fullPath))
            {
                return;
            }

            int width = 300;
            int height = 240;

            using (Bitmap bmp = new Bitmap(width, height))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Tô nền gradient hiện đại
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(0, 0, width, height),
                    bgColor,
                    Color.FromArgb(240, 240, 240),
                    LinearGradientMode.ForwardDiagonal))
                {
                    g.FillRectangle(brush, 0, 0, width, height);
                }

                // Vẽ khung viền
                using (Pen pen = new Pen(bgColor, 4))
                {
                    g.DrawRectangle(pen, 2, 2, width - 4, height - 4);
                }

                // Vẽ thẻ danh mục
                using (SolidBrush tagBrush = new SolidBrush(Color.White))
                using (Font tagFont = new Font("Segoe UI", 10, FontStyle.Bold))
                {
                    g.FillRectangle(tagBrush, 20, 25, 120, 28);
                    g.DrawString(category, tagFont, new SolidBrush(bgColor), 25, 30);
                }

                // Vẽ tên sản phẩm
                using (Font titleFont = new Font("Segoe UI", 13, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(30, 30, 30)))
                {
                    g.DrawString(title, titleFont, textBrush, new RectangleF(20, 75, width - 40, 60));
                }

                // Vẽ biểu tượng minh họa
                using (Font subFont = new Font("Segoe UI", 9, FontStyle.Italic))
                using (SolidBrush subBrush = new SolidBrush(Color.FromArgb(80, 80, 80)))
                {
                    g.DrawString("Ảnh mẫu demo ProductManager", subFont, subBrush, 20, 195);
                }

                bmp.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        /// <summary>
        /// Lấy danh sách 5 sản phẩm mẫu phong phú (vượt tiêu chí tối thiểu 3 sản phẩm của đề bài)
        /// </summary>
        public static List<Product> GetSampleProducts()
        {
            EnsureSampleImagesExist();

            string imgPath(string file) => Path.Combine(ImagesFolder, file);

            return new List<Product>
            {
                new Product("SP01", "iPhone 15 Pro Max 256GB", "Điện thoại", 29990000m, 15, new DateTime(2026, 9, 15), true, imgPath("SP01.png")),
                new Product("SP02", "MacBook Air M3 16GB", "Laptop", 27490000m, 8, new DateTime(2026, 9, 20), true, imgPath("SP02.png")),
                new Product("SP03", "Bàn phím Logitech MX Mechanical", "Phụ kiện", 3250000m, 30, new DateTime(2026, 9, 28), true, imgPath("SP03.png")),
                new Product("SP04", "Samsung Galaxy S24 Ultra", "Điện thoại", 26990000m, 12, new DateTime(2026, 10, 1), true, imgPath("SP04.png")),
                new Product("SP05", "Tai nghe Sony WH-1000XM5", "Phụ kiện", 6490000m, 20, new DateTime(2026, 10, 5), true, imgPath("SP05.png"))
            };
        }
    }
}
```

---

## 5. Tệp 4: `Form1.cs`

**Đường dẫn:** `Lab06/Form1.cs`  
**Chức năng:** Trọng tâm điều phối toàn bộ nghiệp vụ của ứng dụng:
* Quản lý trạng thái Form với 3 chế độ (`View`, `Add`, `Edit`).
* Liên kết dữ liệu 2 chiều với `BindingList<Product>` và `BindingSource`.
* Cập nhật phản hồi thời gian thực qua `StatusStrip` và thuật toán tính tổng tồn kho.
* Xử lý hình ảnh sản phẩm với `MemoryStream` chống khóa file.
* Tìm kiếm và lọc danh mục Real-time.
* Xuất file qua `SaveFileDialog` và mở file tự động với `Process.Start`.

```csharp
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
    /// <summary>
    /// Màn hình chính Quản lý sản phẩm (ProductManager)
    /// Đề tài Lab 06 - COMP1019 Lập trình trên Windows
    /// Báo cáo chuyên sâu NHÓM 3: StatusStrip Real-time, Thống kê tồn kho & Đọc/Ghi File
    /// </summary>
    public partial class Form1 : Form
    {
        // Định nghĩa các trạng thái làm việc của Form
        private enum FormMode
        {
            View,       // Chế độ Xem: Tất cả thông tin chi tiết bị KHÓA, nút Cập nhật bị vô hiệu hóa
            Add,        // Chế độ Thêm mới SP: Mở khóa các ô nhập liệu, kích hoạt nút Cập nhật
            Edit        // Chế độ Chỉnh sửa SP: Mở khóa tất cả thông tin chi tiết, kích hoạt nút Cập nhật
        }

        private FormMode _currentMode = FormMode.View;

        // Lưu trữ đường dẫn ảnh ngầm trong bộ nhớ thay vì hiển thị dạng text
        private string _duongDanAnhHienTai = string.Empty;

        // 1. Danh sách sản phẩm gốc lưu trữ trong bộ nhớ bằng BindingList (Hỗ trợ 2 chiều với DataGridView)
        private readonly BindingList<Product> _danhSachGoc = new BindingList<Product>();

        // 2. BindingSource làm cầu nối giữa BindingList và DataGridView để hỗ trợ lọc và sắp xếp
        private readonly BindingSource _bindingSource = new BindingSource();

        // Cờ kiểm soát tránh kích hoạt sự kiện SelectionChanged ngoài ý muốn khi đang nạp dữ liệu
        private bool _isDataBinding = false;

        public Form1()
        {
            InitializeComponent();
        }

        #region Form Load & Khởi tạo

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thiết lập ComboBox mặc định
            cboLoaiSP.SelectedIndex = 0;
            cboLocLoai.SelectedIndex = 0;

            // Khởi tạo và nạp dữ liệu mẫu ban đầu (tối thiểu 3 sản phẩm theo yêu cầu)
            KhoiTaoDuLieuMau();

            // Đảm bảo không bao giờ tự động phát sinh cột đường dẫn ảnh trong DataGridView
            dgvSanPham.AutoGenerateColumns = false;

            // Kết nối BindingSource với BindingList và DataGridView
            _bindingSource.DataSource = _danhSachGoc;
            dgvSanPham.DataSource = _bindingSource;

            // Đưa Form về trạng thái mặc định: KHÓA tất cả thông tin chi tiết, nút Cập nhật bị Disable
            ThietLapTrangThaiForm(FormMode.View);

            // Nạp dữ liệu sản phẩm đầu tiên lên form (nếu có)
            if (_bindingSource.Count > 0)
            {
                dgvSanPham_SelectionChanged(sender, e);
            }

            // Cập nhật thống kê và trạng thái ban đầu lên StatusStrip
            CapNhatThongKeStatusStrip("🟢 Sẵn sàng | Đã nạp thành công 5 sản phẩm mẫu");

            // Hiển thị đồng hồ thời gian thực ngay lập tức
            timerDongHo_Tick(sender, e);
        }

        /// <summary>
        /// Khởi tạo dữ liệu mẫu ban đầu theo yêu cầu I của đề bài
        /// </summary>
        private void KhoiTaoDuLieuMau()
        {
            _danhSachGoc.Clear();
            List<Product> sampleData = SampleDataHelper.GetSampleProducts();
            foreach (var item in sampleData)
            {
                _danhSachGoc.Add(item);
            }
        }

        #endregion

        #region Quản lý Luồng Trạng Thái Form (Form State Management)

        /// <summary>
        /// THIẾT LẬP TRẠNG THÁI FORM:
        /// - View: Khóa tất cả thông tin chi tiết, nút Cập nhật và Hủy bị vô hiệu hóa
        /// - Add: Mở khóa các trường, bật nút Cập nhật
        /// - Edit: Chỉ mở khóa tất cả các thông tin chi tiết khi ấn vào nút 'Chỉnh sửa'
        /// </summary>
        private void ThietLapTrangThaiForm(FormMode mode)
        {
            _currentMode = mode;

            switch (mode)
            {
                case FormMode.View:
                    // 1. KHÓA TẤT CẢ các thông tin chi tiết để chỉ xem
                    txtMaSP.ReadOnly = true;
                    txtTenSP.ReadOnly = true;
                    cboLoaiSP.Enabled = false;
                    numDonGia.Enabled = false;
                    numSoLuong.Enabled = false;
                    dtpNgayNhap.Enabled = false;
                    chkConKinhDoanh.Enabled = false;
                    btnChonAnh.Enabled = false;

                    // 2. NÚT CẬP NHẬT VÀ HỦY CHỈ CÓ THỂ SỬ DỤNG KHI ẤN 'Thêm SP' HOẶC 'Chỉnh sửa'
                    btnCapNhat.Enabled = false;
                    btnHuy.Enabled = false;

                    // 3. Cho phép người dùng thao tác các nút chức năng chính
                    btnThem.Enabled = true;
                    btnChinhSua.Enabled = (_bindingSource.Current != null);
                    btnXoa.Enabled = (_bindingSource.Current != null);
                    btnLamMoi.Enabled = true;
                    btnXuatFile.Enabled = true;

                    dgvSanPham.Enabled = true;
                    pnlSearch.Enabled = true;
                    break;

                case FormMode.Add:
                    // 1. MỞ KHÓA các ô để nhập sản phẩm mới
                    txtMaSP.ReadOnly = false;
                    txtTenSP.ReadOnly = false;
                    cboLoaiSP.Enabled = true;
                    numDonGia.Enabled = true;
                    numSoLuong.Enabled = true;
                    dtpNgayNhap.Enabled = true;
                    chkConKinhDoanh.Enabled = true;
                    btnChonAnh.Enabled = true;

                    // 2. KÍCH HOẠT nút Cập nhật và nút Hủy bỏ
                    btnCapNhat.Enabled = true;
                    btnHuy.Enabled = true;

                    // 3. Khóa tạm thời các nút khác để tránh xung đột luồng
                    btnThem.Enabled = false;
                    btnChinhSua.Enabled = false;
                    btnXoa.Enabled = false;

                    dgvSanPham.Enabled = false;
                    pnlSearch.Enabled = false;
                    break;

                case FormMode.Edit:
                    // 1. CHỈ ĐƯỢC MỞ KHÓA TẤT CẢ CÁC THÔNG TIN CHI TIẾT ĐỂ CHỈNH SỬA KHI ẤN VÀO NÚT 'CHỈNH SỬA'
                    txtMaSP.ReadOnly = true; // Giữ mã SP làm khóa chính định danh không thay đổi
                    txtTenSP.ReadOnly = false;
                    cboLoaiSP.Enabled = true;
                    numDonGia.Enabled = true;
                    numSoLuong.Enabled = true;
                    dtpNgayNhap.Enabled = true;
                    chkConKinhDoanh.Enabled = true;
                    btnChonAnh.Enabled = true;

                    // 2. KÍCH HOẠT nút Cập nhật và nút Hủy bỏ
                    btnCapNhat.Enabled = true;
                    btnHuy.Enabled = true;

                    // 3. Khóa tạm thời các nút khác
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

        /// <summary>
        /// CẬP NHẬT TRẠNG THÁI VÀ THỐNG KÊ TỒN KHO THEO THỜI GIAN THỰC LÊN STATUSSTRIP
        /// </summary>
        /// <param name="thongDiepTrangThai">Thông điệp hành động vừa thực hiện</param>
        private void CapNhatThongKeStatusStrip(string? thongDiepTrangThai = null)
        {
            // 1. Cập nhật thông điệp trạng thái thao tác real-time
            if (!string.IsNullOrEmpty(thongDiepTrangThai))
            {
                lblTrangThai.Text = thongDiepTrangThai;
            }

            // 2. Thuật toán tính toán chỉ số thống kê tồn kho từ danh sách hiện tại
            // Công thức: Tổng giá trị = sum(Số lượng * Đơn giá)
            int soMatHang = _bindingSource.Count;
            int tongSoLuongTon = 0;
            decimal tongGiaTriTonKho = 0;

            foreach (Product sp in _bindingSource)
            {
                tongSoLuongTon += sp.SoLuong;
                decimal thanhTien = sp.SoLuong * sp.DonGia;
                tongGiaTriTonKho += thanhTien;
            }

            // 3. Hiển thị trực tiếp các chỉ số thống kê lên các nhãn của StatusStrip
            lblTongSanPham.Text = $"📦 Mặt hàng: {soMatHang} | Tổng SL tồn: {tongSoLuongTon:N0} chiếc";
            lblTongGiaTriTonKho.Text = $"💰 TỔNG TỒN KHO: {tongGiaTriTonKho:N0} VNĐ";
        }

        /// <summary>
        /// Timer cập nhật đồng hồ thời gian thực mỗi giây góc phải StatusStrip
        /// </summary>
        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            lblDongHo.Text = $"🕒 {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        #endregion

        #region Xử lý các Nút Thao tác: Thêm SP, Chỉnh sửa, Cập nhật, Hủy, Xóa, Làm mới

        /// <summary>
        /// Khi bấm "Thêm SP": Xóa trắng form, mở khóa nhập liệu, kích hoạt nút Cập nhật
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaTrangFormNhapLieu();
            ThietLapTrangThaiForm(FormMode.Add);
            txtMaSP.Focus();
            CapNhatThongKeStatusStrip("📝 Đang ở chế độ Thêm mới SP. Vui lòng nhập thông tin rồi bấm 'Cập nhật' để lưu");
        }

        /// <summary>
        /// Nút "Chỉnh sửa": MỞ KHÓA TẤT CẢ CÁC THÔNG TIN CHI TIẾT để sửa lại thông tin của các mặt hàng
        /// </summary>
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not Product spDangChon)
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng trong danh sách trước khi bấm 'Chỉnh sửa'!", "Chưa chọn sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở khóa tất cả các thông tin chi tiết và kích hoạt nút Cập nhật
            ThietLapTrangThaiForm(FormMode.Edit);
            txtTenSP.Focus();
            CapNhatThongKeStatusStrip($"✏️ Đang chỉnh sửa SP [{spDangChon.MaSP} - {spDangChon.TenSP}]. Chỉnh sửa xong bấm 'Cập nhật' để lưu lại");
        }

        /// <summary>
        /// NÚT "CẬP NHẬT": CHỈ CÓ THỂ SỬ DỤNG KHI ẤN VÀO 'Thêm SP' HOẶC 'Chỉnh sửa'
        /// Thực hiện lưu dữ liệu vào hệ thống và khóa lại form
        /// </summary>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (_currentMode == FormMode.Add)
            {
                // XỬ LÝ LƯU KHI THÊM MỚI SẢN PHẨM
                string maSP = txtMaSP.Text.Trim();
                string tenSP = txtTenSP.Text.Trim();
                string loaiSP = cboLoaiSP.Text;
                decimal donGia = numDonGia.Value;
                int soLuong = (int)numSoLuong.Value;
                DateTime ngayNhap = dtpNgayNhap.Value;
                bool conKinhDoanh = chkConKinhDoanh.Checked;
                string duongDanAnh = _duongDanAnhHienTai;

                // Validation dữ liệu
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

                // Kiểm tra trùng mã sản phẩm
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

                // Tạo đối tượng và thêm vào danh sách
                Product spMoi = new Product(maSP, tenSP, loaiSP, donGia, soLuong, ngayNhap, conKinhDoanh, duongDanAnh);
                _danhSachGoc.Add(spMoi);

                if (_bindingSource.DataSource != _danhSachGoc)
                {
                    ResetBoLocTimKiem();
                }

                _bindingSource.Position = _danhSachGoc.IndexOf(spMoi);

                // Khóa lại tất cả thông tin chi tiết và tắt nút Cập nhật
                ThietLapTrangThaiForm(FormMode.View);

                CapNhatThongKeStatusStrip($"✅ Vừa thêm mới SP [{spMoi.MaSP} - {spMoi.TenSP}] thành công");
                MessageBox.Show($"Đã thêm mới sản phẩm [{spMoi.TenSP}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_currentMode == FormMode.Edit)
            {
                // XỬ LÝ LƯU KHI CHỈNH SỬA SẢN PHẨM
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

                // Cập nhật thông tin vào đối tượng
                spDangChon.TenSP = tenSP;
                spDangChon.LoaiSP = cboLoaiSP.Text;
                spDangChon.DonGia = numDonGia.Value;
                spDangChon.SoLuong = (int)numSoLuong.Value;
                spDangChon.NgayNhap = dtpNgayNhap.Value;
                spDangChon.ConKinhDoanh = chkConKinhDoanh.Checked;
                spDangChon.DuongDanAnh = _duongDanAnhHienTai;

                // Đồng bộ cập nhật lên DataGridView
                _bindingSource.ResetBindings(false);

                // Khóa lại tất cả thông tin chi tiết và tắt nút Cập nhật
                ThietLapTrangThaiForm(FormMode.View);

                CapNhatThongKeStatusStrip($"✏️ Đã cập nhật SP [{spDangChon.MaSP} - {spDangChon.TenSP}] thành công");
                MessageBox.Show($"Đã cập nhật thông tin sản phẩm [{spDangChon.MaSP}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Nút "Hủy bỏ": Hủy bỏ thao tác Thêm hoặc Chỉnh sửa, khóa lại form và phục hồi dữ liệu ban đầu
        /// </summary>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ThietLapTrangThaiForm(FormMode.View);

            // Nạp lại dữ liệu của dòng đang chọn
            if (_bindingSource.Current is Product sp)
            {
                HienThiThongTinSanPhamLenForm(sp);
            }
            else
            {
                XoaTrangFormNhapLieu();
            }

            CapNhatThongKeStatusStrip("🟢 Đã hủy thao tác, quay về chế độ chỉ xem");
        }

        /// <summary>
        /// Xóa sản phẩm đang chọn khỏi hệ thống
        /// </summary>
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
                CapNhatThongKeStatusStrip($"🗑️ Đã xóa sản phẩm [{maSPDaXoa} - {tenSPDaXoa}] khỏi hệ thống");
                MessageBox.Show($"Đã xóa sản phẩm [{maSPDaXoa}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Làm mới: Khôi phục danh sách hiển thị gốc và đưa Form về chế độ Xem
        /// </summary>
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

            CapNhatThongKeStatusStrip("🔄 Đã làm mới các trường và hiển thị toàn bộ danh sách");
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

        /// <summary>
        /// Khi người dùng chọn dòng trên DataGridView, hiển thị dữ liệu chi tiết lên form
        /// </summary>
        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (_isDataBinding) return;

            // Chỉ cập nhật hiển thị khi đang ở chế độ xem (View)
            if (_currentMode != FormMode.View) return;

            if (_bindingSource.Current is Product sp)
            {
                HienThiThongTinSanPhamLenForm(sp);
                btnChinhSua.Enabled = true;
                btnXoa.Enabled = true;
                lblTrangThai.Text = $"🔍 Đang xem chi tiết SP: [{sp.MaSP}] - {sp.TenSP}";
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
            CapNhatThongKeStatusStrip("🔄 Đã bỏ lọc, hiển thị toàn bộ sản phẩm");
        }

        private void ThucHienLocVaTimKiem()
        {
            // Nếu đang trong quá trình Thêm hoặc Sửa thì không kích hoạt lọc
            if (_currentMode != FormMode.View) return;

            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            string loaiLoc = cboLocLoai.SelectedItem?.ToString() ?? "-- Tất cả loại sản phẩm --";

            if (string.IsNullOrEmpty(tuKhoa) && (loaiLoc == "-- Tất cả loại sản phẩm --" || cboLocLoai.SelectedIndex == 0))
            {
                if (_bindingSource.DataSource != _danhSachGoc)
                {
                    _bindingSource.DataSource = _danhSachGoc;
                    CapNhatThongKeStatusStrip("🟢 Đang hiển thị toàn bộ danh sách sản phẩm");
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
            CapNhatThongKeStatusStrip($"🔎 Tìm thấy {ketQuaLoc.Count} sản phẩm phù hợp");
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
                    lblTrangThai.Text = "📷 Đã chọn ảnh minh họa cho sản phẩm";
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
                    // Dùng MemoryStream đọc ảnh để tránh khóa file trên ổ cứng
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

                        CapNhatThongKeStatusStrip($"💾 Đã xuất file thành công: {Path.GetFileName(duongDanLuu)}");

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
                        CapNhatThongKeStatusStrip($"❌ Lỗi xuất file: {ex.Message}");
                    }
                }
            }
        }

        #endregion
    }
}
```

---

## 6. Tệp 5: `Program.cs`

**Đường dẫn:** `Lab06/Program.cs`  
**Chức năng:** Lớp khởi tạo điểm chạy chính (Main entry point) của ứng dụng, thiết lập môi trường đồ họa High-DPI và chạy `Form1`.

```csharp
namespace Lab06
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Tối ưu hóa cấu hình hiển thị DPI cao và font chữ mặc định hệ thống
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
```

---

## 7. Tệp 6: `Lab06.csproj`

**Đường dẫn:** `Lab06/Lab06.csproj`  
**Chức năng:** Định nghĩa thuộc tính biên dịch dự án .NET Windows Forms.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net9.0-windows</TargetFramework>
    <Nullable>enable</Nullable>
    <UseWindowsForms>true</UseWindowsForms>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

</Project>
```

---

## 8. Bảng tóm tắt các kỹ thuật lập trình nâng cao đã áp dụng

| STT | Kỹ thuật / Công nghệ | Vị trí áp dụng | Mục đích & Lợi ích mang lại |
|:---:|:---|:---|:---|
| **1** | `BindingList<T>` & `BindingSource` | `Form1.cs` | Cơ chế đồng bộ dữ liệu hai chiều tự động với `DataGridView`. Loại bỏ giật lag và việc gán lại DataSource thủ công. |
| **2** | State Pattern (Form State Management) | `Form1.cs` (`FormMode`) | Khóa các ô chi tiết và nút Cập nhật ở chế độ xem; chỉ mở khi Thêm hoặc Sửa. Ngăn chặn 100% việc nhập đè sai lệch dữ liệu. |
| **3** | StatusStrip Real-time & Thuật toán tính kho | `Form1.cs` | Cung cấp phản hồi thao tác tức thời; tự động tính tổng số lượng và tổng thành tiền $\sum(SL \times DonGia)$ riêng cho bộ lọc hiện tại. |
| **4** | `MemoryStream` & `File.ReadAllBytes` | `Form1.cs` (`HienThiHinhAnh`) | Tránh lỗi khóa tệp (`File Lock`) của Windows khi nạp ảnh lên `PictureBox`. Giải phóng hoàn toàn tài nguyên đĩa cứng. |
| **5** | Composite Formatting `{index, width}` | `ProductFileService.cs` | Định dạng cột báo cáo `.txt` căn lề thẳng hàng tuyệt đối, phục vụ in ấn chuyên nghiệp. |
| **6** | `UTF8Encoding(true)` (BOM) | `ProductFileService.cs` | Ghi ký tự nhận diện BOM (`EF BB BF`) vào đầu file `.csv`, giúp Microsoft Excel hiển thị tiếng Việt không bao giờ bị lỗi font. |
| **7** | GDI+ Graphics & `LinearGradientBrush` | `SampleDataHelper.cs` | Tự sinh ảnh minh họa đẹp mắt vào RAM/Disk, giúp ứng dụng chạy độc lập trên mọi máy tính mà không sợ thiếu dữ liệu. |
