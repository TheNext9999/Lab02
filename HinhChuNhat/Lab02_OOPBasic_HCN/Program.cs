using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasic_HCN
{
    // Lớp Hình chữ nhật
    public class HinhChuNhat
    {
        public double ChieuDai { get; set; }
        public double ChieuRong { get; set; }

        public HinhChuNhat(double cd, double cr)
        {
            ChieuDai = cd;
            ChieuRong = cr;
        }

        public double TinhChuVi() => 2 * (ChieuDai + ChieuRong);
        public double TinhDienTich() => ChieuDai * ChieuRong;

        public void HienThi()
        {
            Console.WriteLine($"\n---> Hình chữ nhật có kích thước ({ChieuDai} x {ChieuRong})");
            Console.WriteLine($"---> Chu vi     : {TinhChuVi():N2}");
            Console.WriteLine($"---> Diện tích  : {TinhDienTich():N2}");
        }
    }

    // Hàm Main khởi chạy
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                Console.WriteLine("=== TÍNH CHU VI & DIỆN TÍCH HÌNH CHỮ NHẬT ===");

                Console.Write("Nhập chiều dài: ");
                double cd = double.Parse(Console.ReadLine());

                Console.Write("Nhập chiều rộng: ");
                double cr = double.Parse(Console.ReadLine());

                if (cd <= 0 || cr <= 0)
                {
                    Console.WriteLine("Lỗi: Chiều dài và chiều rộng phải lớn hơn 0!");
                }
                else
                {
                    HinhChuNhat hcn = new HinhChuNhat(cd, cr);
                    hcn.HienThi();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nhập liệu: Vui lòng nhập số hợp lệ. Chi tiết: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}