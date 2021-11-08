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
    public partial class fAdmin : Form
    {
        string maDT;

        BindingSource listDoiTac = new BindingSource();

            public fAdmin()
        {
            InitializeComponent();

            Load();
        }

        void Load()
        {
            LoadHangHoa();
            LoadMaLoaiHangHoa();
            LoadMaKho();
            BindingHangHoa();

            LoadLoaiHangHoa();
            
            LoadKho();
            LoadTaiKhoang();
            LoadIDNhanVien();

            LoadNhanVien();
            dtgvDoiTac.DataSource = listDoiTac;
            
            LoadComboboxTenDT();
            LoadDoiTac();
            BindingDoiTac();
            BindingKho();
            BindingLHH();
            BindingTaiKhoan();
            BindingNhanVien();
            LoadKhachHang();
            BindingKhachHang();
        }

        #region Hàng hoá (method)
        void LoadHangHoa()
        {
            dtgvHangHoa.DataSource = HangHoaDAO.Instance.GetListHangHoa();
        }
        int HangHoaCheck()
        {
            if(string.IsNullOrEmpty(txbMaHH.Text)==true)
            {
                return 1;//ko dc de trong maHH
            }
            if(string.IsNullOrEmpty(txbTenHH.Text)==true)
            {
                return 2;//ko dc de trong tenHH
            }
            if(string.IsNullOrEmpty(txbGiaNhap.Text)==true)
            {
                return 3;//ko dc de trong gianhap
            }
            if(double.Parse(txbGiaNhap.Text)<0)
            {
                return 4;//gia nhap 0 dc nho hon 0
            }
            if(string.IsNullOrEmpty(txbGiaBan.Text)==true)
            {
                return 5;//ko dc de trong gia ban
            }
            if(double.Parse(txbGiaBan.Text)<0)
            {
                return 6;
            }

            return 0;
        }

        void LoadMaLoaiHangHoa()
        {
            List<LoaiHangHoaDTO> lsh = LoaiHangHoaDAO.Instance.GetListLoaiHangHoa();
            cbxMaLoai.DataSource = lsh;
            cbxMaLoai.DisplayMember = "MaLoai";
            
        }
      
        void LoadComboboxTenDT()
        {
            List<DoiTacDTO> tdt = DoiTacDAO.Instance.GetListMaDoiTac();
            cbxTenDT.DataSource = tdt;
            cbxTenDT.DisplayMember = "TenDT";
            cbxTenDT.ValueMember = maDT;

        }

        void LoadMaKho()
        {
            List<KhoDTO> kho = KhoDAO.Instance.GetListKho();
            cbxMaKho.DataSource = kho;
            cbxMaKho.DisplayMember = "MaKho";
        }
        void ThemHangHoa(string maHH, string tenHH, string tenDT, decimal giaNhap, decimal giaBan, string ghiChu, string maKho, string maDT, string maLoai)
        {
            if (HangHoaDAO.Instance.InsertHangHoa(maHH, tenHH, tenDT, giaNhap, giaBan, ghiChu, maKho, maDT, maLoai))
            {
                MessageBox.Show("Thêm hàng hoá thành công!");
            }
            else
            {
                MessageBox.Show("Thêm hàng hoá thất bại!");
            }

            LoadHangHoa();
        }

        void SuaHangHoa(string maHH, string tenHH, string tenDT, decimal giaNhap, decimal giaBan, string ghiChu, string maKho, string maDT, string maLoai)
        {
            if (HangHoaDAO.Instance.UpdateHangHoa(maHH, tenHH, tenDT, giaNhap, giaBan, ghiChu, maKho, maDT, maLoai))
            {
                MessageBox.Show("Sửa hàng hoá thành công!");
            }
            else
            {
                MessageBox.Show("Sửa hàng hoá thất bại!");
            }

            LoadHangHoa();
        }

        void XoaHangHoa(string maHH)
        {
            if (HangHoaDAO.Instance.DeleteHangHoa(maHH))
            {
                MessageBox.Show("Xoá hàng hoá thành công!");
            }
            else
            {
                MessageBox.Show("Xóa hàng hoá thất bại!");
            }


            LoadHangHoa();
        }

        void BindingHangHoa()
        {
            txbMaHH.DataBindings.Add(new Binding("Text", dtgvHangHoa.DataSource, "MaHH"));
            txbTenHH.DataBindings.Add(new Binding("Text", dtgvHangHoa.DataSource, "TenHH"));
            cbxTenDT.DataBindings.Add(new Binding("Text", dtgvHangHoa.DataSource, "TenDT"));
            txbGiaNhap.DataBindings.Add(new Binding("Text", dtgvHangHoa.DataSource, "GiaNhap"));
            txbGiaBan.DataBindings.Add(new Binding("Text", dtgvHangHoa.DataSource, "GiaBan"));
            txbGhiChu.DataBindings.Add(new Binding("Text", dtgvHangHoa.DataSource, "GhiChu"));
            cbxMaKho.DataBindings.Add(new Binding("Text", dtgvHangHoa.DataSource, "MaKho"));
            cbxMaDT.DataBindings.Add(new Binding("Text", dtgvHangHoa.DataSource, "MaDT"));
            cbxMaLoai.DataBindings.Add(new Binding("Text", dtgvHangHoa.DataSource, "MaLoai"));
        }
        #endregion

        #region Loại hàng hoá (method)
        void LoadLoaiHangHoa()
        {
            dtgvLoaiHangHoa.DataSource = LoaiHangHoaDAO.Instance.GetListLoaiHangHoa();
        }

        int LoaiHangHoaCheck()
        {
            if(string.IsNullOrEmpty(txbMLHH.Text)==true)
            {
                return 1;// ko được để trống mã loại
            }
            if(string.IsNullOrEmpty(txbTLHH.Text)==true)
            {
                return 2;// ko đc để trống tên loại
            }
            if(string.IsNullOrEmpty(txbSLHH.Text)==true)
            {
                return 3;// ko đc để trống số lượng
            }
            if(int.Parse(txbSLHH.Text)<0)
            {
                return 4;//ko được nhập số lượng nhỏ hơn 0
            }
            return 0;
        }
        void ThemLoaiHangHoa(string maLoai, string tenLoai, int soLuong)
        {
            if (LoaiHangHoaDAO.Instance.InsertLoaiHangHoa(maLoai, tenLoai, soLuong))
            {
                MessageBox.Show("Thêm loại hàng hoá thành công!");
            }
            else
            {
                MessageBox.Show("Thêm loại hàng hoá thất bại!");
            }

            LoadLoaiHangHoa();
        }

        void SuaLoaiHangHoa(string maLoai, string tenLoai, int soLuong)
        {
            if (LoaiHangHoaDAO.Instance.UpdateLoaiHangHoa(maLoai, tenLoai, soLuong))
            {
                MessageBox.Show("Sửa loại hàng hoá thành công!");
            }
            else
            {
                MessageBox.Show("Sửa loại hàng hoá thất bại!");
            }

            LoadLoaiHangHoa();
        }

        void XoaLoaiHangHoa(string maLoai)
        {
            if (LoaiHangHoaDAO.Instance.DeleteLoaiHangHoa(maLoai))
            {
                MessageBox.Show("Xoá loại hàng hoá thành công!");
            }
            else
            {
                MessageBox.Show("Xoá loại hàng hoá thất bại!");
            }

            LoadLoaiHangHoa();
        }
        void BindingLHH()
        {
            txbMLHH.DataBindings.Add(new Binding("Text", dtgvLoaiHangHoa.DataSource, "MaLoai"));
            txbTLHH.DataBindings.Add(new Binding("Text", dtgvLoaiHangHoa.DataSource, "TenLoai"));
            txbSLHH.DataBindings.Add(new Binding("Text", dtgvLoaiHangHoa.DataSource, "SoLuong"));
        }
        #endregion

        #region Kho (method)
        void LoadKho()
        {
            dtgvKho.DataSource = KhoDAO.Instance.GetListKho();
        }
        int KhoCheck()
        {
            if(string.IsNullOrEmpty(txbMaKho.Text)==true)
            {
                return 1;
            }
            if(string.IsNullOrEmpty(txbTenKho.Text)==true)
            {
                return 2;
            }
            return 0;
        }
        void ThemKho(string maKho, string tenKho)
        {
            if (KhoDAO.Instance.InsertKho(maKho, tenKho))
            {
                MessageBox.Show("Thêm kho thành công!");
            }
            else
            {
                MessageBox.Show("Thêm kho thất bại!");
            }

            LoadKho();
        }

        void SuaKho(string maKho, string tenKho)
        {
            if (KhoDAO.Instance.UpdateKho(maKho, tenKho))
            {
                MessageBox.Show("Sửa kho thành công!");
            }
            else
            {
                MessageBox.Show("Sửa kho thất bại!");
            }

            LoadKho();
        }

        void XoaKho(string maKho)
        {
            if (KhoDAO.Instance.DeleteKho(maKho))
            {
                MessageBox.Show("Xoá kho thành công!");
            }
            else
            {
                MessageBox.Show("Xoá kho thất bại!");
            }

            LoadKho();
        }
        void BindingKho()
        {
            txbMaKho.DataBindings.Add(new Binding("Text", dtgvKho.DataSource, "MaKho"));
            txbTenKho.DataBindings.Add(new Binding("Text", dtgvKho.DataSource, "TenKho"));

        }
        #endregion

        #region Tài khoảng (method)

        void LoadTaiKhoang()
        {
            dtgvTaiKhoang.DataSource = TaiKhoangDAO.Instance.GetListTaiKhoang();
        }
        int TaiKhoanCheck()
        {
            if(string.IsNullOrEmpty(txbTaiKhoang.Text)==true)
            {
                return 1;
            }
            if(string.IsNullOrEmpty(txbTenHienThi.Text)==true)
            {
                return 2;
            }
            if(string.IsNullOrEmpty(txbMatKhau.Text)==true)
            {
                return 3;
            }
            return 0;
        }

        void ThemTaiKhoang(string userName, string displayName, string passWord, int Type, string maNV)
        {
            if (TaiKhoangDAO.Instance.InsertTaiKhoang(userName, displayName, passWord, Type, maNV))
            {
                MessageBox.Show("Thêm tài khoảng thành công!");
            }
            else
            {
                MessageBox.Show("Thêm tài khoảng thất bại!");
            }

            LoadTaiKhoang();
        }

        void SuaTaiKhoang(string userName, string displayName, string passWord, int Type, string maNV)
        {
            if (TaiKhoangDAO.Instance.UpdateTaiKhoang(userName, displayName, passWord, Type, maNV))
            {
                MessageBox.Show("Sửa tài khoảng thành công!");
            }
            else
            {
                MessageBox.Show("Sửa tài khoảng thất bại!");
            }

            LoadTaiKhoang();
        }

        void XoaTaiKhoang(string maNV)
        {
            if (TaiKhoangDAO.Instance.DeleteTaiKhoang(maNV))
            {
                MessageBox.Show("Xoá tài khoảng thành công!");
            }
            else
            {
                MessageBox.Show("Xoá tài khoảng thất bại!");
            }

            LoadTaiKhoang();
        }
        void DoiMKTaiKhoan(string userName,  string passWord)
        {
            if(TaiKhoangDAO.Instance.UpdatePassWord(userName, passWord))
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!");
            }
            LoadTaiKhoang();
        }
        void BindingTaiKhoan()
        {
            txbTenHienThi.DataBindings.Add(new Binding("Text", dtgvTaiKhoang.DataSource, "DisplayName"));
            txbTaiKhoang.DataBindings.Add(new Binding("Text", dtgvTaiKhoang.DataSource, "UserName"));
            cbxType.DataBindings.Add(new Binding("Text", dtgvTaiKhoang.DataSource, "Type"));
            cbxMaNV.DataBindings.Add(new Binding("Text", dtgvTaiKhoang.DataSource, "MaNV"));


        }
        #endregion

        #region Khách hàng (method)
        void LoadKhachHang()
        {
            dtgvKhachHang.DataSource = KhachHangDAO.Instance.GetListKhachHang();
        }
        void ThemKhachHang(string maKH, string tenKH, string sdt, string diaChi, string gioiTinh, DateTime? ngaySinh)
        {
            if (KhachHangDAO.Instance.InsertKhachHang(maKH, tenKH, sdt, diaChi, gioiTinh, ngaySinh))
            {
                MessageBox.Show("Thêm hàng hoá thành công!");
            }
            else
            {
                MessageBox.Show("Thêm hàng hoá thất bại!");
            }
            LoadKhachHang();
        }

        void SuaKhachHang(string maKH, string tenKH, string sdt, string diaChi, string gioiTinh, DateTime? ngaySinh)
        {
            if (KhachHangDAO.Instance.UpdateNKhachHang(maKH, tenKH, sdt, diaChi, gioiTinh, ngaySinh))
            {
                MessageBox.Show("Sửa khách hàng thành công!");
            }
            else
            {
                MessageBox.Show("Sửa khách hàng thất bại!");
            }

            LoadKhachHang();
        }

        void XoaKhachHang(string maKH)
        {
            if (KhachHangDAO.Instance.DeleteKhachHang(maKH))
            {
                MessageBox.Show("Xoá khách hàng thành công!");
            }
            else
            {
                MessageBox.Show("Xoá khách hàng thất bại!");
            }

            LoadKhachHang();
        }
        void BindingKhachHang()
        {
            txbMaKH.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "MaKH"));
            txbTenKH.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "TenKH"));
            txbSDTKH.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "SDT"));
            cbxGioiTinhKH.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "GioiTinh"));
            dtpKH.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "NgaySinh"));
            txbDiaChiKH.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "DiaChi"));
        }
        int KhachHangCheck()
        {
            if(string.IsNullOrEmpty(txbMaKH.Text)==true)
            {
                return 1;
            }
            if(string.IsNullOrEmpty(txbTenKH.Text)==true)
            {
                return 2;
            }
            if(string.IsNullOrEmpty(txbSDTKH.Text)==true)
            {
                return 3;
            }
            if(string.IsNullOrEmpty(txbDiaChiKH.Text)==true)
            {
                return 4;
            }
            return 0;
        }


        #endregion

        #region Nhân viên (method)
        void LoadNhanVien()
        {
            dtgvNhanVien.DataSource = NhanVienDAO.Instance.GetListNhanVien();
        }
        int NhanVienCheck()
        {
            if(string.IsNullOrEmpty(txbMaNV.Text)==true)
            {
                return 1;
            }
            if(string.IsNullOrEmpty(txbTenNV.Text)==true)
            {
                return 2;
            }
            if(string.IsNullOrEmpty(txbChucVu.Text)==true)
            {
                return 3;
            }
            if (string.IsNullOrEmpty(txbDiaChi.Text) == true)
            {
                return 4;
            }
            if (string.IsNullOrEmpty(txbSDT.Text) == true)
            {
                return 5;
            }
            if(string.IsNullOrEmpty(txbLuong.Text)==true)
            {
                return 6;
            }
            if(double.Parse(txbLuong.Text)<0)
            {
                return 7;
            }
            return 0;
        }
        void ThemNhanVien(string maNV, string tenNV, string sdt, string diaChi, string chucVu, string gioiTinh, DateTime? ngaySinh, decimal luong)
        {
            try
            {
                if (NhanVienDAO.Instance.InsertNhanVien(maNV, tenNV, sdt, diaChi, chucVu, gioiTinh, ngaySinh, luong))
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!");
                }

                LoadNhanVien();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi!");
            }
        }

        void XoaNhanVien(string maNV)
        {
            if (NhanVienDAO.Instance.DeleteNhanVien(maNV))
            {
                MessageBox.Show("Xoá nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Xoá nhân viên thất bại!");
            }

            LoadNhanVien();
        }

        void SuaNhanVien(string maNV, string tenNV, string sdt, string diaChi, string chucVu, string gioiTinh, DateTime? ngaySinh, decimal luong)
        {
            if (NhanVienDAO.Instance.UpdateNhanVien(maNV, tenNV, sdt, diaChi, chucVu, gioiTinh, ngaySinh, luong))
            {
                MessageBox.Show("Sửa nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thất bại!");
            }

            LoadNhanVien();
        }

        void LoadIDNhanVien()
        {
            cbxMaNV.DataSource = NhanVienDAO.Instance.GetListNhanVien();
            cbxMaNV.DisplayMember = "MaNV";
        }
        void BindingNhanVien()
        {
            txbMaNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "MaNV"));
            txbTenNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "TenNV"));
            dtpNgaySinh.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "NgaySinh"));
            cbxGioiTinh.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "GioiTinh"));
            txbChucVu.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "ChucVu"));
            txbLuong.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "Luong"));
            txbSDT.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "SDT"));
            txbDiaChi.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "DiaChi"));
        }

        #endregion

        #region Đối tác (method)

      

        void LoadDoiTac()
        {
            listDoiTac.DataSource = DoiTacDAO.Instance.GetListMaDoiTac();
        }
        int DoiTacCheck()
        {
            if(string.IsNullOrEmpty(txbMaDoiTac.Text)==true)
            {
                return 1;
            }
            if(string.IsNullOrEmpty(txbTenDoiTac.Text)==true)
            {
                return 2;
            }
            if(string.IsNullOrEmpty(txbSDTDoiTac.Text)==true)
            {
                return 3;
            }
            if(string.IsNullOrEmpty(txbEmailDoiTac.Text)==true)
            {
                return 4;
            }
            return 0;
        }
        void BindingDoiTac()
        {
            txbMaDoiTac.DataBindings.Add(new Binding("Text", dtgvDoiTac.DataSource, "MaDT"));
            txbTenDoiTac.DataBindings.Add(new Binding("Text", dtgvDoiTac.DataSource, "TenDT"));
            txbSDTDoiTac.DataBindings.Add(new Binding("Text", dtgvDoiTac.DataSource, "SDT"));
            txbEmailDoiTac.DataBindings.Add(new Binding("Text", dtgvDoiTac.DataSource, "Email"));
        }

        void ThemDoiTac(string maDT, string tendT, string sdt, string email)
        {
            if (DoiTacDAO.Instance.InsertDoiTac(maDT, tendT, sdt, email))
            {
                MessageBox.Show("Thêm đối tác thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thêm đối tác thất bại!", "Thông báo");
            }
            


            LoadDoiTac();
        }

        void XoaDoiTac(string maDT)
        {
            if (DoiTacDAO.Instance.DeleteDoiTac(maDT))
            {
                MessageBox.Show("Xoá đối tác thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xóa đối tác thất bại!", "Thông báo");
            }

            LoadDoiTac();
        }

        void SuaDoiTac(string maDT, string tendT, string sdt, string email)
        {
            if (DoiTacDAO.Instance.UpdateDoiTac(maDT, tendT, sdt, email))
            {
                MessageBox.Show("Sửa đối tác thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Sửa đối tác thất bại!", "Thông báo");
            }

            LoadDoiTac();
        }



        #endregion

        #region Hàng hoá (event)


        private void btnThemHangHoa_Click(object sender, EventArgs e)
        {
            int checkHH = HangHoaCheck();
            switch(checkHH)
            {
                case 0:

                    try
                    {
                        string maHH = txbMaHH.Text;
                        string tenHH = txbTenHH.Text;
                        string tenDT = cbxTenDT.Text;
                        decimal giaNhap = Convert.ToDecimal(txbGiaNhap.Text);
                        decimal giaBan = Convert.ToDecimal(txbGiaBan.Text);
                        string ghiChu = txbGhiChu.Text;
                        string maKho = cbxMaKho.Text;
                        string maDT = cbxMaDT.Text;
                        string maLoai = cbxMaLoai.Text;

                        ThemHangHoa(maHH, tenHH, tenDT, giaNhap, giaBan, ghiChu, maKho, maDT, maLoai);

                        btnXoaHangHoa.Enabled = true;
                        btnXoaHangHoa.BackColor = Color.White;
                        btnXoaHangHoa.ForeColor = Color.Firebrick;

                        btnSuaHangHoa.Enabled = true;
                        btnSuaHangHoa.BackColor = Color.White;
                        btnSuaHangHoa.ForeColor = Color.Firebrick;

                        btnThemHangHoa.Enabled = false;

                        btnHuyHH.Visible = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm hàng hóa thất bại!", "Thông Báo!", MessageBoxButtons.OKCancel);
                    }
                    break;

                case 1:
                    MessageBox.Show("Vui lòng nhập mã hàng hóa", "Thông báo ", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Vui lòng nhập tên hàng hóa", "Thông báo ", MessageBoxButtons.OK);
                    break;
                case 3:
                    MessageBox.Show("Vui lòng nhập giá nhập", "Thông báo ", MessageBoxButtons.OK);
                    break;
                case 4:
                    MessageBox.Show("Vui lòng nhập giá nhập lớn hơn 0", "Thông báo ", MessageBoxButtons.OK);
                    break;
                case 5:
                    MessageBox.Show("Vui lòng nhập giá bán", "Thông báo ", MessageBoxButtons.OK);
                    break;
                case 6:
                    MessageBox.Show("Vui lòng nhập giá bán lớn hơn 0", "Thông báo ", MessageBoxButtons.OK);
                    break;

            }

        }
            
        

        private void btnSuaHangHoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maHH = txbMaHH.Text;
                string tenHH = txbTenHH.Text;
                string tenDT = cbxTenDT.Text;
                decimal giaNhap = Convert.ToDecimal(txbGiaNhap.Text);
                decimal giaBan = Convert.ToDecimal(txbGiaBan.Text);
                string ghiChu = txbGhiChu.Text;
                string maKho = cbxMaKho.Text;
                string maDT = cbxMaDT.Text;
                string maLoai = cbxMaLoai.Text;

                SuaHangHoa(maHH, tenHH, tenDT, giaNhap, giaBan, ghiChu, maKho, maDT, maLoai);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sửa hàng hóa thất bại","Thông Báo!", MessageBoxButtons.OKCancel);
            }
           
        }

        private void btnXoaHangHoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa hàng hóa này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) ;
                {
                    string maHH = txbMaHH.Text;

                    XoaHangHoa(maHH);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xóa hàng hóa thất bại" , "Thông Báo!" , MessageBoxButtons.OK);
            }
            
        }
        private void btnEditThemNV_Click(object sender, EventArgs e)
        {
            btnHuyHH.Visible = true;
            btnThemHangHoa.Enabled = true;
            btnThemHangHoa.BackColor = Color.White;
            btnThemHangHoa.ForeColor = Color.Firebrick;

            txbMaHH.Text = "";
            txbTenHH.Text = "";
            cbxMaDT.ResetText();
            cbxMaLoai.ResetText();
            cbxTenDT.ResetText();
            txbGiaBan.Text = "";
            txbGiaNhap.Text = "";
            cbxMaKho.ResetText();
            txbGhiChu.Text = "";

            btnSuaHangHoa.Enabled = false;
            btnSuaHangHoa.BackColor = Color.DarkGray;
            btnSuaHangHoa.ForeColor = Color.Black;

            btnXoaHangHoa.Enabled = false;
            btnXoaHangHoa.BackColor = Color.DarkGray;
            btnXoaHangHoa.ForeColor = Color.Black;

            btnEditThemHH.Visible = false;
        }
        private void btnHuyHH_Click(object sender, EventArgs e)
        {
            btnXoaHangHoa.Enabled = true;
            btnXoaHangHoa.BackColor = Color.White;
            btnXoaHangHoa.ForeColor = Color.Firebrick;

            btnSuaHangHoa.Enabled = true;
            btnSuaHangHoa.BackColor = Color.White;
            btnSuaHangHoa.ForeColor = Color.Firebrick;

            btnThemHangHoa.Enabled = false;
            btnHuyHH.Visible = false;

            btnEditThemHH.Visible = true;
        }

        #endregion

        #region Loại hàng hoá (event)
        private void btnThemLoaiHangHoa_Click_1(object sender, EventArgs e)
        {
            int c = LoaiHangHoaCheck();
            switch(c)
            {
                case 0:
                    try
                    {
                        string maLoai = txbMLHH.Text;
                        string tenLoai = txbMLHH.Text;
                        int soLuong = Convert.ToInt32(txbSLHH.Text);

                        ThemLoaiHangHoa(maLoai, tenLoai, Convert.ToInt32(soLuong));

                        btnXoaLoaiHangHoa.Enabled = true;
                        btnXoaLoaiHangHoa.BackColor = Color.White;
                        btnXoaLoaiHangHoa.ForeColor = Color.Firebrick;

                        btnSuaLoaiHangHoa.Enabled = true;
                        btnSuaLoaiHangHoa.BackColor = Color.White;
                        btnSuaLoaiHangHoa.ForeColor = Color.Firebrick;

                        btnThemLoaiHangHoa.Enabled = false;

                        btnHuyLHH.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm loại hàng hóa thất bại!", "Thông Báo!", MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    MessageBox.Show("Vui lòng nhập mã loại", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Vui lòng nhập tên loại", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 3:
                    MessageBox.Show("Vui lòng nhập số lượng", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 4:
                    MessageBox.Show("Vui lòng nhập số lượng nhỏ hơn 0", "Thông Báo!", MessageBoxButtons.OK);
                    break;

            }
            
            

            }

        private void btnXoaLoaiHangHoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa loại hàng hóa này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) ;
                {
                    string maLoai = txbMLHH.Text;

                    XoaLoaiHangHoa(maLoai);
                }
            }
            catch
            {
                MessageBox.Show("Xóa loại hàng hóa thất bại!", "Thông Báo!", MessageBoxButtons.OKCancel);
            }
            
        }

        private void btnSuaLoaiHangHoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maLoai = txbMLHH.Text;
                string tenLoai = txbTLHH.Text;
                int soLuong = Convert.ToInt32(txbSLHH.Text);

                SuaLoaiHangHoa(maLoai, tenLoai, Convert.ToInt32(soLuong));
            }
            catch
            {
                MessageBox.Show("Sửa loại hàng hóa thất bại!", "Thông Báo!", MessageBoxButtons.OKCancel);
            }
            
        }
        private void btnEditThemLHH_Click(object sender, EventArgs e)
        {
            btnHuyLHH.Visible = true;
            btnThemLoaiHangHoa.Enabled = true;
            btnThemLoaiHangHoa.BackColor = Color.White;
            btnThemLoaiHangHoa.ForeColor = Color.Firebrick;

            btnSuaLoaiHangHoa.Enabled = false;
            btnSuaLoaiHangHoa.BackColor = Color.DarkGray;
            btnSuaLoaiHangHoa.ForeColor = Color.Black;

            btnXoaLoaiHangHoa.Enabled = false;
            btnXoaLoaiHangHoa.BackColor = Color.DarkGray;
            btnXoaLoaiHangHoa.ForeColor = Color.Black;

            btnEditThemLHH.Visible = false;

            txbMLHH.Text = "";
            txbTLHH.Text = "";
            txbSLHH.Text = "";
        }
        private void btnHuyLHH_Click(object sender, EventArgs e)
        {
            btnXoaLoaiHangHoa.Enabled = true;
            btnXoaLoaiHangHoa.BackColor = Color.White;
            btnXoaLoaiHangHoa.ForeColor = Color.Firebrick;

            btnSuaLoaiHangHoa.Enabled = true;
            btnSuaLoaiHangHoa.BackColor = Color.White;
            btnSuaLoaiHangHoa.ForeColor = Color.Firebrick;

            btnThemLoaiHangHoa.Enabled = false;
            btnHuyLHH.Visible = false;
            btnEditThemLHH.Visible = true;
        }


        #endregion

        #region Kho (event)
        private void btnThemKho_Click(object sender, EventArgs e)
        {
            int c = KhoCheck();
            switch(c)
            {
                case 0:
                    try
                    {
                        string maKho = txbMaKho.Text;
                        string tenKho = txbTenKho.Text;

                        ThemKho(maKho, tenKho);

                        btnXoaKho.Enabled = true;
                        btnXoaKho.BackColor = Color.White;
                        btnXoaKho.ForeColor = Color.Firebrick;

                        btnSuaKho.Enabled = true;
                        btnSuaKho.BackColor = Color.White;
                        btnSuaKho.ForeColor = Color.Firebrick;

                        btnThemKho.Enabled = false;

                        btnHuyKho.Visible = false;
                    }
                    catch
                    {
                        MessageBox.Show("Thêm kho thất bại!", "Thông Báo!", MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    MessageBox.Show("Vui lòng nhập mã kho", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Vui lòng nhập tên kho", "Thông Báo!", MessageBoxButtons.OK);
                    break;


            }
            
           
        }

        private void btnXoaKho_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa kho này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) ;
            {
                string maKho = txbMaKho.Text;

                XoaKho(maKho);
            }
        }

        private void btnSuaKho_Click(object sender, EventArgs e)
        {
            string maKho = txbMaKho.Text;
            string tenKho = txbTenKho.Text;

            SuaKho(maKho, tenKho);
        }
        private void btnEditKho_Click(object sender, EventArgs e)
        {
            btnHuyKho.Visible = true;
            btnThemKho.Enabled = true;
            btnThemKho.BackColor = Color.White;
            btnThemKho.ForeColor = Color.Firebrick;

            btnSuaKho.Enabled = false;
            btnSuaKho.BackColor = Color.DarkGray;
            btnSuaKho.ForeColor = Color.Black;

            btnXoaKho.Enabled = false;
            btnXoaKho.BackColor = Color.DarkGray;
            btnXoaKho.ForeColor = Color.Black;

            btnEditKho.Visible = false;

            txbMaKho.Text = "";
            txbTenKho.Text = "";
        }
        private void btnHuyKho_Click(object sender, EventArgs e)
        {
            btnXoaKho.Enabled = true;
            btnXoaKho.BackColor = Color.White;
            btnXoaKho.ForeColor = Color.Firebrick;

            btnSuaKho.Enabled = true;
            btnSuaKho.BackColor = Color.White;
            btnSuaKho.ForeColor = Color.Firebrick;

            btnThemKho.Enabled = false;
            btnHuyKho.Visible = false;
            btnEditKho.Visible = true;
        }




        #endregion

        #region Tài khoản(event)
        private void btnThemTaiKhoang_Click(object sender, EventArgs e)
        {
            int c = TaiKhoanCheck();
            switch(c)
            {
                case 0:
                    try
                    {
                        string userName = txbTaiKhoang.Text;
                        string displayName = txbTenHienThi.Text;
                        string passWord = txbMatKhau.Text;
                        int Type = Convert.ToInt32(cbxType.Text);
                        string maNV = cbxMaNV.Text;

                        ThemTaiKhoang(userName, displayName, passWord, Type, maNV);

                        btnXoaTaiKhoang.Enabled = true;
                        btnXoaTaiKhoang.BackColor = Color.White;
                        btnXoaTaiKhoang.ForeColor = Color.Firebrick;

                        btnSuaTaiKhoang.Enabled = true;
                        btnSuaTaiKhoang.BackColor = Color.White;
                        btnSuaTaiKhoang.ForeColor = Color.Firebrick;

                        btnDoiMatKhau.Enabled = true;
                        btnDoiMatKhau.BackColor = Color.White;
                        btnDoiMatKhau.ForeColor = Color.Firebrick;

                        btnThemTaiKhoang.Enabled = false;

                        btnHuyTK.Visible = false;
                    }
                    catch
                    {
                        MessageBox.Show("Thêm tài khoản thất bại!", "Thông Báo!", MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    MessageBox.Show("Vui lòng nhập tài khoản", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Vui lòng nhập tên hiển thị", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 3:
                    MessageBox.Show("Vui lòng nhập mật khẩu", "Thông Báo!", MessageBoxButtons.OK);
                    break;
            }
            
            
        }

        private void btnSuaTaiKhoang_Click(object sender, EventArgs e)
        {
            string userName = txbTaiKhoang.Text;
            string displayName = txbTenHienThi.Text;
            string passWord = txbMatKhau.Text;
            int Type = Convert.ToInt32(cbxType.Text);
            string maNV = cbxMaNV.Text;

            SuaTaiKhoang(userName, displayName, passWord, Type, maNV);
        }

        private void btnXoaTaiKhoang_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa tài khoản này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) ;
                {
                    string maNV = cbxMaNV.Text;

                    if (cbxMaNV.Text == "")
                    {
                        MessageBox.Show("Chọn lại nhân viên có tài khoản");
                    }
                    else
                    {
                        XoaTaiKhoang(maNV);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Xóa tài khoản thất bại!", "Thông Báo!", MessageBoxButtons.OK);
            }
            
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txbTaiKhoang.Text;
                string displayName = txbTenHienThi.Text;
                string passWord = txbMatKhau.Text;
                int Type = Convert.ToInt32(cbxType.Text);
                string maNV = cbxMaNV.Text;

                DoiMKTaiKhoan(userName, passWord);
            }
            catch
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Thông Báo!", MessageBoxButtons.OK);
            }
            

        }
        private void btnEditThemTK_Click(object sender, EventArgs e)
        {
            btnHuyTK.Visible = true;
            btnThemTaiKhoang.Enabled = true;
            btnThemTaiKhoang.BackColor = Color.White;
            btnThemTaiKhoang.ForeColor = Color.Firebrick;

            btnSuaTaiKhoang.Enabled = false;
            btnSuaTaiKhoang.BackColor = Color.DarkGray;
            btnSuaTaiKhoang.ForeColor = Color.Black;

            btnXoaTaiKhoang.Enabled = false;
            btnXoaTaiKhoang.BackColor = Color.DarkGray;
            btnXoaTaiKhoang.ForeColor = Color.Black;

            btnDoiMatKhau.Enabled = false;
            btnDoiMatKhau.BackColor = Color.DarkGray;
            btnDoiMatKhau.ForeColor = Color.Black;

            btnEditThemTK.Visible = false;

            txbTaiKhoang.Text = "";
            txbTenHienThi.Text = "";
            cbxType.ResetText();
            cbxMaNV.ResetText();
            txbMatKhau.Text = "";
        }
        private void btnHuyTK_Click(object sender, EventArgs e)
        {
            btnXoaTaiKhoang.Enabled = true;
            btnXoaTaiKhoang.BackColor = Color.White;
            btnXoaTaiKhoang.ForeColor = Color.Firebrick;

            btnSuaTaiKhoang.Enabled = true;
            btnSuaTaiKhoang.BackColor = Color.White;
            btnSuaTaiKhoang.ForeColor = Color.Firebrick;

            btnDoiMatKhau.Enabled = true;
            btnDoiMatKhau.BackColor = Color.White;
            btnDoiMatKhau.ForeColor = Color.Firebrick;

            btnThemTaiKhoang.Enabled = false;
            btnHuyTK.Visible = false;

            btnEditThemTK.Visible = true;
        }


        #endregion

        #region Nhân viên (event)
        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            int c = NhanVienCheck();
            switch(c)
            {
                case 0:
                    try
                    {
                        string maNV = txbMaNV.Text;
                        string tenNV = txbTenNV.Text;
                        string sdt = txbSDT.Text;
                        string diaChi = txbDiaChi.Text;
                        string chucVu = txbChucVu.Text;
                        string gioiTinh = cbxGioiTinh.Text;
                        DateTime? ngaySinh = dtpNgaySinh.Value;
                        decimal luong = Convert.ToDecimal(txbLuong.Text);

                        ThemNhanVien(maNV, tenNV, sdt, diaChi, chucVu, gioiTinh, ngaySinh, luong);

                        btnXoaNhanVien.Enabled = true;
                        btnXoaNhanVien.BackColor = Color.White;
                        btnXoaNhanVien.ForeColor = Color.Firebrick;

                        btnSuaNhanVien.Enabled = true;
                        btnSuaNhanVien.BackColor = Color.White;
                        btnSuaNhanVien.ForeColor = Color.Firebrick;

                        btnThemNhanVien.Enabled = false;

                        btnHuyNV.Visible = false;
                    }
                    catch
                    {
                        MessageBox.Show("Thêm nhân viên thất bại", "Thông Báo!", MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 3:
                    MessageBox.Show("Vui lòng nhập chức vụ", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 4:
                    MessageBox.Show("Vui lòng nhập địa chỉ", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 5:
                    MessageBox.Show("Vui lòng nhập số điện thoại", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 6:
                    MessageBox.Show("Vui lòng nhập lương", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 7:
                    MessageBox.Show("Vui lòng nhập lương lớn hơn 0", "Thông Báo!", MessageBoxButtons.OK);
                    break;

            }
            
           
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa hàng hóa này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) ;
                {
                    string maNV = txbMaNV.Text;

                    XoaNhanVien(maNV);
                }
            }
            catch
            {
                MessageBox.Show("Xóa nhân viên thất bại", "Thông Báo!", MessageBoxButtons.OK);
            }
            
        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txbMaNV.Text;
                string tenNV = txbTenNV.Text;
                string sdt = txbSDT.Text;
                string diaChi = txbDiaChi.Text;
                string chucVu = txbChucVu.Text;
                string gioiTinh = cbxGioiTinh.Text;
                DateTime? ngaySinh = dtpNgaySinh.Value;
                decimal luong = Convert.ToDecimal(txbLuong.Text);

                SuaNhanVien(maNV, tenNV, sdt, diaChi, chucVu, gioiTinh, ngaySinh, luong);
            }
            catch
            {
                MessageBox.Show("Sửa nhân viên thất bại", "Thông Báo!", MessageBoxButtons.OK);
            }
            
        }
        private void btnEditThemNV_Click_1(object sender, EventArgs e)
        {
            btnHuyNV.Visible = true;
            btnThemNhanVien.Enabled = true;
            btnThemNhanVien.BackColor = Color.White;
            btnThemNhanVien.ForeColor = Color.Firebrick;

            txbMaNV.Text = "";
            txbTenNV.Text = "";
            cbxGioiTinh.ResetText();
            txbChucVu.Text = "";
            txbDiaChi.Text = "";
            txbLuong.Text = "";
            txbSDT.Text = "";

            btnSuaNhanVien.Enabled = false;
            btnSuaNhanVien.BackColor = Color.DarkGray;
            btnSuaNhanVien.ForeColor = Color.Black;

            btnXoaNhanVien.Enabled = false;
            btnXoaNhanVien.BackColor = Color.DarkGray;
            btnXoaNhanVien.ForeColor = Color.Black;

            btnEditThemNV.Visible = false;

        }

        private void btnHuyNV_Click(object sender, EventArgs e)
        {
            btnXoaNhanVien.Enabled = true;
            btnXoaNhanVien.BackColor = Color.White;
            btnXoaNhanVien.ForeColor = Color.Firebrick;

            btnSuaNhanVien.Enabled = true;
            btnSuaNhanVien.BackColor = Color.White;
            btnSuaNhanVien.ForeColor = Color.Firebrick;

            btnThemNhanVien.Enabled = false;
            btnHuyNV.Visible = false;
            btnEditThemNV.Visible = true;
        }


        #endregion

        #region Đối tác (event)
        private void button1_Click(object sender, EventArgs e)
        {
            int c = NhanVienCheck();
            switch(c)
            {
                case 0:
                    try
                    {
                        string maDT = txbMaDoiTac.Text;
                        string tenDT = txbTenDoiTac.Text;
                        string sdtDT = txbSDTDoiTac.Text;
                        string emailDT = txbEmailDoiTac.Text;

                        ThemDoiTac(maDT, tenDT, sdtDT, emailDT);

                        btnXoaDoiTac.Enabled = true;
                        btnXoaDoiTac.BackColor = Color.White;
                        btnXoaDoiTac.ForeColor = Color.Firebrick;

                        btnSuaDoiTac.Enabled = true;
                        btnSuaDoiTac.BackColor = Color.White;
                        btnSuaDoiTac.ForeColor = Color.Firebrick;

                        btnThemDoiTac.Enabled = false;

                        btnHuyDT.Visible = false;
                    }
                    catch
                    {
                        MessageBox.Show("Thêm đối tác thất bại", "Thông Báo!", MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    MessageBox.Show("Vui lòng nhập mã đối tác", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Vui lòng nhập tên đối tác", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 3:
                    MessageBox.Show("Vui lòng nhập số điện thoại đối tác", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 4:
                    MessageBox.Show("Vui lòng nhập email đối tác", "Thông Báo!", MessageBoxButtons.OK);
                    break;

            }
           
            
        }


        private void btnXoaDoiTac_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa đối tác này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) ;
                {
                    string maDT = txbMaDoiTac.Text;

                    XoaDoiTac(maDT);
                }
            }
            catch
            {
                MessageBox.Show("Xóa đối tác thất bại", "Thông Báo!", MessageBoxButtons.OK);
            }
        }

        private void btnSuaDoiTac_Click_1(object sender, EventArgs e)
        {
            try
            {
                string maDT = txbMaDoiTac.Text;
                string tenDT = txbTenDoiTac.Text;
                string sdtDT = txbSDTDoiTac.Text;
                string emailDT = txbEmailDoiTac.Text;

                SuaDoiTac(maDT, tenDT, sdtDT, emailDT);
            }
            catch
            {
                MessageBox.Show("Sửa đối tác thất bại", "Thông Báo!", MessageBoxButtons.OK);
            }
        }
        private void btnEditThemDT_Click(object sender, EventArgs e)
        {

            btnHuyDT.Visible = true;
            btnThemDoiTac.Enabled = true;
            btnThemDoiTac.BackColor = Color.White;
            btnThemDoiTac.ForeColor = Color.Firebrick;

            txbMaDoiTac.Text = "";
            txbTenDoiTac.Text = "";
            txbEmailDoiTac.Text = "";
            txbSDTDoiTac.Text = "";

            btnSuaDoiTac.Enabled = false;
            btnSuaDoiTac.BackColor = Color.DarkGray;
            btnSuaDoiTac.ForeColor = Color.Black;

            btnXoaDoiTac.Enabled = false;
            btnXoaDoiTac.BackColor = Color.DarkGray;
            btnXoaDoiTac.ForeColor = Color.Black;

            btnEditThemDT.Visible = false;
        }

        private void btnHuyDT_Click(object sender, EventArgs e)
        {
            btnXoaDoiTac.Enabled = true;
            btnXoaDoiTac.BackColor = Color.White;
            btnXoaDoiTac.ForeColor = Color.Firebrick;

            btnSuaDoiTac.Enabled = true;
            btnSuaDoiTac.BackColor = Color.White;
            btnSuaDoiTac.ForeColor = Color.Firebrick;

            btnThemDoiTac.Enabled = false;
            btnHuyDT.Visible = false;
            btnEditThemDT.Visible = true;
        }




        #endregion

        #region Khách hàng (event)

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            int c = KhachHangCheck();
            switch(c)
            {
                case 0:
                    try
                    {
                        string maKH = txbMaKH.Text;
                        string tenKH = txbTenKH.Text;
                        string sdt = txbSDTKH.Text;
                        string diaChi = txbDiaChiKH.Text;
                        string gioiTinh = cbxGioiTinhKH.Text;
                        DateTime? ngaySinh = dtpKH.Value;

                        ThemKhachHang(maKH, tenKH, sdt, diaChi, gioiTinh, ngaySinh);

                        btnXoaKH.Enabled = true;
                        btnXoaKH.BackColor = Color.White;
                        btnXoaKH.ForeColor = Color.Firebrick;

                        btnSuaKH.Enabled = true;
                        btnSuaKH.BackColor = Color.White;
                        btnSuaKH.ForeColor = Color.Firebrick;

                        btnThemKH.Enabled = false;

                        btnHuyKH.Visible = false;
                    }
                    catch
                    {
                        MessageBox.Show("Thêm khách hàng thất bại", "Thông Báo!", MessageBoxButtons.OK);
                    }
                    break;

                case 1:
                    MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Vui lòng nhập tên khách hàng", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 3:
                    MessageBox.Show("Vui lòng nhập số điện thoại khách hàng", "Thông Báo!", MessageBoxButtons.OK);
                    break;
                case 4:
                    MessageBox.Show("Vui lòng nhập địa chỉ khách hàng", "Thông Báo!", MessageBoxButtons.OK);
                    break;

            }
            
           
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) ;
                {
                    string maKH = txbMaKH.Text;
                    XoaKhachHang(maKH);
                }
            }
            catch
            {
                MessageBox.Show("Xóa khách hàng thất bại", "Thông Báo!", MessageBoxButtons.OK);
            }
        }

        private void SuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txbMaKH.Text;
                string tenKH = txbTenKH.Text;
                string sdt = txbSDTKH.Text;
                string diaChi = txbDiaChiKH.Text;
                string gioiTinh = cbxGioiTinhKH.Text;
                DateTime? ngaySinh = dtpKH.Value;

                SuaKhachHang(maKH, tenKH, sdt, diaChi, gioiTinh, ngaySinh);
            }
            catch
            {
                MessageBox.Show("Sửa khách hàng thất bại", "Thông Báo!", MessageBoxButtons.OK);
            }

        }
        private void btnEditThemKH_Click(object sender, EventArgs e)
        {
            btnHuyKH.Visible = true;
            btnThemKH.Enabled = true;
            btnThemKH.BackColor = Color.White;
            btnThemKH.ForeColor = Color.Firebrick;

            btnSuaKH.Enabled = false;
            btnSuaKH.BackColor = Color.DarkGray;
            btnSuaKH.ForeColor = Color.Black;

            btnXoaKH.Enabled = false;
            btnXoaKH.BackColor = Color.DarkGray;
            btnXoaKH.ForeColor = Color.Black;

            btnEditThemKH.Visible = false;

            txbMaKH.Text = "";
            txbTenKH.Text = "";
            txbSDTKH.Text = "";
            txbDiaChiKH.Text = "";
            cbxGioiTinhKH.ResetText();
        }

        private void btnHuyKH_Click(object sender, EventArgs e)
        {
            btnXoaKH.Enabled = true;
            btnXoaKH.BackColor = Color.White;
            btnXoaKH.ForeColor = Color.Firebrick;

            btnSuaKH.Enabled = true;
            btnSuaKH.BackColor = Color.White;
            btnSuaKH.ForeColor = Color.Firebrick;

            btnThemKH.Enabled = false;
            btnHuyKH.Visible = false;
            btnEditThemKH.Visible = true;
        }


        #endregion


    }
}
