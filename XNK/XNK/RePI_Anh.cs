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
    public partial class RePI_Anh : DevExpress.XtraEditors.XtraForm
    {
        public RePI_Anh()
        {
            InitializeComponent();
        }

        private void RePI_Anh_Load(object sender, EventArgs e)
        {
            LoadDT();
            txtfob.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
        private void LoadDT()
        {
            Blinding();
            txtsodonsx.Text = TonPI_Anh.sodonsx;
            txtpi.Text = TonPI_Anh.PI;
            txtpsi.Text = TonPI_Anh.PSI_ref;
            txtpl_pi.Value = Convert.ToInt32(TonPI_Anh.pallet_pi);
            txtprice.Value = Convert.ToDecimal(TonPI_Anh.price);
            txtitem.Text = TonPI_Anh.item;
            txtctn.Text = TonPI_Anh.CTN;
            txtvar.Text = TonPI_Anh.VariantPI;
            txtkh.Text = TonPI_Anh.khachhang;
        }
        private void Blinding()
        {
            string sql = "select *from Supplies where Variant = '" + TonPI_Anh.VariantPI + "'";
            DataTable dt = ConnectDB.getTable(sql);
            txtctlcode.DataBindings.Add("Text", dt, "CatalanCode");
            txtsize.DataBindings.Add("Text", dt, "Size");
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string insert = "insert into Ton_PI values ('" + txtsodonsx.Text + "','" + txtpi.Text + "','" + txtpsi.Text + "','" + txtprice.Text + "','" + txtpl_pi.Text + "','" + Convert.ToDateTime(txtfob.Text).ToString("MM/dd/yyyy") + "','" + txtsl.Text + "','" + txtctn.Text + "',N'Anh',N'" + txtkh.Text + "','" + txtvar.Text + "','" + txtitem.Text + "')";
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