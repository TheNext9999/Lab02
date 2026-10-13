using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasic_TKNH
{
    // Lớp xử lý nghiệp vụ ngân hàng
    public class TaiKhoanNganHang
    {
        public string SoTaiKhoan { get; set; }
        public string TenChuTaiKhoan { get; set; }
        public double SoDu { get; private set; }

        public TaiKhoanNganHang(string soTaiKhoan, string tenChuTaiKhoan, double soDuBanDau)
        {
            SoTaiKhoan = soTaiKhoan;
            TenChuTaiKhoan = tenChuTaiKhoan;
            SoDu = soDuBanDau;
        }

        public void NapTien(double soTien)
        {
            SoDu += soTien;
            Console.WriteLine($"[+] Nạp thành công {soTien:N0} VNĐ vào TK {SoTaiKhoan}. Số dư mới: {SoDu:N0} VNĐ");
        }

        public bool RutTien(double soTien)
        {
            if (soTien > SoDu)
            {
                Console.WriteLine($"[x] Lỗi: TK {SoTaiKhoan} không đủ số dư để rút {soTien:N0} VNĐ.");
                return false;
            }
            SoDu -= soTien;
            Console.WriteLine($"[-] Rút thành công {soTien:N0} VNĐ từ TK {SoTaiKhoan}. Số dư còn lại: {SoDu:N0} VNĐ");
            return true;
        }

        public void ChuyenTien(TaiKhoanNganHang tkNhan, double soTien)
        {
            Console.WriteLine($"\n---> Chuyển {soTien:N0} VNĐ từ TK {SoTaiKhoan} sang TK {tkNhan.SoTaiKhoan}:");
            if (RutTien(soTien))
            {
                tkNhan.NapTien(soTien);
                Console.WriteLine($"==> Chuyển tiền thành công!");
            }
        }

        public void HienThi()
        {
            Console.WriteLine($"STK: {SoTaiKhoan,-10} | Chủ TK: {TenChuTaiKhoan,-18} | Số dư: {SoDu:N0} VNĐ");
        }
    }

    // Hàm Main khởi chạy chương trình
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Khởi tạo tài khoản
            TaiKhoanNganHang tk1 = new TaiKhoanNganHang("101001", "Nguyễn Như An", 5000000);
            TaiKhoanNganHang tk2 = new TaiKhoanNganHang("101002", "Trần Văn Bình", 2000000);

            Console.WriteLine("=== TRẠNG THÁI TÀI KHOẢN BAN ĐẦU ===");
            tk1.HienThi();
            tk2.HienThi();

            Console.WriteLine("\n=== THỰC HIỆN CÁC GIAO DỊCH ===");

            // 2. Thử nạp tiền
            tk1.NapTien(1000000);

            // 3. Thử rút tiền
            tk1.RutTien(2000000);

            // 4. Thử chuyển tiền
            tk1.ChuyenTien(tk2, 1500000);

            Console.WriteLine("\n=== TRẠNG THÁI TÀI KHOẢN SAU GIAO DỊCH ===");
            tk1.HienThi();
            tk2.HienThi();

            // Dừng màn hình
            Console.ReadKey();
        }
    }
}