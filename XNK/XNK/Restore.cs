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
using System.Data.SqlClient;

namespace XNK
{
    public partial class Restore : DevExpress.XtraEditors.XtraForm
    {
        public Restore()
        {
            InitializeComponent();
        }

        string connString = @"Data Source=192.168.1.151,1433;Initial Catalog=XNK;User ID=IT;Password=catalan123";

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection sqlcon = new SqlConnection(connString);
                sqlcon.Open();
                string sql = string.Format("ALTER DATABASE [XNK] SET SINGLE_USER WITH ROLLBACK IMMEDIATE ");
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.ExecuteNonQuery();
                string sql1 = "Use master restore database [XNK] from disk ='" + textEdit1.Text + "' with replace;";
                SqlCommand cmd1 = new SqlCommand(sql1, sqlcon);
                cmd1.ExecuteNonQuery();
                string sql3 = string.Format("alter database [XNK] set MULTI_USER");
                SqlCommand cmd2 = new SqlCommand(sql3, sqlcon);
                cmd2.ExecuteNonQuery();
                DialogResult dr = XtraMessageBox.Show("Phục hồi thành công dữ liệu. Khởi động lại chương trình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            catch
            {
                XtraMessageBox.Show("Phục hồi dữ liệu không thành công!");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SEVER database backup file|*.bak";
            dlg.Title = "Phục hồi Database";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textEdit1.Text = dlg.FileName;
                simpleButton2.Enabled = true;
            }
        }
    }
}