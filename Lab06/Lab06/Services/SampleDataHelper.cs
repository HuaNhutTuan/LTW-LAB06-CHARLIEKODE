using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Lab06.Models;

namespace Lab06.Services
{

    public static class SampleDataHelper
    {
        private static readonly string ImagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleImages");


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
