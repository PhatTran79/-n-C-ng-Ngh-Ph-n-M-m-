using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    public class LoaiHangHoaDTO
    {
        public LoaiHangHoaDTO(string maLoai, string tenLoai, int soLuong )
        {
            this.MaLoai = maLoai;
            this.TenLoai = tenLoai;
            this.SoLuong = soLuong;
        }

        public LoaiHangHoaDTO(DataRow row)
        {
            this.MaLoai = (string)row["maLoai"];
            this.TenLoai = (string)row["tenLoai"];
            this.SoLuong = (int)row["soLuong"];
        }

        private int soLuong;

        private string tenLoai;

        private string maLoai;

        public string MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }

        public string TenLoai
        {
            get { return tenLoai; }
            set { tenLoai = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
    }
}
