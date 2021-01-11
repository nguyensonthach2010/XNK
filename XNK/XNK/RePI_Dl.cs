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
    public partial class RePI_Dl : DevExpress.XtraEditors.XtraForm
    {
        public RePI_Dl()
        {
            InitializeComponent();
        }

        private void RePI_Dl_Load(object sender, EventArgs e)
        {
            LoadDT();
            txtfob.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
        private void LoadDT()
        {
            Blinding();
            txtsodonsx.Text = TonPI_Dl.sodonsx;
            txtpi.Text = TonPI_Dl.PI;
            txtpsi.Text = TonPI_Dl.PSI_ref;
            txtpl_pi.Value = Convert.ToInt32(TonPI_Dl.pallet_pi);
            txtprice.Value = Convert.ToDecimal(TonPI_Dl.price);
            txtitem.Text = TonPI_Dl.item;
            txtctn.Text = TonPI_Dl.CTN;
            txtvar.Text = TonPI_Dl.VariantPI;
            txtkh.Text = TonPI_Dl.khachhang;
        }
        private void Blinding()
        {
            string sql = "select *from Supplies where Variant = '" + TonPI_Dl.VariantPI + "'";
            DataTable dt = ConnectDB.getTable(sql);
            txtctlcode.DataBindings.Add("Text", dt, "CatalanCode");
            txtsize.DataBindings.Add("Text", dt, "Size");
        }
        //Thêm
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string insert = "insert into Ton_PI values ('" + txtsodonsx.Text + "','" + txtpi.Text + "','" + txtpsi.Text + "','" + txtprice.Text + "','" + txtpl_pi.Text + "','" + Convert.ToDateTime(txtfob.Text).ToString("MM/dd/yyyy") + "','" + txtsl.Text + "','" + txtctn.Text + "',N'Đài loan',N'" + txtkh.Text + "','" + txtvar.Text + "','" + txtitem.Text + "')";
                ConnectDB.Query(insert);
                DialogResult tb = XtraMessageBox.Show("Đã thêm. Hãy bấm F5 ở form Tồn PI để load lại dữ liệu !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (tb == DialogResult.OK)
                    this.Close();
            }
            catch
            {
                XtraMessageBox.Show("Không thể kết nối tới CSDL!!");
            }
        }
        // Reset
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtfob.Text = "";
            txtsl.Text = "";
        }
    }
}