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
    public partial class ReAddListPrint : DevExpress.XtraEditors.XtraForm
    {
        public ReAddListPrint()
        {
            InitializeComponent();
        }

        private void ReAddListPrint_Load(object sender, EventArgs e)
        {
            LoadDT();
            Blinding();
        }

        private void LoadDT()
        {
            txtduoimau.Text = ListPrint.duoimau;
            txtloca.Text = ListPrint.loca;
            txtop.Value = Convert.ToInt32(ListPrint.OuterPacks);
            txtpok.Text = ListPrint.POKhach;
            txtvar.EditValue = ListPrint.Variant;
            txtslpallet.Value = Convert.ToInt32(ListPrint.TotalPallets);
            txtsupp.Text = ListPrint.SUPPLIER;
            txtvrponum.Text = ListPrint.PO;
            txtweight.Value = Convert.ToInt32(ListPrint.Weight);
        }
        private void Blinding()
        {
            string sql = "select *from ThamChieuB";
            txtvar.Properties.DataSource = ConnectDB.getTable(sql);
            txtvar.Properties.ValueMember = "Variant";
            txtvar.Properties.DisplayMember = "Variant";
        }

        private void txtvar_EditValueChanged(object sender, EventArgs e)
        {
            string sql = "select *from ThamChieuB where Variant ='" + txtvar.EditValue.ToString() + "'";
            DataTable dt = ConnectDB.getTable(sql);

            txtbox.Value = Convert.ToInt32(dt.Rows[0]["Box"].ToString());
            txtdes.Text = dt.Rows[0]["SuppliesName"].ToString();
            txtprnum.Text = dt.Rows[0]["ProductNumber"].ToString();
            txtsuppcode.Text = dt.Rows[0]["Productcode"].ToString();
            txtvien.Value = Convert.ToInt32(dt.Rows[0]["Bricks"].ToString());
            txtbar.Text = dt.Rows[0]["Barcode"].ToString();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string insert = "insert into PrintB values ('" + txtvar.EditValue.ToString() + "','" + txtsupp.Text + "','" + txtpok.Text + "','" + txtvrponum.Text + "','" + txtop.Text + "','" + txtweight.Text + "','" + txtslpallet.Text + "','" + txtduoimau.Text + "','" + txtloca.Text + "')";
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
    }
}