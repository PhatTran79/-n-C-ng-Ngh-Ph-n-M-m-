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
    class DoiTacDAO
    {
        private static DoiTacDAO instance;

        public static DoiTacDAO Instance
        {
            get { if (instance == null) instance = new DoiTacDAO(); return DoiTacDAO.instance; }
            private set { DoiTacDAO.instance = value; }
        }

        private DoiTacDAO() { }

        public List<DoiTacDTO> GetListMaDoiTac()
        {
            List<DoiTacDTO> dsDoiTac = new List<DoiTacDTO>();

            string query = "SELECT * FROM QuanLyBanHang.dbo.DoiTac";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DoiTacDTO dt = new DoiTacDTO(item);
                dsDoiTac.Add(dt);
            }

            return dsDoiTac;
        }

        public List<DoiTacDTO> GetListTenDoiTac(string maDT)
        {
            List<DoiTacDTO> dsTenDoiTac = new List<DoiTacDTO>();


            string query = string.Format("SELECT * FROM QuanLyBanHang.dbo.DoiTac WHERE MaDT = N'{0}'", maDT);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DoiTacDTO tdt = new DoiTacDTO(item);
                dsTenDoiTac.Add(tdt);
            }

            return dsTenDoiTac;
        }


        public bool InsertDoiTac(string maDT, string tendT, string sdt, string email)
        {
            string query = string.Format("INSERT QuanLyBanHang.dbo.DoiTac( MaDT, TenDT, SDT, Email)VALUES( N'{0}', N'{1}', N'{2}', N'{3}')", maDT, tendT, sdt, email);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateDoiTac(string maDT, string tendT, string sdt, string email)
        {
            string query = string.Format("UPDATE QuanLyBanHang.dbo.DoiTac SET TenDT = N'{1}', SDT = N'{2}', Email = N'{3}' WHERE MaDT = N'{0}'", maDT, tendT, sdt, email);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteDoiTac(string maDT)
        {
            string query = string.Format("DELETE QuanLyBanHang.dbo.DoiTac WHERE MaDT = N'{0}'", maDT);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
