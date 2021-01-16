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
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid;

namespace XNK
{
    public partial class ListPrint : DevExpress.XtraEditors.XtraForm
    {
        public ListPrint()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try 
            {
                string sql = "SELECT        dbo.PrintB.Variant, dbo.PrintB.SUPPLIER, dbo.PrintB.POKhach, dbo.PrintB.PO, dbo.PrintB.OuterPacks, dbo.PrintB.Weight, dbo.PrintB.TotalPallets, dbo.ThamChieuB.Barcode, dbo.ThamChieuB.Bricks, dbo.ThamChieuB.Productcode, dbo.ThamChieuB.ProductNumber, dbo.ThamChieuB.SuppliesName, dbo.ThamChieuB.Box, dbo.PrintB.duoimau, dbo.PrintB.loca FROM dbo.PrintB INNER JOIN dbo.ThamChieuB ON dbo.ThamChieuB.Variant = dbo.PrintB.Variant";
                gridControl1.DataSource = ConnectDB.getTable(sql);
            }catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra, Không thể kết nối tới CSDL!!");
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            string Variant = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "Variant").ToString();
            string SUPPLIER = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "SUPPLIER").ToString();
            string POKhach = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "POKhach").ToString();
            string PO = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "PO").ToString();
            string OuterPacks = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "OuterPacks").ToString();
            string Weight = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "Weight").ToString();
            string TotalPallets = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "TotalPallets").ToString();
            string duoimau = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "duoimau").ToString();
            string loca = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "loca").ToString();

            string sql = "SELECT dbo.PrintB.Variant, dbo.PrintB.SUPPLIER, dbo.PrintB.POKhach, dbo.PrintB.PO, dbo.PrintB.OuterPacks, dbo.PrintB.Weight, dbo.PrintB.TotalPallets, dbo.ThamChieuB.Barcode, dbo.ThamChieuB.Bricks,  dbo.ThamChieuB.Productcode, dbo.ThamChieuB.ProductNumber, dbo.ThamChieuB.SuppliesName, dbo.ThamChieuB.Box, dbo.PrintB.duoimau,PrintB.loca FROM dbo.PrintB INNER JOIN dbo.ThamChieuB ON dbo.ThamChieuB.Variant = dbo.PrintB.Variant where PrintB.Variant = '" + Variant + "' and SUPPLIER = '" + SUPPLIER + "' and POKhach = '" + POKhach + "' and PO = '" + PO + "' and OuterPacks = '" + OuterPacks + "' and Weight = '" + Weight + "' and TotalPallets = '" + TotalPallets + "' and duoimau = '" + duoimau + "' and loca = '" + loca + "'";
            try
            {
                for (int i = 1; i < int.Parse(bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "TotalPallets").ToString()); i++)
                {
                    sql = sql + " union all SELECT dbo.PrintB.Variant, dbo.PrintB.SUPPLIER, dbo.PrintB.POKhach, dbo.PrintB.PO, dbo.PrintB.OuterPacks, dbo.PrintB.Weight, dbo.PrintB.TotalPallets, dbo.ThamChieuB.Barcode, dbo.ThamChieuB.Bricks,  dbo.ThamChieuB.Productcode, dbo.ThamChieuB.ProductNumber, dbo.ThamChieuB.SuppliesName, dbo.ThamChieuB.Box, dbo.PrintB.duoimau,PrintB.loca FROM dbo.PrintB INNER JOIN dbo.ThamChieuB ON dbo.ThamChieuB.Variant = dbo.PrintB.Variant where PrintB.Variant = '" + Variant + "' and SUPPLIER = '" + SUPPLIER + "' and POKhach = '" + POKhach + "' and PO = '" + PO + "' and OuterPacks = '" + OuterPacks + "' and Weight = '" + Weight + "' and TotalPallets = '" + TotalPallets + "' and duoimau = '" + duoimau + "' and loca = '" + loca + "'";
                }
                if (barEditItem2.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("Hãy chọn kiểu In!!","Lưu ý!!",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }else    
                    
                if (barEditItem2.EditValue.ToString() == "Anderley + Pescara")
                {
                    DataTable dt = ConnectDB.getTable(sql);
                    Anderley_Pescara rp = new Anderley_Pescara();
                    rp.DataSource = dt;
                    rp.ShowPreviewDialog();
                }else if(barEditItem2.EditValue.ToString() == "EJK Tiles")
                {
                    DataTable dt = ConnectDB.getTable(sql);
                    EJKTiles eJK = new EJKTiles();
                    eJK.DataSource = dt;
                    eJK.ShowPreviewDialog();
                }else if(barEditItem2.EditValue.ToString() == "Tile Giant")
                {
                    DataTable dt = ConnectDB.getTable(sql);
                    TileGiant tg = new TileGiant();
                    tg.DataSource = dt;
                    tg.ShowPreviewDialog();
                }else if(barEditItem2.EditValue.ToString() == "Wickes")
                {
                    DataTable dt = ConnectDB.getTable(sql);
                    Wickes w = new Wickes();
                    w.DataSource = dt;
                    w.ShowPreviewDialog();
                }
                else if(barEditItem2.EditValue.ToString() == "Wickes + Verona")
                {
                    DataTable dt = ConnectDB.getTable(sql);
                    Wickes_Verona wv = new Wickes_Verona();
                    wv.DataSource = dt;
                    wv.ShowPreviewDialog();
                }
            }
            catch
            {
                XtraMessageBox.Show("Không thế kết nối tới CSDL!!");
            }
        }

        private void ListPrint_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLookupedit();
        }
        private void LoadLookupedit()
        {
            try
            {
                string sql = "select dbo.ThamChieuB.Barcode, dbo.ThamChieuB.Bricks, dbo.ThamChieuB.Productcode, dbo.ThamChieuB.ProductNumber, dbo.ThamChieuB.SuppliesName, dbo.ThamChieuB.Box,dbo.ThamChieuB.Variant from ThamChieuB ";
                repositoryItemLookUpEdit1.DataSource = ConnectDB.getTable(sql);
                repositoryItemLookUpEdit1.ValueMember = "Variant";
                repositoryItemLookUpEdit1.DisplayMember = "Variant";
            }catch
            {
                XtraMessageBox.Show("Không kết nối được CSDL!!");
            }
        }

        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string Variant = bandedGridView1.GetRowCellValue(e.RowHandle, "Variant").ToString();
            try
            {
                GridView view = sender as GridView;
                string sql2 = "select *from ThamChieuB where Variant ='"+Variant+"'";
                DataTable tb = ConnectDB.getTable(sql2);
                if (view == null) return;

                switch (e.Column.Caption.ToString())
                {
                    case "Verona Product Number":

                        view.SetRowCellValue(e.RowHandle, "SuppliesName", "");
                        string cellValue = "" + tb.Rows[0]["SuppliesName"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "SuppliesName").ToString();
                        view.SetRowCellValue(e.RowHandle, "SuppliesName", cellValue);

                        view.SetRowCellValue(e.RowHandle, "ProductNumber", "");
                        string cellValue4 = "" + tb.Rows[0]["ProductNumber"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "ProductNumber").ToString();
                        view.SetRowCellValue(e.RowHandle, "ProductNumber", cellValue4);

                        view.SetRowCellValue(e.RowHandle, "Productcode", "");
                        string cellValue1 = "" + tb.Rows[0]["Productcode"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "Productcode").ToString();
                        view.SetRowCellValue(e.RowHandle, "Productcode", cellValue1);

                        view.SetRowCellValue(e.RowHandle, "Box", "");
                        string cellValue2 = "" + tb.Rows[0]["Box"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "Box").ToString();
                        view.SetRowCellValue(e.RowHandle, "Box", cellValue2);

                        view.SetRowCellValue(e.RowHandle, "Bricks", "");
                        string cellValue3 = "" + tb.Rows[0]["Bricks"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "Bricks").ToString();
                        view.SetRowCellValue(e.RowHandle, "Bricks", cellValue3);

                        view.SetRowCellValue(e.RowHandle, "Barcode", "");
                        string cellValue5 = "" + tb.Rows[0]["Barcode"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "Barcode").ToString();
                        view.SetRowCellValue(e.RowHandle, "Barcode", cellValue5);

                        break;
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show(e.ToString());
            }
        }

        private void bandedGridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            // kiem tra cell cua mot dong dang Edit xem co rong ko?
            if (bandedGridView1.GetRowCellValue(e.RowHandle, "Variant").ToString() == "" ||bandedGridView1.GetRowCellValue(e.RowHandle, "SUPPLIER").ToString()=="" || bandedGridView1.GetRowCellValue(e.RowHandle, "POKhach").ToString()==""
                || bandedGridView1.GetRowCellValue(e.RowHandle, "PO").ToString()=="" || bandedGridView1.GetRowCellValue(e.RowHandle, "TotalPallets").ToString()=="")
            {
                // chuỗi thông báo lỗi
                bVali = false;
                sErr = sErr + "Vui lòng điền mã code!!";
            }

            if (bVali)
            {
                //lưu giá trị hiển thị trên gridview vào các biến tương ứng
                string Variant = bandedGridView1.GetRowCellValue(e.RowHandle, "Variant").ToString();
                string SUPPLIER = bandedGridView1.GetRowCellValue(e.RowHandle, "SUPPLIER").ToString();
                string POKhach = bandedGridView1.GetRowCellValue(e.RowHandle, "POKhach").ToString();
                string PO = bandedGridView1.GetRowCellValue(e.RowHandle, "PO").ToString();
                string OuterPacks = bandedGridView1.GetRowCellValue(e.RowHandle, "OuterPacks").ToString();
                string Weight = bandedGridView1.GetRowCellValue(e.RowHandle, "Weight").ToString();
                string TotalPallets = bandedGridView1.GetRowCellValue(e.RowHandle, "TotalPallets").ToString();
                string duoimau = bandedGridView1.GetRowCellValue(e.RowHandle, "duoimau").ToString();
                string loca = bandedGridView1.GetRowCellValue(e.RowHandle, "loca").ToString();

                GridView view = sender as GridView;
                //kiểm tra xem dòng đang chọn có phải dòng mới không nếu đúng thì insert không thì update
                if (view.IsNewItemRow(e.RowHandle))
                {
                    try
                    {
                        string insert = "insert into PrintB values ('" + Variant + "','" + SUPPLIER + "','" + POKhach + "','" + PO + "','" + OuterPacks + "','" + Weight + "','" + TotalPallets + "','" + duoimau + "','" + loca + "')";
                        ConnectDB.Query(insert);
                        LoadData();
                    }
                    catch (Exception exx)
                    {
                        XtraMessageBox.Show(exx.ToString());
                    }
                }
                else
                {
                    //if (Quyen.nhomnd == "Admin")
                    //{
                    try
                    {
                        string update = "update PrintB set Variant = '" + Variant + "',SUPPLIER= '" + SUPPLIER + "',POKhach = '" + POKhach + "',PO = '" + PO + "',OuterPacks = '" + OuterPacks + "',Weight = '" + Weight + "',TotalPallets = '" + TotalPallets + "',duoimau = '" + duoimau + "',loca = '" + loca + "'";
                        ConnectDB.Query(update);
                        LoadData();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Không thể kết nối tới CSDL!!");
                    }
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("Chỉ Admin mới có quyền Sửa");
                    //}
                }
            }
            else
            {
                e.Valid = false;
                DialogResult tb = XtraMessageBox.Show(sErr, "Lỗi trong quá trình nhập!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tb == DialogResult.OK)
                {
                    // load lại form
                    LoadData();
                }
            }
        }

        private void bandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
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
    }
}