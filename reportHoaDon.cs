using Microsoft.Reporting.WinForms;
using QLBH.DAO;
using QLBH.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class reportHoaDon : Form
    {
        public reportHoaDon()
        {
            InitializeComponent();
        }

        private void reportHoaDon_Load(object sender, EventArgs e)
        {

           
            List<ChiTietDonHangDTO> dsCTHH = new List<ChiTietDonHangDTO>();
            dsCTHH = ChiTietDonHangDAO.Instance.GetListChiTietHangHoa();
            ReportParameter[] param = new ReportParameter[1];

            param[1] = new ReportParameter("TIME", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            this.reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            this.reportViewer1.LocalReport.SetParameters(param);
            var reportDataSource = new ReportDataSource("DataSetHD", dsCTHH);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

            
        }
    }
}
