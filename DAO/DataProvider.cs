using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class DataProvider
    {
        private static DataProvider instance; // Ctrl + R + E để đóng gói
        // instance giống như 1 biến static, được khởi tạo 1 lần duy nhất và sử dụng hết vòng đời của chương trình
        // và biến static chỉ được gọi thông qua 1 thân hàm

        public static DataProvider Instance
        {
            get { if (Instance1 == null) Instance1 = new DataProvider(); return DataProvider.Instance1; }
            private set { DataProvider.Instance1 = value; } //private set: chỉ thằng bên trong DataProvider mới được dùng
        }

        public static DataProvider Instance1 { get => instance; set => instance = value; }

        private DataProvider() { }

        private string connectionSTR = "Data Source=LAPTOP-K5VIUSHM\\SQLEXPRESS04;Initial Catalog=QuanLyBanHang;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        } //Trả ra những dòng kết quả

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        } //Trả ra số dòng được thực thi: inset, delete, update

        public decimal ExecuteScalar(string query, object[] parameter = null)
        {
            decimal data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                //if (parameter != null)
                //{
                //    string[] listPara = query.Split(' ');
                //    int i = 0;
                //    foreach (string item in listPara)
                //    {
                //        if (item.Contains('@'))
                //        {
                //            command.Parameters.AddWithValue(item, parameter[i]);
                //            i++;
                //        }
                //    }
                //}

                data = (decimal)command.ExecuteScalar();

                connection.Close();
            }

            return data;
        } //Trả ra kết quả như select count *
    }
}