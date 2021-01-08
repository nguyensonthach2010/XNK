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
    public partial class RePI_UK : DevExpress.XtraEditors.XtraForm
    {
        public RePI_UK()
        {
            InitializeComponent();
        }

        private void RePI_UK_Load(object sender, EventArgs e)
        {
            LoadDT();
        }
        private void LoadDT()
        {
            Blinding();
            txtsodonsx.Text = TonPI_UK.sodonsx;
            txtpi.Text = TonPI_UK.PI;
            txtpsi.Text = TonPI_UK.PSI_ref;
            txtpl_pi.Value = Convert.ToInt32(TonPI_UK.pallet_pi);
            txtprice.Value = Convert.ToDecimal(TonPI_UK.price);
            txtitem.Text = TonPI_UK.item;
            txtctn.Text = TonPI_UK.CTN;
            txtvar.Text = TonPI_UK.VariantPI;
            txtkh.Text = TonPI_UK.khachhang;
        }
        private void Blinding()
        {
            string sql = "select *from Supplies where Variant = '" + TonPI_UK.VariantPI + "'";
            DataTable dt = ConnectDB.getTable(sql);
            txtctlcode.DataBindings.Add("Text", dt, "CatalanCode");
            txtsize.DataBindings.Add("Text", dt, "Size");
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string insert = "insert into Ton_PI values ('" + txtsodonsx.Text + "','" + txtpi.Text + "','" + txtpsi.Text + "','" + txtprice.Text + "','" + txtpl_pi.Text + "','" + Convert.ToDateTime(txtfob.Text).ToString("MM/dd/yyyy") + "','" + txtsl.Text + "','" + txtctn.Text + "',N'UK',N'" + txtkh.Text + "','" + txtvar.Text + "','" + txtitem.Text + "')";
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtfob.Text = "";
            txtsl.Text = "";
        }
    }
}