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

namespace XNK
{
    public partial class XK_Anh : DevExpress.XtraEditors.XtraForm
    {
        public XK_Anh()
        {
            InitializeComponent();
        }

        private void XK_Anh_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Load_lookupedit();
                string sql = "select stt, kh,xe, ngaydong,sttcont,pokhach,Supplies.CatalanCode,pocatalan,XuatK.Variant,palles,Box, (Box*palles) as tonghop, M2, (Box*palles*M2) as tongm2,duoimau,loca, vitri,socont, sochi,note,nuoc from XuatK inner join Supplies on Supplies.Variant = XuatK.Variant order by xe ASC, ngaydong ASC, sttcont ASC ";
                gridControl1.DataSource = ConnectDB.getTable(sql);
            }
            catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra!! Không kết nối được tới CSDL");
            }
        }
        private void Load_lookupedit()
        {
            try
            {
                string sql1 = "select Variant, CatalanCode, SuppliesName,Bricks, Size, M2,Box,Shelf,CustomerName from Supplies";
                repositoryItemLookUpEdit1.DataSource = ConnectDB.getTable(sql1);
                repositoryItemLookUpEdit1.ValueMember = "Variant";
                repositoryItemLookUpEdit1.DisplayMember = "Variant";
            }catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra!!");
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                string sql2 = @"select * from Supplies where Variant = '" + view.GetRowCellValue(e.RowHandle, "Variant").ToString() + "' ";
                DataTable tb = ConnectDB.getTable(sql2);
                if (view == null) return;

                switch (e.Column.Caption.ToString())
                {
                    case "Variant":
                        
                        view.SetRowCellValue(e.RowHandle, "Box", "");
                        string cellValue4 = "" + tb.Rows[0]["Box"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "Box").ToString();
                        view.SetRowCellValue(e.RowHandle, "Box", cellValue4);

                        view.SetRowCellValue(e.RowHandle, "CatalanCode", "");
                        string cellValue = "" + tb.Rows[0]["CatalanCode"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "CatalanCode").ToString();
                        view.SetRowCellValue(e.RowHandle, "CatalanCode", cellValue);

                        view.SetRowCellValue(e.RowHandle, "M2", "");
                        string cellValue1 = "" + tb.Rows[0]["M2"].ToString().Trim() + "" + view.GetRowCellValue(e.RowHandle, "M2").ToString();
                        view.SetRowCellValue(e.RowHandle, "M2", cellValue1);
                        break;

                    case "Pallets":

                        int tonghop = int.Parse(tb.Rows[0]["Box"].ToString().Trim()) * int.Parse(view.GetRowCellValue(e.RowHandle, "palles").ToString());
                        float tongm2 = float.Parse(tb.Rows[0]["Box"].ToString().Trim()) * float.Parse(view.GetRowCellValue(e.RowHandle, "palles").ToString())
                            * float.Parse(tb.Rows[0]["M2"].ToString().Trim());

                        view.SetRowCellValue(e.RowHandle, "tonghop", "");
                        string cellValue2 = "" + tonghop + "" + view.GetRowCellValue(e.RowHandle, "tonghop").ToString();
                        view.SetRowCellValue(e.RowHandle, "tonghop", cellValue2);

                        view.SetRowCellValue(e.RowHandle, "tongm2", "");
                        string cellValue3 = "" + Math.Round((float)tongm2, 2) + "" + view.GetRowCellValue(e.RowHandle, "tongm2").ToString();
                        view.SetRowCellValue(e.RowHandle, "tongm2", cellValue3);
                       
                        break;
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show(e.ToString());
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            // kiem tra cell cua mot dong dang Edit xem co rong ko?
            if (gridView1.GetRowCellValue(e.RowHandle, "Variant").ToString() == "" || gridView1.GetRowCellValue(e.RowHandle, "pocatalan").ToString() == "" || gridView1.GetRowCellValue(e.RowHandle, "palles").ToString() == "")
            {
                // chuỗi thông báo lỗi
                bVali = false;
                sErr = sErr + "Vui lòng điền đầy đủ thông tin!! Nhấn OK để load lại form nhập!!";
            }

            if (bVali)
            {
                //lưu giá trị hiển thị trên gridview vào các biến tương ứng
                string Variant = gridView1.GetRowCellValue(e.RowHandle, "Variant").ToString();
                string pocatalan = gridView1.GetRowCellValue(e.RowHandle, "pocatalan").ToString();
                string palles = gridView1.GetRowCellValue(e.RowHandle, "palles").ToString();
                string kh = gridView1.GetRowCellValue(e.RowHandle, "kh").ToString();
                string xe = gridView1.GetRowCellValue(e.RowHandle, "xe").ToString();
                string ngaydong = gridView1.GetRowCellValue(e.RowHandle, "ngaydong").ToString();
                string sttcont = gridView1.GetRowCellValue(e.RowHandle, "sttcont").ToString();
                string pokhach = gridView1.GetRowCellValue(e.RowHandle, "pokhach").ToString();
                string duoimau = gridView1.GetRowCellValue(e.RowHandle, "duoimau").ToString();
                string loca = gridView1.GetRowCellValue(e.RowHandle, "loca").ToString();
                string vitri = gridView1.GetRowCellValue(e.RowHandle, "vitri").ToString();
                string socont = gridView1.GetRowCellValue(e.RowHandle, "socont").ToString();
                string sochi = gridView1.GetRowCellValue(e.RowHandle, "sochi").ToString();
                string note = gridView1.GetRowCellValue(e.RowHandle, "note").ToString();
                string stt = gridView1.GetRowCellValue(e.RowHandle, "stt").ToString();
                string stt = gridView1.GetRowCellValue(e.RowHandle, "stt").ToString();
                GridView view = sender as GridView;
                //kiểm tra xem dòng đang chọn có phải dòng mới không nếu đúng thì insert không thì update
                if (view.IsNewItemRow(e.RowHandle))
                {
                    try
                    {
                        string insert = "insert into XuatK values (N'" + kh + "',N'" + xe + "','" + Convert.ToDateTime(ngaydong).ToString("MM/dd/yyyy") + "','" + sttcont + "','" + pokhach + "','" + pocatalan + "','" + Variant + "','" + palles + "','" + duoimau + "','" + loca + "','" + vitri + "','" + socont + "','" + sochi + "',N'" + note + "',N'Anh')";
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
                            string update = "update XuatK set kh = N'" + kh + "',xe = N'" + xe + "',ngaydong= '" + Convert.ToDateTime(ngaydong).ToString("MM/dd/yyyy") + "',sttcont = '" + sttcont + "',pokhach = '" + pokhach + "',pocatalan = '" + pocatalan + "',Variant = '" + Variant + "',palles = '" + palles + "',duoimau = '" + duoimau + "',loca = '" + loca + "',vitri = N'" + vitri + "',socont = '" + socont + "',sochi = '" + sochi + "',note = N'" + note + "' where stt = '"+stt+"'";
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

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //string Variant = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Variant").ToString();
            //string pocatalan = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "pocatalan").ToString();
            //string palles = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "palles").ToString();
            //string kh = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "kh").ToString();
            //string xe = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "xe").ToString();
            //string ngaydong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ngaydong").ToString();
            //string sttcont = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sttcont").ToString();
            //string pokhach = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "pokhach").ToString();
            //string duoimau = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "duoimau").ToString();
            //string loca = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "loca").ToString();
            //string vitri = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "vitri").ToString();
            //string socont = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "socont").ToString();
            //string sochi = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sochi").ToString();
            //string note = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "note").ToString();
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
                            string delete = "delete from XuatK where stt ='" + stt + "'";
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
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Xuất file Excel từ gridview sau khi truyền dữ liệu từ câu sql vào gridview
            try
            {
                string sql = "select stt, kh,xe, ngaydong,sttcont,pokhach,Supplies.CatalanCode,pocatalan,XuatK.Variant,palles,Box, (Box*palles) as tonghop, M2, (Box*palles*M2) as tongm2,duoimau,loca, vitri,socont, sochi,note,nuoc from XuatK inner join Supplies on Supplies.Variant = XuatK.Variant order by xe ASC, ngaydong ASC, sttcont ASC ";
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
    }
}