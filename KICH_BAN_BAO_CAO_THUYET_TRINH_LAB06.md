# KỊCH BẢN BÁO CÁO & THUYẾT TRÌNH BÀI TẬP LAB 06
## MÔN HỌC: COMP1019 – LẬP TRÌNH TRÊN WINDOWS
### ĐỀ TÀI: PRODUCT MANAGER (WINDOWS FORMS NÂNG CAO & DATAGRIDVIEW)
### BÁO CÁO CHUYÊN SÂU NHÓM 3: STATUSSTRIP REAL-TIME, THỐNG KÊ TỒN KHO & XUẤT FILE BÁO CÁO (SAVEDIALOG & STREAMWRITER)

---

## 📌 THÔNG TIN CHUNG
* **Đối tượng báo cáo:** Giảng viên bộ môn và sinh viên lớp học phần COMP1019.
* **Thời lượng dự kiến:** 10 – 15 phút (bao gồm Demo & Hỏi đáp phản biện).
* **Người thực hiện:** Thành viên Nhóm 3.
* **Mục tiêu buổi báo cáo:**
  1. Thuyết trình rõ ràng kiến trúc mã nguồn và luồng hoạt động chuẩn mực của ứng dụng.
  2. Thực hiện thao tác Demo phần mềm mượt mà, chuyên nghiệp, không vấp lỗi.
  3. Phân tích chi tiết các kỹ thuật chuyên sâu điểm cộng (StatusStrip, Thống kê kho, MemoryStream, Xuất file UTF-8 BOM).
  4. Trả lời sắc bén, tự tin các câu hỏi vấn đáp / phản biện từ Giảng viên.

---

## PHẦN 1: PHÂN BỔ THỜI GIAN & TIẾN TRÌNH THUYẾT TRÌNH

| Giai đoạn | Nội dung chính | Thời lượng gợi ý | Người phụ trách |
|:---|:---|:---:|:---:|
| **Mở đầu (1 - 2 phút)** | Chào hỏi, giới thiệu thành viên, mục tiêu đồ án Lab 06 & nội dung Nhóm 3 | 2 phút | Người dẫn / Nhóm trưởng |
| **Kiến trúc & Trạng thái (3 - 4 phút)** | Trình bày mô hình 3 tầng, State Pattern Form và Two-way Data Binding | 3 phút | Thành viên thuyết trình 1 |
| **Demo Trực quan (4 - 5 phút)** | Thao tác trực tiếp trên phần mềm theo từng chức năng nghiệp vụ | 5 phút | Thành viên Demo máy tính |
| **Chuyên sâu kỹ thuật (2 - 3 phút)** | Trình bày StatusStrip Real-time, MemoryStream chống khóa ảnh, Xuất CSV UTF-8 BOM | 3 phút | Thành viên thuyết trình 2 |
| **Hỏi đáp & Phản biện (2 - 3 phút)** | Trả lời câu hỏi của Giảng viên và lớp | 2 phút | Toàn bộ nhóm |

---

## PHẦN 2: LỜI THOẠI CHI TIẾT THEO TỪNG SLIDE / MÀN HÌNH

### 🎤 SLIDE 1: GIỚI THIỆU ĐỀ TÀI & MỤC TIÊU (0:00 - 1:30)

> **Lời thoại:**
> *"Kính chào Thầy/Cô và toàn thể các bạn sinh viên đang có mặt trong buổi báo cáo hôm nay.*
>
> *Em xin đại diện cho **Nhóm 3** trình bày kết quả thực hiện đồ án **Lab 06 – Ứng dụng Quản lý Sản phẩm (Product Manager)** thuộc học phần Lập trình trên Windows.*
>
> *Bài Lab 06 đặt ra yêu cầu xây dựng ứng dụng Windows Forms kết hợp DataGridView nâng cao, quản lý thông tin các mặt hàng thiết bị công nghệ với đầy đủ hình ảnh, giá cả và số lượng.*
>
> *Bên cạnh việc đáp ứng 100% các tiêu chí cơ bản của đề bài, Nhóm 3 chúng em chọn nghiên cứu và triển khai chuyên sâu vào 3 vấn đề then chốt trong thực tế doanh nghiệp:*
> 1. *Thanh trạng thái **StatusStrip Real-time** hiển thị phản hồi tức thì và đồng hồ hệ thống.*
> 2. *Thuật toán **Thống kê tồn kho động** (tổng số lượng, tổng giá trị tồn kho theo bộ lọc).*
> 3. *Cơ chế **Đọc/Ghi file báo cáo chuyên nghiệp** bằng `SaveFileDialog` và `StreamWriter`, hỗ trợ xuất file Text căn lề thẳng hàng và Excel CSV chuẩn tiếng Việt có dấu."*

