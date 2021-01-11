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
    public partial class NXT_DL : DevExpress.XtraEditors.XtraForm
    {
        public NXT_DL()
        {
            InitializeComponent();
        }

        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                string sql2 = "select CtlCode as ctl, SUM(TonPI) as tondh from(Select X.PI as MaVT, x.ContractNo as Contr, x.khachhang as KH, H.CatalanCode as CtlCode, x.item as Item, X.PSI_ref, H.Size, x.pallet_pi, x.sodonsx, x.price, Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'Đài loan' Group By X.VariantPI, X.PI, H.CatalanCode, X.pallet_pi, x.khachhang, x.item, X.PSI_ref, x.ContractNo, H.Size, x.pallet_pi, x.PSI_ref, x.sodonsx, x.price having SUM(X.amount) > 0)as TonDH where CtlCode='" + view.GetRowCellValue(e.RowHandle, "ctlcode").ToString() + "' group by CtlCode";
                DataTable tb = ConnectDB.getTable(sql2);
                if (view == null) return;

                switch (e.Column.Caption.ToString())
                {
                    case "Mã Code":

                        view.SetRowCellValue(e.RowHandle, "tondh", "");
                        string cellValue4 = "" + tb.Rows[0]["tondh"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "tondh").ToString();
                        view.SetRowCellValue(e.RowHandle, "tondh", cellValue4);

                        break;
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show(e.ToString());
            }
        }

        private void bandedGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && bandedGridView1.State != DevExpress.XtraGrid.Views.BandedGrid.BandedGridState.Editing)
            {
                string stt = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "stt").ToString();

                DialogResult tb = XtraMessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tb == DialogResult.Yes)
                {
                    //if (Quyen.nhomnd == "Admin")
                    //{
                    try
                    {
                        string delete = "delete from NXT where stt ='" + stt + "'";
                        ConnectDB.Query(delete);
                        LoadDT();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Không thế kết nối tới CSDL!!");
                    }
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("Chỉ Admin mới có quyền xoá");
                    //}
                }
                else
                {
                    LoadDT();
                }
            }
            if (e.KeyCode == Keys.F5 && bandedGridView1.State != DevExpress.XtraGrid.Views.BandedGrid.BandedGridState.Editing)
            {
                LoadDT();
            }
            if (e.Control && e.KeyCode == Keys.P && bandedGridView1.State != DevExpress.XtraGrid.Views.BandedGrid.BandedGridState.Editing)
            {
                Export();
            }
        }

        private void bandedGridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            // kiem tra cell cua mot dong dang Edit xem co rong ko?
            if (bandedGridView1.GetRowCellValue(e.RowHandle, "ctlcode").ToString() == "")
            {
                // chuỗi thông báo lỗi
                bVali = false;
                sErr = sErr + "Vui lòng điền mã code!!";
            }

            if (bVali)
            {
                //lưu giá trị hiển thị trên gridview vào các biến tương ứng
                string namsx = bandedGridView1.GetRowCellValue(e.RowHandle, "namsx").ToString();
                string ngaynhap = bandedGridView1.GetRowCellValue(e.RowHandle, "ngaynhap").ToString();
                string kho = bandedGridView1.GetRowCellValue(e.RowHandle, "kho").ToString();
                string vitri = bandedGridView1.GetRowCellValue(e.RowHandle, "vitri").ToString();
                string ctlcode = bandedGridView1.GetRowCellValue(e.RowHandle, "ctlcode").ToString();
                string duoimau = bandedGridView1.GetRowCellValue(e.RowHandle, "duoimau").ToString();
                string loca = bandedGridView1.GetRowCellValue(e.RowHandle, "loca").ToString();
                string slgia = bandedGridView1.GetRowCellValue(e.RowHandle, "slgia").ToString();
                string slhop = bandedGridView1.GetRowCellValue(e.RowHandle, "slhop").ToString();
                string dnxl = bandedGridView1.GetRowCellValue(e.RowHandle, "dnxl").ToString();
                string FOB_Date = bandedGridView1.GetRowCellValue(e.RowHandle, "FOB_Date").ToString();
                string FOB_Amount = bandedGridView1.GetRowCellValue(e.RowHandle, "FOB_Amount").ToString();
                string stt = bandedGridView1.GetRowCellValue(e.RowHandle, "stt").ToString();
                string slhopx = bandedGridView1.GetRowCellValue(e.RowHandle, "slhopx").ToString();

                GridView view = sender as GridView;
                //kiểm tra xem dòng đang chọn có phải dòng mới không nếu đúng thì insert không thì update
                if (view.IsNewItemRow(e.RowHandle))
                {
                    try
                    {
                        string insert = "insert into NXT values ('" + namsx + "','" + Convert.ToDateTime(ngaynhap).ToString("MM/dd/yyyy") + "',N'" + kho + "',N'" + vitri + "','" + ctlcode + "','" + duoimau + "','" + loca + "','" + slgia + "','" + slhop + "','" + dnxl + "','" + Convert.ToDateTime(FOB_Date).ToString("MM/dd/yyyy") + "','" + FOB_Amount + "',N'Đài loan','" + slhopx + "')";
                        ConnectDB.Query(insert);
                        LoadDT();
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
                        string update = "update NXT set namsx = '" + namsx + "',ngaynhap= '" + Convert.ToDateTime(ngaynhap).ToString("MM/dd/yyyy") + "',kho = N'" + kho + "',vitri = N'" + vitri + "',ctlcode = '" + ctlcode + "',duoimau = '" + duoimau + "',loca = '" + loca + "',slgia = '" + slgia + "',slhop = '" + slhop + "',dnxl = N'" + dnxl + "', FOB_Date =' " + Convert.ToDateTime(FOB_Date).ToString("MM/dd/yyyy") + " ',FOB_Amount = ' " + FOB_Amount + " ',slhopx='" + slhopx + "'  where stt = '" + stt + "'";
                        ConnectDB.Query(update);
                        LoadDT();
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
                    LoadDT();
                }
            }
        }

        private void bandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        public static string namsx = "";
        public static string ngaynhap = "";
        public static string kho = "";
        public static string vitri = "";
        public static string ctlcode = "";
        public static string duoimau = "";
        public static string loca = "";
        public static string slgia = "";
        public static string slhop = "";
        public static string dnxl = "";
        public static string stt = "";
        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            namsx = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "namsx").ToString();
            ngaynhap = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "ngaynhap").ToString();
            kho = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "kho").ToString();
            vitri = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "vitri").ToString();
            ctlcode = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "ctlcode").ToString();
            duoimau = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "duoimau").ToString();
            loca = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "loca").ToString();
            slgia = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "slgia").ToString();
            slhop = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "slhop").ToString();
            dnxl = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "dnxl").ToString();
            stt = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "stt").ToString();

            ReNXT_DL re = new ReNXT_DL();
            re.Show();
        }
        private void LoadDT()
        {
            Load_Lookupedit();
            try
            {
                string sql = "SELECT [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop],[stt],[dnxl],[FOB_Date],[FOB_Amount],slhopx,iif(slgia - dnxl - SUM(FOB_Amount) OVER(PARTITION BY[namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt) > 0, FOB_Amount, FOB_Amount + (slgia - dnxl - SUM(FOB_Amount) OVER(PARTITION BY[namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt))) AS slxuat,(dnxl + SUM(FOB_Amount) OVER(PARTITION BY [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt)) as Tongxuat,slgia - dnxl - SUM(FOB_Amount) OVER(PARTITION BY[namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt) AS tongia ,	iif(slhop - SUM(slhopx) OVER (PARTITION BY [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt)>0, slhopx, slhopx + ( slhopx - SUM(slhopx) OVER (PARTITION BY [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt))) AS slhxuat,(SUM(slhopx) OVER (PARTITION BY [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt)) as Tonghxuat,slhop - SUM(slhopx) OVER (PARTITION BY [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt) AS tonhop, tondh FROM[dbo].[NXT] inner join(select CtlCode as ctl, SUM(TonPI) as tondh from(Select X.PI as MaVT, x.ContractNo as Contr, x.khachhang as KH, H.CatalanCode as CtlCode, x.item as Item, X.PSI_ref, H.Size, x.pallet_pi, x.sodonsx, x.price, Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'Đài loan' Group By X.VariantPI, X.PI, H.CatalanCode, X.pallet_pi, x.khachhang, x.item, X.PSI_ref, x.ContractNo, H.Size, x.pallet_pi, x.PSI_ref, x.sodonsx, x.price having SUM(X.amount) > 0) as TonDH group by CtlCode) a on a.ctl = NXT.ctlcode  where NXT.nuoc = 'Đài loan' order by stt desc";
                gridControl1.DataSource = ConnectDB.getTable(sql);
            }
            catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra, không load được CSDL!!");
            }
        }

        private void Load_Lookupedit()
        {
            string sql1 = "select CtlCode as ctl, SUM(TonPI) as tondh from(Select X.PI as MaVT, x.ContractNo as Contr, x.khachhang as KH, H.CatalanCode as CtlCode, x.item as Item, X.PSI_ref, H.Size, x.pallet_pi, x.sodonsx, x.price, Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'Đài loan' Group By X.VariantPI, X.PI, H.CatalanCode, X.pallet_pi, x.khachhang, x.item, X.PSI_ref, x.ContractNo, H.Size, x.pallet_pi, x.PSI_ref, x.sodonsx, x.price having SUM(X.amount) > 0)as TonDH group by CtlCode";
            repositoryItemLookUpEdit1.DataSource = ConnectDB.getTable(sql1);
            repositoryItemLookUpEdit1.ValueMember = "ctl";
            repositoryItemLookUpEdit1.DisplayMember = "ctl";
        }
        private void NXT_DL_Load(object sender, EventArgs e)
        {
            LoadDT();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export();
        }
        private void Export()
        {
            //Xuất file Excel từ gridview sau khi truyền dữ liệu từ câu sql vào gridview
            try
            {
                string sql3 = "SELECT [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop],[stt],[dnxl],[FOB_Date],[FOB_Amount],slhopx,iif(slgia - dnxl - SUM(FOB_Amount) OVER(PARTITION BY[namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt) > 0, FOB_Amount, FOB_Amount + (slgia - dnxl - SUM(FOB_Amount) OVER(PARTITION BY[namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt))) AS slxuat,(dnxl + SUM(FOB_Amount) OVER(PARTITION BY [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt)) as Tongxuat,slgia - dnxl - SUM(FOB_Amount) OVER(PARTITION BY[namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt) AS tongia ,	iif(slhop - SUM(slhopx) OVER (PARTITION BY [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt)>0, slhopx, slhopx + ( slhopx - SUM(slhopx) OVER (PARTITION BY [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt))) AS slhxuat,(SUM(slhopx) OVER (PARTITION BY [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt)) as Tonghxuat,slhop - SUM(slhopx) OVER (PARTITION BY [namsx],[ngaynhap],[kho],[vitri],[ctlcode],[duoimau],[loca],[slgia],[slhop] ORDER BY stt) AS tonhop, tondh FROM[dbo].[NXT] inner join(select CtlCode as ctl, SUM(TonPI) as tondh from(Select X.PI as MaVT, x.ContractNo as Contr, x.khachhang as KH, H.CatalanCode as CtlCode, x.item as Item, X.PSI_ref, H.Size, x.pallet_pi, x.sodonsx, x.price, Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'Đài loan' Group By X.VariantPI, X.PI, H.CatalanCode, X.pallet_pi, x.khachhang, x.item, X.PSI_ref, x.ContractNo, H.Size, x.pallet_pi, x.PSI_ref, x.sodonsx, x.price having SUM(X.amount) > 0) as TonDH group by CtlCode) a on a.ctl = NXT.ctlcode  where NXT.nuoc = 'Đài loan' order by stt desc";
                SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
                saveFileDialogExcel.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
                {
                    string exportFilePath = saveFileDialogExcel.FileName;
                    gridControl1.DataSource = ConnectDB.getTable(sql3);
                    gridControl1.ExportToXlsx(exportFilePath);
                    XtraMessageBox.Show("Xuất file Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                XtraMessageBox.Show("Không thể Xuất file Excel", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        bool indicatorIcon = true;
        private void bandedGridView1_RowCountChanged(object sender, EventArgs e)
        {
            GridView gridview = ((GridView)sender);
            if (!gridview.GridControl.IsHandleCreated) return;
            Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
            SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
            gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 10;
        }

        private void bandedGridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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
    }
}