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
    public partial class ReNXT_Anh : DevExpress.XtraEditors.XtraForm
    {
        public ReNXT_Anh()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string insert = "insert into NXT values ('" + txtnamsx.Text + "','" + Convert.ToDateTime(txtngaynhap.Text).ToString("MM/dd/yyyy") + "',N'" + txtkho.Text + "',N'" + txtvitri.Text + "','" + txtmacode.Text + "','" + txtduoimau.Text + "','" + txtloca.Text + "','" + txtslgia.Value + "','" + txtslhop.Text + "','" + txtdnxl.Text + "','" + Convert.ToDateTime(txtfob.Text).ToString("MM/dd/yyyy") + "','" + txtslgiax.Text + "',N'Anh','" + txtslhopx.Text + "')";
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
            txtdnxl.Text = NXT_Anh.dnxl;
            txtkho.Text = NXT_Anh.kho;
            txtloca.Text = NXT_Anh.loca;
            txtduoimau.Value = Convert.ToInt32(NXT_Anh.duoimau);
            txtslgia.Value = Convert.ToInt32(NXT_Anh.slgia);
            txtslhop.Value = Convert.ToInt32(NXT_Anh.slhop);
            txtngaynhap.Text = Convert.ToDateTime(NXT_Anh.ngaynhap).ToString("MM/dd/yyyy");
            txtnamsx.Text = NXT_Anh.namsx;
            txtvitri.Text = NXT_Anh.vitri;
            txtmacode.Text = NXT_Anh.ctlcode;
        }

        private void ReNXT_Anh_Load(object sender, EventArgs e)
        {
            LoadDT();
        }
    }
}