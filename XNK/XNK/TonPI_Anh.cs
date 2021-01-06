﻿using System;
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

namespace XNK
{
    public partial class TonPI_Anh : DevExpress.XtraEditors.XtraForm
    {
        public TonPI_Anh()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KH k = new KH();
            k.Show();
        }
        public void LoadData()
        {
            Load_lookupedit();
            try
            {
                string sql = "SELECT [stt],[sodonsx],[PI],[PSI_ref],[price],[pallet_pi],[POB_Date],ContractNo,[nuoc],amount, khachhang,[VariantPI],[item],CatalanCode,Size,iif(pallet_pi - SUM(amount) OVER(PARTITION BY VariantPI, PI, item, ContractNo ORDER BY stt) > 0, amount, amount + (pallet_pi - SUM(amount) OVER(PARTITION BY VariantPI, PI, item, ContractNo ORDER BY stt))) AS slxuat,(SUM(amount) OVER(PARTITION BY VariantPI, PI, item, ContractNo ORDER BY stt)) as Tongxuat,pallet_pi - SUM(amount) OVER(PARTITION BY VariantPI, PI, item, ContractNo ORDER BY stt) AS tonpi FROM[dbo].[Ton_PI] inner join Supplies on Supplies.Variant = Ton_PI.VariantPI where Ton_PI.nuoc = 'Anh' Order by PI asc,POB_Date desc";
                gridControl1.DataSource =  ConnectDB.getTable(sql);
                
            }catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra");
            }
        }

        private void TonPI_Anh_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void Load_lookupedit()
        {
            try
            {
                string sql1 = "select Variant, CatalanCode, SuppliesName,Bricks, Size, M2,Box,Shelf,CustomerName from Supplies";
                repositoryItemLookUpEdit2.DataSource = ConnectDB.getTable(sql1);
                repositoryItemLookUpEdit2.ValueMember = "Variant";
                repositoryItemLookUpEdit2.DisplayMember = "Variant";

                string sqll = "select * from KH";
                repositoryItemLookUpEdit1.DataSource = ConnectDB.getTable(sqll);
                repositoryItemLookUpEdit1.ValueMember = "khachhang";
                repositoryItemLookUpEdit1.DisplayMember = "khachhang";
            }
            catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra!!");
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                string sql2 = @"select * from Supplies where Variant = '" + view.GetRowCellValue(e.RowHandle, "VariantPI").ToString() + "' ";
                DataTable tb = ConnectDB.getTable(sql2);
                
                if (view == null) return;

                switch (e.Column.Caption.ToString())
                {
                    case "VariantPI":
                        string i = tb.Rows[0]["SuppliesName"].ToString().Trim()+ " "+ tb.Rows[0]["Productcode"].ToString().Trim();
                        view.SetRowCellValue(e.RowHandle, "item", "");
                        string cellValue4 = "" + i + "" + view.GetRowCellValue(e.RowHandle, "item").ToString();
                        view.SetRowCellValue(e.RowHandle, "item", cellValue4);

                        view.SetRowCellValue(e.RowHandle, "CatalanCode", "");
                        string cellValue = "" + tb.Rows[0]["CatalanCode"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "CatalanCode").ToString();
                        view.SetRowCellValue(e.RowHandle, "CatalanCode", cellValue);

                        view.SetRowCellValue(e.RowHandle, "Size", "");
                        string cellValue1 = "" + tb.Rows[0]["Size"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "Size").ToString();
                        view.SetRowCellValue(e.RowHandle, "Size", cellValue1);
                        break;

                    case "SL Xuất":

                        string sql1 = "select SUM(amount) as Xuat ,AVG(pallet_pi) - SUM(amount) as TonPI from Ton_PI where VariantPI='" + view.GetRowCellValue(e.RowHandle, "VariantPI").ToString() + "' and PI='" + view.GetRowCellValue(e.RowHandle, "PI").ToString() + "'";
                        DataTable tb1 = ConnectDB.getTable(sql1);

                        int Tongxuat = int.Parse(tb1.Rows[0]["Xuat"].ToString().Trim()) + int.Parse(view.GetRowCellValue(e.RowHandle, "amount").ToString());
                        int tonpi = int.Parse(tb1.Rows[0]["TonPI"].ToString().Trim()) - int.Parse(view.GetRowCellValue(e.RowHandle, "amount").ToString());
                        view.SetRowCellValue(e.RowHandle, "Tongxuat", "");
                        string cellValue2 = "" + Tongxuat + "" + view.GetRowCellValue(e.RowHandle, "Tongxuat").ToString();
                        view.SetRowCellValue(e.RowHandle, "Tongxuat", cellValue2);

                        view.SetRowCellValue(e.RowHandle, "tonpi", "");
                        string cellValue3 = "" + tonpi + "" + view.GetRowCellValue(e.RowHandle, "tonpi").ToString();
                        view.SetRowCellValue(e.RowHandle, "tonpi", cellValue3);

                        break;
                }
            }
            catch
            {
                XtraMessageBox.Show("");
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            // kiem tra cell cua mot dong dang Edit xem co rong ko?
            if (gridView1.GetRowCellValue(e.RowHandle, "PI").ToString() == "" || gridView1.GetRowCellValue(e.RowHandle, "VariantPI").ToString() == "" || gridView1.GetRowCellValue(e.RowHandle, "amount").ToString() == "")
            {
                // chuỗi thông báo lỗi
                bVali = false;
                sErr = sErr + "Vui lòng điền đầy đủ thông tin!! Nhấn OK để load lại form nhập!!";
            }

            if (bVali)
            {
                //lưu giá trị hiển thị trên gridview vào các biến tương ứng
                string amount = gridView1.GetRowCellValue(e.RowHandle, "amount").ToString();
                string PI = gridView1.GetRowCellValue(e.RowHandle, "PI").ToString();
                string VariantPI = gridView1.GetRowCellValue(e.RowHandle, "VariantPI").ToString();
                string sodonsx = gridView1.GetRowCellValue(e.RowHandle, "sodonsx").ToString();
                string PSI_ref = gridView1.GetRowCellValue(e.RowHandle, "PSI_ref").ToString();
                string CTN = gridView1.GetRowCellValue(e.RowHandle, "ContractNo").ToString();
                string khachhang = gridView1.GetRowCellValue(e.RowHandle, "khachhang").ToString();
                float price = float.Parse(gridView1.GetRowCellValue(e.RowHandle, "price").ToString());
                string pallet_pi = gridView1.GetRowCellValue(e.RowHandle, "pallet_pi").ToString();
                string POB_Date = gridView1.GetRowCellValue(e.RowHandle, "POB_Date").ToString();
                string item = gridView1.GetRowCellValue(e.RowHandle, "item").ToString();
                string stt = gridView1.GetRowCellValue(e.RowHandle, "stt").ToString();

                GridView view = sender as GridView;
                //kiểm tra xem dòng đang chọn có phải dòng mới không nếu đúng thì insert không thì update
                if (view.IsNewItemRow(e.RowHandle))
                {
                    try
                    {
                        string insert = "insert into Ton_PI values ('" + sodonsx + "','" + PI + "','" + PSI_ref + "','" + price + "','" + pallet_pi + "','" + Convert.ToDateTime(POB_Date).ToString("MM/dd/yyyy") + "','" + amount + "','" + CTN + "',N'Anh',N'" + khachhang + "','" + VariantPI + "','" + item + "')";
                        ConnectDB.Query(insert);
                        LoadData();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Không thể kết nối tới CSDL!!");
                    }
                }
                else
                {
                    //if (Quyen.nhomnd == "Admin")
                    //{
                    try
                    {
                        string update = "update Ton_PI set sodonsx = '" + sodonsx + "',PI = '" + PI + "',POB_Date= '" + Convert.ToDateTime(POB_Date).ToString("MM/dd/yyyy") + "',PSI_ref = '" + PSI_ref + "',price = '" + price + "',pallet_pi = '" + pallet_pi + "',amount = '" + amount + "',ContractNo = '" + CTN + "',khachhang = '" + khachhang + "',VariantPI = '" + VariantPI + "',item = N'" + item + "' where stt = '" + stt + "'";
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
                DialogResult tb = XtraMessageBox.Show(sErr, "Lỗi trong quá trình nhập!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tb == DialogResult.OK)
                {
                    // load lại form
                    LoadData();
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Exporting();
        }
        private void Exporting()
        {
            //Xuất file Excel từ gridview sau khi truyền dữ liệu từ câu sql vào gridview
            try
            {
                string sql = "SELECT [stt],[sodonsx],[PI],[PSI_ref],[price],[pallet_pi],[POB_Date],ContractNo,[nuoc],amount, khachhang,[VariantPI],[item],CatalanCode,Size,iif(pallet_pi - SUM(amount) OVER(PARTITION BY VariantPI, PI, item, ContractNo ORDER BY stt) > 0, amount, amount + (pallet_pi - SUM(amount) OVER(PARTITION BY VariantPI, PI, item, ContractNo ORDER BY stt))) AS slxuat,(SUM(amount) OVER(PARTITION BY VariantPI, PI, item, ContractNo ORDER BY stt)) as Tongxuat,pallet_pi - SUM(amount) OVER(PARTITION BY VariantPI, PI, item, ContractNo ORDER BY stt) AS tonpi FROM[dbo].[Ton_PI] inner join Supplies on Supplies.Variant = Ton_PI.VariantPI where Ton_PI.nuoc = 'Anh' Order by PI asc,POB_Date desc";
                SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
                saveFileDialogExcel.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
                {
                    string exportFilePath = saveFileDialogExcel.FileName;
                    gridControl1.DataSource = ConnectDB.getTable(sql);
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
            string stt = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "stt").ToString();

            if (e.KeyCode == Keys.Delete)
            {
                DialogResult tb = XtraMessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tb == DialogResult.Yes)
                {
                    //if (Quyen.nhomnd == "Admin")
                    //{
                    try
                    {
                        string delete = "delete from Ton_PI where stt ='" + stt + "'";
                        ConnectDB.Query(delete);
                        LoadData();
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
                    LoadData();
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                LoadData();
            }

            if (e.KeyCode == Keys.F1)
            {
                KH k = new KH();
                k.Show();
            }

            if (e.Control && e.KeyCode == Keys.P)
            {
                Exporting();
            }
        }
        public static string PI = "";
        public static string VariantPI = "";
        public static string sodonsx = "";
        public static string PSI_ref = "";
        public static string CTN = "";
        public static string khachhang = "";
        public static string price = "";
        public static string pallet_pi = "";
        public static string POB_Date = "";
        public static string item = "";
        public static string stt = "";

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            PI = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PI").ToString();
            VariantPI = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VariantPI").ToString();
            sodonsx = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sodonsx").ToString();
            PSI_ref = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSI_ref").ToString();
            CTN = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ContractNo").ToString();
            khachhang = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "khachhang").ToString();
            price = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "price").ToString();
            pallet_pi = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "pallet_pi").ToString();
            item = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "item").ToString();
            stt = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "stt").ToString();

            RePI_Anh re = new RePI_Anh();
            re.Show();
        }
    }
}