using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Lab06.Models;

namespace Lab06.Services
{
    
    public static class ProductFileService
    {

        /// <param name="filePath">Đường dẫn file cần lưu</param>
        /// <param name="products">Danh sách sản phẩm</param>
        public static void ExportToTxt(string filePath, IEnumerable<Product> products)
        {

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {

                writer.WriteLine("====================================================================================================");
                writer.WriteLine("                         BÁO CÁO THỐNG KÊ TỒN KHO VÀ DANH SÁCH SẢN PHẨM                            ");
                writer.WriteLine("                              (Phần mềm Quản lý sản phẩm - Nhóm 3)                                  ");
                writer.WriteLine("====================================================================================================");
                writer.WriteLine($"Ngày xuất báo cáo : {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                writer.WriteLine($"Người lập báo cáo : Quản trị viên hệ thống");
                writer.WriteLine("----------------------------------------------------------------------------------------------------");


                writer.WriteLine(string.Format("{0,-8} | {1,-26} | {2,-18} | {3,18} | {4,12} | {5,-16} | {6,-14}",
                    "Mã SP", "Tên Sản Phẩm", "Loại SP", "Đơn Giá (VNĐ)", "SL Tồn Kho", "Ngày Nhập", "Kinh Doanh"));
                writer.WriteLine("----------------------------------------------------------------------------------------------------");

                int tongSoLuongSP = 0;
                decimal tongGiaTriTonKho = 0;
                int demSanPham = 0;

                foreach (var p in products)
                {
                    demSanPham++;
                    tongSoLuongSP += p.SoLuong;
                    decimal thanhTien = p.SoLuong * p.DonGia;
                    tongGiaTriTonKho += thanhTien;

                    string trangThaiKD = p.ConKinhDoanh ? "Đang bán" : "Ngừng bán";

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

                writer.WriteLine("====================================================================================================");
                writer.WriteLine("TỔNG KẾT BÁO CÁO:");
                writer.WriteLine($"- Tổng số mặt hàng (mã sản phẩm) : {demSanPham} mặt hàng");
                writer.WriteLine($"- Tổng số lượng sản phẩm tồn kho : {tongSoLuongSP:N0} cái/chiếc");
                writer.WriteLine($"- TỔNG GIÁ TRỊ TỒN KHO            : {tongGiaTriTonKho:N0} VNĐ");
                writer.WriteLine("====================================================================================================");
                writer.WriteLine("Ghi chú: Báo cáo được trích xuất tự động từ phần mềm ProductManager - Windows Forms Nâng cao.");
            }
        }

        /// <param name="filePath">Đường dẫn file</param>
        /// <param name="products">Danh sách sản phẩm</param>
        public static void ExportToCsv(string filePath, IEnumerable<Product> products)
        {
            
            using (StreamWriter writer = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {

                writer.WriteLine("MaSP,TenSP,LoaiSP,DonGia,SoLuong,NgayNhap,ConKinhDoanh,ThanhTien");

                foreach (var p in products)
                {
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
