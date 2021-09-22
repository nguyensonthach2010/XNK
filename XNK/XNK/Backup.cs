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
    public partial class Backup : DevExpress.XtraEditors.XtraForm
    {
        public Backup()
        {
            InitializeComponent();
        }
            
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textEdit1.Text = dlg.SelectedPath;
                simpleButton2.Enabled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit1.Text == string.Empty)
                {
                    XtraMessageBox.Show("Vui lòng chọn đường dẫn lưu file backup", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = "BACKUP DATABASE [XNK] TO DISK ='" + textEdit1.Text + "\\" + "DATABASE" + "-" + DateTime.Now.ToString() + ".bak'";
                    if (ConnectDB.Query(sql) == -1)
                    {
                        XtraMessageBox.Show("Chỉ sao lưu dữ liệu được trên Server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else 
                    {
                        XtraMessageBox.Show("Back up dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        simpleButton2.Enabled = false;
                        this.Close();
                    }
                }
            }
            catch(Exception)
            {
                XtraMessageBox.Show(e.ToString());
            }
        }
    }
}