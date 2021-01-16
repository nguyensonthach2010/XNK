using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;

namespace XNK
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {

       
                InitializeComponent();
         

        }

        private void skin()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(skinRibbonGalleryBarItem1, true);
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Valentine"; // cài đặt giao diện mặc định của form
        }
        public static string taikhoan = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            skin();
            taikhoan = Login.tk;
            barSubItem2.Caption = "Welcome" + taikhoan + " !";
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            //timedelay load form data time 0.3s
            //splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(300);
            //splashScreenManager1.CloseWaitForm();
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            for (int i = 1; i <= 100; i++)
            {
                SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "%");
                Thread.Sleep(4);
            }
            SplashScreenManager.CloseForm(false);

            Vattu vt = new Vattu();
            vt.MdiParent = this;
            vt.Text = "Vật Tư";
            vt.Show();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //timedelay load form data time 0.3s
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            XK_Anh xka = new XK_Anh();
            xka.MdiParent = this;
            xka.Text = "Xuất Khẩu Anh";
            xka.Show();
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //timedelay load form data time 0.3s
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            XK_Dailoan xkdl = new XK_Dailoan();
            xkdl.MdiParent = this;
            xkdl.Text = "Xuất Khẩu DL";
            xkdl.Show();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //timedelay load form data time 0.3s
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            XK_UK xkuk = new XK_UK();
            xkuk.MdiParent = this;
            xkuk.Text = "Xuất Khẩu Anh";
            xkuk.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(300);
            //splashScreenManager1.CloseWaitForm();


            Backup bk = new Backup();

            bk.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
            //Thread.Sleep(300);
            //splashScreenManager1.CloseWaitForm();


            Restore rs = new Restore();
            rs.Show();

        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            TonPI_Anh tpi_a = new TonPI_Anh();
            tpi_a.MdiParent = this;
            tpi_a.Text = "Tồn PI Anh";
            tpi_a.Show();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            TonPI_UK tpi_uk = new TonPI_UK();
            tpi_uk.MdiParent = this;
            tpi_uk.Text = "Tồn PI UK";
            tpi_uk.Show();
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            TonPI_Dl tpi_dl = new TonPI_Dl();
            tpi_dl.MdiParent = this;
            tpi_dl.Text = "Tồn PI Đài Loan";
            tpi_dl.Show();
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            NXT_DL nxt_dl = new NXT_DL();
            nxt_dl.MdiParent = this;
            nxt_dl.Text = "Nhập Xuất Tồn ĐL";
            nxt_dl.Show();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            NXT_Anh nxt_a = new NXT_Anh();
            nxt_a.MdiParent = this;
            nxt_a.Text = "Nhập Xuất Tồn Anh";
            nxt_a.Show();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            NXT_UK nxt_uk = new NXT_UK();
            nxt_uk.MdiParent = this;
            nxt_uk.Text = "Nhập Xuất UK";
            nxt_uk.Show();
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            TkTonPI_Anh nxt_uk = new TkTonPI_Anh();
            nxt_uk.MdiParent = this;
            nxt_uk.Show();
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            TKNXT_Anh nxt_uk = new TKNXT_Anh();
            nxt_uk.MdiParent = this;
            nxt_uk.Show();
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            tkTonPI_UK nxt_uk = new tkTonPI_UK();
            nxt_uk.MdiParent = this;
            nxt_uk.Show();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            TKNXT_UK nxt_uk = new TKNXT_UK();
            nxt_uk.MdiParent = this;
            nxt_uk.Show();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            tkTonPI_DL nxt_uk = new tkTonPI_DL();
            nxt_uk.MdiParent = this;
            nxt_uk.Show();
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            TKNXT_DL nxt_uk = new TKNXT_DL();
            nxt_uk.MdiParent = this;
            nxt_uk.Show();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            Taikhoan tk = new Taikhoan();

            tk.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult thongbao = XtraMessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
                Application.Exit();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult thongbao = XtraMessageBox.Show("Bạn muốn đăng xuất tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                this.Visible = false;
                new Login().ShowDialog();
            }

        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            Thamchieuin tcin = new Thamchieuin();
            tcin.MdiParent = this;
            tcin.Show();
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListPrint p = new ListPrint();
            p.MdiParent = this;
            p.Show();
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Thread.Sleep(300);
            splashScreenManager1.CloseWaitForm();

            DMK dmk = new DMK();

            dmk.Show();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult thongbao = XtraMessageBox.Show("Chức năng tạm thời bị khóa ! Vui lòng đợi trong thời gian tới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (thongbao == DialogResult.Yes)
            {

            }
        }
    }
}
