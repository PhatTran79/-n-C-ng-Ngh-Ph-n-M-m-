using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    public class HangHoaDTO
    {
        public HangHoaDTO(string maHH, string tenHH, string tenDT, decimal giaNhap, decimal giaBan, string ghiChu, string maKho, string maDT, string maLoai)
        {
            this.MaHH = maHH;
            this.TenHH = tenHH;
            this.TenDT = tenDT;
            this.GiaNhap = giaNhap;
            this.GiaBan = giaBan;
            this.GhiChu = ghiChu;
            this.MaKho = maKho;
            this.MaDT = maDT;
            this.MaLoai = maLoai;
        }

        public HangHoaDTO(DataRow row)
        {
            this.MaHH = (string)row["maHH"];
            this.TenHH = (string)row["tenHH"];
            this.TenDT = (string)row["tenDT"];
            this.GiaNhap = Convert.ToDecimal(row["giaNhap"]);
            this.GiaBan = Convert.ToDecimal(row["giaBan"]);

            var ghiChuTemp = row["GhiChu"];
            if (ghiChuTemp.ToString() != "")
                this.GhiChu = (string)ghiChuTemp;

            //this.GhiChu = (string)row["GhiChu"];
            this.MaKho = (string)row["maKho"];
            this.MaDT = (string)row["maDT"];
            this.MaLoai = (string)row["maLoai"];
        }

        private string maLoai;

        private string maDT;

        private string maKho;

        private string ghiChu;

        private decimal giaBan;

        private decimal giaNhap;

        private string tenDT;

        private string tenHH;

        private string maHangHoa;
        private string maHH;


        private string hoangAnh;
        public string MaHH
        {
            get { return maHH; }
            set { maHH = value; }
        }

        public string TenHH
        {
            get { return tenDT; }
            set { tenDT = value; }
        }

        public string TenDT
        {
            get { return tenHH; }
            set { tenHH = value; }
        }

        public decimal GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }

        public decimal GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }

        public string MaDT
        {
            get { return maDT; }
            set { maDT = value; }
        }

        public string MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }

        public string MaHangHoa { get => maHangHoa; set => maHangHoa = value; }
        public string HoangAnh { get => hoangAnh; set => hoangAnh = value; }
    }
}
