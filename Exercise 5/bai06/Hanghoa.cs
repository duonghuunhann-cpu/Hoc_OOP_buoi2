using System;
using System.Collections.Generic;
using System.Text;

namespace Module03.bai06
{
    // ================= HÀNG HÓA =================
    public abstract class HangHoa
    {
        private string maHang;
        private string tenHang;
        private double donGia;
        private int soLuongTon;

        public HangHoa(string maHang, string tenHang, double donGia, int soLuongTon)
        {
            this.maHang = maHang;
            this.tenHang = string.IsNullOrWhiteSpace(tenHang) ? "xxx" : tenHang;
            this.donGia = donGia >= 0 ? donGia : 0;
            this.soLuongTon = soLuongTon >= 0 ? soLuongTon : 0;
        }

        public string MaHang
        {
            get { return maHang; }
        }

        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = string.IsNullOrWhiteSpace(value) ? "xxx" : value; }
        }

        public double DonGia
        {
            get { return donGia; }
            set
            {
                if (value >= 0)
                    donGia = value;
            }
        }

        public int SoLuongTon
        {
            get { return soLuongTon; }
            set
            {
                if (value >= 0)
                    soLuongTon = value;
            }
        }

        // Phương thức trừu tượng
        public abstract double TinhVAT();

        public abstract string DanhGia();

        public override string ToString()
        {
            return $"Mã hàng: {MaHang}\n" +
                   $"Tên hàng: {TenHang}\n" +
                   $"Đơn giá: {DonGia}\n" +
                   $"Số lượng tồn: {SoLuongTon}";
        }
    }


    // ================= HÀNG THỰC PHẨM =================
    public class HangThucPham : HangHoa
    {
        private string nhaCungCap;
        private DateTime ngaySanXuat;
        private DateTime ngayHetHan;

        public HangThucPham(
            string maHang,
            string tenHang,
            double donGia,
            int soLuongTon,
            string nhaCungCap,
            DateTime ngaySanXuat,
            DateTime ngayHetHan)
            : base(maHang, tenHang, donGia, soLuongTon)
        {
            this.nhaCungCap = nhaCungCap;
            this.ngaySanXuat = ngaySanXuat;
            this.ngayHetHan = ngayHetHan;
        }

        public string NhaCungCap
        {
            get { return nhaCungCap; }
            set { nhaCungCap = value; }
        }

        public DateTime NgaySanXuat
        {
            get { return ngaySanXuat; }
        }

        public DateTime NgayHetHan
        {
            get { return ngayHetHan; }
        }

        // VAT hàng thực phẩm = 5%
        public override double TinhVAT()
        {
            return DonGia * SoLuongTon * 0.05;
        }

        // Còn tồn kho và đã hết hạn => khó bán
        public override string DanhGia()
        {
            if (SoLuongTon > 0 && NgayHetHan < DateTime.Now)
                return "Khó bán";

            return "Không đánh giá";
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nNhà cung cấp: {NhaCungCap}" +
                   $"\nNgày sản xuất: {NgaySanXuat:dd/MM/yyyy}" +
                   $"\nNgày hết hạn: {NgayHetHan:dd/MM/yyyy}" +
                   $"\nĐánh giá: {DanhGia()}";
        }
    }


    // ================= HÀNG ĐIỆN MÁY =================
    public class HangDienMay : HangHoa
    {
        private int thoiGianBaoHanh;
        private double congSuat;

        public HangDienMay(
            string maHang,
            string tenHang,
            double donGia,
            int soLuongTon,
            int thoiGianBaoHanh,
            double congSuat)
            : base(maHang, tenHang, donGia, soLuongTon)
        {
            this.thoiGianBaoHanh = thoiGianBaoHanh;
            this.congSuat = congSuat;
        }

        public int ThoiGianBaoHanh
        {
            get { return thoiGianBaoHanh; }
            set
            {
                if (value >= 0)
                    thoiGianBaoHanh = value;
            }
        }

        public double CongSuat
        {
            get { return congSuat; }
            set
            {
                if (value >= 0)
                    congSuat = value;
            }
        }

        // VAT hàng điện máy = 10%
        public override double TinhVAT()
        {
            return DonGia * SoLuongTon * 0.10;
        }

        // Số lượng tồn < 3 => bán được
        public override string DanhGia()
        {
            if (SoLuongTon < 3)
                return "Bán được";

            return "Không đánh giá";
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nThời gian bảo hành: {ThoiGianBaoHanh} tháng" +
                   $"\nCông suất: {CongSuat} KW" +
                   $"\nĐánh giá: {DanhGia()}";
        }
    }


    // ================= HÀNG SÀNH SỨ =================
    public class HangSanhSu : HangHoa
    {
        private string nhaSanXuat;
        private DateTime ngayNhapKho;

        public HangSanhSu(
            string maHang,
            string tenHang,
            double donGia,
            int soLuongTon,
            string nhaSanXuat,
            DateTime ngayNhapKho)
            : base(maHang, tenHang, donGia, soLuongTon)
        {
            this.nhaSanXuat = nhaSanXuat;
            this.ngayNhapKho = ngayNhapKho;
        }

        public string NhaSanXuat
        {
            get { return nhaSanXuat; }
            set { nhaSanXuat = value; }
        }

        public DateTime NgayNhapKho
        {
            get { return ngayNhapKho; }
        }

        // VAT hàng sành sứ = 10%
        public override double TinhVAT()
        {
            return DonGia * SoLuongTon * 0.10;
        }

        // Tồn > 50 và lưu kho > 10 ngày => bán chậm
        public override string DanhGia()
        {
            double soNgayLuuKho =
                (DateTime.Now - NgayNhapKho).TotalDays;

            if (SoLuongTon > 50 && soNgayLuuKho > 10)
                return "Bán chậm";

            return "Không đánh giá";
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nNhà sản xuất: {NhaSanXuat}" +
                   $"\nNgày nhập kho: {NgayNhapKho:dd/MM/yyyy}" +
                   $"\nĐánh giá: {DanhGia()}";
        }
    }


    // ================= SO SÁNH THEO TÊN =================
    public class SoSanhTheoTen : IComparer<HangHoa>
    {
        public int Compare(HangHoa x, HangHoa y)
        {
            return string.Compare(
                x.TenHang,
                y.TenHang,
                StringComparison.OrdinalIgnoreCase);
        }
    }


    // ================= SO SÁNH THEO SỐ LƯỢNG =================
    public class SoSanhTheoSoLuong : IComparer<HangHoa>
    {
        public int Compare(HangHoa x, HangHoa y)
        {
            return y.SoLuongTon.CompareTo(x.SoLuongTon);
        }
    }


    // ================= QUẢN LÝ HÀNG HÓA =================
    public class QuanLyHangHoa
    {
        private HangHoa[] danhSach;
        private int soLuong;

        // Constructor tạo mảng n phần tử
        public QuanLyHangHoa(int n)
        {
            danhSach = new HangHoa[n];
            soLuong = 0;
        }

        // Thêm hàng hóa nếu không trùng mã
        public bool Them(HangHoa hangHoa)
        {
            if (soLuong >= danhSach.Length)
                return false;

            if (TimKiem(hangHoa.MaHang) != null)
                return false;

            danhSach[soLuong] = hangHoa;
            soLuong++;

            return true;
        }

        // Tìm hàng hóa theo mã
        public HangHoa TimKiem(string maHang)
        {
            for (int i = 0; i < soLuong; i++)
            {
                if (danhSach[i].MaHang == maHang)
                    return danhSach[i];
            }

            return null;
        }

        // Xuất toàn bộ danh sách
        public void XuatDanhSach()
        {
            for (int i = 0; i < soLuong; i++)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(danhSach[i]);
                Console.WriteLine($"VAT: {danhSach[i].TinhVAT():N0}");
            }
        }

        // Xuất hàng thực phẩm
        public void XuatThucPham()
        {
            for (int i = 0; i < soLuong; i++)
            {
                if (danhSach[i] is HangThucPham)
                    Console.WriteLine(danhSach[i]);
            }
        }

        // Xuất hàng điện máy
        public void XuatDienMay()
        {
            for (int i = 0; i < soLuong; i++)
            {
                if (danhSach[i] is HangDienMay)
                    Console.WriteLine(danhSach[i]);
            }
        }

        // Xuất hàng sành sứ
        public void XuatSanhSu()
        {
            for (int i = 0; i < soLuong; i++)
            {
                if (danhSach[i] is HangSanhSu)
                    Console.WriteLine(danhSach[i]);
            }
        }

        // Sắp xếp tên tăng dần
        public void SapXepTheoTen()
        {
            Array.Sort(danhSach, 0, soLuong, new SoSanhTheoTen());
        }

        // Sắp xếp số lượng tồn giảm dần
        public void SapXepTheoSoLuong()
        {
            Array.Sort(danhSach, 0, soLuong, new SoSanhTheoSoLuong());
        }

        // Xuất hàng thực phẩm khó bán
        public void XuatThucPhamKhoBan()
        {
            for (int i = 0; i < soLuong; i++)
            {
                if (danhSach[i] is HangThucPham &&
                    danhSach[i].DanhGia() == "Khó bán")
                {
                    Console.WriteLine(danhSach[i]);
                }
            }
        }

        // Xóa hàng hóa theo mã
        public bool Xoa(string maHang)
        {
            int viTri = -1;

            for (int i = 0; i < soLuong; i++)
            {
                if (danhSach[i].MaHang == maHang)
                {
                    viTri = i;
                    break;
                }
            }

            if (viTri == -1)
                return false;

            for (int i = viTri; i < soLuong - 1; i++)
            {
                danhSach[i] = danhSach[i + 1];
            }

            danhSach[soLuong - 1] = null;
            soLuong--;

            return true;
        }

        // Sửa đơn giá theo mã
        public bool SuaDonGia(string maHang, double donGiaMoi)
        {
            HangHoa hang = TimKiem(maHang);

            if (hang == null || donGiaMoi < 0)
                return false;

            hang.DonGia = donGiaMoi;

            return true;
        }
    }
}
