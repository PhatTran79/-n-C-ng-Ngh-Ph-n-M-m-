using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DTO
{
    public class KhoDTO
    {
        public KhoDTO(string maKho, string tenKho)
        {
            this.MaKho = maKho;
            this.TenKho = tenKho;
        }

        public KhoDTO(DataRow row)
        {
            this.MaKho = (string)row["MaKho"];
            this.TenKho = (string)row["TenKho"];
        }

        private string tenKho;

        private string maKho;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }

        public string TenKho
        {
            get { return tenKho; }
            set { tenKho = value; }
        }
    }
}