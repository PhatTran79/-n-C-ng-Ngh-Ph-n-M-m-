using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    class TaiKhoangDTO
    {
        public TaiKhoangDTO(int id, string userName, string displayName, string passWord, int Type, string maNV)
        {
            this.Id = id;
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;
            this.MaNV = maNV;
        }

        public TaiKhoangDTO(DataRow row)
        {

            this.Id = (int)row["id"];
            this.UserName = (string)row["userName"];
            this.DisplayName = (string)row["displayName"];
            this.Type = (int)row["type"];
            this.MaNV = (string)row["maNV"];
        }

        private string maNV;
        private int type;
        private string displayName;
        private string userName;
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
    }
}
