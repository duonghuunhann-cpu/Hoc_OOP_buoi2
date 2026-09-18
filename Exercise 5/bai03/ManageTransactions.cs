using System;
using System.Collections.Generic;
using System.Text;

namespace Module03.bai03
{
    public class ManageTransactions
    {

        //instance fields 
        private string Magiaodich;
        private DateTime Ngaygiaodich;
        protected double Dongia;
        protected int Soluong;

        //constructor 
        public ManageTransactions(string magiaodich, DateTime ngaygiaodich, double dongia, int soluong)
        {
            Magiaodich = magiaodich;
            Ngaygiaodich = ngaygiaodich;
            Dongia = dongia;
            Soluong = soluong;
        }
    }
    public class GoldTransactions : ManageTransactions
    {
        //instance fields 
        private double Loaivang;
        //constructor 
        public GoldTransactions(string magiaodich, DateTime ngaygiaodich, double dongia, int soluong, double loaivang) : base(magiaodich, ngaygiaodich, dongia, soluong)
        {
            Loaivang = loaivang;
        }
    }
    public class CurrencyTransactions : ManageTransactions
    {
        //instance fields 
        private string Loaitien;
        private double Tygia;
        //constructor 
        public CurrencyTransactions(string magiaodich, DateTime ngaygiaodich, double dongia, int soluong, string loaitien, double tygia) : base(magiaodich, ngaygiaodich, dongia, soluong)
        {
            Loaitien = loaitien;
            Tygia = tygia;
        }
        //create a methods to culcalate type of currency transactions
        public double TotalPrice()
        {
            double TotalPrice = 0;
            if (Loaitien == "USD" || Loaitien == "Euro")
            {
                TotalPrice = Dongia * Soluong * Tygia;
            }
            else
            {
                TotalPrice = Dongia * Soluong;
            }
            return TotalPrice;
        }
        //Create a methods to culcalate AVG of currency transactions
        public double AVGPrice()
        {
            double AVGPrice = 0;
            if (Loaitien == "USD" || Loaitien == "Euro")
            {
                AVGPrice = (Dongia * Soluong * Tygia) / Soluong;
            }
            else
            {
                AVGPrice = (Dongia * Soluong) / Soluong;
            }
            return AVGPrice;
        }
    }
}
