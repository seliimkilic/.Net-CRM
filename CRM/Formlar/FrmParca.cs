using CRM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRM.Model;
using System.IO;
using CRM.Formlar;
using Microsoft.EntityFrameworkCore;

namespace CRM
{

    public partial class FrmParca : Form
    {
        CevikTeknikTestProjContext db = new CevikTeknikTestProjContext();
        public int KonuId;
        public int KullanıcıId;
        public int rowIndex;
        public string path;
        public FrmParca()
        {

            InitializeComponent();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {


            if (txtbxKonu.Text == "")
            {
                MessageBox.Show("Lütfen Konu Girişi Yapınız.");
            }
            else
            {
                Form1 fr = new Form1();

                //FrmParca frmp = (FrmParca)Application.OpenForms["FrmParca"];
                fr.KonuId = KonuId;



                if (KonuId != 0)
                {
                    var konu = db.Konulars.FirstOrDefault(x => x.KonuId == KonuId);
                    konu.Konu = txtbxKonu.Text;
                    konu.Tarih = dateTimePicker1.Value;
                    konu.StokId = lpStokAd.EditValue != null ? (double)lpStokAd.EditValue : 0;
                    konu.CariId = lpFirmaAd.EditValue != null ? (int)lpFirmaAd.EditValue : 0;
                    konu.TurId = lpKonuTur.EditValue != null ? (int)lpKonuTur.EditValue : 0;
                    konu.KullanıcıId = KullanıcıId;
                    konu.AktifPasif = true;
                    db.SaveChanges();

                    var goruntuleyenler = from izintbl in db.Izinlers
                                          join users in db.Kullanıcılars on izintbl.KullanıcıId equals users.Id into kullanıcı
                                          from users in kullanıcı.DefaultIfEmpty()
                                          where izintbl.KonuId == konu.KonuId && izintbl.Durum==true
                                          select new
                                          {
                                              users.AdSoyad,
                                              izintbl.Durum

                                          };


                    var list = goruntuleyenler.Select(x=>x.AdSoyad).ToList();

                    List<string> izinliListesi = new List<string>();

                    foreach (var item in lstbxGoruntuleyenler.Items)
                    {
                        izinliListesi.Add(item.ToString());
                    }




                    var TumKullanıcılar = db.Kullanıcılars.ToList();
                    //foreach (var user in TumKullanıcılar)
                    //{
                    //    foreach (var izinli in izinliListesi)
                    //    {
                    //        var kisiId = db.Kullanıcılars.FirstOrDefault(x => x.AdSoyad == izinli).Id;
                    //        var durumt = db.Izinlers.FirstOrDefault(x => x.KonuId == KonuId && x.KullanıcıId == kisiId && x.Durum == true);
                    //        var durumf = db.Izinlers.FirstOrDefault(x => x.KonuId == KonuId && x.KullanıcıId == kisiId && x.Durum == false);
                    //        if (durumt == null && durumf == null)
                    //        {
                    //            //veritabanına yeni giriş 
                    //        }

                    //        else if (durumt != null)
                    //        {
                    //            //işlem yok
                    //        }

                    //        else if (durumf != null)
                    //        {
                    //            //durum trueya çevrilecek
                    //        }

                    //        else
                    //        {

                    //        }

                    //    }
                    //    //var izinsizId = db.Kullanıcılars.FirstOrDefault(x => x.AdSoyad == user.AdSoyad).Id;
                    //    //var iznikaldırılan = db.Izinlers.FirstOrDefault(x => x.KonuId == KonuId && x.KullanıcıId == izinsizId );
                    //    //if (iznikaldırılan != null)
                    //    //{
                    //    //    //durumu false
                    //    //}
                    //}

                    List<string> farkliElemanlar = list.Except(izinliListesi).ToList();
                    farkliElemanlar.AddRange(izinliListesi.Except(list));
                    //Console.WriteLine("Farklı Elemanlar: ");
                    foreach (string eleman in farkliElemanlar)
                    {
                        var kisiId = db.Kullanıcılars.FirstOrDefault(x => x.AdSoyad == eleman).Id;
                        var durumt = db.Izinlers.FirstOrDefault(x => x.KonuId == KonuId && x.KullanıcıId == kisiId && x.Durum == true);
                        var durumf = db.Izinlers.FirstOrDefault(x => x.KonuId == KonuId && x.KullanıcıId == kisiId && x.Durum == false);
                        if (durumt == null && durumf == null)
                        {
                            //veritabanına yeni giriş 
                            var kullanıcıId = db.Kullanıcılars.Where(k => k.AdSoyad == eleman).Select(k => k.Id).FirstOrDefault();
                            var kullanıcıRolId = db.Kullanıcılars.Where(k => k.AdSoyad == eleman).Select(k => k.RolId).FirstOrDefault();
                            Izinler kullanıcıizin = new Izinler();
                            kullanıcıizin.KullanıcıId = kullanıcıId;
                            kullanıcıizin.KonuId = KonuId;
                            kullanıcıizin.RolId = kullanıcıRolId;
                            kullanıcıizin.Durum = true;
                            db.Izinlers.Add(kullanıcıizin);
                            db.SaveChanges();

                        }

                        else if (durumt != null)
                        {
                            //false a çevir
                            var izinsiz = db.Izinlers.FirstOrDefault(x => x.KonuId == KonuId && x.KullanıcıId == kisiId && x.Durum == true);
                            izinsiz.Durum = false;
                            db.SaveChanges();

                        }

                        else if (durumf != null)
                        {
                            var izinli = db.Izinlers.FirstOrDefault(x => x.KonuId == KonuId && x.KullanıcıId == kisiId && x.Durum == false);
                            izinli.Durum = true;
                            db.SaveChanges();
                            //durum trueya çevrilecek
                        }

                        else
                        {

                        }
                    }



                    this.Hide();
                    //Form1 frm = (Form1)Application.OpenForms["Form1"];
                    //frm.Listele();
                }
                else
                {
                    KonuKaydet();
                }

            }



        }


        public void KonuKaydet()
        {
            // Konu Ekle
            Konular konuEkle = new Konular();
            string KonuMetni = $"{txtbxKonu.Text} ({Convert.ToDateTime(dateTimePicker1.Value.ToString())}) ";
            konuEkle.Konu = KonuMetni;
            konuEkle.Tarih = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            konuEkle.StokId = lpStokAd.EditValue != null ? (double)lpStokAd.EditValue : 0;
            konuEkle.CariId = lpFirmaAd.EditValue != null ? (int)lpFirmaAd.EditValue : 0;
            konuEkle.TurId = lpKonuTur.EditValue != null ? (int)lpKonuTur.EditValue : 0;
            konuEkle.KullanıcıId = KullanıcıId;
            konuEkle.AktifPasif = true;
            db.Konulars.Add(konuEkle);
            db.SaveChanges();



            //izin

            FrmCevap frmc = new FrmCevap();
            var kullanıcı = db.Kullanıcılars.Where(k => k.Id == KullanıcıId).Select(k => k.AdSoyad).FirstOrDefault();
            var kullanıcıRolId = db.Kullanıcılars.Where(k => k.Id == KullanıcıId).Select(k => k.RolId).FirstOrDefault();
            frmc.lstbxGoruntuleyenler.Items.Add(kullanıcı);
            Izinler kullanıcıizin = new Izinler();
            kullanıcıizin.KullanıcıId = KullanıcıId;
            kullanıcıizin.KonuId = konuEkle.KonuId;
            kullanıcıizin.RolId = kullanıcıRolId;
            kullanıcıizin.Durum = true;
            db.Izinlers.Add(kullanıcıizin);
            db.SaveChanges();
            var kullanıcılar = db.Kullanıcılars.ToList();
            var izinliler = lstbxGoruntuleyenler.Items.Cast<string>().ToList();

            //var izinsizId = db.Kullanıcılars.Where(i => i.AdSoyad == user.AdSoyad).Select(i => i.Id).FirstOrDefault();
            //var izinsizRolId = db.Kullanıcılars.Where(i => i.AdSoyad == user.AdSoyad).Select(i => i.RolId).FirstOrDefault();
            //Izinler izinsiz = new Izinler();
            //izinsiz.KullanıcıId = izinsizId;
            //izinsiz.RolId = izinsizRolId;
            //izinsiz.KonuId = konuEkle.KonuId;
            //izinsiz.Durum = false;
            //db.Izinlers.Add(izinsiz);
            //db.SaveChanges();




            //var izinliler = lstbxGoruntuleyenler.Items.Cast<string>().ToList();

            //izinler
            foreach (var veri in izinliler)
            {
                if (veri != kullanıcı)
                {
                    //var secilen = db.Kullanıcılars.FirstOrDefault(i => i.AdSoyad == veri);
                    var izinliId = db.Kullanıcılars.Where(i => i.AdSoyad == veri).Select(i => i.Id).FirstOrDefault();
                    var izinliRolId = db.Kullanıcılars.Where(i => i.AdSoyad == veri).Select(i => i.RolId).FirstOrDefault();
                    Izinler izin = new Izinler();
                    izin.KullanıcıId = izinliId;
                    izin.RolId = izinliRolId;
                    izin.KonuId = konuEkle.KonuId;
                    izin.Durum = true;
                    db.Izinlers.Add(izin);
                    db.SaveChanges();
                    frmc.lstbxGoruntuleyenler.Items.Add(veri);
                }
            }

            //ResimEkle

            if (pbResim1.Image != null)
            {
                resimKaydet(pbResim1, "1");

            }
            else
            {

            }
            if (pbResim2.Image != null)
            {
                resimKaydet(pbResim2, "2");
            }
            else
            {

            }
            if (pbResim3.Image != null)
            {
                resimKaydet(pbResim3, "3");
            }
            else
            {

            }
            if (pbResim4.Image != null)
            {
                resimKaydet(pbResim4, "4");
            }
            else
            {

            }

            //List<string> Belgeler = new List<string>();

            //foreach (DataGridViewRow row in dtgBelge.Rows)
            //{
            //    if (!row.IsNewRow)
            //    {
            //        DataGridViewCell veri = row.Cells[1]; // İlgili sütunun indeksini belirtin

            //        if (veri.Value != null)
            //        {
            //            string belge = veri.Value.ToString();
            //            Belgeler.Add(belge);
            //        }
            //    }
            //}

            

            foreach (DataGridViewRow row in dtgBelge.Rows)
            {
                if (!row.IsNewRow)
                {
                    int rowindex = row.Index;
                    DataGridViewCell veri = row.Cells[2]; // İlgili sütunun indeksini belirtin
                    if (veri.Value != null)
                    {

                        Resimler belgeEkle = new Resimler();
                        belgeEkle.KonuId = konuEkle.KonuId;
                        belgeEkle.ImageName = row.Cells[1].Value.ToString();
                        belgeEkle.StId = lpStokAd.EditValue != null ? (double)lpStokAd.EditValue : 0; ;
                        belgeEkle.ImageUrl = veri.Value.ToString();
                        belgeEkle.Tipi = $"kb{rowindex + 1}";
                        db.Resimlers.Add(belgeEkle);
                        db.SaveChanges();

                    }
                }
            }




            if (txtbxKonu.Text.Length <= 15)
            {
                DialogResult cevap1 = MessageBox.Show($"Bu konu ({txtbxKonu.Text}) için cevap eklemek istermisiniz ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap1 == DialogResult.Yes)
                {

                    frmc.txtbxKonu.Text = KonuMetni;
                    double cariId = (int)lpFirmaAd.EditValue;
                    var firm = db.Scaris.FirstOrDefault(f => f.Crid == cariId);
                    frmc.txtbxCari.Text = firm.Crisim;
                    frmc.KullanıcıId = KullanıcıId;
                    this.Hide();
                    frmc.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Konu Kaydedildi");
                    this.Close();
                    Form1 frm = (Form1)Application.OpenForms["Form1"];
                    frm.Listele();
                }
            }
            else if (txtbxKonu.Text.Length > 15)
            {
                DialogResult cevap1 = MessageBox.Show($"Bu konu ({txtbxKonu.Text.Substring(0, 15)}...) için cevap eklemek istermisiniz ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap1 == DialogResult.Yes)
                {

                    frmc.txtbxKonu.Text = KonuMetni;
                    double cariId = (int)lpFirmaAd.EditValue;
                    var firm = db.Scaris.FirstOrDefault(f => f.Crid == cariId);
                    frmc.txtbxCari.Text = firm.Crisim;
                    frmc.KullanıcıId = KullanıcıId;
                    this.Hide();
                    frmc.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Konu Kaydedildi");
                    this.Close();
                    Form1 frm = (Form1)Application.OpenForms["Form1"];
                    frm.Listele();
                }
            }
        }



        private void FrmParca_Load(object sender, EventArgs e)
        {

            lpDoldur();
            KullanıcıDoldur();
            combo();
            try
            {
                if (KonuId > 0)
                {

                    FormuDoldur();
                }
                else
                {
                    //KonuKaydet();
                }

            }
            catch
            {


            }
        }
        
        public void FormuDoldur()
        {
            try
            {
                var konu = db.Konulars.FirstOrDefault(x => x.KonuId == KonuId);
                if (konu != null)
                {
                    lpKonuTur.EditValue = konu.TurId;
                    dateTimePicker1.Value = konu.Tarih.Value;
                    //lpFirmaAd.EditValue = konu.CariId;
                    //lpStokAd.EditValue = konu.StokId;
                    lpFirmaAd.EditValue = (int)konu.CariId;
                    lpStokAd.EditValue = (double)konu.StokId;
                    txtbxKonu.Text = konu.Konu;
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
                            lstbxGoruntuleyenler.Items.Add(item.AdSoyad);
                        }

                    }



                }
            }
            catch
            {


            }
        }
        private void lpKonuTur_EditValueChanged(object sender, EventArgs e)
        {

        }

        public void lpDoldur()
        {

            lpKonuTur.Properties.DataSource = db.KonuTurus.Where(x=>x.Aktif==true).ToList();
            lpKonuTur.Properties.DisplayMember = "Ad";
            lpKonuTur.Properties.ValueMember = "Id";
            lpKonuTur.ItemIndex = -1;

            lpFirmaKod.Properties.DataSource = db.Scaris.ToList();
            lpFirmaKod.Properties.DisplayMember = "Crkod";
            lpFirmaKod.Properties.ValueMember = "Crid";
            lpFirmaKod.ItemIndex = -1;

            lpFirmaAd.Properties.DataSource = db.Scaris.ToList();
            lpFirmaAd.Properties.DisplayMember = "Crisim";
            lpFirmaAd.Properties.ValueMember = "Crid";
            lpFirmaAd.ItemIndex = -1;

            lpStokKod.Properties.DataSource = db.Sstoks.ToList();
            lpStokKod.Properties.DisplayMember = "Stokkod";
            lpStokKod.Properties.ValueMember = "Sstokid";
            lpStokKod.ItemIndex = -1;

            lpStokAd.Properties.DataSource = db.Sstoks.ToList();
            lpStokAd.Properties.DisplayMember = "Stokadi";
            lpStokAd.Properties.ValueMember = "Sstokid";
            lpStokAd.ItemIndex = -1;


        }


        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstbxGoruntuleyenler.Items.Remove(lstbxGoruntuleyenler.SelectedValue);
        }

