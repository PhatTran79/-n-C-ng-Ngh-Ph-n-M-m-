using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    class KhachHangDTO
    {
        public KhachHangDTO(string maKH, string tenKH, string sdt, string diaChi, string gioiTinh, DateTime? ngaySinh)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.GioiTinh = gioiTinh;
            this.Sdt = sdt;
            this.DiaChi = diaChi;
            this.NgaySinh = ngaySinh;
        }

        public KhachHangDTO(DataRow row)
        {

            this.MaKH = (string)row["MaKH"];
            this.TenKH = (string)row["TenKH"];
            this.GioiTinh = (string)row["GioiTinh"];
            this.Sdt = (string)row["SDT"];
            this.DiaChi = (string)row["DiaChi"];
            
            var ngaySinhTemp = row["NgaySinh"];
            if (ngaySinhTemp.ToString() != "")
                this.NgaySinh = (DateTime)ngaySinhTemp;

        }

        private DateTime? ngaySinh;
        private string gioiTinh;
        private string diaChi;
        private string sdt;
        private string tenKH;
        private string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }

        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public DateTime? NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

    }
}
