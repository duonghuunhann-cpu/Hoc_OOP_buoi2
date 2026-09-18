using Module03.bai01;
using Module03.bai02;
using Module03.bai03;
using Module03.bai04;
using Module03.bai05;
using Module03.bai06;
using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        //Bai 1 : create a list trip , calculate the total revenue of all trip andf each type of trip
        //Add some trip objects to the list
        List<Quanlichuyenxe> trips = new List<Quanlichuyenxe>();
        //Create 2 object of Chuyenxenoithanh class
        Quanlichuyenxe trip1 = new Chuyenxenoithanh("CX001", "Cristiano Ronaldo G.O.A.T", "29A-12345", 1000000, "Tuyen 1", 50);
        Quanlichuyenxe trip2 = new Chuyenxenoithanh("CX002", "Lionel Peppsi", "29B-67890", 1500000, "Tuyen 2", 60);
        //Create 2 object of Chuyenxengoaithanh class
        Quanlichuyenxe trip3 = new Chuyenxengoaithanh("CX003", "Nguyễn Công Phúng", "29C-54321", 2000000, "TP HCM", 5);
        Quanlichuyenxe trip4 = new Chuyenxengoaithanh("CX004", "Ky Ly Ân Em Pé Ba", "29D-98765", 2500000, "Ha Noi", 10);

        trips.Add(trip1);
        trips.Add(trip2);
        trips.Add(trip3);
        trips.Add(trip4);

        //Tổng doanh thu của tất cả các chuyến xe
        double TotalRevenue = trip1.Doanhthu + trip2.Doanhthu + trip3.Doanhthu + trip4.Doanhthu;

        //Tổng daonh thu của từng loại chuyến xe
        double TotalRevenueNoithanh = trip1.Doanhthu + trip2.Doanhthu;
        double TotalRevenueNgoaithanh = trip3.Doanhthu + trip4.Doanhthu;

        //In ra kết quả doanh thu 
        Console.WriteLine("Tổng doanh thu của tất cả các chuyến xe: ${0}", TotalRevenue);
        Console.WriteLine("Tổng doanh thu của chuyến xe nội thành: ${0}", TotalRevenueNoithanh);
        Console.WriteLine("Tổng doanh thu của chuyến xe ngoại thành: ${0}", TotalRevenueNgoaithanh);


        //bai 2 : create a list the library management books & calculate price of all books and each type of book
        List<ThelibraryX> book = new List<ThelibraryX>();
        //Create each type 3 book objects
        SachgiaoKhoa b1 = new SachgiaoKhoa("B001", DateTime.Now, 100000, 10, "NXB A", "Cu");
        SachgiaoKhoa b2 = new SachgiaoKhoa("B002", DateTime.Now, 150000, 5, "NXB B", "Moi");
        SachgiaoKhoa b3 = new SachgiaoKhoa("B003", DateTime.Now, 200000, 8, "NXB K", "Cu");

        SachThamKhao b4 = new SachThamKhao("B004", DateTime.Now, 250000, 12, "NXB D", 2500);
        SachThamKhao b5 = new SachThamKhao("B005", DateTime.Now, 300000, 15, "NXB E", 3900);
        SachThamKhao b6 = new SachThamKhao("B006", DateTime.Now, 350000, 20, "NXB T", 5000);

        book.Add(b1);
        book.Add(b2);
        book.Add(b3);
        book.Add(b4);
        book.Add(b5);
        book.Add(b6);

        //Calculate total price of each type of books
        double TotalPriceSachGiaoKhoa = b1.TotalPrice() + b2.TotalPrice() + b3.TotalPrice();


        double TotalPriceSachThamKhao = b4.Dongia * b4.Soluong + b4.Thue * b4.Soluong + b5.Dongia * b5.Soluong + b5.Thue * b5.Soluong + b6.Dongia * b6.Soluong + b6.Thue * b6.Soluong;

        //Result output
        Console.WriteLine("Tổng giá của sách giáo khoa: ${0}", TotalPriceSachGiaoKhoa);
        Console.WriteLine("Tổng giá của sách tham khảo: ${0}", TotalPriceSachThamKhao);

        // Xuất ra các quyển sách có tên nhà xuất bản K ( yêu cầu nhập K )
        Console.WriteLine("Các quyển sách có tên nhà xuất bản K:");
        foreach (ThelibraryX b in book)
        {
            if (b is SachgiaoKhoa && b.Nhaxuatban == "NXB K")
            {
                Console.WriteLine($"Masach: {b.Masach}, Ngaynhap: {b.Ngaynhap}, Dongia: {b.Dongia}, Soluong: {b.Soluong}, Nhaxuatban: {b.Nhaxuatban}");
            }
        }
        // Tìm TotalPrice cao nhất 
        double maxPrice = 0;
        ThelibraryX maxPriceBook = null;
        foreach (ThelibraryX b in book)
        {
            double price = 0;
            if (b is SachgiaoKhoa)
            {
                price = ((SachgiaoKhoa)b).TotalPrice();
            }
            else if (b is SachThamKhao)
            {
                price = b.Dongia * b.Soluong + ((SachThamKhao)b).Thue * b.Soluong;
            }
            if (price > maxPrice)
            {
                maxPrice = price;
                maxPriceBook = b;
            }
        }
        Console.WriteLine("Quyển sách có giá trị cao nhất:");
        Console.WriteLine($"Masach: {maxPriceBook.Masach}, Ngaynhap: {maxPriceBook.Ngaynhap}, Dongia: {maxPriceBook.Dongia}, Soluong: {maxPriceBook.Soluong}, Nhaxuatban: {maxPriceBook.Nhaxuatban}");

        //Bai 3 : create a list ManageTransactions
        //Create each type transaction 3 objects\
        List<ManageTransactions> gd = new List<ManageTransactions>();

        GoldTransactions gd1 = new GoldTransactions("GD001", DateTime.Now, 5000000, 2, 24);
        GoldTransactions gd2 = new GoldTransactions("GD002", DateTime.Now, 6000000, 3, 18);
        GoldTransactions gd3 = new GoldTransactions("GD003", DateTime.Now, 70000000, 4, 14);

        CurrencyTransactions gd4 = new CurrencyTransactions("GD004", DateTime.Now, 1000000, 5, "USD", 4000);
        CurrencyTransactions gd5 = new CurrencyTransactions("GD005", DateTime.Now, 2000000, 10, "EUR", 4500);
        CurrencyTransactions gd6 = new CurrencyTransactions("GD006", DateTime.Now, 3000000, 15, "VND", 25000);

        gd.Add(gd1);
        gd.Add(gd2);
        gd.Add(gd3);
        gd.Add(gd4);
        gd.Add(gd5);
        gd.Add(gd6);
        //Tính tổng số lượng cho từng loại giao dịch
        double TotalQuantityGold = gd1.Soluong + gd2.Soluong + gd3.Soluong;
        double TotalCurrencyTransactions = gd4.TotalPrice() + gd5.TotalPrice() + gd6.TotalPrice();
        Console.WriteLine("Tổng số lượng giao dịch vàng: {0}", TotalQuantityGold);
        Console.WriteLine("Tổng giá trị giao dịch tiền tệ: {0}", TotalCurrencyTransactions);
        //Tính trung bình TotalPrice của giao dịch tiền tệ 
        double AVGTotalCurrencyTransactions = TotalCurrencyTransactions / 3;
        Console.WriteLine("Trung bình giá trị giao dịch tiền tệ: {0}", AVGTotalCurrencyTransactions);
        // Xuất ra các giao dịch có đơn giá trên 1 tỷ 
        foreach (ManageTransactions t in gd)
        {
            if (t is GoldTransactions && t.Dongia > 1000000000 || t is CurrencyTransactions && t.Dongia > 1000000000)
            {
                Console.WriteLine($" Các giao dịch có đơn giá trên 1 tỷ: Magiaodich: {t.Magiaodich}, Ngaygiaodich: {t.Ngaygiaodich}, Dongia: {t.Dongia}, Soluong: {t.Soluong}");
            }
        }


        //bai 4 : create a list manage books include SachgiaoKhoa and SachThamKhao
        List<Books> sach = new List<Books>();
        Sachgiaokhoa s1 = new Sachgiaokhoa("S001", DateTime.Now, 100000, 10, "NXB A", true);
        Sachgiaokhoa s2 = new Sachgiaokhoa("S002", DateTime.Now, 150000, 5, "NXB B", false);
        Sachgiaokhoa s3 = new Sachgiaokhoa("S003", DateTime.Now, 200000, 8, "NXB C", true);
        Sachthamkhao s4 = new Sachthamkhao("S004", DateTime.Now, 250000, 12, "NXB D", 2500);
        Sachthamkhao s5 = new Sachthamkhao("S005", DateTime.Now, 300000, 15, "NXB E", 3900);

        sach.Add(s1);
        sach.Add(s2);
        sach.Add(s3);
        sach.Add(s4);
        sach.Add(s5);

        // Tính tổng giá của từng loại sách
        double TotalPriceSachgiaokhoa = s1.TotalPrice() + s2.TotalPrice() + s3.TotalPrice();
        double TotalPriceSachthamkhao = s4.dongia * s4.soLuong + s4.thue * s4.soLuong + s5.dongia * s5.soLuong + s5.thue * s5.soLuong;

        //in kết quả 
        Console.WriteLine($"Tổng giá của sách giáo khoa: {TotalPriceSachgiaokhoa}");
        Console.WriteLine($"Tổng giá của sách tham khảo: {TotalPriceSachthamkhao}");
        // Xuất ra các quyển sách có tên nhà xuất bản B
        Console.WriteLine("Các quyển sách có tên nhà xuất bản B:");
        foreach (Books s in sach)
        {
            if (s is Sachgiaokhoa && s.nhaXuatBan == "NXB B")
            {
                Console.WriteLine($"Masach: {s.maSach}, Ngaynhap: {s.ngayNhap}, Dongia: {s.dongia}, Soluong: {s.soLuong}, Nhaxuatban: {s.nhaXuatBan}");
            }
        }

        //Tính trung bình của sách tham khảo 
        double AVGPriceSachthamkhao = TotalPriceSachthamkhao / 2;
        Console.WriteLine($"Trung bình giá của sách tham khảo: {AVGPriceSachthamkhao}");

        //Tìm quyển sách có giá trị cao nhất
        double maxPriceSach = 0;
        Books maxPriceSachBook = null;
        foreach (Books s in sach)
        {
            double price = 0;
            if (s is Sachgiaokhoa)
            {
                price = ((Sachgiaokhoa)s).TotalPrice();
            }
            else if (s is Sachthamkhao)
            {
                price = s.dongia * s.soLuong + ((Sachthamkhao)s).thue * s.soLuong;
            }
            if (price > maxPriceSach)
            {
                maxPriceSach = price;
                maxPriceSachBook = s;
            }
        }
        Console.WriteLine($"Quyển sách có giá trị cao nhất: {maxPriceSachBook}");

        // bai 5 : create a list manage salary of each type employee in companyXYZ
        // Tạo danh sách các đối tượng Employee
        List<Employee> employees = new List<Employee>();

        // Tạo nhân viên hưởng lương tuần
        SalariedEmployee e1 = new SalariedEmployee(
            "Nguyen", "An", "111-11-1111", 1000);

        // Tạo nhân viên hưởng lương theo giờ
        HourlyEmployee e2 = new HourlyEmployee(
            "Tran", "Binh", "222-22-2222", 20, 45);

        // Tạo nhân viên hưởng hoa hồng
       CommissionEmployee e3 = new CommissionEmployee(
            "Le", "Cuong", "333-33-3333", 10000, 0.1);

        // Tạo nhân viên hưởng hoa hồng + lương cơ bản
        BasePlusCommissionEmployee e4 = new BasePlusCommissionEmployee(
            "Pham", "Dung", "444-44-4444", 10000, 0.1, 500);

        // Thêm các nhân viên vào danh sách
        employees.Add(e1);
        employees.Add(e2);
        employees.Add(e3);
        employees.Add(e4);

        // In thông tin và tiền lương của từng nhân viên
        foreach (Employee emp in employees)
        {
            Console.WriteLine(emp.ToString());
            Console.WriteLine($"Earnings: {emp.Earnings()}");
            Console.WriteLine();
        }

        // Bai 6 : 
        // Tạo danh sách tối đa 10 hàng hóa
        QuanLyHangHoa ds = new QuanLyHangHoa(10);

        // Tạo hàng thực phẩm
        HangThucPham h1 = new HangThucPham(
            "TP01",
            "Sua",
            25000,
            100,
            "Vinamilk",
            DateTime.Now.AddDays(-20),
            DateTime.Now.AddDays(-5));

        HangThucPham h2 = new HangThucPham(
            "TP02",
            "Banh",
            15000,
            50,
            "Kinh Do",
            DateTime.Now.AddDays(-5),
            DateTime.Now.AddDays(10));

        // Tạo hàng điện máy
        HangDienMay h3 = new HangDienMay(
            "DM01",
            "Tu Lanh",
            10000000,
            2,
            24,
            1.5);

        HangDienMay h4 = new HangDienMay(
            "DM02",
            "May Giat",
            8000000,
            5,
            12,
            2);

        // Tạo hàng sành sứ
        HangSanhSu h5 = new HangSanhSu(
            "SS01",
            "Bat Su",
            50000,
            60,
            "Bat Trang",
            DateTime.Now.AddDays(-20));

        HangSanhSu h6 = new HangSanhSu(
            "SS02",
            "Ly Su",
            30000,
            20,
            "Minh Long",
            DateTime.Now.AddDays(-5));

        // Thêm hàng hóa vào danh sách
        ds.Them(h1);
        ds.Them(h2);
        ds.Them(h3);
        ds.Them(h4);
        ds.Them(h5);
        ds.Them(h6);

        // In toàn bộ danh sách
        Console.WriteLine("===== TOAN BO HANG HOA =====");
        ds.XuatDanhSach();

        // In từng loại hàng
        Console.WriteLine("\n===== HANG THUC PHAM =====");
        ds.XuatThucPham();

        Console.WriteLine("\n===== HANG DIEN MAY =====");
        ds.XuatDienMay();

        Console.WriteLine("\n===== HANG SANH SU =====");
        ds.XuatSanhSu();

        // In hàng thực phẩm khó bán
        Console.WriteLine("\n===== HANG THUC PHAM KHO BAN =====");
        ds.XuatThucPhamKhoBan();

        // Sắp xếp theo tên
        ds.SapXepTheoTen();

        Console.WriteLine("\n===== SAP XEP THEO TEN =====");
        ds.XuatDanhSach();

        // Sắp xếp theo số lượng tồn giảm dần
        ds.SapXepTheoSoLuong();

        Console.WriteLine("\n===== SAP XEP SO LUONG GIAM DAN =====");
        ds.XuatDanhSach();

        // Tìm kiếm
        Console.WriteLine("\n===== TIM KIEM =====");

        HangHoa tim = ds.TimKiem("DM01");

        if (tim != null)
            Console.WriteLine(tim);
        else
            Console.WriteLine("Khong tim thay!");

        // Sửa đơn giá
        Console.WriteLine("\n===== SUA DON GIA =====");

        if (ds.SuaDonGia("TP01", 30000))
            Console.WriteLine("Sua don gia thanh cong!");

        // Xóa hàng hóa
        Console.WriteLine("\n===== XOA HANG HOA =====");

        if (ds.Xoa("SS02"))
            Console.WriteLine("Xoa thanh cong!");

        // In danh sách sau khi xóa
        Console.WriteLine("\n===== DANH SACH SAU KHI XOA =====");
        ds.XuatDanhSach();
    }
}
