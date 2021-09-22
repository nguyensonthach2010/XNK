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
            txtfob.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
        private void LoadDT()
        {
            Blinding();
            txtsodonsx.Text = TonPI_UK.sodonsx;
            txtpi.Text = TonPI_UK.PI;
            txtpsi.Text = TonPI_UK.PSI_ref;
            txtpl.Value = Convert.ToInt32(TonPI_UK.pallet_pi);
            txt_price.Value = Convert.ToDecimal(TonPI_UK.price);
            txtitem.Text = TonPI_UK.item;
            txtctn.Text = TonPI_UK.CTN;
            txtvar.EditValue = TonPI_UK.VariantPI;
            txtkh.Text = TonPI_UK.khachhang;
        }
        private void Blinding()
        {
            string sql = "select *from Supplies";
            txtvar.Properties.DataSource = ConnectDB.getTable(sql);
            txtvar.Properties.ValueMember = "Variant";
            txtvar.Properties.DisplayMember = "CatalanCode";
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string insert = "insert into Ton_PI values ('" + txtsodonsx.Text + "','" + txtpi.Text + "','" + txtpsi.Text + "','" + txt_price.Text + "','" + txtpl.Text + "','" + Convert.ToDateTime(txtfob.Text).ToString("MM/dd/yyyy") + "','" + txtsl.Text + "','" + txtctn.Text + "',N'UK',N'" + txtkh.Text + "','" + txtvar.EditValue.ToString() + "','" + txtitem.Text + "')";
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

        private void txtvar_EditValueChanged(object sender, EventArgs e)
        {
            string sql = "select *from Supplies where Variant = '" + txtvar.EditValue.ToString() + "'";
            DataTable dt = ConnectDB.getTable(sql);

            string item = dt.Rows[0]["SuppliesName"].ToString() + " " + dt.Rows[0]["Productcode"].ToString();
            txtsize.Text = dt.Rows[0]["Size"].ToString();
            txtitem.Text = item;
            if (txtvar.EditValue.ToString() == TonPI_UK.VariantPI)
            {
                txt_price.ReadOnly = true;
                txtpl.ReadOnly = true;
                txtpl.Value = Convert.ToInt32(TonPI_UK.pallet_pi);
                txt_price.Value = Convert.ToDecimal(TonPI_UK.price);
            }
            else
            {
                txt_price.ReadOnly = false;
                txtpl.ReadOnly = false;
                txt_price.Value = 0;
                txtpl.Value = 0;
            }
        }
    }
}