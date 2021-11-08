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
    public class HangHoaDAO
    {
        private static HangHoaDAO instance;

        public static HangHoaDAO Instance
        {
            get { if (instance == null) instance = new HangHoaDAO(); return HangHoaDAO.instance; }
            private set { HangHoaDAO.instance = value; }
        }

        private HangHoaDAO() { }

        public List<HangHoaDTO> GetListHangHoa()
        {
            List<HangHoaDTO> dsHangHoa = new List<HangHoaDTO>();

            string query = "select * from HangHoa";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                HangHoaDTO hanghoa = new HangHoaDTO(item);
                dsHangHoa.Add(hanghoa);
            }

            return dsHangHoa;
        }

        public List<HangHoaDTO> GetListHangHoaByID(string id)
        {
            List<HangHoaDTO> listHangHoa = new List<HangHoaDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery(string.Format("SELECT * FROM dbo.HangHoa WHERE MaHH = N'{0}'", id));

            foreach (DataRow item in data.Rows)
            {
                HangHoaDTO info = new HangHoaDTO(item);
                listHangHoa.Add(info);
            }

            return listHangHoa;
        }

        public string GetGiaBan(string id)
        {
            string query = string.Format("SELECT GiaBan FROM HangHoa WHERE MaHH = N'{0}' ", id);

            decimal gb = DataProvider.Instance.ExecuteScalar(query);

            return gb.ToString();
        }

        public bool InsertHangHoa(string maHH, string tenHH, string tenDT, decimal giaNhap, decimal giaBan, string ghiChu, string maKho, string maDT, string maLoai)
        {
            string query = string.Format("INSERT QuanLyBanHang.dbo.HangHoa( MaHH, TenHH, TenDT, GiaNhap, GiaBan, GhiChu, MaKho, MaDT, MaLoai)VALUES( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}' )", maHH, tenHH, tenDT, giaNhap, giaBan, ghiChu, maKho, maDT, maLoai);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateHangHoa(string maHH, string tenHH, string tenDT, decimal giaNhap, decimal giaBan, string ghiChu, string maKho, string maDT, string maLoai)
        {
            string query = string.Format("UPDATE QuanLyBanHang.dbo.HangHoa SET TenHH = N'{1}', TenDT = N'{2}', GiaNhap = N'{3}', GiaBan = N'{4}', GhiChu = N'{5}', MaKho = N'{6}', MaDT = N'{7}', MaLoai = N'{8}' WHERE MaHH = N'{0}'", maHH, tenHH, tenDT, giaNhap, giaBan, ghiChu, maKho, maDT, maLoai);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteHangHoa(string maHH)
        {
            string query = string.Format("DELETE QuanLyBanHang.dbo.HangHoa WHERE MaHH = N'{0}'", maHH);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
