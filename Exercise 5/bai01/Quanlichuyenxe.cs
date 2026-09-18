using System;
using System.Collections.Generic;
using System.Text;

namespace Module03.bai01
{
    public class Quanlichuyenxe
    {
        // instance fields
        private string Masochuyen;
        private string Hotentaixe;
        private string Soxe;
        protected double Doanhthu;

        //Constructor
        public Quanlichuyenxe(string masochuyen,string hotentaixe , string soxe , double doanhthu)
        {
            Masochuyen = masochuyen;
            Hotentaixe = hotentaixe;
            Soxe = soxe;
            Doanhthu = doanhthu;
        }
    }
    public class Chuyenxenoithanh : Quanlichuyenxe
    {
        //instance fields
        private string Sotuyen;
        private double Sokmdiduoc;
        //Constructor
        public Chuyenxenoithanh(string masochuyen, string hotentaixe, string soxe, double doanhthu, string sotuyen, double sokmdiduoc) : base(masochuyen, hotentaixe, soxe, doanhthu)
        {
            Sotuyen = sotuyen;
            Sokmdiduoc = sokmdiduoc;
        }
    }
    public class Chuyenxengoaithanh : Quanlichuyenxe
    {
        //state (instance) fields - attributes/properties
        private string Noiden;
        private int Songaydiduoc;
        //Constructor
        public Chuyenxengoaithanh (string masochuyen, string hotentaixe, string soxe, double doanhthu, string noiden, int songaydiduoc) : base(masochuyen, hotentaixe, soxe, doanhthu)
        {
            Noiden = noiden;
            Songaydiduoc = songaydiduoc;
        }
    }
}
