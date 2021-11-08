using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    class DoiTacDTO
    {

        public DoiTacDTO(string maDT, string tendT, string sdt, string email)
        {
            this.MaDT = maDT;
            this.TenDT = tenDT;
            this.Sdt = sdt;
            this.Email = email;
        }

        public DoiTacDTO(DataRow row)
        {
            this.MaDT = (string)row["maDT"];
            this.TenDT = (string)row["tenDT"];
            this.Sdt = (string)row["sdt"];
            this.Email = (string)row["email"];
        }

        private string email;
        private string sdt;
        private string tenDT;
        private string maDT;

        public string MaDT
        {
            get { return maDT; }
            set { maDT = value; }
        }

        public string TenDT
        {
            get { return tenDT; }
            set { tenDT = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