---

### 🎤 SLIDE 2: KIẾN TRÚC MÃ NGUỒN & TWO-WAY DATA BINDING (1:30 - 3:00)

> **Lời thoại:**
> *"Thưa Thầy/Cô, để phần mềm vận hành trơn tru và dễ bảo trì, nhóm em chia cấu trúc mã nguồn thành 3 khối trách nhiệm độc lập:*
> - *Khối **Models**: Chứa lớp `Product.cs` đại diện cho đối tượng hàng hóa.*
> - *Khối **Services**: Gồm `ProductFileService.cs` xử lý xuất file I/O và `SampleDataHelper.cs` sinh sẵn 5 mặt hàng mẫu cùng ảnh minh họa bằng đồ họa GDI+.*
> - *Khối **Presentation**: Là `Form1.cs` điều phối giao diện.*
>
> *Một điểm đặc biệt trong mã nguồn của nhóm là **không sử dụng `List<Product>` thông thường**, mà sử dụng cặp đôi **`BindingList<Product>` và `BindingSource`**.*
>
> *Nhờ `BindingList`, khi ta thêm, sửa hay xóa một sản phẩm, danh sách sẽ tự động phát sinh sự kiện `ListChanged`, giúp DataGridView tự cập nhật giao diện mà không cần lập trình viên phải gán lại `DataSource = null` gây giật màn hình.*
> *Đồng thời, `BindingSource` đóng vai trò proxy trung gian giúp chức năng Tìm kiếm và Lọc danh mục diễn ra mượt mà mà không làm mất dữ liệu gốc."*

---

### 🎤 SLIDE 3: THIẾT KẾ LUỒNG TRẠNG THÁI FORM AN TOÀN (STATE PATTERN) (3:00 - 4:30)

> **Lời thoại:**
> *"Trong trải nghiệm người dùng thực tế, nếu để các ô thông tin chi tiết luôn mở, người dùng rất dễ gõ nhầm bàn phím làm sai lệch dữ liệu khi chỉ có ý định xem.*
>
> *Do đó, nhóm em đã áp dụng mẫu thiết kế **Form State Machine** với 3 trạng thái nghiêm ngặt:*
> 1. *Trạng thái 1 – **Chế độ Xem (View)**: Đây là trạng thái mặc định khi mở Form. Tất cả các ô nhập liệu (Mã, Tên, Loại, Đơn giá, Số lượng, Ảnh...) đều bị **KHÓA CHỈ ĐỌC (ReadOnly = true)**. Nút 'Cập nhật' và 'Hủy' bị làm mờ (Disable). Người dùng click chọn dòng nào trên bảng thì thông tin chi tiết dòng đó hiển thị lên form.*
> 2. *Trạng thái 2 – **Chế độ Thêm mới (Add)**: Kích hoạt khi bấm nút 'Thêm SP'. Lúc này form xóa trắng toàn bộ các ô, mở khóa tất cả các trường nhập liệu và kích hoạt nút 'Cập nhật' & 'Hủy'.*
> 3. *Trạng thái 3 – **Chế độ Chỉnh sửa (Edit)**: Chỉ mở khóa khi người dùng chọn một sản phẩm và bấm nút 'Chỉnh sửa'. Lúc này, **Mã sản phẩm vẫn được KHÓA** vì là khóa chính định danh không được đổi, các trường còn lại được mở khóa để người dùng sửa đổi.*
>
> *Sau khi bấm 'Cập nhật' lưu thành công hoặc bấm 'Hủy', Form lập tức quay về trạng thái View an toàn."*

---

### 🎤 SLIDE 4 & DEMO TRỰC TIẾP TRÊN PHẦN MỀM (4:30 - 9:30)

*(Người thuyết trình chuyển qua cửa sổ Visual Studio hoặc bật ứng dụng chạy trực tiếp, phối hợp nói và thao tác theo kịch bản từng bước dưới đây)*

#### Bước 1: Khởi động chương trình & Giới thiệu Giao diện Ban đầu
* **Hành động:** Chạy ứng dụng (`F5`).
* **Lời nói:**
  > *"Như Thầy/Cô đang quan sát trên màn hình, khi ứng dụng vừa khởi động, hệ thống đã nạp sẵn **5 sản phẩm mẫu** gồm điện thoại, laptop, phụ kiện công nghệ cùng hình ảnh minh họa sắc nét.*
  > *Toàn bộ các ô nhập bên trái đang ở trạng thái KHÓA hoàn toàn, nút 'Cập nhật' và 'Hủy' bị mờ đi. Thanh StatusStrip phía dưới cùng báo trạng thái màu xanh lá: '🟢 Sẵn sàng | Đã nạp thành công 5 sản phẩm mẫu'. Bên phải thanh trạng thái hiển thị tổng 5 mặt hàng, tổng tồn kho 85 chiếc và tổng giá trị là 1.156.400.000 VNĐ cùng đồng hồ thời gian thực."*

