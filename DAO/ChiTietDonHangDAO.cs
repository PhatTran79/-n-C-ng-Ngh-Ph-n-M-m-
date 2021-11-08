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
    class ChiTietDonHangDAO
    {
            private static ChiTietDonHangDAO instance;

            public static ChiTietDonHangDAO Instance
            {
                get { if (instance == null) instance = new ChiTietDonHangDAO(); return ChiTietDonHangDAO.instance; }
                private set { ChiTietDonHangDAO.instance = value; }
            }

            private ChiTietDonHangDAO() { }

        public List<ChiTietDonHangDTO> GetListChiTietHangHoa()
        {
            List<ChiTietDonHangDTO> dsCTHH = new List<ChiTietDonHangDTO>();

            string query = "select * from CTDonHang";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ChiTietDonHangDTO cthh = new ChiTietDonHangDTO(item);
                dsCTHH.Add(cthh);
            }

            return dsCTHH;
        }

        public bool InsertChiTietHangHoa(string maHH, decimal donGia, decimal giamGia, int soLuong)
        {
            string query = string.Format("INSERT QuanLyBanHang.dbo.CTDonHang( MaHH, DonGia, GiamGia, SoLuong)VALUES( N'{0}', N'{1}', {2}, {3})", maHH, donGia, giamGia, soLuong);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool ThanhToanDH(int maDH)
        {
            string query = string.Format("DELETE QuanLyBanHang.dbo.CTDonHang WHERE MaDH = N'{0}'", maDH);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


    }
}
