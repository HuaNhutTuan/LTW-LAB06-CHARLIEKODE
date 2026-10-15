# -*- coding: utf-8 -*-
import os
import subprocess
import html

print("Đang đọc mã nguồn dự án...")
with open(r"Lab06\Lab06\Form1.Designer.cs", "r", encoding="utf-8") as f:
    designer_code = f.read()
with open(r"Lab06\Lab06\Form1.cs", "r", encoding="utf-8") as f:
    form1_code = f.read()
with open(r"Lab06\Lab06\Models\Product.cs", "r", encoding="utf-8") as f:
    product_code = f.read()
with open(r"Lab06\Lab06\Services\ProductFileService.cs", "r", encoding="utf-8") as f:
    file_service_code = f.read()
with open(r"Lab06\Lab06\Services\SampleDataHelper.cs", "r", encoding="utf-8") as f:
    sample_helper_code = f.read()
with open(r"Lab06\Lab06\Program.cs", "r", encoding="utf-8") as f:
    program_code = f.read()
with open(r"Lab06\Lab06\Lab06.csproj", "r", encoding="utf-8") as f:
    csproj_code = f.read()

# -------------------------------------------------------------
# 1. TẠO FILE BaoCao_ThuyetTrinh_Lab06.html
# -------------------------------------------------------------
print("Đang biên soạn BaoCao_ThuyetTrinh_Lab06.html...")