#### Bước 2: Duyệt xem chi tiết sản phẩm
* **Hành động:** Dùng chuột click lần lượt vào SP01 (iPhone 15), SP02 (MacBook Air), SP03 (Logitech).
* **Lời nói:**
  > *"Khi em click chọn từng dòng trên DataGridView, sự kiện `SelectionChanged` lập tức nạp Mã, Tên, Đơn giá, Số lượng và **hình ảnh minh họa** tương ứng lên PictureBox.*
  > *StatusStrip cập nhật ngay: '🔍 Đang xem chi tiết SP: [SP02] - MacBook Air M3 16GB'. Dù em cố tình gõ phím vào ô Tên hay Đơn giá, phần mềm đều chặn lại vì đang ở chế độ Xem an toàn."*

#### Bước 3: Thêm mới sản phẩm (Validation & Cập nhật StatusStrip)
* **Hành động:**
  - Bấm nút **➕ Thêm SP**.
  - Nhập thử trùng mã `SP01` &rarr; Bấm **Cập nhật** &rarr; Hiện thông báo lỗi trùng mã.
  - Sửa lại: Mã SP `SP06`, Tên `iPad Pro M4`, Loại `Máy tính bảng`, Đơn giá `28.500.000`, Số lượng `10`.
  - Bấm nút **Chọn ảnh** &rarr; Chọn một tấm ảnh bất kỳ.
  - Bấm **💾 Cập nhật**.
* **Lời nói:**
  > *"Bây giờ em bấm 'Thêm SP'. Form lập tức chuyển sang chế độ Add: xóa trắng các ô và mở khóa nhập liệu, nút Cập nhật sáng lên.*
  > *Nếu em cố tình nhập trùng mã SP01, phần mềm có cơ chế Validation kiểm tra trùng lặp và cảnh báo ngay lập tức.*
  > *Em sửa lại mã hợp lệ là SP06 - iPad Pro M4, chọn ảnh và bấm 'Cập nhật'. Dữ liệu lập tức được thêm vào bảng, form tự động khóa lại để bảo vệ dữ liệu, và StatusStrip phía dưới nhảy ngay: Mặt hàng tăng lên 6, tổng tồn kho tăng lên 95 chiếc và tổng giá trị tự động cộng dồn thêm 285 triệu đồng."*

#### Bước 4: Chỉnh sửa sản phẩm an toàn
* **Hành động:**
  - Chọn sản phẩm `SP01`.
  - Bấm nút **✏️ Chỉnh sửa**.
  - Chỉ cho Thầy/Cô thấy ô Mã SP (`txtMaSP`) bị khóa cứng màu xám, ô Tên và Đơn giá mở khóa.
  - Sửa số lượng tồn từ `15` thành `20`.
  - Bấm **💾 Cập nhật**.
* **Lời nói:**
  > *"Tiếp theo là thao tác Chỉnh sửa. Em chọn SP01 và bấm 'Chỉnh sửa'. Quý Thầy/Cô có thể thấy ô Mã SP vẫn bị khóa cứng để đảm bảo tính toàn vẹn khóa chính, các ô còn lại được mở.*
  > *Em điều chỉnh số lượng tồn từ 15 lên 20 chiếc rồi bấm 'Cập nhật'. Thông tin trên DataGridView lập tức đồng bộ, tổng tiền tồn kho trên StatusStrip tăng thêm tương ứng."*

#### Bước 5: Tìm kiếm & Lọc sản phẩm Real-time
* **Hành động:**
  - Gõ vào ô Tìm kiếm từ khóa: `phone` hoặc `pro`.
  - Chọn ComboBox Lọc loại: `Điện thoại`.
  - Bấm **Bỏ lọc**.
* **Lời nói:**
  > *"Điểm nhấn tiếp theo là tính năng Lọc và Tìm kiếm Real-time qua BindingSource. Khi em gõ chữ 'pro', DataGridView lọc tức thời mà không cần bấm nút tìm kiếm.*
  > *Đặc biệt, **StatusStrip phía dưới tự động tính toán lại tổng số lượng và tổng tồn kho RIÊNG CHO CÁC SẢN PHẨM ĐANG HIỂN THỊ**. Khi em bấm 'Bỏ lọc', bảng khôi phục đầy đủ toàn bộ danh mục."*

