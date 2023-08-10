using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRM.Data;
using CRM.Model;
using CRM.Properties;
using System.Data.SqlClient;
using CRM.Formlar;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRM
{
    public partial class Form1 : Form
    {

        CevikTeknikTestProjContext db = new CevikTeknikTestProjContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
            



        }
        public int Id;
        public int KonuId;
        public int KullanıcıId;



        private void btnYeniKonu_Click(object sender, EventArgs e)
        {
            //KonuturuContext.Show(Cursor.Position);
            FrmParca frm = new FrmParca();
            frm.KullanıcıId = KullanıcıId;
            frm.Show();

        }

        private void içYazışmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIcYazisma frm = new FrmIcYazisma();
            frm.Show();
        }

        private void dışYazışmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDisYazisma frm = new FrmDisYazisma();
            frm.Show();
        }

        private void parçaÜzerineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParca frm = new FrmParca();
            frm.Show();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        public void Listele()
        {
            var liste = from konu in db.Konulars
                        join cevap in db.Cevaplars on konu.KonuId equals cevap.KonuId into aa
                        from cevap in aa.DefaultIfEmpty()
                        join cari in db.Scaris on konu.CariId equals (int)cari.Crid into c
                        from cari in c.DefaultIfEmpty()
                        join kisi in db.Kullanıcılars on cevap.GorusenId equals kisi.Id into k
                        from kisi in k.DefaultIfEmpty()
                        join stok in db.Sstoks on konu.StokId equals (int)stok.Sstokid into s
                        from stok in s.DefaultIfEmpty()
                        join konuTur in db.KonuTurus on konu.TurId equals konuTur.Id into kt
                        from konuTur in kt.DefaultIfEmpty()


                        select new
                        {
                            Id = cevap.Id != null ? cevap.Id : 0,
                            konu.KonuId,
                            AktifPasif = konu.AktifPasif,/* = konu.AktifPasif == true ? "A" : "P"*/
                            cari.Crisim,
                            konu.Konu,
                            cevap.Cevap,
                            kisi.AdSoyad,
                            cevap.Gorusulen,
                            KonuTarihi = konu.Tarih,
                            cevap.Tarih,
                            konuTur.Ad,
                            stok.Stokadi,
                            stok.Stokkod,
                            stok.Stokadet

                        };

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string)); // column byl ekleniyor
            dt.Columns.Add("KonuId", typeof(int));
            dt.Columns.Add("AktifPasif", typeof(string));
            dt.Columns.Add("Crisim", typeof(string));
            dt.Columns.Add("Konu", typeof(string));
            dt.Columns.Add("Cevap", typeof(string));
            dt.Columns.Add("AdSoyad", typeof(string));
            dt.Columns.Add("Gorusulen", typeof(string));
            dt.Columns.Add("Tarih", typeof(string));
            dt.Columns.Add("Ad", typeof(string));
            dt.Columns.Add("Stokadi", typeof(string));
            dt.Columns.Add("Stokkod", typeof(string));
            dt.Columns.Add("Stokadet", typeof(string));




            // cevap yoksa "" algılatıcaz

            // burda cevap id 0 sa yazdırma dediğimiz için cevabı olmayanlar gelmedi
            foreach (var item in liste.OrderByDescending(x => x.Tarih).ToList())
            // 1den ... başlayıp gidince en altta 1 olucak şimdi

            {
                // once bakıyoruz konuya bağlı hiç cevap var mı konuya bağlı cevp varsa ve id 0 değilse yaz
                // konuya bağlı cevap yoksa ve id 0 sa yaz 

                if (db.Izinlers.FirstOrDefault(x => x.KonuId == item.KonuId && x.KullanıcıId == KullanıcıId && x.Durum == true) != null)
                {
                    if (db.Cevaplars.Where(x => x.KonuId == item.KonuId).Count() > 0 && item.Id != 0)
                    {
                        dt.Rows.Add(// 
                            item.Id
                            , item.KonuId
                            , item.AktifPasif == true ? "A" : "P"
                            , item.Crisim,
                            item.Konu
                            , item.Cevap
                            , item.AdSoyad
                            , item.Gorusulen
                            , item.Tarih
                            , item.Ad
                            , item.Stokadi
                            , item.Stokkod
                            , item.Stokadet
                            );
                    }
                    else if (db.Cevaplars.Where(x => x.KonuId == item.KonuId).Count() == 0 && item.Id == 0)
                    {
                        dt.Rows.Add(// 
                         ""
                          , item.KonuId

                          , item.AktifPasif == true ? "A" : "P"
                          , item.Crisim
                          , item.Konu
                          //, item.Cevap
                          , item.AdSoyad
                          , item.Gorusulen
                          , item.Tarih
                          , item.Ad
                          , item.Stokadi
                          , item.Stokkod
                          , item.Stokadet
                          , ""
                          );

                    }
                }
                else
                {

                }


            }


            gridControl1.DataSource = dt; 

        }

        public void Listele2()
        {
            var liste = from konu in db.Konulars
                        join cevap in db.Cevaplars on konu.KonuId equals cevap.KonuId into aa
                        from cevap in aa.DefaultIfEmpty()    
                        join cari in db.Scaris on konu.CariId equals (int)cari.Crid into c
                        from cari in c.DefaultIfEmpty()
                        join kisi in db.Kullanıcılars on cevap.GorusenId equals kisi.Id into k
                        from kisi in k.DefaultIfEmpty()
                        join stok in db.Sstoks on konu.StokId equals (int)stok.Sstokid into s
                        from stok in s.DefaultIfEmpty()
                        join konuTur in db.KonuTurus on konu.TurId equals konuTur.Id into kt
                        from konuTur in kt.DefaultIfEmpty()

                        select new
                        {
                            Id = cevap.Id != null ? cevap.Id : 0,
                            konu.KonuId,
                            AktifPasif = konu.AktifPasif,/* = konu.AktifPasif == true ? "A" : "P"*/
                            cari.Crisim,
                            konu.Konu,
                            cevap.Cevap,
                            kisi.AdSoyad,
                            cevap.Gorusulen,
                            KonuTarihi = konu.Tarih,
                            cevap.Tarih,
                            konuTur.Ad,
                            stok.Stokadi,
                            stok.Stokkod,
                            stok.Stokadet

                        };
            

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string)); // column byl ekleniyor
            dt.Columns.Add("KonuId", typeof(int));
            dt.Columns.Add("AktifPasif", typeof(string));
            dt.Columns.Add("Crisim", typeof(string));
            dt.Columns.Add("Konu", typeof(string));
            dt.Columns.Add("Cevap", typeof(string));
            dt.Columns.Add("AdSoyad", typeof(string));
            dt.Columns.Add("Gorusulen", typeof(string));
            dt.Columns.Add("Tarih", typeof(string));
            dt.Columns.Add("Ad", typeof(string));
            dt.Columns.Add("Stokadi", typeof(string));
            dt.Columns.Add("Stokkod", typeof(string));
            dt.Columns.Add("Stokadet", typeof(string));




            // cevap yoksa "" algılatıcaz

            // burda cevap id 0 sa yazdırma dediğimiz için cevabı olmayanlar gelmedi
            foreach (var item in liste.OrderByDescending(x => x.Tarih).ToList())
            // 1den ... başlayıp gidince en altta 1 olucak şimdi

            {
                // once bakıyoruz konuya bağlı hiç cevap var mı konuya bağlı cevp varsa ve id 0 değilse yaz
                // konuya bağlı cevap yoksa ve id 0 sa yaz 



                if (db.Cevaplars.Where(x => x.KonuId == item.KonuId).Count() > 0 && item.Id != 0)
                {
                    dt.Rows.Add(// 
                        item.Id
                        , item.KonuId
                        , item.AktifPasif == true ? "A" : "P"
                        , item.Crisim,
                        item.Konu
                        , item.Cevap
                        , item.AdSoyad
                        , item.Gorusulen
                        , item.Tarih
                        , item.Ad
                        , item.Stokadi
                        , item.Stokkod
                        , item.Stokadet
                        );
                }
                else if (db.Cevaplars.Where(x => x.KonuId == item.KonuId).Count() == 0 && item.Id == 0)
                {
                    dt.Rows.Add(// 
                     ""
                      , item.KonuId

                      , item.AktifPasif == true ? "A" : "P"
                      , item.Crisim
                      , item.Konu
                      //, item.Cevap
                      , item.AdSoyad
                      , item.Gorusulen
                      , item.Tarih
                      , item.Ad
                      , item.Stokadi
                      , item.Stokkod
                      , item.Stokadet
                      , ""
                      );

                }
            }


            gridControl1.DataSource = dt; 
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnDüzenle_Click(object sender, EventArgs e)
        {

            try
            {
                var secilenKonu = gridView1.GetGroupRowValue(gridView1.FocusedRowHandle);
                var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu.ToString());
                if (secilenKonu.ToString() == null || konu == null )
                {
                    MessageBox.Show("Lütfen Konu Seçin");

                }

                var secilenCevap = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");

                if (secilenCevap == null )
                {
                    var konuId = db.Konulars.Where(k => k.KonuId == konu.KonuId).Select(k => k.KonuId).FirstOrDefault();
                    FrmParca frp = new FrmParca();
                    frp.KonuId = konuId;
                    frp.ShowDialog();
                    
                }
                else
                {
                    var konuId = db.Konulars.Where(k => k.KonuId == konu.KonuId).Select(k => k.KonuId).FirstOrDefault();
                    var cari = db.Scaris.Where(x => x.Crid == konu.CariId).Select(x => x.Crisim).FirstOrDefault();
                    var cevapId = db.Cevaplars.Where(k => k.KonuId == konu.KonuId).Select(k => k.Id).FirstOrDefault();
                    FrmCevap frc = new FrmCevap();
                    frc.Id = cevapId;
                    frc.KonuId = konuId;
                    frc.txtbxKonu.Text = secilenKonu.ToString();
                    frc.txtbxCari.Text = cari.ToString();
                    frc.txtbxCevap.Text = secilenCevap.ToString();
                    var goruntuleyenler = from izintbl in db.Izinlers
                                          join users in db.Kullanıcılars on izintbl.KullanıcıId equals users.Id into kullanıcı
                                          from users in kullanıcı.DefaultIfEmpty()
                                          where izintbl.KonuId == konu.KonuId
                                          select new
                                          {
                                              users.AdSoyad,
                                              izintbl.Durum

                                          };
                    foreach (var item in goruntuleyenler.ToList())
                    {
                        if (item.Durum == true)
                        {
                            frc.lstbxGoruntuleyenler.Items.Add(item.AdSoyad);
                        }

                    }
                    frc.ShowDialog();
                }
   

            }
            catch
            {


            }


        }


        private void cevapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var secilen = gridView1.GetGroupRowValue(gridView1.FocusedRowHandle);
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilen.ToString());
            if (konu!=null)
            {
                FrmCevap frmcevap = new FrmCevap();
                frmcevap.KullanıcıId = KullanıcıId;
                FrmParca frmprc = new FrmParca();
                frmcevap.KonuId = konu.KonuId;
                var cari = db.Scaris.Where(i => i.Crid == konu.CariId).Select(i => i.Crisim).FirstOrDefault();
                var cevap = db.Cevaplars.FirstOrDefault(x => x.Cevap == secilen.ToString());
                frmcevap.txtbxCari.Text = cari;
                frmcevap.txtbxKonu.Text = konu.Konu;
                var goruntuleyenler = from izintbl in db.Izinlers
                                      join users in db.Kullanıcılars on izintbl.KullanıcıId equals users.Id into kullanıcı
                                      from users in kullanıcı.DefaultIfEmpty()
                                      where izintbl.KonuId == konu.KonuId
                                      select new
                                      {
                                          users.AdSoyad,
                                          izintbl.Durum

                                      };
                foreach (var item in goruntuleyenler.ToList())
                {
                    if (item.Durum == true)
                    {
                        frmcevap.lstbxGoruntuleyenler.Items.Add(item.AdSoyad);
                    }

                }
                frmcevap.Show();
            }

            else
            {
                MessageBox.Show("Lütfen Konu Seçiniz");
            }
           

        }


        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var secilenKonu = gridView1.GetGroupRowValue(gridView1.FocusedRowHandle);
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu.ToString());
            var secilenCevap = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");
            if (secilenKonu.ToString() == null || konu == null)
            {
                MessageBox.Show("Lütfen Konu Seçin");

            }
            else if(secilenCevap==null)
            {
                DialogResult cevap1 = MessageBox.Show("Bu Konuyu ve konuya ait tüm cevapları silmek istediğinize eminmisiniz ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap1 == DialogResult.Yes)
                {
                    try
                    {
                        var konuId = db.Konulars.Where(k => k.KonuId == konu.KonuId).Select(k => k.KonuId).FirstOrDefault();
                        db.Database.ExecuteSqlRaw($"delete from Cevaplar where KonuId={konuId}");
                        db.Database.ExecuteSqlRaw($"delete from Konular where KonuID={konuId}");
                        Form1 frm = (Form1)Application.OpenForms["Form1"];
                        frm.Listele();
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                DialogResult cevap1 = MessageBox.Show("Seçili cevapı silmek istediğinize eminmisiniz ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap1 == DialogResult.Yes)
                {
                    var cevapId = db.Cevaplars.Where(k => k.KonuId == konu.KonuId).Select(k => k.Id).FirstOrDefault();
                    db.Database.ExecuteSqlRaw($"delete from Cevaplar where Id={cevapId}");
                    Form1 frm = (Form1)Application.OpenForms["Form1"];
                    frm.Listele();
                }
                else
                {

                }
            }
            

           

        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmKonuIzin frizin = new frmKonuIzin();
            frizin.ShowDialog();

        }

        private void gridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private void btnYazdır_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Crm listesini Pdf olarak aktarmak istediğinizden emin misiniz?", "Pdfe Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (cevap == DialogResult.Yes)
            {
                string path = "StokListesi" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".pdf";
                gridView1.ExportToPdf(path);
                Process process = new Process();
                process.StartInfo.FileName = path;
                process.StartInfo.UseShellExecute = true;
                process.Start();

            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ayrıntılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                var secilenKonu = gridView1.GetGroupRowValue(gridView1.FocusedRowHandle);
                var secilenCevap = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");
                var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu.ToString());
                if (konu!=null)
                {
                    FrmAyrıntılar frmAyrıntılar = new FrmAyrıntılar();
                    if (secilenCevap == null)
                    {
                        frmAyrıntılar.secilenKonu = secilenKonu.ToString();
                        frmAyrıntılar.KullanıcıId = KullanıcıId;
                        //frmAyrıntılar.secilenCevap = secilenIlkCevap.Cevap;
                        //frmAyrıntılar.cevapId = scıd;
                        frmAyrıntılar.ShowDialog();
                    }
                    else
                    {
                        frmAyrıntılar.secilenKonu = secilenKonu.ToString();
                        frmAyrıntılar.secilenCevap = secilenCevap.ToString();
                        frmAyrıntılar.KullanıcıId = KullanıcıId;
                        frmAyrıntılar.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Konu Seçiniz");
                }
                //var secilenIlkCevap = (db.Cevaplars.Where(x => x.KonuId == konu.KonuId).OrderBy(x => x.Id).FirstOrDefault());
                //int scıd = secilenIlkCevap.Id;
                
         
            
            
            

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            //YeniKonutur

            frmYeniKonuTur tur = new frmYeniKonuTur();
            tur.ShowDialog();
        }
    }
}
