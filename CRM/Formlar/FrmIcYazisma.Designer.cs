
namespace CRM
{
    partial class FrmIcYazisma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIcYazisma));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstbxGoruntuleyenler = new DevExpress.XtraEditors.ListBoxControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vazgeçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.lpGoruntuleyenler = new DevExpress.XtraEditors.LookUpEdit();
            this.lpFirmaKod = new DevExpress.XtraEditors.LookUpEdit();
            this.lpFirmaAd = new DevExpress.XtraEditors.LookUpEdit();
            this.lpKullanıcılar = new DevExpress.XtraEditors.LookUpEdit();
            this.txtbxKonu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lstbxGoruntuleyenler)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lpGoruntuleyenler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lpFirmaKod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lpFirmaAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lpKullanıcılar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(298, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Firma Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(60, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Firma Kodu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(60, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kulanıcılar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(298, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Görüntüleyenler";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(60, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tarih";
            // 
            // lstbxGoruntuleyenler
            // 
            this.lstbxGoruntuleyenler.ContextMenuStrip = this.contextMenuStrip1;
            this.lstbxGoruntuleyenler.HorizontalScrollbar = true;
            this.lstbxGoruntuleyenler.Location = new System.Drawing.Point(298, 184);
            this.lstbxGoruntuleyenler.Name = "lstbxGoruntuleyenler";
            this.lstbxGoruntuleyenler.Size = new System.Drawing.Size(242, 66);
            this.lstbxGoruntuleyenler.TabIndex = 8;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silToolStripMenuItem,
            this.vazgeçToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 48);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // vazgeçToolStripMenuItem
            // 
            this.vazgeçToolStripMenuItem.Name = "vazgeçToolStripMenuItem";
            this.vazgeçToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.vazgeçToolStripMenuItem.Text = "Vazgeç";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(60, 227);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(172, 23);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(344, 344);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(95, 24);
            this.btnKaydet.TabIndex = 13;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVazgec.Appearance.Options.UseFont = true;
            this.btnVazgec.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVazgec.ImageOptions.Image")));
            this.btnVazgec.Location = new System.Drawing.Point(445, 344);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(95, 24);
            this.btnVazgec.TabIndex = 14;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // lpGoruntuleyenler
            // 
            this.lpGoruntuleyenler.Location = new System.Drawing.Point(298, 148);
            this.lpGoruntuleyenler.Name = "lpGoruntuleyenler";
            this.lpGoruntuleyenler.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lpGoruntuleyenler.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdSoyad", "Kişi Seçiniz")});
            this.lpGoruntuleyenler.Properties.NullText = "";
            this.lpGoruntuleyenler.Properties.EditValueChanged += new System.EventHandler(this.lpGoruntuleyenler_Properties_EditValueChanged);
            this.lpGoruntuleyenler.Size = new System.Drawing.Size(242, 20);
            this.lpGoruntuleyenler.TabIndex = 18;
            // 
            // lpFirmaKod
            // 
            this.lpFirmaKod.Location = new System.Drawing.Point(60, 74);
            this.lpFirmaKod.Name = "lpFirmaKod";
            this.lpFirmaKod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lpFirmaKod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Crid", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Crkod", "Firma Kodu Seçiniz")});
            this.lpFirmaKod.Properties.NullText = "";
            this.lpFirmaKod.Size = new System.Drawing.Size(172, 20);
            this.lpFirmaKod.TabIndex = 19;
            this.lpFirmaKod.EditValueChanged += new System.EventHandler(this.lpFirmaKod_EditValueChanged);
            // 
            // lpFirmaAd
            // 
            this.lpFirmaAd.Location = new System.Drawing.Point(298, 74);
            this.lpFirmaAd.Name = "lpFirmaAd";
            this.lpFirmaAd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lpFirmaAd.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Crid", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Crisim", "Firma Adı Seçiniz")});
            this.lpFirmaAd.Properties.NullText = "";
            this.lpFirmaAd.Size = new System.Drawing.Size(242, 20);
            this.lpFirmaAd.TabIndex = 20;
            this.lpFirmaAd.EditValueChanged += new System.EventHandler(this.lpFirmaAd_EditValueChanged);
            // 
            // lpKullanıcılar
            // 
            this.lpKullanıcılar.Location = new System.Drawing.Point(60, 148);
            this.lpKullanıcılar.Name = "lpKullanıcılar";
            this.lpKullanıcılar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lpKullanıcılar.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdSoyad", "Kişi Seçiniz")});
            this.lpKullanıcılar.Properties.NullText = "";
            this.lpKullanıcılar.Size = new System.Drawing.Size(172, 20);
            this.lpKullanıcılar.TabIndex = 21;
            // 
            // txtbxKonu
            // 
            this.txtbxKonu.Location = new System.Drawing.Point(60, 298);
            this.txtbxKonu.Multiline = true;
            this.txtbxKonu.Name = "txtbxKonu";
            this.txtbxKonu.Size = new System.Drawing.Size(481, 29);
            this.txtbxKonu.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(60, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Konu";
            // 
            // FrmIcYazisma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 405);
            this.Controls.Add(this.lpKullanıcılar);
            this.Controls.Add(this.lpFirmaAd);
            this.Controls.Add(this.lpFirmaKod);
            this.Controls.Add(this.lpGoruntuleyenler);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtbxKonu);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lstbxGoruntuleyenler);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmIcYazisma";
            this.Text = "FrmIcYazisma";
            this.Load += new System.EventHandler(this.FrmIcYazisma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstbxGoruntuleyenler)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lpGoruntuleyenler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lpFirmaKod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lpFirmaAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lpKullanıcılar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.ListBoxControl lstbxGoruntuleyenler;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.LookUpEdit lpGoruntuleyenler;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vazgeçToolStripMenuItem;
        private DevExpress.XtraEditors.LookUpEdit lpFirmaKod;
        private DevExpress.XtraEditors.LookUpEdit lpKullanıcılar;
        public DevExpress.XtraEditors.LookUpEdit lpFirmaAd;
        public System.Windows.Forms.TextBox txtbxKonu;
        private System.Windows.Forms.Label label7;
    }
}