#### Bước 6: Xuất file Báo cáo (Text căn lề & Excel CSV chuẩn UTF-8)
* **Hành động:**
  - Bấm nút **💾 Xuất File (Report)**.
  - Hộp thoại `SaveFileDialog` hiện lên &rarr; Chọn lưu định dạng `.txt` ra Desktop &rarr; Bấm Lưu.
  - Chọn **Yes** trong hộp thoại hỏi mở file ngay &rarr; File Notepad mở lên.
  - Quay lại phần mềm bấm **Xuất File** lần nữa &rarr; Chọn đuôi `.csv` &rarr; Mở file CSV bằng Excel hoặc Notepad.
* **Lời nói:**
  > *"Cuối cùng là chức năng xuất file chuyên sâu của Nhóm 3. Em bấm 'Xuất File', chọn định dạng .txt.*
  > *File văn bản mở lên hiển thị bảng thống kê căn cột thẳng hàng tuyệt đối, có phần header ngày giờ và tổng kết số liệu ở chân trang.*
  > *Bên cạnh đó, khi xuất ra file .csv, nhóm em sử dụng kỹ thuật mã hóa UTF-8 kèm BOM, giúp khi mở bằng Microsoft Excel tiếng Việt có dấu hiển thị 100% chuẩn xác, không bao giờ bị vỡ font."*

---

### 🎤 SLIDE 5: TỔNG KẾT & MỞ PHẦN HỎI ĐÁP PHẢN BIỆN (9:30 - 10:30)

> **Lời thoại:**
> *"Kính thưa Thầy/Cô, qua quá trình xây dựng đề tài Lab 06, Nhóm 3 đã hoàn thành vượt mức các yêu cầu đề ra:*
> - *Giao diện trực quan, chuyên nghiệp, hiện đại.*
> - *Kiểm soát trạng thái form chặt chẽ theo State Pattern.*
> - *Xử lý triệt để các lỗi tiềm ẩn của Windows Forms như File Lock hình ảnh hay giật lag Data Binding.*
> - *Tính năng StatusStrip Real-time và Xuất file mang tính ứng dụng thực tiễn cao.*
>
> *Em xin chân thành cảm ơn Thầy/Cô và các bạn đã lắng nghe bài thuyết trình. Nhóm 3 rất mong nhận được những lời nhận xét, góp ý và sẵn sàng trả lời các câu hỏi phản biện từ Thầy/Cô!"*

---

## PHẦN 3: BỘ CÂU HỎI VẤN ĐÁP PHẢN BIỆN DỰ KIẾN TỪ GIẢNG VIÊN & ĐÁP ÁN CHUẨN

### ❓ Câu hỏi 1: Tại sao nhóm không dùng `List<Product>` mà lại dùng `BindingList<Product>` và `BindingSource`?
* **Cách trả lời tự tin:**
  > *"Dạ thưa Thầy/Cô, `List<T>` trong C# chỉ là một danh sách phẳng thuần túy trong bộ nhớ, nó không hỗ trợ cơ chế giao tiếp sự kiện. Nếu dùng `List<T>` gán cho `DataGridView.DataSource`, mỗi khi thêm hoặc xóa một sản phẩm, chúng em bắt buộc phải gán `DataSource = null` rồi gán lại danh sách. Thao tác này gây hiện tượng nhấp nháy màn hình, làm mất tiêu điểm dòng đang chọn và hiệu năng rất kém khi danh sách lớn.*
  >
  > *Ngược lại, `BindingList<T>` triển khai interface `IBindingList`, tự động bắn sự kiện `ListChanged` mỗi khi danh sách có biến động. DataGridView tự động nhận diện và cập nhật lại đúng ô cần vẽ mà không cần gán lại DataSource.*
  >
  > *Còn `BindingSource` hoạt động như một tầng proxy trung gian. Nhờ nó, nhóm em có thể dễ dàng chuyển đổi qua lại giữa danh sách gốc và danh sách đã lọc (Search/Filter) một cách trơn tru mà không sợ mất dữ liệu ban đầu ạ!"*

---

