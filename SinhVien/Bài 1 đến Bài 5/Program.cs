using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_1_đến_Bài_5
{
    // 1. Khai báo lớp SinhVien ở đây (trong namespace, ngoài class Program)
    public class SinhVien
    {
        private string _hoTen;
        private double _diemTB;

        public string MaSV { get; set; }

        public string HoTen
        {
            get => _hoTen;
            set { if (!string.IsNullOrWhiteSpace(value)) _hoTen = value.Trim(); }
        }

        public DateTime NgaySinh { get; set; }

        public double DiemTB
        {
            get => _diemTB;
            set { if (value >= 0 && value <= 10) _diemTB = value; }
        }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiemTB = diemTB;
        }

        public int TinhTuoi() => DateTime.Today.Year - NgaySinh.Year;

        public string XepLoai()
        {
            if (DiemTB >= 9.0) return "Xuất sắc";
            if (DiemTB >= 8.0) return "Giỏi";
            if (DiemTB >= 6.5) return "Khá";
            if (DiemTB >= 5.0) return "Trung bình";
            return "Yếu";
        }

        public void HienThi()
        {
            Console.WriteLine($"Mã: {MaSV} | Tên: {HoTen,-15} | Tuổi: {TinhTuoi()} | ĐTB: {DiemTB} | XL: {XepLoai()}");
        }
    }

    internal class Program
    {
        // 2. Viết code chạy chương trình vào bên trong hàm Main
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Khởi tạo danh sách sinh viên
            List<SinhVien> ds = new List<SinhVien>
            {
                new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2),
                new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8),
                new SinhVien("SV03", "Lê Cường", new DateTime(2004, 11, 20), 9.4)
            };

            // Hiển thị danh sách
            Console.WriteLine("--- DANH SÁCH SINH VIÊN ---");
            foreach (var sv in ds)
            {
                sv.HienThi();
            }

            // Tìm kiếm
            Console.Write("\nNhập mã sinh viên cần tìm: ");
            string ma = Console.ReadLine();
            SinhVien kq = ds.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (kq != null)
            {
                Console.WriteLine("Tìm thấy:");
                kq.HienThi();
            }
            else
            {
                Console.WriteLine("Không tìm thấy!");
            }

            // Dừng màn hình để xem kết quả
            Console.ReadKey();
        }
    }
}