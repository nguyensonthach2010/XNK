using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            //
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skin();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XK_Anh a = new XK_Anh();
            a.MdiParent = this;
            a.Show();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TonPI_Anh a = new TonPI_Anh();
            a.MdiParent = this;
            a.Show();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NXT_Anh x = new NXT_Anh();
            x.MdiParent = this;
            x.Show();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TkTonPI_Anh t = new TkTonPI_Anh();
            t.MdiParent = this;
            t.Show();
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TKNXT_Anh t = new TKNXT_Anh();
            t.MdiParent = this;
            t.Show();
        }

        //private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{

        //    }    
        //}
    }
}
