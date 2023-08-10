
namespace CRM.Formlar
{
    partial class frmKonuIzin
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
            this.lpKullanıcı = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rBTumu = new System.Windows.Forms.RadioButton();
            this.rBbelirsiz = new System.Windows.Forms.RadioButton();
            this.rBIzinsiz = new System.Windows.Forms.RadioButton();
            this.rBIzinli = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmsIzin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.izinVerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinKaldırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Konu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AdSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Durum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KonuID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.İzinli = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lpKullanıcı.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsIzin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lpKullanıcı
            // 
            this.lpKullanıcı.Location = new System.Drawing.Point(15, 33);
            this.lpKullanıcı.Name = "lpKullanıcı";
            this.lpKullanıcı.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lpKullanıcı.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdSoyad", "Seçiniz...")});
            this.lpKullanıcı.Properties.NullText = "Kullanıcı Seçiniz...";
            this.lpKullanıcı.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lpKullanıcı.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.lpKullanıcı.Size = new System.Drawing.Size(221, 20);
            this.lpKullanıcı.TabIndex = 0;
            this.lpKullanıcı.EditValueChanged += new System.EventHandler(this.lpKullanıcı_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rBTumu);
            this.panel1.Controls.Add(this.rBbelirsiz);
            this.panel1.Controls.Add(this.rBIzinsiz);
            this.panel1.Controls.Add(this.rBIzinli);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lpKullanıcı);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 77);
            this.panel1.TabIndex = 4;
            // 
            // rBTumu
            // 
            this.rBTumu.AutoSize = true;
            this.rBTumu.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.rBTumu.Location = new System.Drawing.Point(286, 29);
            this.rBTumu.Name = "rBTumu";
            this.rBTumu.Size = new System.Drawing.Size(66, 24);
            this.rBTumu.TabIndex = 4;
            this.rBTumu.TabStop = true;
            this.rBTumu.Text = "Tümü";
            this.rBTumu.UseVisualStyleBackColor = true;
            this.rBTumu.CheckedChanged += new System.EventHandler(this.rBTumu_CheckedChanged);
            // 
            // rBbelirsiz
            // 
            this.rBbelirsiz.AutoSize = true;
            this.rBbelirsiz.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.rBbelirsiz.Location = new System.Drawing.Point(595, 29);
            this.rBbelirsiz.Name = "rBbelirsiz";
            this.rBbelirsiz.Size = new System.Drawing.Size(75, 24);
            this.rBbelirsiz.TabIndex = 3;
            this.rBbelirsiz.TabStop = true;
            this.rBbelirsiz.Text = "Belirsiz";
            this.rBbelirsiz.UseVisualStyleBackColor = true;
            this.rBbelirsiz.CheckedChanged += new System.EventHandler(this.rBbelirsiz_CheckedChanged);
            // 
            // rBIzinsiz
            // 
            this.rBIzinsiz.AutoSize = true;
            this.rBIzinsiz.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.rBIzinsiz.Location = new System.Drawing.Point(488, 29);
            this.rBIzinsiz.Name = "rBIzinsiz";
            this.rBIzinsiz.Size = new System.Drawing.Size(68, 24);
            this.rBIzinsiz.TabIndex = 3;
            this.rBIzinsiz.TabStop = true;
            this.rBIzinsiz.Text = "İzinsiz";
            this.rBIzinsiz.UseVisualStyleBackColor = true;
            this.rBIzinsiz.CheckedChanged += new System.EventHandler(this.rBIzinsiz_CheckedChanged);
            // 
            // rBIzinli
            // 
            this.rBIzinli.AutoSize = true;
            this.rBIzinli.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.rBIzinli.Location = new System.Drawing.Point(387, 29);
            this.rBIzinli.Name = "rBIzinli";
            this.rBIzinli.Size = new System.Drawing.Size(59, 24);
            this.rBIzinli.TabIndex = 3;
            this.rBIzinli.TabStop = true;
            this.rBIzinli.Text = "İzinli";
            this.rBIzinli.UseVisualStyleBackColor = true;
            this.rBIzinli.CheckedChanged += new System.EventHandler(this.rBIzinli_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1131, 446);
            this.panel2.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmsIzin;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1131, 446);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsIzin
            // 
            this.cmsIzin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izinVerToolStripMenuItem,
            this.izinKaldırToolStripMenuItem});
            this.cmsIzin.Name = "cmsIzin";
            this.cmsIzin.Size = new System.Drawing.Size(126, 48);
            // 
            // izinVerToolStripMenuItem
            // 
            this.izinVerToolStripMenuItem.Name = "izinVerToolStripMenuItem";
            this.izinVerToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.izinVerToolStripMenuItem.Text = "İzin ver";
            this.izinVerToolStripMenuItem.Click += new System.EventHandler(this.izinVerToolStripMenuItem_Click);
            // 
            // izinKaldırToolStripMenuItem
            // 
            this.izinKaldırToolStripMenuItem.Name = "izinKaldırToolStripMenuItem";
            this.izinKaldırToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.izinKaldırToolStripMenuItem.Text = "İzin Kaldır";
            this.izinKaldırToolStripMenuItem.Click += new System.EventHandler(this.izinKaldırToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Konu,
            this.AdSoyad,
            this.Durum,
            this.KonuID,
            this.İzinli});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // Konu
            // 
            this.Konu.Caption = "Konu";
            this.Konu.FieldName = "Konu";
            this.Konu.Name = "Konu";
            this.Konu.Visible = true;
            this.Konu.VisibleIndex = 0;
            // 
            // AdSoyad
            // 
            this.AdSoyad.Caption = "Ad Soyad";
            this.AdSoyad.FieldName = "AdSoyad";
            this.AdSoyad.Name = "AdSoyad";
            this.AdSoyad.Visible = true;
            this.AdSoyad.VisibleIndex = 1;
            // 
            // Durum
            // 
            this.Durum.Caption = "Durum";
            this.Durum.FieldName = "Durum";
            this.Durum.Name = "Durum";
            this.Durum.Visible = true;
            this.Durum.VisibleIndex = 2;
            // 
            // KonuID
            // 
            this.KonuID.Caption = "KonuId";
            this.KonuID.FieldName = "KonuId";
            this.KonuID.Name = "KonuID";
            // 
            // İzinli
            // 
            this.İzinli.Caption = "KullanıcıId";
            this.İzinli.FieldName = "KullanıcıId";
            this.İzinli.Name = "İzinli";
            // 
            // frmKonuIzin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 523);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmKonuIzin";
            this.Text = "frmKonuIzin";
            this.Load += new System.EventHandler(this.frmKonuIzin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lpKullanıcı.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsIzin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lpKullanıcı;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Konu;
        private DevExpress.XtraGrid.Columns.GridColumn AdSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn Durum;
        private System.Windows.Forms.ContextMenuStrip cmsIzin;
        private System.Windows.Forms.ToolStripMenuItem izinVerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinKaldırToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn KonuID;
        private DevExpress.XtraGrid.Columns.GridColumn İzinli;
        private System.Windows.Forms.RadioButton rBIzinli;
        private System.Windows.Forms.RadioButton rBbelirsiz;
        private System.Windows.Forms.RadioButton rBIzinsiz;
        private System.Windows.Forms.RadioButton rBTumu;
    }
}