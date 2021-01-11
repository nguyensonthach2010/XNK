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
    public partial class TkTonPI_Anh : DevExpress.XtraEditors.XtraForm
    {
        public TkTonPI_Anh()
        {
            InitializeComponent();
        }

        private void TkTonPI_Anh_Load(object sender, EventArgs e)
        {
            Loaddt();
        }
        private void Loaddt()
        {
            try
            {
                string sql = "Select X.PI ,x.ContractNo , x.khachhang , H.CatalanCode , x.item , X.PSI_ref,H.Size, x.pallet_pi,x.sodonsx,x.price ,Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'Anh' Group By X.VariantPI,X.PI, H.CatalanCode, X.pallet_pi,x.khachhang,x.item,X.PSI_ref,x.ContractNo,H.Size, x.pallet_pi,x.PSI_ref,x.sodonsx,x.price having SUM(X.amount) > 0 order by PI asc";
                gridControl1.DataSource = ConnectDB.getTable(sql);
            }catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra!!");
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5 && gridView1.State != DevExpress.XtraGrid.Views.BandedGrid.BandedGridState.Editing)
            {
                Loaddt();
            }
            if(e.Control && e.KeyCode == Keys.P && gridView1.State != DevExpress.XtraGrid.Views.BandedGrid.BandedGridState.Editing)
            {
                Exporting();
            }    
        }
        private void Exporting()
        {
            //Xuất file Excel từ gridview sau khi truyền dữ liệu từ câu sql vào gridview
            try
            {
                string sql1 = "Select X.PI ,x.ContractNo , x.khachhang , H.CatalanCode , x.item , X.PSI_ref,H.Size, x.pallet_pi,x.sodonsx,x.price ,Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'Anh' Group By X.VariantPI,X.PI, H.CatalanCode, X.pallet_pi,x.khachhang,x.item,X.PSI_ref,x.ContractNo,H.Size, x.pallet_pi,x.PSI_ref,x.sodonsx,x.price having SUM(X.amount) > 0 order by PI asc";
                SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
                saveFileDialogExcel.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
                {
                    string exportFilePath = saveFileDialogExcel.FileName;
                    gridControl1.DataSource = ConnectDB.getTable(sql1);
                    gridControl1.ExportToXlsx(exportFilePath);
                    XtraMessageBox.Show("Xuất file Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                XtraMessageBox.Show("Không thể Xuất file Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}