namespace XNK
{
    partial class Thamchieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Variant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ctlcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SuppliesName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Bricks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.M2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Box = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Shelf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1217, 606);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Variant,
            this.ctlcode,
            this.SuppliesName,
            this.Size,
            this.Bricks,
            this.M2,
            this.Box,
            this.Shelf,
            this.CustomerName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Bảng tham chiếu xuất nhập khẩu";
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Nhấp vào đây để thêm dữ liệu mới ";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // Variant
            // 
            this.Variant.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Variant.AppearanceCell.Options.UseFont = true;
            this.Variant.AppearanceCell.Options.UseTextOptions = true;
            this.Variant.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Variant.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Variant.AppearanceHeader.Options.UseFont = true;
            this.Variant.AppearanceHeader.Options.UseTextOptions = true;
            this.Variant.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Variant.Caption = "Variant";
            this.Variant.FieldName = "Variant";
            this.Variant.Name = "Variant";
            this.Variant.Visible = true;
            this.Variant.VisibleIndex = 0;
            // 
            // ctlcode
            // 
            this.ctlcode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlcode.AppearanceCell.Options.UseFont = true;
            this.ctlcode.AppearanceCell.Options.UseTextOptions = true;
            this.ctlcode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ctlcode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlcode.AppearanceHeader.Options.UseFont = true;
            this.ctlcode.AppearanceHeader.Options.UseTextOptions = true;
            this.ctlcode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ctlcode.Caption = "Catalan code";
            this.ctlcode.FieldName = "ctlcode";
            this.ctlcode.Name = "ctlcode";
            this.ctlcode.Visible = true;
            this.ctlcode.VisibleIndex = 1;
            // 
            // SuppliesName
            // 
            this.SuppliesName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuppliesName.AppearanceCell.Options.UseFont = true;
            this.SuppliesName.AppearanceCell.Options.UseTextOptions = true;
            this.SuppliesName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SuppliesName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuppliesName.AppearanceHeader.Options.UseFont = true;
            this.SuppliesName.AppearanceHeader.Options.UseTextOptions = true;
            this.SuppliesName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SuppliesName.Caption = "Tên sản phẩm";
            this.SuppliesName.FieldName = "SuppliesName";
            this.SuppliesName.Name = "SuppliesName";
            this.SuppliesName.Visible = true;
            this.SuppliesName.VisibleIndex = 2;
            // 
            // Size
            // 
            this.Size.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size.AppearanceCell.Options.UseFont = true;
            this.Size.AppearanceCell.Options.UseTextOptions = true;
            this.Size.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Size.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size.AppearanceHeader.Options.UseFont = true;
            this.Size.AppearanceHeader.Options.UseTextOptions = true;
            this.Size.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Size.Caption = "Size";
            this.Size.FieldName = "Size";
            this.Size.Name = "Size";
            this.Size.Visible = true;
            this.Size.VisibleIndex = 3;
            // 
            // Bricks
            // 
            this.Bricks.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bricks.AppearanceCell.Options.UseFont = true;
            this.Bricks.AppearanceCell.Options.UseTextOptions = true;
            this.Bricks.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Bricks.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bricks.AppearanceHeader.Options.UseFont = true;
            this.Bricks.AppearanceHeader.Options.UseTextOptions = true;
            this.Bricks.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Bricks.Caption = "Viên/hộp";
            this.Bricks.FieldName = "Bricks";
            this.Bricks.Name = "Bricks";
            this.Bricks.Visible = true;
            this.Bricks.VisibleIndex = 4;
            // 
            // M2
            // 
            this.M2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M2.AppearanceCell.Options.UseFont = true;
            this.M2.AppearanceCell.Options.UseTextOptions = true;
            this.M2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.M2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M2.AppearanceHeader.Options.UseFont = true;
            this.M2.AppearanceHeader.Options.UseTextOptions = true;
            this.M2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.M2.Caption = "M2/Hộp";
            this.M2.FieldName = "M2";
            this.M2.Name = "M2";
            this.M2.Visible = true;
            this.M2.VisibleIndex = 5;
            // 
            // Box
            // 
            this.Box.AppearanceCell.Options.UseTextOptions = true;
            this.Box.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Box.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Box.AppearanceHeader.Options.UseFont = true;
            this.Box.AppearanceHeader.Options.UseTextOptions = true;
            this.Box.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Box.Caption = "Hộp/giá";
            this.Box.FieldName = "Box";
            this.Box.Name = "Box";
            this.Box.Visible = true;
            this.Box.VisibleIndex = 6;
            // 
            // Shelf
            // 
            this.Shelf.AppearanceCell.Options.UseTextOptions = true;
            this.Shelf.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Shelf.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shelf.AppearanceHeader.Options.UseFont = true;
            this.Shelf.AppearanceHeader.Options.UseTextOptions = true;
            this.Shelf.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Shelf.Caption = "Hộp/cont";
            this.Shelf.FieldName = "Self";
            this.Shelf.Name = "Shelf";
            this.Shelf.Visible = true;
            this.Shelf.VisibleIndex = 7;
            // 
            // CustomerName
            // 
            this.CustomerName.AppearanceCell.Options.UseTextOptions = true;
            this.CustomerName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CustomerName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerName.AppearanceHeader.Options.UseFont = true;
            this.CustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.CustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CustomerName.Caption = "Khách Hàng";
            this.CustomerName.FieldName = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 8;
            // 
            // Thamchieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 606);
            this.Controls.Add(this.gridControl1);
            this.Name = "Thamchieu";
            this.Text = "Thamchieu";
            this.Load += new System.EventHandler(this.Thamchieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Variant;
        private DevExpress.XtraGrid.Columns.GridColumn ctlcode;
        private DevExpress.XtraGrid.Columns.GridColumn SuppliesName;
        private DevExpress.XtraGrid.Columns.GridColumn Size;
        private DevExpress.XtraGrid.Columns.GridColumn Bricks;
        private DevExpress.XtraGrid.Columns.GridColumn M2;
        private DevExpress.XtraGrid.Columns.GridColumn Box;
        private DevExpress.XtraGrid.Columns.GridColumn Shelf;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}