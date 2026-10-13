using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasic_SP
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }

        public SanPham(string maSP, string tenSP, double donGia, int soLuong)
        {
            MaSP = maSP; TenSP = tenSP; DonGia = donGia; SoLuong = soLuong;
        }

        public double TinhThanhTien() => DonGia * SoLuong;

        public void HienThi()
        {
            Console.WriteLine($"Mã: {MaSP} | Tên: {TenSP,-15} | Giá: {DonGia:N0} | SL: {SoLuong} | Thành tiền: {TinhThanhTien():N0}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SanPham sp1 = new SanPham("SP01", "Laptop Dell XPS", 25000000, 3);
            SanPham sp2 = new SanPham("SP02", "Chuột Logitech", 500000, 10);

            Console.WriteLine("--- THÔNG TIN SẢN PHẨM ---");
            sp1.HienThi();
            sp2.HienThi();

            Console.ReadKey();
        }
    }
}
