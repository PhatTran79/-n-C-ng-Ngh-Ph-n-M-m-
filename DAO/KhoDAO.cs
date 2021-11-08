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
    class KhoDAO
    {
        private static KhoDAO instance;

        public static KhoDAO Instance
        {
            get { if (instance == null) instance = new KhoDAO(); return KhoDAO.instance; }
            private set { KhoDAO.instance = value; }
        }

        private KhoDAO() { }

        public List<KhoDTO> GetListKho()
        {
            List<KhoDTO> dsKho = new List<KhoDTO>();

            string query = "SELECT * FROM QuanLyBanHang.dbo.Kho";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                KhoDTO kho = new KhoDTO(item);
                dsKho.Add(kho);
            }

            return dsKho;
        }

        public bool InsertKho(string maKho, string tenKho)
        {
            string query = string.Format("INSERT QuanLyBanHang.dbo.Kho( MaKho, TenKho)VALUES(   N'{0}', N'{1}')", maKho, tenKho);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateKho(string maKho, string tenKho)
        {
            string query = string.Format("UPDATE QuanLyBanHang.dbo.Kho SET TenKho = N'{1}' WHERE MaKho = N'{0}'", maKho, tenKho);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteKho(string maKho)
        {
            string query = string.Format("DELETE QuanLyBanHang.dbo.Kho WHERE MaKho = N'{0}'", maKho);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
