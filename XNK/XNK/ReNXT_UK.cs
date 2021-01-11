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
    public partial class ReNXT_UK : DevExpress.XtraEditors.XtraForm
    {
        public ReNXT_UK()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtfob.Text = "";
            txtslgiax.Text = "";
            txtslhopx.Text = "";
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string insert = "insert into NXT values ('" + txtnamsx.Text + "','" + Convert.ToDateTime(txtngaynhap.Text).ToString("MM/dd/yyyy") + "',N'" + txtkho.Text + "',N'" + txtvitri.Text + "','" + txtmacode.Text + "','" + txtduoimau.Text + "','" + txtloca.Text + "','" + txtslgia.Value + "','" + txtslhop.Text + "','" + txtdnxl.Text + "','" + Convert.ToDateTime(txtfob.Text).ToString("MM/dd/yyyy") + "','" + txtslgiax.Text + "',N'UK','" + txtslhopx.Text + "')";
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
        private void LoadDT()
        {
            txtdnxl.Text = NXT_UK.dnxl;
            txtkho.Text = NXT_UK.kho;
            txtloca.Text = NXT_UK.loca;
            txtduoimau.Value = Convert.ToInt32(NXT_UK.duoimau);
            txtslgia.Value = Convert.ToInt32(NXT_UK.slgia);
            txtslhop.Value = Convert.ToInt32(NXT_UK.slhop);
            txtngaynhap.Text = Convert.ToDateTime(NXT_UK.ngaynhap).ToString("MM/dd/yyyy");
            txtnamsx.Text = NXT_UK.namsx;
            txtvitri.Text = NXT_UK.vitri;
            txtmacode.Text = NXT_UK.ctlcode;
        }

        private void ReNXT_UK_Load(object sender, EventArgs e)
        {
            LoadDT();
        }
    }
}