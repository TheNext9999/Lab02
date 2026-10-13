using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasic_NV
{
    // Lớp Nhân viên
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public double LCB { get; set; }
        public double HSL { get; set; }
        public double PhuCap { get; set; }

        public NhanVien(string ma, string ten, double lcb, double hsl, double phuCap)
        {
            MaNV = ma;
            HoTen = ten;
            LCB = lcb;
            HSL = hsl;
            PhuCap = phuCap;
        }

        public double TinhLuong() => (LCB * HSL) + PhuCap;

        public void HienThi()
        {
            Console.WriteLine($"Mã NV: {MaNV,-6} | Họ tên: {HoTen,-18} | LCB: {LCB,10:N0} | HSL: {HSL,4:F1} | Phụ cấp: {PhuCap,8:N0} | Thực lĩnh: {TinhLuong(),12:N0} VNĐ");
        }
    }

    // Hàm Main khởi chạy
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Tạo danh sách nhân viên
            List<NhanVien> dsNV = new List<NhanVien>
            {
                new NhanVien("NV01", "Nguyễn Văn A", 5000000, 2.5, 1000000),
                new NhanVien("NV02", "Trần Thị B", 4500000, 3.0, 1500000),
                new NhanVien("NV03", "Lê Hoàng C", 6000000, 2.0, 500000)
            };

            Console.WriteLine("=============================== BẢNG LƯƠNG NHÂN VIÊN ===============================");
            foreach (var nv in dsNV)
            {
                nv.HienThi();
            }
            Console.WriteLine("====================================================================================");

            Console.ReadKey();
        }
    }
}