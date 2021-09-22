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
    public partial class ImportPI : DevExpress.XtraEditors.XtraForm
    {
        public ImportPI()
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
                List<TonPI> nhap = new List<TonPI>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TonPI nhap1 = new TonPI();
                    nhap1.sodonsx = dt.Rows[i]["Số đơn SX"].ToString();
                    nhap1.PI = dt.Rows[i]["PI"].ToString();
                    nhap1.PSI_ref = dt.Rows[i]["PSI ref"].ToString();
                    nhap1.ContractNo = dt.Rows[i]["Contract No"].ToString();
                    nhap1.khachhang = dt.Rows[i]["Khách hàng"].ToString();
                    nhap1.VariantPI = dt.Rows[i]["Variant"].ToString();
                    nhap1.item = dt.Rows[i]["Item"].ToString();
                    nhap1.pallet_pi = dt.Rows[i]["Pallets theo PI"].ToString();
                    nhap1.price = dt.Rows[i]["Giá"].ToString();
                    nhap1.POB_Date = Convert.ToDateTime(dt.Rows[i]["FOB Date"].ToString()).ToString("MM/dd/yyyy");
                    nhap1.amount = dt.Rows[i]["Số giá xuất"].ToString();
                    nhap1.nuoc = dt.Rows[i]["Nước"].ToString();
                    nhap.Add(nhap1);
                }
                tonPIBindingSource.DataSource = nhap;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string conn = XNK.Properties.Settings.Default.connString;
                DapperPlusManager.Entity<TonPI>().Table("Ton_PI");
                List<TonPI> nhaps = tonPIBindingSource.DataSource as List<TonPI>;
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