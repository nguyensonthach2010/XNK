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
using System.Threading;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace XNK
{
    public partial class Vattu : DevExpress.XtraEditors.XtraForm
    {
        public Vattu()
        {
            InitializeComponent();
        }

        //Hiển thị dư liệu lên gridcontrol
        private void Loaddata()
        {
            try
            {
                string sql = "SELECT [Variant],[CatalanCode],[SuppliesName],[Size],[Bricks],[M2],[Box],[Shelf],[CustomerName],[Productcode], (Box*Shelf) as hc, (Box*Shelf*M2) as gc FROM [dbo].[Supplies]";
                gridControl1.DataSource = ConnectDB.getTable(sql);
            }
            catch
            {
                XtraMessageBox.Show("Không thể kết nối tới CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void Vattu_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        //Code gridcontrol
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            // kiem tra cell cua mot dong dang Edit xem co rong ko?
            if (gridView1.GetRowCellValue(e.RowHandle, "Variant").ToString() == "" || gridView1.GetRowCellValue(e.RowHandle, "SuppliesName").ToString() == "" || gridView1.GetRowCellValue(e.RowHandle, "Size").ToString() == "" || gridView1.GetRowCellValue(e.RowHandle, "Bricks").ToString() == "" || gridView1.GetRowCellValue(e.RowHandle, "M2").ToString() == "" || gridView1.GetRowCellValue(e.RowHandle, "Box").ToString() == "" || gridView1.GetRowCellValue(e.RowHandle, "Shelf").ToString() == ""  || gridView1.GetRowCellValue(e.RowHandle, "Productcode").ToString() == "")
            {
                // chuỗi thông báo lỗi
                bVali = false;
                sErr = sErr + "Hãy điền đầy đủ thông tin!!";
            }
            if (bVali)
            {
                //lưu giá trị hiển thị trên gridview vào các biến tương ứng

                string variant = gridView1.GetRowCellValue(e.RowHandle, "Variant").ToString();
                string CatalanCode = gridView1.GetRowCellValue(e.RowHandle, "CatalanCode").ToString();
                string SuppliesName = gridView1.GetRowCellValue(e.RowHandle, "SuppliesName").ToString();
                string size = gridView1.GetRowCellValue(e.RowHandle, "Size").ToString();
                string Bricks = gridView1.GetRowCellValue(e.RowHandle, "Bricks").ToString();
                string M2 = gridView1.GetRowCellValue(e.RowHandle, "M2").ToString();
                string Box = gridView1.GetRowCellValue(e.RowHandle, "Box").ToString();
                string Shelf = gridView1.GetRowCellValue(e.RowHandle, "Shelf").ToString();
                string CustomerName = gridView1.GetRowCellValue(e.RowHandle, "CustomerName").ToString();
                string Productcode = gridView1.GetRowCellValue(e.RowHandle, "Productcode").ToString();



                GridView view = sender as GridView;
                //kiểm tra xem dòng đang chọn có phải dòng mới không nếu đúng thì insert không thì update
                if (view.IsNewItemRow(e.RowHandle))
                {
                    try
                    {
                        string insert = "insert into Supplies values('" + variant + "','" + CatalanCode + "','" + SuppliesName + "','" + size + "','" + Bricks + "','" + M2 + "','" + Box + "','" + Shelf + "','" + CustomerName + "','" + Productcode + "')";
                        ConnectDB.Query(insert);
                     
                        Loaddata();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Không thể kết nối tới CSDL!!");
                    }
                }
                else
                {
                    try
                    {
                        string update = "update Supplies set CatalanCode = '" + CatalanCode + "',Productcode = '" + Productcode + "', SuppliesName = '" + SuppliesName + "', Size = '" + size + "', Bricks = '" + Bricks + "', M2 = '" + M2 + "', Box = '" + Box + "', Shelf = '" + Shelf + "', CustomerName = '" + CustomerName + "' where Variant = '" + variant + "'";
                        ConnectDB.Query(update);
                       
                        Loaddata();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Không thể kết nối tới CSDL!!");
                    }
                }
            }
            else
            {
                e.Valid = false;
                XtraMessageBox.Show(sErr, "Lỗi trong quá trình nhập!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // code trường STT
        bool indicatorIcon = true;
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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

        //Code chức năng xóa 
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView1.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                string Variant = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Variant").ToString();
                DialogResult tb = XtraMessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tb == DialogResult.Yes)
                {
                    GridView view = sender as GridView;
                    view.DeleteRow(view.FocusedRowHandle);
                    try
                    {
                        string delete = "delete from Supplies where Variant ='" + Variant + "' ";
                        
                        ConnectDB.Query(delete);
                        Loaddata();

                    }
                    catch
                    {
                        XtraMessageBox.Show("Lỗi! Hãy thử lại!");
                        Loaddata();
                    }
                }
                else
                {
                    Loaddata();
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Xuất file Excel từ gridview sau khi truyền dữ liệu từ câu sql vào gridview
            try
            {
                //string sql3 = "SELECT [Variant],[CatalanCode],[SuppliesName],[Size],[Bricks],[M2],[Box],[Shelf],[CustomerName],[Productcode], (Box*Shelf) as hc, (Box*Shelf*M2) as gc FROM [dbo].[Supplies]";
                SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
                saveFileDialogExcel.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
                {
                    string exportFilePath = saveFileDialogExcel.FileName;
                    gridView1.ColumnPanelRowHeight = 40;
                    gridView1.OptionsPrint.AutoWidth = AutoSize;
                    gridView1.OptionsPrint.AllowCancelPrintExport = true;
                    gridView1.OptionsPrint.ShowPrintExportProgress = true;
                    XlsxExportOptions options = new XlsxExportOptions();
                    options.TextExportMode = TextExportMode.Value;
                    options.ExportMode = XlsxExportMode.SingleFile;
                    options.SheetName = "Tham Chiếu";
                    ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                    gridView1.ExportToXlsx(exportFilePath, options);
                    //gridControl1.DataSource = ConnectDB.getTable(sql3);
                    //gridControl1.ExportToXlsx(exportFilePath);
                    XtraMessageBox.Show("Xuất file Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (XtraMessageBox.Show("Mở File xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        System.Diagnostics.Process prc = new System.Diagnostics.Process();
                        prc.StartInfo.FileName = exportFilePath ; 
                        prc.Start();
                    }    
                }
            }
            catch
            {
                XtraMessageBox.Show("Không thể Xuất file Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            try
            {
                GridView view = sender as GridView;
                if (view == null) return;
                string M2 = gridView1.GetRowCellValue(e.RowHandle, "M2").ToString();
                string Box = gridView1.GetRowCellValue(e.RowHandle, "Box").ToString();
                string Shelf = gridView1.GetRowCellValue(e.RowHandle, "Shelf").ToString();

                switch (e.Column.Caption.ToString())
                {

                    case "Giá/cont":

                        int tonghop = int.Parse(Box) * int.Parse(Shelf);
                        float tongm2 = float.Parse(Box) * float.Parse(Shelf)
                            * float.Parse(M2);

                        view.SetRowCellValue(e.RowHandle, "hc", "");
                        string cellValue2 = "" + tonghop + "" + view.GetRowCellValue(e.RowHandle, "hc").ToString();
                        view.SetRowCellValue(e.RowHandle, "hc", cellValue2);

                        view.SetRowCellValue(e.RowHandle, "gc", "");
                        string cellValue3 = "" + Math.Round((float)tongm2, 2) + "" + view.GetRowCellValue(e.RowHandle, "gc").ToString();
                        view.SetRowCellValue(e.RowHandle, "gc", cellValue3);

                        break;
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show(e.ToString());
            }
            
        }
    }
}