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
    public partial class TKNXT_Anh : DevExpress.XtraEditors.XtraForm
    {
        public TKNXT_Anh()
        {
            InitializeComponent();
        }

        private void TKNXT_Anh_Load(object sender, EventArgs e)
        {
            Loaddt();
        }
        private void Loaddt()
        {
            try
            {
                string sql = "SELECT [namsx],[ngaynhap],[kho],[vitri],x.[ctlcode],[duoimau],[loca],[slgia],[slhop],[dnxl],SUM(x.slhopx) as Tonghx,SUM(x.FOB_Amount) as giaxuat, dnxl + SUM( x.FOB_Amount) as Tonggiax,(slgia - dnxl - SUM(FOB_Amount)) as tongia,(slhop -SUM(slhopx)) as tonhop,tondh From NXT x, ( select CtlCode as ctl, SUM(TonPI) as tondh from( Select X.PI as MaVT, x.ContractNo as Contr, x.khachhang as KH, H.CatalanCode as CtlCode, x.item as Item, X.PSI_ref, H.Size, x.pallet_pi, x.sodonsx, x.price, Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'Anh' Group By X.VariantPI, X.PI, H.CatalanCode, X.pallet_pi, x.khachhang, x.item, X.PSI_ref, x.ContractNo, H.Size, x.pallet_pi, x.PSI_ref, x.sodonsx, x.price having SUM(X.amount) > 0 ) as TonDH group by CtlCode ) a where a.ctl = x.ctlcode and x.nuoc = 'Anh' group by[namsx],[ngaynhap],[kho],[vitri], x.[ctlcode],[duoimau],[loca],[slgia],[slhop],[dnxl],a.tondh";
                gridControl1.DataSource = ConnectDB.getTable(sql);
            }
            catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra!!");
            }
        }
        private void Exporting()
        {
            //Xuất file Excel từ gridview sau khi truyền dữ liệu từ câu sql vào gridview
            try
            {
                string sql1 = "SELECT [namsx],[ngaynhap],[kho],[vitri],x.[ctlcode],[duoimau],[loca],[slgia],[slhop],[dnxl],SUM(x.slhopx) as Tonghx,SUM(x.FOB_Amount) as giaxuat,dnxl + SUM(x.FOB_Amount) as Tonggiax,(slgia - dnxl - SUM(FOB_Amount)) as tongia,(slhop -SUM(slhopx)) as tonhop,tondh From NXT x, ( select CtlCode as ctl, SUM(TonPI) as tondh from( Select X.PI as MaVT, x.ContractNo as Contr, x.khachhang as KH, H.CatalanCode as CtlCode, x.item as Item, X.PSI_ref, H.Size, x.pallet_pi, x.sodonsx, x.price, Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'Anh' Group By X.VariantPI, X.PI, H.CatalanCode, X.pallet_pi, x.khachhang, x.item, X.PSI_ref, x.ContractNo, H.Size, x.pallet_pi, x.PSI_ref, x.sodonsx, x.price having SUM(X.amount) > 0 ) as TonDH group by CtlCode ) a where a.ctl = x.ctlcode and x.nuoc = 'Anh' group by[namsx],[ngaynhap],[kho],[vitri], x.[ctlcode],[duoimau],[loca],[slgia],[slhop],[dnxl],a.tondh";
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

        private void bandedGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && bandedGridView1.State != DevExpress.XtraGrid.Views.BandedGrid.BandedGridState.Editing)
            {
                Loaddt();
            }
            if (e.Control && e.KeyCode == Keys.P && bandedGridView1.State != DevExpress.XtraGrid.Views.BandedGrid.BandedGridState.Editing)
            {
                Exporting();
            }
        }
    }
}