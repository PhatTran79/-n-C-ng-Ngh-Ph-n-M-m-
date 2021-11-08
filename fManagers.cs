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
    public partial class fManagers : Form
    {
        public fManagers()
        {
            InitializeComponent();
            dtgvChiTietHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadIDHangHoa();

            ShowChiTietHangHoa();

            BindingThanhTien();

        }

        #region Hàng hoá (method)
        void LoadIDHangHoa()
        {
            cbxMaHangHoa.DataSource = HangHoaDAO.Instance.GetListHangHoa();
            cbxMaHangHoa.DisplayMember = "MaHH";
        }

        void LoadTenHangHoa(string id)
        {
            txbGiaBan.Text = HangHoaDAO.Instance.GetGiaBan(id);
        }

        void LoadListHangHoa()
        {
            string id = cbxMaHangHoa.Text;
            dtgvCheckHangHoa.DataSource = HangHoaDAO.Instance.GetListHangHoaByID(id);
        }

        void BindingThanhTien()
        {
            txbThanhTien.DataBindings.Add(new Binding("Text", dtgvChiTietHoaDon.DataSource, "DonGia"));
        }
        #endregion

        #region Chi tiết hàng hoá (method)

        void ShowChiTietHangHoa()
        {
            dtgvChiTietHoaDon.DataSource = ChiTietDonHangDAO.Instance.GetListChiTietHangHoa();
        }

        void ThemChiTietHoaDon(string maHH, decimal donGia, decimal giamGia, int soLuong)
        {

            if (ChiTietDonHangDAO.Instance.InsertChiTietHangHoa( maHH, donGia, giamGia, soLuong))
            {
                MessageBox.Show("Thêm hàng hoá thành công", "Thông báo");
            }

            ShowChiTietHangHoa();
        }
        void ThanhToanCTHH(int maDH)
        {
            if(MessageBox.Show("Bạn muốn thanh toán hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (ChiTietDonHangDAO.Instance.ThanhToanDH(maDH))
                {
                    MessageBox.Show("Thanh toán đơn hàng thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thanh toán đơn hàng thất bại", "Thông báo");
                }
                ShowChiTietHangHoa();
            }
            
            

        }

        #endregion

        #region Hàng hoá (sự kiện)

        private void btnShowHangHoa_Click_1(object sender, EventArgs e)
        {

            string id = cbxMaHangHoa.Text;

            LoadListHangHoa();
            LoadTenHangHoa(id);
        }

        #endregion

        #region Chi tiết hoá đơn (event)
        private void btnAddHangHoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maHH = cbxMaHangHoa.Text;
                int soLuong = Convert.ToInt32(numSoLuong.Value);

                decimal donGia = Convert.ToDecimal(txbGiaBan.Text) * numSoLuong.Value;
                decimal giamGia = numGiamGia.Value;

                ThemChiTietHoaDon(maHH, donGia, giamGia, soLuong);
            }
            catch
            {
                MessageBox.Show("Vui lòng nhấn xem để kiểm tra hàng hóa muốn thêm", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
           
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fManagers f = new fManagers();
            if (MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            reportHoaDon f = new reportHoaDon();
            f.ShowDialog();

        }




        #endregion

        
    }
}
