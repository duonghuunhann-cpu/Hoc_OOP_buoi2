using System;
using System.Collections.Generic;
using System.Text;

namespace Module03.bai02
{
    public class ThelibraryX
    {
        // instance fields 
        private string Masach;
        private DateTime Ngaynhap;
        protected double Dongia;
        protected int Soluong;
        private string Nhaxuatban;
        //Constructor
        public ThelibraryX(string masach, DateTime ngaynhap, double dongia, int soluong, string nhaxuatban)
        {
            Masach = masach;
            Ngaynhap = ngaynhap;
            Dongia = dongia;
            Soluong = soluong;
            Nhaxuatban = nhaxuatban;
        }

      
    }
    public class SachgiaoKhoa : ThelibraryX
    {
        //instance fields
        private string Tinhtrang;
        //Constructor
        public SachgiaoKhoa(string masach, DateTime ngaynhap, double dongia, int soluong, string nhaxuatban, string tinhtrang) : base(masach, ngaynhap, dongia, soluong, nhaxuatban)
        {
            Tinhtrang = tinhtrang;

        }
        //create a methods to calculate the total price of all SachgiaoKhoa books
        public double TotalPrice()
        {
            double totalPrice = 0;
            if (Tinhtrang == "Moi")
            {
                totalPrice = Dongia * Soluong;
            }
            else 
            {
                totalPrice = Dongia * Soluong * 0.5;
            }
            return totalPrice;
        }
      
    }
    public class SachThamKhao : ThelibraryX
    {
        //instance fields
        private double Thue;
        //Constructor
        public SachThamKhao(string masach, DateTime ngaynhap, double dongia, int soluong, string nhaxuatban, double thue) : base(masach, ngaynhap, dongia, soluong, nhaxuatban)
        {
            Thue = thue;
        }
    }
    
}
