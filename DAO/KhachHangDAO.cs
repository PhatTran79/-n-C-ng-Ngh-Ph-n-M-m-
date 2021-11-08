using QLBH.DTO;
using QLBH.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.DAO;

namespace QLBH.DAO
{
    class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return KhachHangDAO.instance; }
            private set { KhachHangDAO.instance = value; }
        }

        private KhachHangDAO() { }

        public List<KhachHangDTO> GetListKhachHang()
        {
            List<KhachHangDTO> dsKH = new List<KhachHangDTO>();

            string query = "SELECT * FROM QuanLyBanHang.dbo.KhachHang";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                KhachHangDTO kh = new KhachHangDTO(item);
                dsKH.Add(kh);
            }

            return dsKH;
        }

        public bool InsertKhachHang(string maKH, string tenKH, string sdt, string diaChi, string gioiTinh, DateTime? ngaySinh)
        {
            string query = string.Format("INSERT QuanLyBanHang.dbo.KhachHang ( MaKH, TenKH, GioiTinh, SDT, DiaChi, NgaySinh )VALUES(   N'{0}',   N'{1}', N'{2}',   N'{3}',   N'{4}',  N'{5}' )", maKH, tenKH, gioiTinh, sdt, diaChi, ngaySinh);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateNKhachHang(string maKH, string tenKH, string sdt, string diaChi, string gioiTinh, DateTime? ngaySinh)
        {
            string query = string.Format("UPDATE QuanLyBanHang.dbo.KhachHang SET TenKH = N'{1}', GioiTinh = N'{2}', SDT = N'{3}', DiaChi = N'{4}', NgaySinh = GETDATE({5}) WHERE MaKH = N'{0}'", maKH, tenKH, sdt, diaChi, gioiTinh, ngaySinh);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteKhachHang(string maKH)
        {
            string query = string.Format("DELETE QuanLyBanHang.dbo.KhachHang WHERE MaKH = N'{0}'", maKH);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
