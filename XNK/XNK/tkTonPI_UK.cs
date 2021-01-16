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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid;

namespace XNK
{
    public partial class tkTonPI_UK : DevExpress.XtraEditors.XtraForm
    {
        public tkTonPI_UK()
        {
            InitializeComponent();
        }

        private void tkTonPI_UK_Load(object sender, EventArgs e)
        {
            Loaddt();
        }
        private void Loaddt()
        {
            try
            {
                string sql = "Select X.PI ,x.ContractNo , x.khachhang , H.CatalanCode , x.item , X.PSI_ref,H.Size, x.pallet_pi,x.sodonsx,x.price ,Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'UK' Group By X.VariantPI,X.PI, H.CatalanCode, X.pallet_pi,x.khachhang,x.item,X.PSI_ref,x.ContractNo,H.Size, x.pallet_pi,x.PSI_ref,x.sodonsx,x.price having SUM(X.amount) > 0 order by PI asc";
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
                string sql1 = "Select X.PI ,x.ContractNo , x.khachhang , H.CatalanCode , x.item , X.PSI_ref,H.Size, x.pallet_pi,x.sodonsx,x.price ,Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'UK' Group By X.VariantPI,X.PI, H.CatalanCode, X.pallet_pi,x.khachhang,x.item,X.PSI_ref,x.ContractNo,H.Size, x.pallet_pi,x.PSI_ref,x.sodonsx,x.price having SUM(X.amount) > 0 order by PI asc";
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

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && gridView1.State != DevExpress.XtraGrid.Views.BandedGrid.BandedGridState.Editing)
            {
                Loaddt();
            }
            if (e.Control && e.KeyCode == Keys.P && gridView1.State != DevExpress.XtraGrid.Views.BandedGrid.BandedGridState.Editing)
            {
                Exporting();
            }
        }
        bool indicatorIcon = true;
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            try
            {
                GridView view = (GridView)sender;
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    string sText = (e.RowHandle + 1).ToString();
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString(sText, e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = sText;
                }
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;

                if (e.RowHandle == GridControl.InvalidRowHandle)
                {
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString("STT", e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = "STT";
                }
            }
            catch
            {
                XtraMessageBox.Show("Lỗi cột STT");
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridview = ((GridView)sender);
            if (!gridview.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
            SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
            gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 50;
        }
    }
}