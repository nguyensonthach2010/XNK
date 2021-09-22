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
using System.IO;
using ExcelDataReader;
using Z.Dapper.Plus;
using System.Data.SqlClient;

namespace XNK
{
    public partial class ImportNXT : DevExpress.XtraEditors.XtraForm
    {
        public ImportNXT()
        {
            InitializeComponent();
        }

        DataTableCollection tableCollection;

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook(*.xlsx;*.xls)|*.xlsx;*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textEdit1.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            comboBoxEdit1.Properties.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                comboBoxEdit1.Properties.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[comboBoxEdit1.SelectedItem.ToString()];
            if (dt != null)
            {
                List<NXT> nhap = new List<NXT>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NXT nhap1 = new NXT();
                    nhap1.namsx = dt.Rows[i]["Năm SX"].ToString();
                    nhap1.ngaynhap = Convert.ToDateTime(dt.Rows[i]["Ngày nhập"].ToString()).ToString("MM/dd/yyyy");
                    nhap1.kho = dt.Rows[i]["Kho"].ToString();
                    nhap1.vitri = dt.Rows[i]["Vị trí"].ToString();
                    nhap1.ctlcode = dt.Rows[i]["Catalan Code"].ToString();
                    nhap1.duoimau = dt.Rows[i]["Đuôi màu"].ToString();
                    nhap1.loca = dt.Rows[i]["Lô ca"].ToString();
                    nhap1.slgia = dt.Rows[i]["SL giá"].ToString();
                    nhap1.slhop = dt.Rows[i]["SL hộp"].ToString();
                    nhap1.FOB_Date = Convert.ToDateTime(dt.Rows[i]["FOB Date"].ToString()).ToString("MM/dd/yyyy");
                    nhap1.dnxl = dt.Rows[i]["ĐNXL"].ToString();
                    nhap1.slhopx = dt.Rows[i]["SL hộp xuất"].ToString();
                    nhap1.FOB_Amount = dt.Rows[i]["Sl giá xuất"].ToString();
                    nhap1.nuoc = dt.Rows[i]["Nước"].ToString();
                    nhap.Add(nhap1);
                }
                nXTBindingSource.DataSource = nhap;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string conn = XNK.Properties.Settings.Default.connString;
                DapperPlusManager.Entity<NXT>().Table("NXT");
                List<NXT> nhaps = nXTBindingSource.DataSource as List<NXT>;
                if (nhaps != null)
                {
                    using (IDbConnection db = new SqlConnection(conn))
                    {
                        db.BulkInsert(nhaps);
                    }
                }
                XtraMessageBox.Show("Import Succesfully!!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}