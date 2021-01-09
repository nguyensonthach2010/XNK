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

        private void Form1_Load(object sender, EventArgs e)
        {
            skin();

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
                Thread.Sleep(5);
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
    }
}