baocao_html = """<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <title>Báo Cáo Thuyết Trình & Phân Tích Mã Nguồn Lab 06 - Nhóm 3</title>
    <style>
        @page {
            size: A4;
            margin: 16mm 14mm 16mm 14mm;
            @bottom-right {
                content: counter(page);
            }
        }
        
        * {
            box-sizing: border-box;
            -webkit-print-color-adjust: exact !important;
            print-color-adjust: exact !important;
        }

        body {
            font-family: 'Segoe UI', Arial, sans-serif;
            color: #2c3e50;
            line-height: 1.55;
            font-size: 13.5px;
            margin: 0;
            padding: 0;
            background: #fff;
        }

        /* Cover Page */
        .cover-page {
            height: 100vh;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            text-align: center;
            padding: 40px 20px;
            page-break-after: always;
            border: 4px double #1a365d;
        }

        .cover-header margin-top: 30px; }
        .cover-header h3 {
            font-size: 16px;
            font-weight: 600;
            color: #4a5568;
            margin-bottom: 5px;
            text-transform: uppercase;
            letter-spacing: 1px;
        }

        .cover-header h2 {
            font-size: 19px;
            color: #2b6cb0;
            margin: 0;
        }

        .cover-title {
            margin: auto 0;
        }

        .cover-title .tag {
            display: inline-block;
            background: #ebf8ff;
            color: #2b6cb0;
            padding: 6px 16px;
            border-radius: 20px;
            font-weight: bold;
            font-size: 13px;
            border: 1px solid #bee3f8;
            margin-bottom: 15px;
        }

        .cover-title h1 {
            font-size: 26px;
            color: #1a365d;
            margin: 10px 0 15px 0;
            line-height: 1.35;
            text-transform: uppercase;
        }

        .cover-title .subtitle {
            font-size: 15px;
            color: #4a5568;
            font-weight: 500;
        }

        .cover-info {
            background: #f7fafc;
            border: 1px solid #e2e8f0;
            border-radius: 8px;
            padding: 20px;
            margin: 20px auto;
            width: 88%;
            text-align: left;
        }

        .cover-info table {
            width: 100%;
            border-collapse: collapse;
        }

        .cover-info td {
            padding: 6px 10px;
            font-size: 14px;
        }

        .cover-info td.label {
            font-weight: bold;
            color: #2d3748;
            width: 35%;
        }

        .cover-footer {
            font-size: 13px;
            color: #718096;
            margin-bottom: 20px;
        }

        /* Typography & Layout */
        h1, h2, h3, h4 {
            color: #1a365d;
            margin-top: 1.4em;
            margin-bottom: 0.6em;
        }

        h1 {
            font-size: 19px;
            border-bottom: 2px solid #3182ce;
            padding-bottom: 6px;
            text-transform: uppercase;
        }

        h2 {
            font-size: 15.5px;
            color: #2b6cb0;
            border-left: 4px solid #3182ce;
            padding-left: 10px;
            margin-top: 1.2em;
        }

        h3 {
            font-size: 14px;
            color: #2d3748;
        }

        p {
            margin: 0.6em 0;
            text-align: justify;
        }

        ul, ol {
            margin: 0.5em 0;
            padding-left: 24px;
        }

        li {
            margin-bottom: 4px;
        }

        .page-break {
            page-break-after: always;
        }

        .no-break {
            page-break-inside: avoid;
        }

        /* Callouts */
        .callout {
            background: #f0f7ff;
            border-left: 4px solid #3182ce;
            padding: 12px 16px;
            margin: 14px 0;
            border-radius: 0 6px 6px 0;
            page-break-inside: avoid;
        }

        .callout-title {
            font-weight: bold;
            color: #2b6cb0;
            margin-bottom: 5px;
        }

        .callout-success {
            background: #f0fff4;
            border-left-color: #38a169;
        }
        .callout-success .callout-title { color: #276749; }

        .callout-warning {
            background: #fffaf0;
            border-left-color: #dd6b20;
        }
        .callout-warning .callout-title { color: #c05621; }

        /* Tables */
        table.data-table {
            width: 100%;
            border-collapse: collapse;
            margin: 14px 0;
            page-break-inside: avoid;
            font-size: 12.5px;
        }

        table.data-table th, table.data-table td {
            border: 1px solid #cbd5e0;
            padding: 8px 10px;
            text-align: left;
        }

        table.data-table th {
            background: #ebf8ff;
            color: #2c5282;
            font-weight: 700;
        }

        table.data-table tr:nth-child(even) {
            background: #f7fafc;
        }

        /* Code Blocks */
        pre {
            background: #1e1e1e;
            color: #dcdcdc;
            padding: 12px 14px;
            border-radius: 6px;
            font-family: 'Consolas', 'Courier New', monospace;
            font-size: 11.5px;
            line-height: 1.45;
            overflow-x: auto;
            margin: 10px 0;
            page-break-inside: avoid;
            border: 1px solid #333;
        }

        code {
            font-family: 'Consolas', 'Courier New', monospace;
            background: #edf2f7;
            color: #c53030;
            padding: 2px 5px;
            border-radius: 3px;
            font-size: 12px;
        }

        pre code {
            background: transparent;
            color: inherit;
            padding: 0;
            font-size: inherit;
        }

        .kw { color: #569cd6; font-weight: bold; }
        .type { color: #4ec9b0; }
        .str { color: #d69d85; }
        .num { color: #b5cea8; }
        .com { color: #57a64a; font-style: italic; }
        .func { color: #dcdcaa; }

        /* Diagrams */
        .diagram-box {
            background: #f8fafc;
            border: 1px solid #e2e8f0;
            border-radius: 8px;
            padding: 16px;
            margin: 16px 0;
            text-align: center;
            page-break-inside: avoid;
        }

        .state-flow {
            display: flex;
            justify-content: space-around;
            align-items: center;
            margin: 15px 0;
        }

        .state-node {
            background: #fff;
            border: 2px solid #3182ce;
            border-radius: 8px;
            padding: 10px 14px;
            width: 28%;
            box-shadow: 0 2px 4px rgba(0,0,0,0.05);
            text-align: center;
        }

        .state-node.active {
            border-color: #38a169;
            background: #f0fff4;
        }

        .state-node h4 {
            margin: 0 0 6px 0;
            color: #1a365d;
            font-size: 13px;
        }

        .state-node p {
            font-size: 11px;
            margin: 0;
            color: #4a5568;
            text-align: center;
        }

        .state-arrow {
            font-size: 20px;
            color: #a0aec0;
            font-weight: bold;
        }
    </style>
</head>
<body>

    <!-- TRANG BÌA -->
    <div class="cover-page">
        <div class="cover-header">
            <h3>BỘ GIÁO DỤC VÀ ĐÀO TẠO — KHOA CÔNG NGHỆ THÔNG TIN</h3>
            <h2>MÔN HỌC: COMP1019 – LẬP TRÌNH TRÊN WINDOWS</h2>
        </div>

        <div class="cover-title">
            <div class="tag">BÁO CÁO BÀI TẬP LỚN & TÀI LIỆU THUYẾT TRÌNH</div>
            <h1>HỆ THỐNG QUẢN LÝ SẢN PHẨM (PRODUCT MANAGER)<br>WINDOWS FORMS NÂNG CAO & DATAGRIDVIEW</h1>
            <div class="subtitle">Chủ đề chuyên sâu: StatusStrip Real-time, Thống kê tồn kho & Đọc/Ghi File (SaveFileDialog)</div>
        </div>

        <div class="cover-info">
            <table>
                <tr>
                    <td class="label">Đơn vị thực hiện:</td>
                    <td>Nhóm 3 – Lớp COMP1019</td>
                </tr>
                <tr>
                    <td class="label">Nền tảng công nghệ:</td>
                    <td>C# .NET 9.0 / Windows Forms / Visual Studio 2022</td>
                </tr>
                <tr>
                    <td class="label">Trạng thái mã nguồn:</td>
                    <td>Đã tối ưu giao diện gọn gàng, biên dịch hoàn tất (0 Warning, 0 Error)</td>
                </tr>
                <tr>
                    <td class="label">Thời điểm hoàn thiện:</td>
                    <td>Tháng 10 / 2026</td>
                </tr>
            </table>
        </div>

        <div class="cover-footer">
            Tài liệu phục vụ thuyết trình báo cáo, phản biện đồ án và hướng dẫn giải thích chi tiết mã nguồn
        </div>
    </div>

    <!-- MỤC I -->
    <h1>I. Tổng Quan Nhiệm Vụ Nhóm 3 (Theo Yêu Cầu Đề Bài)</h1>
    <p>
        Theo phân công đề tài Lab 06, <strong>Nhóm 3</strong> chịu trách nhiệm nghiên cứu chuyên sâu và xây dựng giải pháp hoàn thiện cho 3 chủ đề kỹ thuật cốt lõi:
    </p>

    <table class="data-table">
        <thead>
            <tr>
                <th style="width: 28%;">Chủ đề nghiên cứu</th>
                <th style="width: 32%;">Yêu cầu kỹ thuật</th>
                <th>Triển khai thực tế trong mã nguồn</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><strong>1. Cập nhật StatusStrip theo thời gian thực (Real-time)</strong></td>
                <td>Hiển thị trạng thái hành động vừa thực hiện (<em>"Vừa thêm SP..."</em>, <em>"Đã xóa..."</em>) và tổng số lượng sản phẩm. Cập nhật đồng hồ hệ thống từng giây.</td>
                <td>Sử dụng <code>ToolStripStatusLabel</code> (với thuộc tính <code>Spring = true</code>) phối hợp <code>System.Windows.Forms.Timer</code> (chu kỳ 1000ms).</td>
            </tr>
            <tr>
                <td><strong>2. Chỉ số thống kê tồn kho</strong></td>
                <td>Tính toán tổng giá trị tồn kho theo công thức: $\\text{Tổng giá trị} = \\sum (\\text{Số lượng} \\times \\text{Đơn giá})$ và hiển thị trực tiếp lên thanh StatusStrip.</td>
                <td>Duyệt qua danh sách <code>_bindingSource</code> để tính tổng tiền tức thời, tự động cập nhật khi thêm/sửa/xóa hoặc khi lọc danh mục.</td>
            </tr>
            <tr>
                <td><strong>3. Xuất file bằng SaveFileDialog & StreamWriter</strong></td>
                <td>Cho phép người dùng chọn vị trí lưu và xuất toàn bộ danh sách sản phẩm ra tệp tin <code>.txt</code> căn lề báo cáo hoặc <code>.csv</code> mở trên Excel.</td>
                <td>Xây dựng lớp <code>ProductFileService</code>, sử dụng mã hóa <code>UTF8Encoding(true)</code> (BOM) để chống lỗi font tiếng Việt trên Microsoft Excel.</td>
            </tr>
        </tbody>
    </table>

    <div class="callout callout-success">
        <div class="callout-title">Sản phẩm & Yêu cầu thuyết trình:</div>
        <ul>
            <li><strong>Demo trực tiếp:</strong> Minh họa thanh StatusStrip cập nhật tự động sau mỗi thao tác (Thêm, Sửa, Xóa, Lọc) và chức năng Xuất file ra đĩa cứng.</li>
            <li><strong>Báo cáo lý thuyết:</strong> Trình bày rõ ràng luồng xử lý I/O ghi file, kiến trúc Two-way Data Binding và công thức tính tổng tồn kho từ danh sách dữ liệu.</li>
        </ul>
    </div>

    <!-- MỤC II -->
    <div class="page-break"></div>
    <h1>II. Tại Sao Dùng Nó? So Sánh Chức Năng & Tính Thực Tiễn</h1>
    <p>
        Để đạt điểm tối đa trong phần phản biện với Giảng viên, nhóm làm rõ sự khác biệt giữa các giải pháp truyền thống (sơ sài) và các kỹ thuật chuyên nghiệp được áp dụng trong đồ án:
    </p>

    <h2>1. So sánh StatusStrip với MessageBox và Label thường</h2>
    <table class="data-table">
        <thead>
            <tr>
                <th>Tiêu chí đánh giá</th>
                <th><code>MessageBox.Show()</code></th>
                <th><code>Label</code> thường đặt trên Form</th>
                <th>✅ <code>StatusStrip</code> (Nhóm 3)</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><strong>Chặn luồng (Modal Blocking)</strong></td>
                <td>Có – buộc người dùng dừng thao tác để click nút OK.</td>
                <td>Không chặn luồng.</td>
                <td><strong>Không chặn luồng:</strong> Thông điệp hiển thị mượt mà, người dùng tiếp tục làm việc bình thường.</td>
            </tr>
            <tr>
                <td><strong>Vị trí chuẩn UI Windows</strong></td>
                <td>Hộp thoại nhảy ra giữa màn hình.</td>
                <td>Đặt rải rác tùy ý, dễ gây rối mắt.</td>
                <td><strong>Nằm cố định ở đáy cửa sổ</strong> theo chuẩn UX của các phần mềm chuyên nghiệp (VS Code, Excel, Word).</td>
            </tr>
            <tr>
                <td><strong>Hiển thị đa thông tin cùng lúc</strong></td>
                <td>Chỉ hiển thị được 1 đoạn văn bản duy nhất.</td>
                <td>Phải tạo nhiều Label rời rạc, khó căn chỉnh.</td>
                <td><strong>Chia thành nhiều ô độc lập</strong>: Thông báo hành động, Mặt hàng, Tổng tồn kho, Đồng hồ thời gian thực.</td>
            </tr>
            <tr>
                <td><strong>Khả năng co giãn (Responsive)</strong></td>
                <td>Không co giãn.</td>
                <td>Phải tự viết mã Anchor/Dock phức tạp.</td>
                <td>Tự động co giãn theo chiều rộng cửa sổ nhờ thuộc tính <code>Spring = true</code>.</td>
            </tr>
            <tr>
                <td><strong>Tính thực tiễn</strong></td>
                <td>Chỉ phù hợp cho lỗi nghiêm trọng hoặc xác nhận.</td>
                <td>Chỉ dùng cho nhãn tiêu đề tĩnh.</td>
                <td><strong>Chuẩn mực công nghiệp</strong> cho việc phản hồi trạng thái liên tục trong ứng dụng quản trị.</td>
            </tr>
        </tbody>
    </table>

    <h2>2. So sánh SaveFileDialog với Đường dẫn cố định (Hardcode Path)</h2>
    <table class="data-table">
        <thead>
            <tr>
                <th>Tiêu chí</th>
                <th>Đường dẫn cố định (VD: <code>C:\\output.txt</code>)</th>
                <th>✅ Sử dụng <code>SaveFileDialog</code> (Nhóm 3)</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><strong>Tính linh hoạt</strong></td>
                <td>Cố định 1 vị trí; file luôn bị ghi đè nếu không đổi tên.</td>
                <td><strong>Tự do hoàn toàn:</strong> Người dùng chủ động chọn thư mục lưu trữ và đặt tên file theo ý muốn.</td>
            </tr>
            <tr>
                <td><strong>Bảo mật & Phân quyền</strong></td>
                <td>Dễ văng lỗi <code>UnauthorizedAccessException</code> khi ghi vào ổ C:\\ hoặc Desktop máy khác.</td>
                <td>Windows đảm bảo an toàn phân quyền vì chính người dùng đã chọn vị trí lưu hợp lệ.</td>
            </tr>
            <tr>
                <td><strong>Đa dạng định dạng (Filter)</strong></td>
                <td>Chỉ xuất đúng 1 định dạng đã viết cứng trong mã.</td>
                <td>Hỗ trợ chuyển đổi linh hoạt giữa <code>.txt</code> và <code>.csv</code> qua bộ lọc Filter.</td>
            </tr>
            <tr>
                <td><strong>Cảnh báo ghi đè</strong></td>
                <td>Không cảnh báo, dễ làm mất dữ liệu quan trọng của người dùng.</td>
                <td>Tự động hiển thị hộp thoại xác nhận <em>"Tệp đã tồn tại, bạn có muốn ghi đè không?"</em>.</td>
            </tr>
        </tbody>
    </table>

    <h2>3. So sánh StreamWriter với File.WriteAllText()</h2>
    <table class="data-table">
        <thead>
            <tr>
                <th>Tiêu chí</th>
                <th><code>File.WriteAllText()</code></th>
                <th>✅ <code>StreamWriter</code> trong khối <code>using</code></th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><strong>Kiểm soát mã hóa (Encoding)</strong></td>
                <td>Mặc định UTF-8 không BOM, khi mở file CSV bằng Microsoft Excel sẽ bị <strong>lỗi font tiếng Việt</strong>.</td>
                <td>Chủ động thiết lập <code>new UTF8Encoding(true)</code>, ghi đúng 3 byte BOM (<code>EF BB BF</code>) giúp <strong>Excel hiển thị tiếng Việt hoàn hảo</strong>.</td>
            </tr>
            <tr>
                <td><strong>Cơ chế ghi dữ liệu</strong></td>
                <td>Phải gom toàn bộ văn bản vào 1 biến String khổng lồ trong RAM rồi mới ghi xuống đĩa.</td>
                <td>Ghi trực tiếp từng dòng dữ liệu qua luồng Stream đệm (Buffer), tiết kiệm bộ nhớ RAM tối đa.</td>
            </tr>
            <tr>
                <td><strong>An toàn tài nguyên (Resource Leak)</strong></td>
                <td>Nếu có lỗi giữa chừng, khó kiểm soát việc giải phóng Handle tệp tin.</td>
                <td>Cú pháp <code>using</code> tương đương <code>try-finally</code>, tự động gọi <code>Flush()</code> và <code>Dispose()</code> trong mọi tình huống.</td>
            </tr>
        </tbody>
    </table>

    <h2>4. So sánh BindingList&lt;Product&gt; với List&lt;Product&gt;</h2>
    <p>
        Trong Windows Forms, nếu liên kết DataGridView với <code>List&lt;Product&gt;</code> thông thường, mỗi khi thêm, sửa hoặc xóa dữ liệu, DataGridView <strong>hoàn toàn không tự động cập nhật</strong>. Lập trình viên buộc phải gán lại <code>DataSource = null</code> rồi gán lại danh sách, gây giật lag và mất vị trí cuộn trang.
    </p>
    <p>
        Ngược lại, <code>BindingList&lt;Product&gt;</code> hỗ trợ cơ chế <strong>Two-way Data Binding</strong>. Khi danh sách thay đổi, nó lập tức kích hoạt sự kiện <code>ListChanged</code>, DataGridView tự động vẽ lại chính xác dòng bị tác động mà không cần can thiệp thủ công.
    </p>

    <!-- MỤC III -->
    <div class="page-break"></div>
    <h1>III. Thiết Kế Giao Diện Tinh Gọn (App Product Manager Đơn Giản Hóa)</h1>
    <p>
        Để phần mềm vừa đáp ứng đầy đủ 100% tính năng theo đề bài, vừa mang phong cách hiện đại, thanh thoát và hiển thị hoàn hảo trên các màn hình máy chiếu độ phân giải vừa phải, nhóm đã thực hiện tái cấu trúc giao diện:
    </p>

    <h2>1. Bảng so sánh giao diện Ban đầu vs. Giao diện Tinh gọn mới</h2>
    <table class="data-table">
        <thead>
            <tr>
                <th>Hạng mục giao diện</th>
                <th>Phiên bản cồng kềnh ban đầu</th>
                <th>✅ Phiên bản Tinh gọn (Mới nhất)</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><strong>Kích thước cửa sổ</strong></td>
                <td>1220 &times; 704 px (Quá lớn, dễ tràn màn hình laptop 14 inch)</td>
                <td><strong>900 &times; 630 px</strong> (Vừa vặn tuyệt đối, gọn gàng, cân đối)</td>
            </tr>
            <tr>
                <td><strong>Thanh Header tiêu đề</strong></td>
                <td>Panel xanh đậm chiếm 70px chiều cao gây lãng phí không gian</td>
                <td><strong>Loại bỏ hoàn toàn</strong>; thông tin đặt gọn vào thanh tiêu đề TitleBar của Form</td>
            </tr>
            <tr>
                <td><strong>Khung hiển thị hình ảnh</strong></td>
                <td>Panel to 320 &times; 218 px làm phình to khung nhập liệu</td>
                <td>PictureBox <strong>135 &times; 110 px đặt gọn gàng góc phải</strong>, vẫn đảm bảo phóng to zoom ảnh</td>
            </tr>
            <tr>
                <td><strong>Kích thước các nút bấm</strong></td>
                <td>105 &times; 38 px (Cồng kềnh)</td>
                <td><strong>80 – 100 &times; 34 px</strong> (Thanh thoát, hiện đại, phối màu trực quan)</td>
            </tr>
            <tr>
                <td><strong>Độ dài thông báo StatusStrip</strong></td>
                <td>Dài dòng: <em>"📦 Mặt hàng: 5 | Tổng SL tồn: 85 chiếc"</em></td>
                <td>Ngắn gọn, súc tích: <em>"📦 5 mặt hàng | SL: 85"</em></td>
            </tr>
            <tr>
                <td><strong>Số dòng mã Designer</strong></td>
                <td>944 dòng</td>
                <td><strong>568 dòng</strong> (Giảm 40% mã nguồn thừa, tốc độ nạp Form cực nhanh)</td>
            </tr>
        </tbody>
    </table>

    <h2>2. Sơ đồ luồng trạng thái an toàn (Form State Machine)</h2>
    <div class="diagram-box">
        <h3 style="margin-top:0;">QUY TRÌNH CHUYỂN ĐỔI 3 TRẠNG THÁI FORM</h3>
        <div class="state-flow">
            <div class="state-node active">
                <h4>1. CHẾ ĐỘ XEM (VIEW)</h4>
                <p>Khóa toàn bộ chi tiết<br>Vô hiệu nút 'Cập nhật' & 'Hủy'<br>Bật Thêm, Sửa, Xóa, Xuất File</p>
            </div>
            <div class="state-arrow">➔</div>
            <div class="state-node">
                <h4>2. CHẾ ĐỘ THÊM (ADD)</h4>
                <p>Xóa trắng dữ liệu ô nhập<br>Mở khóa toàn bộ thông tin<br>Bật nút 'Cập nhật' & 'Hủy'</p>
            </div>
            <div class="state-arrow">➔</div>
            <div class="state-node">
                <h4>3. CHẾ ĐỘ SỬA (EDIT)</h4>
                <p>Mở khóa thông tin chi tiết<br>Khóa Mã SP (Khóa chính)<br>Bật nút 'Cập nhật' & 'Hủy'</p>
            </div>
        </div>
        <div style="font-size:12px; color:#718096; margin-top:8px;">
            Sau khi bấm <strong>"Cập nhật"</strong> (Lưu thành công) hoặc <strong>"Hủy bỏ"</strong>, hệ thống tự động đưa Form trở lại <strong>Chế độ Xem (View)</strong> để bảo vệ dữ liệu.
        </div>
    </div>

    <!-- MỤC IV -->
    <div class="page-break"></div>
    <h1>IV. Giải Thích Chi Tiết Toàn Bộ Code `Form1.Designer.cs` (Dòng 1 Đến Hết)</h1>
    <p>
        File <code>Form1.Designer.cs</code> gồm <strong>568 dòng mã</strong> được chia thành 10 khối chức năng logic rõ ràng:
    </p>

    <h2>Phần 1 (Dòng 1 – 15): Khai báo Partial Class & Cơ chế giải phóng bộ nhớ (Dispose)</h2>
    <ul>
        <li><code>partial class Form1</code>: Từ khóa <code>partial</code> cho phép tách đôi mã nguồn của lớp <code>Form1</code> thành 2 tệp: <code>Form1.cs</code> (chứa code nghiệp vụ) và <code>Form1.Designer.cs</code> (chứa code giao diện). Trình biên dịch C# sẽ tự động gộp lại thành một lớp duy nhất khi build.</li>
        <li><code>private System.ComponentModel.IContainer components = null;</code>: Khai báo thùng chứa (container) quản lý các thành phần phi giao diện (chẳng hạn như Timer) cần theo dõi vòng đời.</li>
        <li><code>protected override void Dispose(bool disposing)</code>: Phương thức giải phóng các tài nguyên không quản lý (Unmanaged Resources như handle GDI+, bút vẽ, phông chữ). Khi Form bị đóng, nó gọi <code>components.Dispose()</code> để tránh rò rỉ bộ nhớ (Memory Leak).</li>
    </ul>

    <h2>Phần 2 (Dòng 16 – 81): Hàm InitializeComponent, Khởi tạo đối tượng & Tạm dừng vẽ layout</h2>
    <ul>
        <li><code>private void InitializeComponent()</code>: Điểm khởi tạo toàn bộ giao diện, được gọi ngay trong hàm khởi tạo <code>Form1()</code>.</li>
        <li>Dòng 21 – 69: Khởi tạo mới (<code>new</code>) toàn bộ 35 đối tượng điều khiển (GroupBox, TextBox, ComboBox, NumericUpDown, DateTimePicker, PictureBox, Button, DataGridView, StatusStrip, Timer).</li>
        <li>Dòng 71 – 80 (<code>SuspendLayout()</code> và <code>BeginInit()</code>): Ra lệnh cho hệ điều hành Windows <strong>tạm dừng cơ chế vẽ lại màn hình</strong> trong lúc thiết lập hàng trăm thuộc tính. Kỹ thuật này giúp Form khởi động cực nhanh và triệt tiêu hoàn toàn hiện tượng nhấp nháy giao diện (Flickering).</li>
    </ul>

    <h2>Phần 3 (Dòng 82 – 105): Thiết lập GroupBox thông tin sản phẩm (grpThongTin)</h2>
    <ul>
        <li><code>grpThongTin.Dock = DockStyle.Top</code>: Neo cố định nhóm thông tin ở phía trên cùng của cửa sổ, tự động dàn trải chiều ngang khi co dãn màn hình.</li>
        <li><code>grpThongTin.Size = new Size(900, 210)</code>: Chiều cao được thu gọn xuống 210px (bản cũ là 245px), tạo thêm không gian rộng rãi cho bảng DataGridView bên dưới.</li>
        <li><code>grpThongTin.Controls.Add(...)</code>: Thêm toàn bộ các điều khiển con (nhãn, ô nhập liệu, ảnh, cụm nút bấm) vào bên trong khung.</li>
    </ul>

    <h2>Phần 4 (Dòng 106 – 202): Cấu hình các ô nhập liệu (Hàng 1 & Hàng 2)</h2>
    <ul>
        <li><strong>Hàng 1 (Dòng 107 – 146):</strong>
            <ul>
                <li><code>txtMaSP</code>: <code>ReadOnly = true</code> (mặc định khóa), <code>PlaceholderText = "VD: SP06"</code> hướng dẫn nhập.</li>
                <li><code>txtTenSP</code>: Ô nhập tên sản phẩm, kích thước 210px.</li>
                <li><code>cboLoaiSP</code>: <code>DropDownStyle = DropDownList</code> (chỉ cho phép chọn từ danh sách, không cho gõ linh tinh), gồm 7 danh mục: Điện thoại, Laptop, Máy tính bảng, Phụ kiện, Linh kiện, Thiết bị mạng, Khác.</li>
            </ul>
        </li>
        <li><strong>Hàng 2 (Dòng 148 – 202):</strong>
            <ul>
                <li><code>numDonGia</code>: <code>Maximum = 1,000,000,000</code> (1 tỷ VNĐ), <code>ThousandsSeparator = true</code> (hiển thị phân cách hàng nghìn như 29,990,000 VNĐ), căn phải số học.</li>
                <li><code>numSoLuong</code>: <code>Maximum = 100,000</code>, căn phải số học.</li>
                <li><code>dtpNgayNhap</code>: <code>CustomFormat = "dd/MM/yyyy"</code> định dạng ngày tháng theo chuẩn Việt Nam.</li>
                <li><code>chkConKinhDoanh</code>: CheckBox màu xanh lá (<code>DarkGreen</code>), mặc định là Checked (đang kinh doanh).</li>
            </ul>
        </li>
    </ul>

    <h2>Phần 5 (Dòng 203 – 218): Khung hình ảnh thu nhỏ (PictureBox) & Nút chọn ảnh</h2>
    <ul>
        <li><code>picHinhAnh</code>: Kích thước <strong>135 &times; 110 px</strong> đặt tại tọa độ (750, 20) góc phải trên. <code>SizeMode = PictureBoxSizeMode.Zoom</code> giúp ảnh luôn giữ đúng tỷ lệ khung hình, không bị méo mó.</li>
        <li><code>btnChonAnh</code>: Nút <em>"📷 Chọn ảnh"</em> đặt ngay dưới PictureBox, mặc định bị Disable và chỉ sáng lên khi bấm Thêm SP hoặc Chỉnh sửa.</li>
    </ul>

    <div class="page-break"></div>
    <h2>Phần 6 (Dòng 219 – 301): Cụm 7 nút bấm thao tác (pnlButtons)</h2>
    <p>
        Sử dụng <code>FlowLayoutPanel</code> giúp các nút tự động dồn hàng từ trái qua phải ngay ngắn:
    </p>
    <ul>
        <li><code>btnThem</code> (90 &times; 34 px): Màu xanh lá <code>RGB(46, 125, 50)</code> – Mở form thêm mới.</li>
        <li><code>btnChinhSua</code> (95 &times; 34 px): Màu cam <code>RGB(230, 126, 34)</code> – Mở khóa sửa dòng đang chọn.</li>
        <li><code>btnCapNhat</code> (100 &times; 34 px): Màu xanh dương <code>RGB(21, 101, 192)</code> – Mặc định <strong>Disabled</strong>, chỉ sáng khi Thêm/Sửa.</li>
        <li><code>btnHuy</code> (80 &times; 34 px): Màu xám ghi <code>RGB(120, 144, 156)</code> – Mặc định <strong>Disabled</strong>, hủy bỏ thao tác.</li>
        <li><code>btnXoa</code> (80 &times; 34 px): Màu đỏ <code>RGB(198, 40, 40)</code> – Xóa sản phẩm kèm hộp thoại xác nhận.</li>
        <li><code>btnLamMoi</code> (90 &times; 34 px): Màu xám đậm <code>RGB(69, 90, 100)</code> – Khôi phục toàn bộ danh sách gốc.</li>
        <li><code>btnXuatFile</code> (100 &times; 34 px): Màu tím <code>RGB(106, 27, 154)</code> – Mở hộp thoại xuất file TXT/CSV.</li>
    </ul>

    <h2>Phần 7 (Dòng 302 – 359): Khung danh sách (grpDanhSach) & Thanh tìm kiếm/Lọc nhanh (pnlSearch)</h2>
    <ul>
        <li><code>grpDanhSach.Dock = DockStyle.Fill</code>: Tự động chiếm trọn vẹn toàn bộ phần diện tích còn lại ở giữa cửa sổ.</li>
        <li><code>txtTimKiem</code>: Gắn sự kiện <code>TextChanged += txtTimKiem_TextChanged</code> – Lọc kết quả real-time ngay khi gõ từng ký tự.</li>
        <li><code>cboLocLoai</code>: Gắn sự kiện <code>SelectedIndexChanged</code> – Lọc theo nhóm danh mục tức thì.</li>
        <li><code>btnBoLoc</code>: Nút "Bỏ lọc" giúp xóa từ khóa tìm kiếm và đưa ComboBox về vị trí <em>"-- Tất cả loại --"</em>.</li>
    </ul>

    <h2>Phần 8 (Dòng 360 – 450): Bảng hiển thị dữ liệu DataGridView (dgvSanPham)</h2>
    <ul>
        <li><code>AutoGenerateColumns = false</code>: Tắt tính năng tự sinh cột để kiểm soát 100% thứ tự, kiểu dáng và độ rộng từng cột.</li>
        <li><code>ReadOnly = true</code> và <code>SelectionMode = FullRowSelect</code>: Khóa không cho người dùng sửa trực tiếp trên ô, click chọn là chọn trọn vẹn cả hàng.</li>
        <li>Header màu xanh navy sang trọng (<code>RGB(37, 64, 97)</code>), dòng xen kẽ sọc xanh nhạt (<code>RGB(245, 248, 252)</code>) chống mỏi mắt.</li>
        <li>8 cột dữ liệu liên kết chuẩn qua <code>DataPropertyName</code>: Mã SP (70px), Tên SP (AutoFill chiếm trọn không gian trống), Loại SP (110px), Đơn giá (130px - Format N0), SL Tồn (75px), Thành tiền (140px - Format N0), Ngày nhập (100px - dd/MM/yyyy), và Cột Checkbox Kinh doanh (45px).</li>
    </ul>

    <h2>Phần 9 (Dòng 451 – 482): Thanh trạng thái StatusStrip & Timer đồng hồ</h2>
    <ul>
        <li><code>statusStrip1.Dock = DockStyle.Bottom</code>: Luôn nằm cố định ở chân Form.</li>
        <li><code>lblTrangThai</code>: Thiết lập <code>Spring = true</code> để tự động giãn rộng sang bên phải, hiển thị thông điệp thao tác hiện tại.</li>
        <li><code>lblTongSanPham</code>: Chữ đậm xanh navy báo cáo tổng số mặt hàng và tổng lượng tồn kho.</li>
        <li><code>lblTongGiaTriTonKho</code>: Chữ đậm màu đỏ <code>DarkRed</code> làm nổi bật tổng giá trị quy đổi thành tiền của toàn bộ kho.</li>
        <li><code>lblDongHo</code> & <code>timerDongHo</code>: Timer chu kỳ 1000ms kích hoạt sự kiện <code>timerDongHo_Tick</code> để hiển thị ngày giờ chuẩn xác theo thời gian thực.</li>
    </ul>

    <h2>Phần 10 (Dòng 483 – 568): Cấu hình Form tổng thể & Khai báo biến thành viên (Fields)</h2>
    <ul>
        <li><code>ClientSize = new Size(900, 630)</code> và <code>MinimumSize = new Size(800, 560)</code>.</li>
        <li><code>StartPosition = FormStartPosition.CenterScreen</code>: Mở cửa sổ ngay giữa màn hình khi chạy.</li>
        <li>Dòng 498 – 511 (<code>ResumeLayout()</code> và <code>PerformLayout()</code>): Bật lại cơ chế vẽ màn hình và hoàn tất sắp đặt bố cục.</li>
        <li>Dòng 516 – 568: Khai báo toàn bộ 35 biến điều khiển <code>private</code> để file logic <code>Form1.cs</code> có thể truy cập và tương tác.</li>
    </ul>

    <!-- MỤC V -->
    <div class="page-break"></div>
    <h1>V. Kịch Bản Thuyết Trình Bài Bản & Câu Hỏi Phản Biện Thường Gặp</h1>

    <h2>1. Kịch bản thuyết trình 7 bước (Demo trực quan trên máy)</h2>
    <table class="data-table">
        <thead>
            <tr>
                <th style="width: 8%; text-align:center;">Bước</th>
                <th style="width: 32%;">Lời thoại người thuyết trình</th>
                <th style="width: 30%;">Thao tác thực hiện trên máy tính</th>
                <th>Điểm nhấn cần chỉ cho Giảng viên</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td style="text-align:center;"><strong>1</strong></td>
                <td><em>"Chào Thầy/Cô, nhóm em xin demo phần mềm ProductManager với giao diện tinh gọn và chuyên sâu Nhóm 3."</em></td>
                <td>Chạy ứng dụng từ Visual Studio.</td>
                <td>Form mở lên 900&times;630 cực kỳ vừa vặn. Toàn bộ ô chi tiết bị KHÓA, nút Cập nhật bị Disable để chống sửa nhầm.</td>
            </tr>
            <tr>
                <td style="text-align:center;"><strong>2</strong></td>
                <td><em>"Khi click các dòng trên DataGridView, dữ liệu và ảnh minh họa được nạp lên để XEM CHI TIẾT."</em></td>
                <td>Click chọn lần lượt các dòng sản phẩm trên bảng.</td>
                <td>Thông tin nhảy lên các ô nhập, PictureBox đổi ảnh tương ứng. Các ô hoàn toàn ở trạng thái chỉ đọc.</td>
            </tr>
            <tr>
                <td style="text-align:center;"><strong>3</strong></td>
                <td><em>"Quan sát StatusStrip dưới cùng: Hiển thị trạng thái 'Sẵn sàng', tổng 5 mặt hàng, tổng tồn kho và đồng hồ chạy từng giây."</em></td>
                <td>Chỉ chuột vào thanh StatusStrip dưới chân Form.</td>
                <td>Nhãn trạng thái dạt trái (Spring=true), tổng tiền tính đúng bằng $\\sum(\\text{SL} \\times \\text{Đơn giá})$.</td>
            </tr>
            <tr>
                <td style="text-align:center;"><strong>4</strong></td>
                <td><em>"Bây giờ em bấm '➕ Thêm SP': Hệ thống xóa trắng ô nhập, MỞ KHÓA các trường và SÁNG nút 'Cập nhật'."</em></td>
                <td>Bấm <strong>➕ Thêm SP</strong> &rarr; Nhập SP06, Tên, Đơn giá &rarr; Bấm <strong>💾 Cập nhật</strong>.</td>
                <td>Lưu thành công, sản phẩm vào DataGridView, các ô TỰ ĐỘNG KHÓA LẠI, nút Cập nhật tắt, tổng tồn kho StatusStrip nhảy tức thì!</td>
            </tr>
            <tr>
                <td style="text-align:center;"><strong>5</strong></td>
                <td><em>"Chức năng 'Chỉnh sửa': Chỉ khi ấn nút 'Chỉnh sửa' thì mới mở khóa thông tin để sửa lại."</em></td>
                <td>Chọn SP01 &rarr; Bấm <strong>✏️ Chỉnh sửa</strong> &rarr; Sửa đơn giá &rarr; Bấm <strong>Cập nhật</strong>.</td>
                <td>Mã SP được giữ nguyên, thông tin lưu lại và Form tự động quay về chế độ Xem an toàn.</td>
            </tr>
            <tr>
                <td style="text-align:center;"><strong>6</strong></td>
                <td><em>"Demo Tìm kiếm và Lọc danh mục theo thời gian thực."</em></td>
                <td>Gõ chữ "iphone" hoặc chọn loại "Điện thoại" &rarr; Bấm "Bỏ lọc".</td>
                <td>Bảng lọc tức thì; StatusStrip tính tổng tồn kho riêng cho nhóm đang lọc. Bấm Bỏ lọc khôi phục toàn bộ.</td>
            </tr>
            <tr>
                <td style="text-align:center;"><strong>7</strong></td>
                <td><em>"Tính năng trọng tâm Nhóm 3: Xuất báo cáo bằng SaveFileDialog & StreamWriter."</em></td>
                <td>Bấm <strong>📤 Xuất File</strong> &rarr; Chọn file .txt và .csv &rarr; Mở file kiểm tra.</td>
                <td>Notepad mở lên bảng biểu căn lề thẳng hàng; Excel mở file CSV hiển thị tiếng Việt có dấu chuẩn 100% không vỡ font.</td>
            </tr>
        </tbody>
    </table>

    <h2>2. Câu hỏi phản biện thường gặp của Giảng viên & Câu trả lời mẫu</h2>
    <div class="callout">
        <div class="callout-title">Câu hỏi 1: Tại sao bình thường nhóm lại khóa hết các ô chi tiết và chỉ mở nút Cập nhật khi bấm Thêm hoặc Sửa?</div>
        <p><strong>Trả lời:</strong> Đây là nguyên tắc <em>Form State Management</em> (Quản lý trạng thái giao diện) trong các hệ thống chuyên nghiệp. Nếu luôn mở ô nhập liệu, người dùng khi click xem chi tiết rất dễ vô tình chạm bàn phím làm thay đổi sai lệch dữ liệu gốc. Việc khóa mặc định và chỉ mở khi người dùng xác nhận ý định (qua nút Thêm hoặc Sửa) giúp bảo vệ tính toàn vẹn dữ liệu cao nhất.</p>
    </div>

    <div class="callout">
        <div class="callout-title">Câu hỏi 2: Tại sao khi ghi file bằng StreamWriter nhóm lại đặt trong khối `using (...)`?</div>
        <p><strong>Trả lời:</strong> Khối <code>using</code> trong C# là cú pháp viết gọn của cấu trúc <code>try-finally</code> kết hợp phương thức <code>Dispose()</code>. Nó đảm bảo kể cả khi quá trình ghi file gặp sự cố ngắt quãng hoặc lỗi đột ngột, luồng ghi file vẫn chắc chắn được đẩy hết dữ liệu đệm xuống đĩa (<code>Flush</code>) và đóng tệp (<code>Close</code>), không bao giờ bị tình trạng tệp bị Windows khóa cứng.</p>
    </div>

    <div class="callout">
        <div class="callout-title">Câu hỏi 3: Làm thế nào để file CSV khi mở trực tiếp bằng Microsoft Excel không bị lỗi font tiếng Việt?</div>
        <p><strong>Trả lời:</strong> Microsoft Excel mặc định khi mở file CSV sẽ đọc theo bảng mã ANSI/Windows-1252 nếu không thấy ký hiệu nhận diện. Để khắc phục, nhóm em khởi tạo luồng ghi bằng <code>new StreamWriter(filePath, false, new UTF8Encoding(true))</code>. Tham số <code>true</code> yêu cầu tự động chèn 3 byte tiền tố Byte Order Mark (BOM - <code>0xEF, 0xBB, 0xBF</code>) vào đầu tệp, giúp Excel nhận diện ngay lập tức là mã UTF-8 và hiển thị tiếng Việt hoàn hảo.</p>
    </div>

</body>
</html>
"""

