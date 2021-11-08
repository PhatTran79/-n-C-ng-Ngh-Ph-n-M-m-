using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    class NhanVienDTO
    {
        public NhanVienDTO(string maNV, string tenNV, string sdt, string diaChi, string chucVu, string gioiTinh, DateTime? ngaySinh, decimal luong)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.Sdt = sdt;
            this.DiaChi = diaChi;
            this.ChucVu = chucVu;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
            this.Luong = luong;
        }

        public NhanVienDTO(DataRow row)
        {

            this.MaNV = (string)row["MaNV"];
            this.TenNV = (string)row["TenNV"];
            this.Sdt = (string)row["SDT"];
            this.DiaChi = (string)row["DiaChi"];
            this.ChucVu = (string)row["ChucVu"];
            this.GioiTinh = (string)row["GioiTinh"];

            var ngaySinhTemp = row["NgaySinh"];
            if (ngaySinhTemp.ToString() != "")
                this.NgaySinh = (DateTime?)ngaySinhTemp;

            this.Luong = (decimal)row["luong"];
        }

        private decimal luong;
        private DateTime? ngaySinh;
        private string gioiTinh;
        private string chucVu;
        private string diaChi;
        private string sdt;
        private string tenNV;
        private string maNV;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
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

        public string ChucVu
        {
            get { return chucVu; }
            set { chucVu = value; }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public DateTime? NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public decimal Luong
        {
            get { return luong; }
            set { luong = value; }
        }
    }
}
