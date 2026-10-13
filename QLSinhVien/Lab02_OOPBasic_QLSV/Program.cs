using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasic_QLSV
{
    // Lớp đối tượng SinhVien
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

        public SinhVien() { }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiemTB = diemTB;
        }

        public int TinhTuoi()
        {
            int tuoi = DateTime.Today.Year - NgaySinh.Year;
            if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;
            return tuoi;
        }

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
            Console.WriteLine($"Mã: {MaSV,-8} | Tên: {HoTen,-20} | Ngày sinh: {NgaySinh:dd/MM/yyyy} | Tuổi: {TinhTuoi(),-2} | ĐTB: {DiemTB,4:N2} | XL: {XepLoai()}");
        }
    }

    // Program chính điều khiển ứng dụng
    internal class Program
    {
        static List<SinhVien> danhSachSV = new List<SinhVien>
        {
            new SinhVien("SV01", "Nguyễn Như An", new DateTime(2006, 3, 15), 9.2),
            new SinhVien("SV02", "Trần Minh Tuấn", new DateTime(2005, 8, 22), 7.5),
            new SinhVien("SV03", "Lê Thanh Hương", new DateTime(2005, 12, 1), 8.4),
            new SinhVien("SV04", "Phạm Hoàng Nam", new DateTime(2006, 5, 10), 4.8),
            new SinhVien("SV05", "Vũ Mai Anh", new DateTime(2005, 7, 30), 6.2)
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int luaChon;
            do
            {
                Console.Clear();
                Console.WriteLine("================ ỨNG DỤNG QUẢN LÝ SINH VIÊN (BÀI 10) ================");
                Console.WriteLine("1. Xem danh sách sinh viên");
                Console.WriteLine("2. Thêm sinh viên mới");
                Console.WriteLine("3. Sửa thông tin sinh viên theo Mã");
                Console.WriteLine("4. Xóa sinh viên theo Mã");
                Console.WriteLine("5. Tìm kiếm sinh viên theo Tên hoặc Mã");
                Console.WriteLine("6. Sắp xếp danh sách (Giảm dần theo Điểm TB)");
                Console.WriteLine("7. Thống kê (Điểm TBC, thủ khoa, đếm xếp loại)");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("=====================================================================");
                Console.Write("Lựa chọn của bạn (0-7): ");

                if (!int.TryParse(Console.ReadLine(), out luaChon)) luaChon = -1;

                Console.WriteLine();
                switch (luaChon)
                {
                    case 1: HienThiDanhSach(); break;
                    case 2: ThemSinhVien(); break;
                    case 3: SuaSinhVien(); break;
                    case 4: XoaSinhVien(); break;
                    case 5: TimKiemSinhVien(); break;
                    case 6: SapXepSinhVien(); break;
                    case 7: ThongKeSinhVien(); break;
                    case 0: Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!"); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }
            } while (luaChon != 0);
        }

        static void HienThiDanhSach()
        {
            Console.WriteLine("--- DANH SÁCH SINH VIÊN ---");
            if (danhSachSV.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }
            foreach (var sv in danhSachSV) sv.HienThi();
        }

        static void ThemSinhVien()
        {
            Console.WriteLine("--- THÊM SINH VIÊN MỚI ---");
            try
            {
                Console.Write("Nhập mã sinh viên: ");
                string ma = Console.ReadLine().Trim();
                if (danhSachSV.Any(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Lỗi: Mã sinh viên đã tồn tại!");
                    return;
                }

                Console.Write("Nhập họ và tên: ");
                string ten = Console.ReadLine();

                Console.Write("Nhập ngày sinh (yyyy-MM-dd hoặc dd/MM/yyyy): ");
                DateTime ngaySinh = DateTime.Parse(Console.ReadLine());

                Console.Write("Nhập điểm trung bình (0-10): ");
                double diem = double.Parse(Console.ReadLine());

                SinhVien sv = new SinhVien(ma, ten, ngaySinh, diem);
                danhSachSV.Add(sv);
                Console.WriteLine("Thêm sinh viên thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nhập liệu: " + ex.Message);
            }
        }

        static void SuaSinhVien()
        {
            Console.WriteLine("--- SỬA THÔNG TIN SINH VIÊN ---");
            Console.Write("Nhập mã sinh viên cần sửa: ");
            string ma = Console.ReadLine().Trim();

            SinhVien sv = danhSachSV.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv == null)
            {
                Console.WriteLine($"Không tìm thấy sinh viên có mã '{ma}'.");
                return;
            }

            try
            {
                Console.Write($"Họ tên mới (Bỏ trống để giữ nguyên '{sv.HoTen}'): ");
                string tenMoi = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(tenMoi)) sv.HoTen = tenMoi;

                Console.Write($"Điểm TB mới (Nhập -1 để giữ nguyên '{sv.DiemTB}'): ");
                if (double.TryParse(Console.ReadLine(), out double diemMoi) && diemMoi >= 0)
                {
                    sv.DiemTB = diemMoi;
                }

                Console.WriteLine("Cập nhật thông tin thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật: " + ex.Message);
            }
        }

        static void XoaSinhVien()
        {
            Console.WriteLine("--- XÓA SINH VIÊN ---");
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string ma = Console.ReadLine().Trim();

            SinhVien sv = danhSachSV.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv == null)
            {
                Console.WriteLine($"Không tìm thấy sinh viên có mã '{ma}'.");
                return;
            }

            danhSachSV.Remove(sv);
            Console.WriteLine($"Đã xóa sinh viên có mã '{ma}' khỏi danh sách.");
        }

        static void TimKiemSinhVien()
        {
            Console.WriteLine("--- TÌM KIẾM SINH VIÊN ---");
            Console.Write("Nhập từ khóa (Mã hoặc Họ tên): ");
            string tuKhoa = Console.ReadLine().Trim();

            var ketQua = danhSachSV.Where(x => x.MaSV.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                               x.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine($"Không tìm thấy sinh viên khớp với từ khóa '{tuKhoa}'.");
            }
            else
            {
                Console.WriteLine($"Tìm thấy {ketQua.Count} kết quả:");
                foreach (var sv in ketQua) sv.HienThi();
            }
        }

        static void SapXepSinhVien()
        {
            danhSachSV = danhSachSV.OrderByDescending(x => x.DiemTB).ToList();
            Console.WriteLine("Đã sắp xếp danh sách sinh viên theo Điểm trung bình GIẢM DẦN.");
            HienThiDanhSach();
        }

        static void ThongKeSinhVien()
        {
            Console.WriteLine("--- THỐNG KÊ DANH SÁCH SINH VIÊN ---");
            if (danhSachSV.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            double diemTBC = danhSachSV.Average(x => x.DiemTB);
            double maxDiem = danhSachSV.Max(x => x.DiemTB);
            var svThuKhoa = danhSachSV.Where(x => x.DiemTB == maxDiem).ToList();

            Console.WriteLine($"1. Tổng số sinh viên: {danhSachSV.Count}");
            Console.WriteLine($"2. Điểm trung bình cả lớp: {diemTBC:F2}");
            Console.WriteLine($"3. Sinh viên có điểm cao nhất ({maxDiem:F2}):");
            foreach (var sv in svThuKhoa)
            {
                Console.WriteLine($"   - {sv.HoTen} ({sv.MaSV})");
            }

            Console.WriteLine("\n4. Phân loại sinh viên:");
            var nhomXepLoai = danhSachSV.GroupBy(x => x.XepLoai());
            foreach (var g in nhomXepLoai)
            {
                Console.WriteLine($"   - {g.Key,-12}: {g.Count()} sinh viên");
            }
        }
    }
}