### ❓ Câu hỏi 2: Tại sao khi nạp ảnh nhóm không dùng lệnh đơn giản `picHinhAnh.Image = Image.FromFile(path)` mà phải dùng `MemoryStream`?
* **Cách trả lời tự tin:**
  > *"Dạ thưa Thầy/Cô, đây là một lỗi rất kinh điển trong lập trình Windows Forms gọi là hiện tượng **File Lock (Khóa tệp)**.*
  > *Hàm `Image.FromFile(path)` của .NET sẽ mở luồng đọc và **giữ khóa độc quyền trên tệp ảnh đó trên ổ cứng** cho đến khi đối tượng Image hoặc Form bị hủy hoàn toàn.*
  > *Hậu quả là nếu ứng dụng đang chạy mà người dùng muốn xóa ảnh, đổi tên, ghi đè hoặc copy file đó thì Windows sẽ ném ngoại lệ `IOException: The process cannot access the file because it is being used by another process`.*
  >
  > *Để khắc phục triệt để, nhóm em dùng `File.ReadAllBytes(path)` nạp toàn bộ byte ảnh vào bộ nhớ RAM rồi ngắt kết nối với tệp tin ngay lập tức. Sau đó nhóm bọc mảng byte này vào `MemoryStream` ảo để khởi tạo Image. Nhờ vậy, tệp tin ảnh trên đĩa cứng hoàn toàn tự do và không bao giờ bị khóa tiến trình ạ!"*

---

### ❓ Câu hỏi 3: Tại sao file CSV khi mở bằng Microsoft Excel hay bị lỗi font tiếng Việt, và nhóm giải quyết như thế nào?
* **Cách trả lời tự tin:**
  > *"Dạ thưa Thầy/Cô, Microsoft Excel có một đặc tính lịch sử là: khi mở trực tiếp file có đuôi `.csv`, Excel sẽ tự động dùng bảng mã ANSI mặc định của hệ điều hành (ví dụ Windows-1252 trên máy phương Tây) chứ không tự động dùng UTF-8 nếu file không có dấu hiệu nhận diện.*
  >
  > *Để xử lý triệt để, nhóm em khởi tạo luồng ghi: `new StreamWriter(filePath, false, new UTF8Encoding(true))`.*
  > *Tham số `true` ở đây báo hiệu cho .NET chèn thêm **3 byte nhận diện BOM (Byte Order Mark) có mã hex là `EF BB BF`** vào ngay đầu tệp tin.*
  > *Khi mở file, Excel đọc được 3 byte này sẽ nhận ra ngay đây là mã hóa UTF-8 và chuyển chế độ đọc, giúp hiển thị tiếng Việt có dấu hoàn hảo 100% không bao giờ bị lỗi font ạ!"*

---

### ❓ Câu hỏi 4: Khi tính tổng thành tiền tồn kho trên StatusStrip, tại sao dùng kiểu `decimal` mà không dùng `double` hay `float`?
* **Cách trả lời tự tin:**
  > *"Dạ thưa Thầy/Cô, trong lập trình tài chính - kế toán và quản lý giá cả, chúng em bắt buộc phải dùng kiểu `decimal` (128-bit cơ số 10) thay vì `double` hay `float` (cơ số 2).*
  > *Bởi vì `double` và `float` là kiểu số thực dấu phẩy động biểu diễn theo chuẩn IEEE 754, rất hay gặp lỗi làm tròn số nhị phân (chẳng hạn phép tính 0.1 + 0.2 sẽ ra 0.30000000000000004).*
  > *Kiểu `decimal` có độ chính xác lên tới 28-29 chữ số thập phân và tính toán hoàn toàn theo hệ thập phân, loại bỏ 100% nguy cơ sai lệch tiền tệ khi tính tích số giữa số lượng lớn và đơn giá tiền tỉ ạ!"*

---

### ❓ Câu hỏi 5: Cột đường dẫn ảnh trong `Product.cs` làm thế nào để không bị hiện lên DataGridView làm xấu bảng?
* **Cách trả lời tự tin:**
  > *"Dạ thưa Thầy/Cô, nhóm kết hợp 2 giải pháp:*
  > 1. *Trong Model `Product.cs`, nhóm gắn thuộc tính `[System.ComponentModel.Browsable(false)]` ngay phía trên property `DuongDanAnh`. Thuộc tính này báo cho các control Data Binding của Windows Forms biết đây là trường dữ liệu ngầm không hiển thị.*
  > 2. *Trên giao diện trong `Form1_Load`, nhóm gán lệnh `dgvSanPham.AutoGenerateColumns = false` và thiết lập các cột thủ công trong Form Designer, chỉ định rõ `DataPropertyName` cho từng cột cần thiết. Nhờ đó, đường dẫn ảnh được lưu ngầm trong bộ nhớ và nạp trực tiếp lên PictureBox mà bảng hiển thị vẫn cực kỳ gọn gàng, đẹp mắt ạ!"*
