
namespace CRM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.KonuturuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.içYazışmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dışYazışmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parçaÜzerineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYeniKonu = new DevExpress.XtraEditors.SimpleButton();
            this.btnListele = new DevExpress.XtraEditors.SimpleButton();
            this.btnDüzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnYazdır = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdmin = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cevapEkleContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cevapEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayrıntılarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Aktif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Firma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Konu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.Cevap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Gorusen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Gorusulen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tür = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StokAdı = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StokKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StokAdet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cevapId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.KonuturuContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cevapEkleContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // KonuturuContext
            // 
            this.KonuturuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.içYazışmaToolStripMenuItem,
            this.dışYazışmaToolStripMenuItem,
            this.parçaÜzerineToolStripMenuItem});
            this.KonuturuContext.Name = "contextMenuStrip1";
            this.KonuturuContext.Size = new System.Drawing.Size(146, 70);
            // 
            // içYazışmaToolStripMenuItem
            // 
            this.içYazışmaToolStripMenuItem.Name = "içYazışmaToolStripMenuItem";
            this.içYazışmaToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.içYazışmaToolStripMenuItem.Text = "İç Yazışma";
            this.içYazışmaToolStripMenuItem.Click += new System.EventHandler(this.içYazışmaToolStripMenuItem_Click);
            // 
            // dışYazışmaToolStripMenuItem
            // 
            this.dışYazışmaToolStripMenuItem.Name = "dışYazışmaToolStripMenuItem";
            this.dışYazışmaToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.dışYazışmaToolStripMenuItem.Text = "Dış Yazışma";
            this.dışYazışmaToolStripMenuItem.Click += new System.EventHandler(this.dışYazışmaToolStripMenuItem_Click);
            // 
            // parçaÜzerineToolStripMenuItem
            // 
            this.parçaÜzerineToolStripMenuItem.Name = "parçaÜzerineToolStripMenuItem";
            this.parçaÜzerineToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.parçaÜzerineToolStripMenuItem.Text = "Parça Üzerine";
            this.parçaÜzerineToolStripMenuItem.Click += new System.EventHandler(this.parçaÜzerineToolStripMenuItem_Click);
            // 
            // btnYeniKonu
            // 
            this.btnYeniKonu.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnYeniKonu.Appearance.Options.UseFont = true;
            this.btnYeniKonu.ContextMenuStrip = this.KonuturuContext;
            this.btnYeniKonu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYeniKonu.ImageOptions.Image")));
            this.btnYeniKonu.Location = new System.Drawing.Point(11, 10);
            this.btnYeniKonu.Name = "btnYeniKonu";
            this.btnYeniKonu.Size = new System.Drawing.Size(96, 24);
            this.btnYeniKonu.TabIndex = 0;
            this.btnYeniKonu.Text = "Yeni Konu";
            this.btnYeniKonu.Click += new System.EventHandler(this.btnYeniKonu_Click);
            // 
            // btnListele
            // 
            this.btnListele.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnListele.Appearance.Options.UseFont = true;
            this.btnListele.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListele.ImageOptions.Image")));
            this.btnListele.Location = new System.Drawing.Point(116, 10);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(96, 24);
            this.btnListele.TabIndex = 1;
            this.btnListele.Text = "Yenile";
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // btnDüzenle
            // 
            this.btnDüzenle.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDüzenle.Appearance.Options.UseFont = true;
            this.btnDüzenle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDüzenle.ImageOptions.Image")));
            this.btnDüzenle.Location = new System.Drawing.Point(221, 10);
            this.btnDüzenle.Name = "btnDüzenle";
            this.btnDüzenle.Size = new System.Drawing.Size(105, 24);
            this.btnDüzenle.TabIndex = 2;
            this.btnDüzenle.Text = "Düzenle";
            this.btnDüzenle.Click += new System.EventHandler(this.btnDüzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.Location = new System.Drawing.Point(333, 10);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(96, 24);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.btnYazdır);
            this.panelControl1.Controls.Add(this.btnAdmin);
            this.panelControl1.Controls.Add(this.btnYeniKonu);
            this.panelControl1.Controls.Add(this.btnSil);
            this.panelControl1.Controls.Add(this.btnListele);
            this.panelControl1.Controls.Add(this.btnDüzenle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1048, 39);
            this.panelControl1.TabIndex = 4;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // btnYazdır
            // 
            this.btnYazdır.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnYazdır.Appearance.Options.UseFont = true;
            this.btnYazdır.Location = new System.Drawing.Point(435, 10);
            this.btnYazdır.Name = "btnYazdır";
            this.btnYazdır.Size = new System.Drawing.Size(75, 23);
            this.btnYazdır.TabIndex = 5;
            this.btnYazdır.Text = "Yazdır";
            this.btnYazdır.Click += new System.EventHandler(this.btnYazdır_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdmin.Appearance.Options.UseFont = true;
            this.btnAdmin.Location = new System.Drawing.Point(516, 10);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(75, 23);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 39);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1048, 425);
            this.panelControl2.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cevapEkleContext;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2});
            this.gridControl1.Size = new System.Drawing.Size(1044, 421);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // cevapEkleContext
            // 
            this.cevapEkleContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cevapEkleToolStripMenuItem,
            this.ayrıntılarToolStripMenuItem});
            this.cevapEkleContext.Name = "contextMenuStrip1";
            this.cevapEkleContext.Size = new System.Drawing.Size(132, 48);
            // 
            // cevapEkleToolStripMenuItem
            // 
            this.cevapEkleToolStripMenuItem.Name = "cevapEkleToolStripMenuItem";
            this.cevapEkleToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.cevapEkleToolStripMenuItem.Text = "Cevap Ekle";
            this.cevapEkleToolStripMenuItem.Click += new System.EventHandler(this.cevapEkleToolStripMenuItem_Click);
            // 
            // ayrıntılarToolStripMenuItem
            // 
            this.ayrıntılarToolStripMenuItem.Name = "ayrıntılarToolStripMenuItem";
            this.ayrıntılarToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.ayrıntılarToolStripMenuItem.Text = "Ayrıntılar";
            this.ayrıntılarToolStripMenuItem.Click += new System.EventHandler(this.ayrıntılarToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gridView1.Appearance.GroupPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Appearance.GroupRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gridView1.Appearance.GroupRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Aktif,
            this.Firma,
            this.Konu,
            this.Cevap,
            this.Gorusen,
            this.Gorusulen,
            this.Tarih,
            this.Tür,
            this.StokAdı,
            this.StokKodu,
            this.StokAdet,
            this.gridColumn1,
            this.cevapId});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowErrorPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Firma, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Konu, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView1_CustomDrawGroupRow);
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // Aktif
            // 
            this.Aktif.Caption = "Aktif";
            this.Aktif.FieldName = "AktifPasif";
            this.Aktif.Name = "Aktif";
            this.Aktif.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.Aktif.Visible = true;
            this.Aktif.VisibleIndex = 0;
            this.Aktif.Width = 68;
            // 
            // Firma
            // 
            this.Firma.Caption = "Firma";
            this.Firma.FieldName = "Crisim";
            this.Firma.Name = "Firma";
            this.Firma.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.Firma.Visible = true;
            this.Firma.VisibleIndex = 11;
            // 
            // Konu
            // 
            this.Konu.Caption = "Konu";
            this.Konu.ColumnEdit = this.repositoryItemMemoEdit1;
            this.Konu.FieldName = "Konu";
            this.Konu.Name = "Konu";
            this.Konu.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.Konu.Visible = true;
            this.Konu.VisibleIndex = 1;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // Cevap
            // 
            this.Cevap.AppearanceCell.Options.UseTextOptions = true;
            this.Cevap.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.Cevap.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.Cevap.Caption = "Cevap";
            this.Cevap.ColumnEdit = this.repositoryItemMemoEdit1;
            this.Cevap.FieldName = "Cevap";
            this.Cevap.Name = "Cevap";
            this.Cevap.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.Cevap.Visible = true;
            this.Cevap.VisibleIndex = 1;
            this.Cevap.Width = 257;
            // 
            // Gorusen
            // 
            this.Gorusen.Caption = "Görüşen Kullanıcı";
            this.Gorusen.FieldName = "AdSoyad";
            this.Gorusen.Name = "Gorusen";
            this.Gorusen.Visible = true;
            this.Gorusen.VisibleIndex = 2;
            this.Gorusen.Width = 43;
            // 
            // Gorusulen
            // 
            this.Gorusulen.Caption = "Görüşülen Kişi";
            this.Gorusulen.FieldName = "Gorusulen";
            this.Gorusulen.Name = "Gorusulen";
            this.Gorusulen.Visible = true;
            this.Gorusulen.VisibleIndex = 3;
            this.Gorusulen.Width = 43;
            // 
            // Tarih
            // 
            this.Tarih.Caption = "Tarih";
            this.Tarih.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Tarih.FieldName = "Tarih";
            this.Tarih.Name = "Tarih";
            this.Tarih.Visible = true;
            this.Tarih.VisibleIndex = 4;
            this.Tarih.Width = 43;
            // 
            // Tür
            // 
            this.Tür.Caption = "Konu Türü";
            this.Tür.FieldName = "Ad";
            this.Tür.Name = "Tür";
            this.Tür.Visible = true;
            this.Tür.VisibleIndex = 5;
            this.Tür.Width = 43;
            // 
            // StokAdı
            // 
            this.StokAdı.Caption = "Stok Adı";
            this.StokAdı.FieldName = "Stokadi";
            this.StokAdı.Name = "StokAdı";
            this.StokAdı.Visible = true;
            this.StokAdı.VisibleIndex = 6;
            this.StokAdı.Width = 43;
            // 
            // StokKodu
            // 
            this.StokKodu.Caption = "Stok Kodu";
            this.StokKodu.FieldName = "Stokkod";
            this.StokKodu.Name = "StokKodu";
            this.StokKodu.Visible = true;
            this.StokKodu.VisibleIndex = 7;
            this.StokKodu.Width = 43;
            // 
            // StokAdet
            // 
            this.StokAdet.Caption = "Stok Adeti";
            this.StokAdet.FieldName = "Stokadet";
            this.StokAdet.Name = "StokAdet";
            this.StokAdet.Visible = true;
            this.StokAdet.VisibleIndex = 8;
            this.StokAdet.Width = 43;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "KonuId";
            this.gridColumn1.FieldName = "KonuId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            this.gridColumn1.Width = 59;
            // 
            // cevapId
            // 
            this.cevapId.Caption = "CevapId";
            this.cevapId.FieldName = "Id";
            this.cevapId.Name = "cevapId";
            this.cevapId.Visible = true;
            this.cevapId.VisibleIndex = 10;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.repositoryItemMemoEdit2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(597, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(125, 23);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Yeni Konu Türü";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1048, 464);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KonuturuContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cevapEkleContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip KonuturuContext;
        private System.Windows.Forms.ToolStripMenuItem içYazışmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dışYazışmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parçaÜzerineToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnYeniKonu;
        private DevExpress.XtraEditors.SimpleButton btnListele;
        private DevExpress.XtraEditors.SimpleButton btnDüzenle;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Aktif;
        private DevExpress.XtraGrid.Columns.GridColumn Firma;
        private DevExpress.XtraGrid.Columns.GridColumn Konu;
        private DevExpress.XtraGrid.Columns.GridColumn Cevap;
        private DevExpress.XtraGrid.Columns.GridColumn Gorusen;
        private DevExpress.XtraGrid.Columns.GridColumn Gorusulen;
        private DevExpress.XtraGrid.Columns.GridColumn Tarih;
        private DevExpress.XtraGrid.Columns.GridColumn Tür;
        private DevExpress.XtraGrid.Columns.GridColumn StokAdı;
        private DevExpress.XtraGrid.Columns.GridColumn StokKodu;
        private DevExpress.XtraGrid.Columns.GridColumn StokAdet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.ContextMenuStrip cevapEkleContext;
        private System.Windows.Forms.ToolStripMenuItem cevapEkleToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn cevapId;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.SimpleButton btnAdmin;
        private DevExpress.XtraEditors.SimpleButton btnYazdır;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private System.Windows.Forms.ToolStripMenuItem ayrıntılarToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}