        private void lpFirmaKod_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lpFirmaKod.ItemIndex > -1)
                {

                    int cariId = (int)lpFirmaKod.EditValue;
                    var cari = db.Scaris.FirstOrDefault(x => x.Crid == cariId);
                    lpFirmaAd.Text = cari.Crisim;
                    lpFirmaKod.ClosePopup();
                    lpStokKod.Properties.DataSource = db.Sstoks.Where(x => x.Scariid == cari.Crid).ToList();
                    lpStokKod.Properties.DisplayMember = "Stokkod";
                    lpStokKod.Properties.ValueMember = "Sstokid";
                    lpStokKod.ItemIndex = -1;
                    
                    //seçim kontrolü yaptık.
                    //seçim varsa cariId ulaştık. cari nesnesi oluşturduk. entegre çalışacağı comboboxa carinin bilgisini yazdırdık.
                }
                else
                {

                    lpFirmaAd.Text = "";

                }
            }
            catch
            {


            }
        }

        private void lpFirmaAd_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lpFirmaAd.ItemIndex > -1)
                {
                    int cariId = (int)lpFirmaAd.EditValue;
                    var cari = db.Scaris.FirstOrDefault(x => x.Crid == cariId);
                    lpFirmaKod.Text = cari.Crkod;
                    lpFirmaAd.ClosePopup();
                    lpStokAd.Properties.DataSource = db.Sstoks.Where(x => x.Scariid == cari.Crid).ToList();
                    lpStokAd.Properties.DisplayMember = "Stokadi";
                    lpStokAd.Properties.ValueMember = "Sstokid";
                    lpStokAd.ItemIndex = -1;
                    
                    //seçim kontrolü yaptık.
                    //seçim varsa cariId ulaştık. cari nesnesi oluşturduk. entegre çalışacağı comboboxa carinin bilgisini yazdırdık.
                }
                else
                {
                    lpFirmaKod.Text = "";


                }
            }
            catch
            {


            }
        }

        private void lpStokKod_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lpStokKod.ItemIndex > -1)
                {
                    double stokId = (double)lpStokKod.EditValue;
                    var stok = db.Sstoks.FirstOrDefault(x => x.Sstokid == stokId);
                    lpStokAd.Text = stok.Stokadi;
                    lpStokKod.ClosePopup();
                    //seçim kontrolü yaptık.
                    //seçim varsa cariId ulaştık. cari nesnesi oluşturduk. entegre çalışacağı comboboxa carinin bilgisini yazdırdık.
                }
                else
                {
                    if (KonuId != 0)
                    {
                        var stokId = db.Konulars.FirstOrDefault(x => x.KonuId == KonuId).StokId;
                        var stokAdı = db.Sstoks.FirstOrDefault(x => x.Sstokid == stokId).Stokadi;
                        lpStokAd.Text = stokAdı; 

                    }
                    lpStokAd.Text = "";

                }
            }
            catch
            {


            }

        }

        private void lpStokAd_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lpStokAd.ItemIndex > -1)
                {

                    double stokId = (double)lpStokAd.EditValue;
                    var stok = db.Sstoks.FirstOrDefault(x => x.Sstokid == stokId);
                    lpStokKod.Text = stok.Stokkod;
                    lpStokAd.ClosePopup();
                    //seçim kontrolü yaptık.
                    //seçim varsa cariId ulaştık. cari nesnesi oluşturduk. entegre çalışacağı comboboxa carinin bilgisini yazdırdık.
                }
                else
                {
                    if (KonuId!=0)
                    {
                        var stokId = db.Konulars.FirstOrDefault(x => x.KonuId == KonuId).StokId;
                        var stokKodu = db.Sstoks.FirstOrDefault(x => x.Sstokid == stokId).Stokkod;
                        lpStokKod.Text = stokKodu;
                    }
                    lpStokKod.Text = "";


                }
            }
            catch
            {


            }
        }


        public void resimSec(PictureBox pictureBox)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Resim Seç";
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp; *.JPG;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox.ImageLocation = openFileDialog1.FileName;

            }
        }

        private void btnResimKaydet1_Click(object sender, EventArgs e)
        {
            resimSec(pbResim1);
        }

        private void btnResimSil1_Click(object sender, EventArgs e)
        {
            pbResim1.Image = null;
        }

        private void btnResimKaydet2_Click(object sender, EventArgs e)
        {
            resimSec(pbResim2);
        }

        private void btnResimSil2_Click(object sender, EventArgs e)
        {
            pbResim2.Image = null;
        }

        private void btnResimKaydet3_Click(object sender, EventArgs e)
        {
            resimSec(pbResim3);
        }

        private void btnResimSil3_Click(object sender, EventArgs e)
        {
            pbResim3.Image = null;
        }

        private void btnResimKaydet4_Click(object sender, EventArgs e)
        {
            resimSec(pbResim4);
        }

        private void btnResimSil4_Click(object sender, EventArgs e)
        {
            pbResim4.Image = null;
        }

        public void resimKaydet(PictureBox pictureBox, string Tip)
        {

            string imageFile = Path.GetFileName(pictureBox.ImageLocation);
            string imagePath = Path.Combine("y:\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + imageFile);
            File.Copy(pictureBox.ImageLocation, imagePath, true);
            string imgName = pictureBox.Name + imagePath;

            string name = imgName.Substring(imgName.LastIndexOf("i\\"));

            Resimler rs = new Resimler();
            var resimKonuId = (db.Konulars.OrderByDescending(x => x.KonuId).FirstOrDefault()).KonuId;
            rs.KonuId = resimKonuId;
            rs.ImageName = imageFile;
            rs.StId = lpStokAd.EditValue != null ? (double)lpStokAd.EditValue : 0; ;
            rs.ImageUrl = imagePath;
            rs.Tipi = Tip;
            db.Resimlers.Add(rs);
            db.SaveChanges();

        }




        public void KullanıcıDoldur()
        {
            var liste = from kullanıcı in db.Kullanıcılars select new { kullanıcı.AdSoyad, kullanıcı.Id };
            gridControl1.DataSource = liste.Distinct().ToList();
            


        }

        private void repositoryItemCheckEdit1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var secilenAd = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AdSoyad");
            var secilenId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Id");
            
            bool veriVarMi = false;

            foreach (var item in lstbxGoruntuleyenler.Items)
            {
                if (secilenAd != null)
                {
                    if (item.ToString() == secilenAd.ToString())
                    {
                        veriVarMi = true;
                        if (true)
                        {
                            lstbxGoruntuleyenler.Items.Remove(item);
                        }
                        else
                        {
                            lstbxGoruntuleyenler.Items.Add(item);
                        }

                        break; // Arama sonlandırıldı, döngüden çıkılıyor
                    }
                }
                else
                {

                }

            }

            if (veriVarMi == false)
            {
                if (secilenAd != null)
                {
                    lstbxGoruntuleyenler.Items.Add(secilenAd.ToString());
                }
                else
                {

                }

            }
            else
            {

            }

        }

        private void btnDgvEkle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Ekle butonu");
        }

        private void rpItBelgeEkle_Click(object sender, EventArgs e)
        {

        }

        public void combo()
        {
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Islem";
            comboBoxColumn.Name = "Islem";

            // ComboBox'a eklenecek seçenekleri belirtin.
            comboBoxColumn.Items.Add("Ekle");
            comboBoxColumn.Items.Add("Sil");

            dtgBelge.Columns.Add(comboBoxColumn);

            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.HeaderText = "Belge Adı";
            textBoxColumn.Name = "BelgeAdı";

            dtgBelge.Columns.Add(textBoxColumn);

            DataGridViewTextBoxColumn textBoxColumn2 = new DataGridViewTextBoxColumn();
            textBoxColumn2.HeaderText = "Belge Yolu";
            textBoxColumn2.Name = "BelgeYolu";

            dtgBelge.Columns.Add(textBoxColumn2);

        }

        private void dtgBelge_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgBelge_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        ComboBox belgeCombo;
        private void dtgBelge_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            belgeCombo = e.Control as ComboBox;
            if (belgeCombo!=null)
            {
                belgeCombo.SelectedIndexChanged -= new EventHandler(belgeCombo_SelectedIndexChanged);
                belgeCombo.SelectedIndexChanged += belgeCombo_SelectedIndexChanged;
            }
        }

        private void belgeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilen = (sender as ComboBox).SelectedItem.ToString();
            if (secilen=="Ekle" && dtgBelge.CurrentRow.Cells[1].Value==null && dtgBelge.CurrentRow.Cells[2].Value==null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Dosya Seç";
                openFileDialog.Filter = "Tüm Dosyalar (*.*)|*.*";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //txtDosyaEkle.Text = openFileDialog.FileName;
                    string dosyaPath = Path.Combine("y:\\ÇEVİK\\version\\Selim\\Dosyalar\\" + openFileDialog.SafeFileName);
                    
                    path = dosyaPath;
                    File.Copy(openFileDialog.FileName, dosyaPath, true);
                    dtgBelge.CurrentRow.Cells[1].Value = openFileDialog.SafeFileName;
                    dtgBelge.CurrentRow.Cells[2].Value = dosyaPath;
                    dtgBelge.CurrentRow.Cells[1].ReadOnly = true;
                    dtgBelge.CurrentRow.Cells[2].ReadOnly = true;
                    int rowindex = dtgBelge.CurrentRow.Index + 1;
                    rowIndex = rowindex;
                    Resimler belge = new Resimler();
                    var belgeKonuId = (db.Konulars.OrderByDescending(x => x.KonuId).FirstOrDefault()).KonuId;
                    belge.KonuId = belgeKonuId;
                    belge.StId = lpStokAd.EditValue != null ? (double)lpStokAd.EditValue : 0; ;
                    belge.ImageUrl = dosyaPath;
                    belge.Tipi = $"kb{rowindex}";
                    db.Resimlers.Add(belge);
                    db.SaveChanges();

                }
                


            }

            else if(secilen=="Sil" && dtgBelge.CurrentRow.Cells[1].Value != null && dtgBelge.CurrentRow.Cells[2].Value != null)
            {

                File.Delete(dtgBelge.CurrentRow.Cells[2].Value.ToString());
                dtgBelge.CurrentRow.Cells[1].Value = null;
                dtgBelge.CurrentRow.Cells[2].Value = null;
                dtgBelge.CurrentRow.Cells[1].ReadOnly = true;
                dtgBelge.CurrentRow.Cells[2].ReadOnly = true;

            }
            
            
        }
    }
}