with open(r"BaoCao_ThuyetTrinh_Lab06.html", "w", encoding="utf-8") as f:
    f.write(baocao_html)

# -------------------------------------------------------------
# 2. TẠO FILE TONG_HOP_TOAN_BO_CODE_LAB06.html
# -------------------------------------------------------------
print("Đang biên soạn TONG_HOP_TOAN_BO_CODE_LAB06.html...")

code_html = f"""<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <title>Tổng Hợp Toàn Bộ Code Lab 06 - Nhóm 3 (Đã Tối Ưu)</title>
    <style>
        @page {{
            size: A4;
            margin: 14mm 12mm 14mm 12mm;
        }}
        * {{
            box-sizing: border-box;
            -webkit-print-color-adjust: exact !important;
            print-color-adjust: exact !important;
        }}
        body {{
            font-family: 'Segoe UI', Arial, sans-serif;
            color: #2c3e50;
            line-height: 1.5;
            font-size: 12.5px;
            margin: 0;
            padding: 0;
        }}
        h1 {{
            color: #1a365d;
            font-size: 18px;
            border-bottom: 2px solid #3182ce;
            padding-bottom: 5px;
            margin-top: 1.2em;
        }}
        h2 {{
            color: #2b6cb0;
            font-size: 14.5px;
            border-left: 4px solid #3182ce;
            padding-left: 8px;
            margin-top: 1.2em;
        }}
        pre {{
            background: #1e1e1e;
            color: #dcdcdc;
            padding: 10px 12px;
            border-radius: 6px;
            font-family: 'Consolas', 'Courier New', monospace;
            font-size: 11px;
            line-height: 1.42;
            overflow-x: auto;
            border: 1px solid #333;
            page-break-inside: avoid;
        }}
        code {{
            font-family: 'Consolas', 'Courier New', monospace;
            background: #edf2f7;
            color: #c53030;
            padding: 2px 4px;
            border-radius: 3px;
            font-size: 11.5px;
        }}
        pre code {{
            background: transparent;
            color: inherit;
            padding: 0;
        }}
        table {{
            width: 100%;
            border-collapse: collapse;
            margin: 12px 0;
            font-size: 12px;
            page-break-inside: avoid;
        }}
        th, td {{
            border: 1px solid #cbd5e0;
            padding: 7px 9px;
            text-align: left;
        }}
        th {{
            background: #ebf8ff;
            color: #2c5282;
            font-weight: bold;
        }}
        tr:nth-child(even) {{
            background: #f7fafc;
        }}
        .page-break {{
            page-break-after: always;
        }}
    </style>
</head>
<body>
<h1>TỔNG HỢP TOÀN BỘ MÃ NGUỒN (SOURCE CODE) DỰ ÁN LAB 06</h1>
<p><strong>Môn học:</strong> COMP1019 – Lập trình trên Windows | <strong>Nhóm 3:</strong> StatusStrip Real-time, Thống kê tồn kho & Đọc/Ghi File</p>
<p><strong>Trạng thái:</strong> Toàn bộ mã nguồn đã được tối ưu hóa giao diện tinh gọn (900 &times; 630 px), biên dịch thành công 0 Warning, 0 Error.</p>

<hr style="border:0; border-top:1px solid #cbd5e0; margin:15px 0;">

<h2>1. Tệp 1: Models/Product.cs (Thực thể sản phẩm)</h2>
<pre><code class="csharp">{html.escape(product_code)}</code></pre>

<div class="page-break"></div>
<h2>2. Tệp 2: Services/ProductFileService.cs (Dịch vụ xuất file TXT & CSV)</h2>
<pre><code class="csharp">{html.escape(file_service_code)}</code></pre>

<div class="page-break"></div>
<h2>3. Tệp 3: Services/SampleDataHelper.cs (Dữ liệu mẫu & Đồ họa GDI+)</h2>
<pre><code class="csharp">{html.escape(sample_helper_code)}</code></pre>

<div class="page-break"></div>
<h2>4. Tệp 4: Form1.Designer.cs (Giao diện tinh gọn mới - 568 dòng)</h2>
<pre><code class="csharp">{html.escape(designer_code)}</code></pre>

<div class="page-break"></div>
<h2>5. Tệp 5: Form1.cs (Logic nghiệp vụ, Quản lý Form State & StatusStrip)</h2>
<pre><code class="csharp">{html.escape(form1_code)}</code></pre>

<div class="page-break"></div>
<h2>6. Tệp 6: Program.cs & Lab06.csproj</h2>
<pre><code class="csharp">{html.escape(program_code)}</code></pre>
<pre><code class="xml">{html.escape(csproj_code)}</code></pre>

</body>
</html>
"""

