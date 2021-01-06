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

        }

        //private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    string sql1 = "Select X.PI as MaVT,x.ContractNo as Contr, x.khachhang as KH, H.CatalanCode as CtlCode, x.item as Item, X.PSI_ref, Sum(X.amount) as Xuat, (pallet_pi - SUM(amount)) as TonPI INTO ##tonpi From Ton_PI X, Supplies H Where X.VariantPI = H.Variant and x.nuoc = 'Anh' Group By X.VariantPI,X.PI, H.CatalanCode, X.pallet_pi,x.khachhang,x.item,X.PSI_ref,x.ContractNo having SUM(X.amount) > 0";          
        //    if(ConnectDB.Query(sql1)==-1)
        //    {
        //        XtraMessageBox.Show("AN");
        //    }else
        //    {
        //        XtraMessageBox.Show("Thành công");
        //        GopTonPI_Anh t = new GopTonPI_Anh();
        //        t.MdiParent = this;
        //        t.Show();
        //    }    
        //}
    }
}
