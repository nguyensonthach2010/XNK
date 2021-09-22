using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace XNK
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }
        private bool validate()
        {
            if (txtuser.Text == "" || txtpass.Text == "")
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtuser.Text= Properties.Settings.Default.user;
            txtpass.Text= Properties.Settings.Default.pass;
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Lilian"; // cài đặt giao diện mặc định của form
        }
        public static string tk = "";
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (validate())  //kiểm tra dữ liệu 
                {

                    string sql = @"select * from NhanVien where username = '" + txtuser.Text + "' and password = '" + txtpass.Text + "'";
                    DataTable data = ConnectDB.getTable(sql);

                    if (data.Rows.Count <= 0)
                    {
                        XtraMessageBox.Show("Tài khoản hoắc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Properties.Settings.Default.user = "";
                        Properties.Settings.Default.pass = "";
                    }
                    else  //nếu số dòng lấy được > 0 thì :
                        if (data.Rows[0]["trangthai"].ToString() == "Active") // kiểm tra dữ liệu cột trạng thái trong sql nếu là Active thì mới được quyền truy cập
                    {
                        Quyentc.quyentc = data.Rows[0]["quyentc"].ToString();
                        tk = txtuser.Text;
                        this.Visible = false;
                        new Form1().ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("Tài khoản này hiện đang bị khoá. Liên hệ quản trị viên để mở khoá tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch
            {
                XtraMessageBox.Show("Không thể kết nối tới CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (checkEdit1.Checked)
            {
                // kiểm tra nếu chọn nhớ mật khẩu thì ghi lại user và pass không thì để trống
                Properties.Settings.Default.user = txtuser.Text;
                Properties.Settings.Default.pass = txtpass.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.user = "";
                Properties.Settings.Default.pass = "";
                Properties.Settings.Default.Save();
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                btnlogin_Click(null, null);
        }
    }
}