with open(r"TONG_HOP_TOAN_BO_CODE_LAB06.html", "w", encoding="utf-8") as f:
    f.write(code_html)

print("Đã tạo thành công 2 file HTML. Đang tiến hành xuất sang file PDF bằng Microsoft Edge headless...")

edge_path = r"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"
if not os.path.exists(edge_path):
    edge_path = r"C:\Program Files\Microsoft\Edge\Application\msedge.exe"

# 1. Xuất BaoCao_ThuyetTrinh_Lab06_Nhom3.pdf
pdf1 = os.path.abspath(r"BaoCao_ThuyetTrinh_Lab06_Nhom3.pdf")
html1 = os.path.abspath(r"BaoCao_ThuyetTrinh_Lab06.html")
cmd1 = [edge_path, "--headless", "--disable-gpu", "--no-pdf-header-footer", f"--print-to-pdf={pdf1}", f"file:///{html1.replace(chr(92), '/')}"]
subprocess.run(cmd1, check=True)
print(f"-> Đã xuất PDF 1: {pdf1} ({os.path.getsize(pdf1):,} bytes)")

# 2. Xuất TONG_HOP_TOAN_BO_CODE_LAB06.pdf
pdf2 = os.path.abspath(r"TONG_HOP_TOAN_BO_CODE_LAB06.pdf")
html2 = os.path.abspath(r"TONG_HOP_TOAN_BO_CODE_LAB06.html")
cmd2 = [edge_path, "--headless", "--disable-gpu", "--no-pdf-header-footer", f"--print-to-pdf={pdf2}", f"file:///{html2.replace(chr(92), '/')}"]
subprocess.run(cmd2, check=True)
print(f"-> Đã xuất PDF 2: {pdf2} ({os.path.getsize(pdf2):,} bytes)")

print("HOÀN TẤT TOÀN BỘ QUÁ TRÌNH XUẤT PDF!")
