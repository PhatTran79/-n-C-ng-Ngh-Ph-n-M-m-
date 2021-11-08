using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QLBH.DTO;
using QuanLyBanHang.DAO;

namespace QLBH.DAO
{
    class TaiKhoangDAO
    {
        private static TaiKhoangDAO instance;

        public static TaiKhoangDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoangDAO(); return TaiKhoangDAO.instance; }
            private set { TaiKhoangDAO.instance = value; }
        }

        private TaiKhoangDAO() { }

        public List<TaiKhoangDTO> GetListTaiKhoang()
        {
            List<TaiKhoangDTO> dsTaiKhoang = new List<TaiKhoangDTO>();

            string query = "SELECT * FROM QuanLyBanHang.dbo.Account";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TaiKhoangDTO tk = new TaiKhoangDTO(item);
                dsTaiKhoang.Add(tk);
            }

            return dsTaiKhoang;
        }

        public bool InsertTaiKhoang( string userName, string displayName, string passWord, int Type, string maNV)
        {
            string query = string.Format("INSERT  QuanLyBanHang.dbo.Account( UserName, DisplayName, Password, MaNV, Type)VALUES( N'{0}', N'{1}', N'{2}', N'{3}', {4} )", userName, displayName, passWord, maNV, Type);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
         public bool UpdatePassWord(string userName, string passWord )
        {
            string query = string.Format("UPDATE QuanLyBanHang.dbo.Account SET Password = N'{1}' WHERE UserName = N'{0}'", userName, passWord);
            
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateTaiKhoang( string userName, string displayName, string passWord, int Type, string maNV)
        {
            string query = string.Format("UPDATE QuanLyBanHang.dbo.Account SET DisplayName = N'{1}', Password = N'{2}', MaNV = N'{3}', Type = {4} WHERE UserName = N'{0}'", userName, displayName, passWord, maNV, Type);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteTaiKhoang(string maNV)
        {
            string query = string.Format("DELETE QuanLyBanHang.dbo.Account WHERE MaNV = N'{0}'", maNV);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public TaiKhoangDTO GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new TaiKhoangDTO(item);
            }

            return null;
        }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName = N'" + userName + "' AND PassWord = N'" + passWord + "' ";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }
    }
}
