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
    public partial class DMK : DevExpress.XtraEditors.XtraForm
    {
        public DMK()
        {
            InitializeComponent();
        }

        private void btndmk_Click(object sender, EventArgs e)
        {

            try
            {
                string sql = @"select * from NhanVien where username = '" + txttk.Text + "' and password = '" + txtmk.Text + "'";
                DataTable data = ConnectDB.getTable(sql);
                if (data.Rows.Count <= 0)
                {
                    MessageBox.Show("Mật khẩu hiện tại sai !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                if (txtmkm.Text != txtxacnhan.Text)
                {
                    MessageBox.Show("Xác nhận lại mật khẩu mới không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sql1 = @"update NhanVien set password='" + txtmkm.Text + "' where username= '" + txttk.Text + "'";
                    if (ConnectDB.Query(sql1) == -1)
                    {
                        MessageBox.Show("Đổi mật khẩu không thành công (T_T) !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thành công, mời bạn đăng nhập lại trong lần kế tiếp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Visible = false;
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Không thể kết nối tới CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void DMK_Load(object sender, EventArgs e)
        {
            txttk.Text = Login.tk;
        }
    }
}