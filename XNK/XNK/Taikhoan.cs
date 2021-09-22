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
    public partial class Taikhoan : DevExpress.XtraEditors.XtraForm
    {
        public Taikhoan()
        {
            InitializeComponent();
        }
        private bool validate()
        {   //hàm kiểm tra dữ liệu nhập vào có rỗng hay k
            if (txtmnv.Text == "" || txttnv.Text == "" || txtttk.Text == "" || txtqtc.Text == "" || txtmk.Text == "" || txttthd.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void Loaddata()
        {
            try
            {
                string sql = "select NhanVien.* from NhanVien";
                gridControl1.DataSource = ConnectDB.getTable(sql);
            }
            catch
            {
                XtraMessageBox.Show("Không thể kết nối tới CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Taikhoan_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    string sql1 = "select*from NhanVien where username ='" + txtttk.Text + "'";
                    DataTable tb = ConnectDB.getTable(sql1);

                    if(tb.Rows.Count<=0)
                    {
                        string sql = "insert into NhanVien values('" + txtmnv.Text + "',N'" + txttnv.Text + "','" + txtttk.Text + "','" + txtmk.Text + "',N'" + txtqtc.Text + "',N'" + txttthd.Text + "')";

                        if (ConnectDB.Query(sql) == -1)
                        {
                            XtraMessageBox.Show("Thêm không thành công tài khoản !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thành công tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Loaddata();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Username này đã tồn tại, hãy nhập username khác!!");
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Không thể kết nối tới CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            txtmnv.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "manv").ToString();
            txttnv.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "tennv").ToString();
            txtttk.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "username").ToString();
            txtmk.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "password").ToString();
            txtqtc.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "quyentc").ToString();
            txttthd.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "trangthai").ToString();
            txtmnv.Enabled = false;
            txttnv.Enabled = true;
            txtttk.Enabled = false;
            txtmk.Enabled = false;
            txtqtc.Enabled = true;
            txttthd.Enabled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    string sql1 = "select*from NhanVien where username ='" + txtttk.Text + "' and manv = '" + txtmnv.Text + "' and password ='" + txtmk.Text + "'";
                    DataTable tb = ConnectDB.getTable(sql1);
                    if(tb.Rows.Count <= 0)
                    {
                        XtraMessageBox.Show("Không tìm thấy tài khoản bạn cần sửa!!");
                        Loaddata();
                    }
                    else
                    {
                        string sql = "update NhanVien set tennv =N'" + txttnv.Text + "',quyentc =N'" + txtqtc.Text + "',trangthai =N'" + txttthd.Text + "' where username ='" + txtttk.Text + "'";

                        if (ConnectDB.Query(sql) == -1)
                        {
                            XtraMessageBox.Show("Sửa không thành công dữ liệu !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            XtraMessageBox.Show("Sửa thành công dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Loaddata();
                        }
                    }    
                }
            }
            catch
            {
                XtraMessageBox.Show("Không thể kết nối tới CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult tb = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tb == DialogResult.Yes)
                {
                    if (validate())
                    {
                        string sql1 = "select*from NhanVien where username ='" + txtttk.Text + "' and manv = '" + txtmnv.Text + "' and password ='" + txtmk.Text + "'";
                        DataTable tb1 = ConnectDB.getTable(sql1);
                        if (tb1.Rows.Count <= 0)
                        {
                            XtraMessageBox.Show("Không tìm thấy tài khoản bạn cần sửa!!");
                            Loaddata();
                        }
                        else
                        {
                            string sql = "delete from NhanVien where username = '" + txtttk.Text + "'";

                            if (ConnectDB.Query(sql) == -1)
                            {
                                XtraMessageBox.Show("Xóa thông tin không thành công (T_T) !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                XtraMessageBox.Show("Xóa thông tin thành công (^-^)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Loaddata();
                            }
                        }
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Không thể kết nối tới CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridView1.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
            {
                string username = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "username").ToString();
                DialogResult tb = XtraMessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tb == DialogResult.Yes)
                {
                    GridView view = sender as GridView;
                    view.DeleteRow(view.FocusedRowHandle);
                    try
                    {
                        string delete = "delete from NhanVien where username ='" + username + "' ";

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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            txtmnv.Text = "";
            txttnv.Text = "";
            txtttk.Text = "";
            txtmk.Text = "";
            txttthd.Text = "";
            txtqtc.Text = "";
            txtmnv.Enabled = true;
            txtttk.Enabled = true;
            txtmk.Enabled = true;

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