using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    public class ChiTietDonHangDTO
    {
        public ChiTietDonHangDTO(int maDH, string maHH, decimal donGia, decimal giamGia, int soLuong )
        {
            this.maDH = maDH;
            this.MaHH = maHH;
            this.DonGia = donGia;
            this.GiamGia = giamGia;
            this.SoLuong = soLuong;
        }

        public ChiTietDonHangDTO(DataRow row)
        {
            this.maDH = (int)row["maDH"];
            this.MaHH = (string)row["maHH"];
            this.DonGia = (decimal)row["donGia"];

            var giamGiaTemp = row["giamGia"];
            if (giamGiaTemp.ToString() != "")
                this.GiamGia = (decimal)giamGiaTemp;

            this.SoLuong = (int)row["soLuong"];
        }

        private int soLuong;
        private decimal giamGia;
        private decimal donGia;
        private int maDH;
        private string maHH;

        public string MaHH
        {
            get { return maHH; }
            set { maHH = value; }
        }

        public int MaDH
        {
            get { return maDH; }
            set { maDH = value; }
        }

        public decimal DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        public decimal GiamGia
        {
            get { return giamGia; }
            set { giamGia = value; }
        }
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
    }
}
