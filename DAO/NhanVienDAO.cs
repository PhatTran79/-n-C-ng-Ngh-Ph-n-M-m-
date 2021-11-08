using QLBH.DTO;
using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAO
{
    class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return NhanVienDAO.instance; }
            private set { NhanVienDAO.instance = value; }
        }

        private NhanVienDAO() { }

        public List<NhanVienDTO> GetListNhanVien()
        {
            List<NhanVienDTO> dsKH = new List<NhanVienDTO>();

            string query = "SELECT * FROM QuanLyBanHang.dbo.NhanVien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVienDTO kH = new NhanVienDTO(item);
                dsKH.Add(kH);
            }

            return dsKH;
        }

        public bool InsertNhanVien(string maNV, string tenNV, string sdt, string diaChi, string chucVu, string gioiTinh, DateTime? ngaySinh, decimal luong)
        {
            string query = string.Format("INSERT QuanLyBanHang.dbo.NhanVien(MaNV, TenNV, SDT, DiaChi, ChucVu, GioiTinh, NgaySinh, Luong)VALUES(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', {7})", maNV, tenNV, sdt, diaChi, chucVu, gioiTinh, ngaySinh, luong);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateNhanVien(string maNV, string tenNV, string sdt, string diaChi, string chucVu, string gioiTinh, DateTime? ngaySinh, decimal luong)
        {
            string query = string.Format("UPDATE QuanLyBanHang.dbo.NhanVien SET TenNV = N'{1}', Sdt = N'{2}', DiaChi = N'{3}', ChucVu = N'{4}', GioiTinh = N'{5}', NgaySinh = N'{6}', Luong = {7} WHERE MaNV = N'{0}'", maNV, tenNV, sdt, diaChi, chucVu, gioiTinh, ngaySinh, luong);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteNhanVien(string maNV)
        {
            string query = string.Format("DELETE QuanLyBanHang.dbo.NhanVien WHERE MaNV = N'{0}'", maNV);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
