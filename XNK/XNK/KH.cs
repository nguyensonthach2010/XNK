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
    public partial class KH : DevExpress.XtraEditors.XtraForm
    {
        public KH()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into KH values('"+textEdit1.Text+"')";
                if(ConnectDB.Query(sql)==-1)
                {
                    XtraMessageBox.Show("Thêm thất bại, hãy thử lại!!");
                }else
                {
                    XtraMessageBox.Show("Thêm khách hàng thành công!!");
                    this.Close();
                }    

            }catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra!! Hãy thử lại!!");
            }
        }
    }
}