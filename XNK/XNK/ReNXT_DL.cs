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
    public partial class ReNXT_DL : DevExpress.XtraEditors.XtraForm
    {
        public ReNXT_DL()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string insert = "insert into NXT values ('" + txtnamsx.Text + "','" + Convert.ToDateTime(txtngaynhap.Text).ToString("MM/dd/yyyy") + "',N'" + txtkho.Text + "',N'" + txtvitri.Text + "','" + txtmacode.Text + "','" + txtduoimau.Text + "','" + txtloca.Text + "','" + txtslgia.Value + "','" + txtslhop.Text + "','" + txtdnxl.Text + "','" + Convert.ToDateTime(txtfob.Text).ToString("MM/dd/yyyy") + "','" + txtslgiax.Text + "',N'Đài loan','" + txtslhopx.Text + "')";
                ConnectDB.Query(insert);
                DialogResult tb = XtraMessageBox.Show("Đã thêm. Hãy bấm F5 ở form NXT để load lại dữ liệu !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (tb == DialogResult.OK)
                    this.Close();
            }
            catch
            {
                XtraMessageBox.Show("Không thể kết nối tới CSDL!!");
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtfob.Text = "";
            txtslgiax.Text = "";
            txtslhopx.Text = "";
        }
        private void LoadDT()
        {
            txtdnxl.Text = NXT_DL.dnxl;
            txtkho.Text = NXT_DL.kho;
            txtloca.Text = NXT_DL.loca;
            txtduoimau.Value = Convert.ToInt32(NXT_DL.duoimau);
            txtslgia.Value = Convert.ToInt32(NXT_DL.slgia);
            txtslhop.Value = Convert.ToInt32(NXT_DL.slhop);
            txtngaynhap.Text = Convert.ToDateTime(NXT_DL.ngaynhap).ToString("MM/dd/yyyy");
            txtnamsx.Text = NXT_DL.namsx;
            txtvitri.Text = NXT_DL.vitri;
            txtmacode.Text = NXT_DL.ctlcode;
        }

        private void ReNXT_DL_Load(object sender, EventArgs e)
        {
            LoadDT();
        }
    }
}