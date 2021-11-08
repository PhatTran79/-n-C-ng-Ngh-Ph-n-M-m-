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
    class LoaiHangHoaDAO
    {
        private static LoaiHangHoaDAO instance;

        public static LoaiHangHoaDAO Instance
        {
            get { if (instance == null) instance = new LoaiHangHoaDAO(); return LoaiHangHoaDAO.instance; }
            private set { LoaiHangHoaDAO.instance = value; }
        }

        private LoaiHangHoaDAO() { }

        public List<LoaiHangHoaDTO> GetListLoaiHangHoa()
        {
            List<LoaiHangHoaDTO> dsLoaiHangHoa = new List<LoaiHangHoaDTO>();

            string query = "SELECT * FROM QuanLyBanHang.dbo.LoaiHH";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                LoaiHangHoaDTO lhh = new LoaiHangHoaDTO(item);
                dsLoaiHangHoa.Add(lhh);
            }

            return dsLoaiHangHoa;
        }

        public bool InsertLoaiHangHoa(string maLoai, string tenLoai, int soLuong)
        {
            string query = string.Format("INSERT QuanLyBanHang.dbo.LoaiHH( MaLoai, TenLoai, SoLuong)VALUES(   N'{0}', N'{1}', {2})", maLoai, tenLoai, soLuong);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateLoaiHangHoa(string maLoai, string tenLoai, int soLuong)
        {
            string query = string.Format("UPDATE QuanLyBanHang.dbo.LoaiHH SET TenLoai = N'{1}', SoLuong = N'{2}' WHERE MaLoai = N'{0}'", maLoai, tenLoai, soLuong);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteLoaiHangHoa(string maLoai)
        {
            string query = string.Format("DELETE QuanLyBanHang.dbo.LoaiHH WHERE MaLoai = N'{0}'", maLoai);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
