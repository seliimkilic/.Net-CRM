using CRM.Data;
using CRM.Model;
using CRM.Formlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CRM.Formlar
{
    public partial class FrmAyrıntılar : Form
    {
        public FrmAyrıntılar()
        {
            InitializeComponent();
        }
        public string secilenKonu;
        public string secilenCevap;
        public int cevapId;
        public int KullanıcıId;
        private void FrmAyrıntılar_Load(object sender, EventArgs e)
        {
            
            KonuDoldur();
            CevapDoldur();
            Listele();
            belgeDoldur();

        }


        CevikTeknikTestProjContext db = new CevikTeknikTestProjContext();
        public void KonuDoldur()
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId);
            var konutur = db.KonuTurus.FirstOrDefault(x => x.Id == konu.TurId);
            var cari = db.Scaris.FirstOrDefault(x => x.Crid == konu.CariId);
            var stok = db.Sstoks.FirstOrDefault(x => x.Sstokid == konu.StokId);
            var kullanıcı = db.Kullanıcılars.FirstOrDefault(x => x.Id == konu.KullanıcıId);
            var resim = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId);
            var belge1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "A");

           

            txtbxKonu.Text = konu.Konu;
            txtbxKKonuTur.Text = konutur.Ad;
            txtbxKFirma.Text = cari.Crisim;

            if (stok != null)
            {
                txtbxKStokadı.Text = stok.Stokadi;
                txtbxKStokKodu.Text = stok.Stokkod;
                txtbxKStokAdeti.Text = stok.Stokadet.ToString();
            }
            else
            {
                txtbxKStokadı.Text = "";
                txtbxKStokKodu.Text = "";
                txtbxKStokAdeti.Text = "";
            }
            
            if (txtbxKGorusen.Text !="" || txtbxKGorusen.Text !=null)
            {
                txtbxKGorusen.Text = kullanıcı.AdSoyad;
            }
            else
            {
                txtbxKGorusen.Text = "";
            }
            
            
            txtbxKTarih.Text = konu.Tarih.ToString();

            var stokImg1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "1");
            var stokImg2 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "2");
            var stokImg3 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "3");
            var stokImg4 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "4");

            pbK1.ImageLocation = stokImg1 != null ? pbK1.ImageLocation = stokImg1 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg1.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
            pbK2.ImageLocation = stokImg2 != null ? pbK2.ImageLocation = stokImg2 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg2.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
            pbK3.ImageLocation = stokImg3 != null ? pbK3.ImageLocation = stokImg3 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg3.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
            pbK4.ImageLocation = stokImg4 != null ? pbK4.ImageLocation = stokImg4 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg4.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;

            var goruntuleyenler = from izintbl in db.Izinlers
                                  join users in db.Kullanıcılars on izintbl.KullanıcıId equals users.Id into kullanici
                                  from users in kullanici.DefaultIfEmpty()
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

        public void CevapDoldur()
        {
            if (secilenCevap != null)
            {
                var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
                var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId);
                var konutur = db.KonuTurus.FirstOrDefault(x => x.Id == konu.TurId);
                var cari = db.Scaris.FirstOrDefault(x => x.Crid == konu.CariId);
                var stok = db.Sstoks.FirstOrDefault(x => x.Sstokid == konu.StokId);
                var kullanıcı = db.Kullanıcılars.FirstOrDefault(x => x.Id == konu.KullanıcıId);
                var resim = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId);
                txtbxCevap.Text = cevap.Cevap;
                txtbxCKonuTur.Text = konutur.Ad;
                txtbxCFirma.Text = cari.Crisim;

                var belge1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "D" && x.CevapId == cevap.Id);

                

                if (stok != null)
                {
                    txtbxCStokAdı.Text = stok.Stokadi;
                    txtbxCStokKodu.Text = stok.Stokkod;
                    txtbxCStokAdeti.Text = stok.Stokadet.ToString();
                }
                else
                {
                    txtbxCStokAdı.Text = "";
                    txtbxCStokKodu.Text = "";
                    txtbxCStokAdeti.Text = "";
                }
                txtbxCGorusen.Text = kullanıcı.AdSoyad;
                txtbxCGorusulen.Text = cevap.Gorusulen;
                txtbxCTarih.Text = konu.Tarih.ToString();

                var stokImg1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "5" && x.CevapId == cevap.Id);
                var stokImg2 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "6" && x.CevapId == cevap.Id);
                var stokImg3 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "7" && x.CevapId == cevap.Id);
                var stokImg4 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "8" && x.CevapId == cevap.Id);

                pbC1.ImageLocation = stokImg1 != null ? pbC1.ImageLocation = stokImg1 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg1.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
                pbC2.ImageLocation = stokImg2 != null ? pbC2.ImageLocation = stokImg2 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg2.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
                pbC3.ImageLocation = stokImg3 != null ? pbC3.ImageLocation = stokImg3 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg3.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
                pbC4.ImageLocation = stokImg4 != null ? pbC4.ImageLocation = stokImg4 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg4.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
            }
            else
            {
                try
                {
                    var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
                    var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId);
                    var konutur = db.KonuTurus.FirstOrDefault(x => x.Id == konu.TurId);
                    var cari = db.Scaris.FirstOrDefault(x => x.Crid == konu.CariId);
                    var stok = db.Sstoks.FirstOrDefault(x => x.Sstokid == konu.StokId);
                    var kullanıcı = db.Kullanıcılars.FirstOrDefault(x => x.Id == konu.KullanıcıId);
                    var resim = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId);
                    var cevapp = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Id == cevapId);

                    var belge1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "D" && x.CevapId==cevapId);

                    if (cevap!=null)
                    {
                        txtbxCevap.Text = cevap.Cevap;
                        txtbxCKonuTur.Text = konutur.Ad;
                        txtbxCFirma.Text = cari.Crisim;

                        if (stok != null)
                        {
                            txtbxCStokAdı.Text = stok.Stokadi;
                            txtbxCStokKodu.Text = stok.Stokkod;
                            txtbxCStokAdeti.Text = stok.Stokadet.ToString();
                        }
                        else
                        {
                            txtbxCStokAdı.Text = "";
                            txtbxCStokKodu.Text = "";
                            txtbxCStokAdeti.Text = "";
                        }
                        txtbxCGorusen.Text = kullanıcı.AdSoyad;
                        txtbxCGorusulen.Text = cevap.Gorusulen;
                        txtbxCTarih.Text = konu.Tarih.ToString();

                        var stokImg1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "5" && x.CevapId == cevapp.Id);
                        var stokImg2 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "6" && x.CevapId == cevapp.Id);
                        var stokImg3 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "7" && x.CevapId == cevapp.Id);
                        var stokImg4 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "8" && x.CevapId == cevapp.Id);

                        pbC1.ImageLocation = stokImg1 != null ? pbC1.ImageLocation = stokImg1 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg1.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
                        pbC2.ImageLocation = stokImg2 != null ? pbC2.ImageLocation = stokImg2 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg2.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
                        pbC3.ImageLocation = stokImg3 != null ? pbC3.ImageLocation = stokImg3 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg3.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
                        pbC4.ImageLocation = stokImg4 != null ? pbC4.ImageLocation = stokImg4 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg4.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
                    }
                    else
                    {
                            
                    }
                    
                }
                catch 
                {

                 
                }
               
            }

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
            foreach (var item in liste.OrderBy(x => x.Tarih).ToList())
            // 1den ... başlayıp gidince en altta 1 olucak şimdi

            {
                var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
                if (item.KonuId == konu.KonuId)
                {
                    dt.Rows.Add(// 
                    item.Id
                  , item.KonuId
                  , item.AktifPasif == true ? "A" : "P"
                  , item.Crisim
                  , item.Konu
                  , item.Cevap
                  , item.AdSoyad
                  , item.Gorusulen
                  , item.Tarih
                  , item.Ad
                  , item.Stokadi
                  , item.Stokkod
                  , item.Stokadet);
                }
                
                else
                {

                }


            }


            gridControl1.DataSource = dt;

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            //var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Cevap == secilenCevap.ToString());
            
            var secilenCevap = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");
            var secilenCevapId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Id");
            var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Id == Convert.ToInt32(secilenCevapId));
            if (secilenCevap != null && cevap!=null)
            {

                var konutur = db.KonuTurus.FirstOrDefault(x => x.Id == konu.TurId);
                var cari = db.Scaris.FirstOrDefault(x => x.Crid == konu.CariId);
                var stok = db.Sstoks.FirstOrDefault(x => x.Sstokid == konu.StokId);
                var kullanıcı = db.Kullanıcılars.FirstOrDefault(x => x.Id == konu.KullanıcıId);
                var resim = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId);
                //var belge = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi.StartsWith("kb") && x.CevapId==cevap.Id);
                var belgeler = db.Resimlers.Where(x => x.KonuId == konu.KonuId && x.Tipi.StartsWith("cb") && x.CevapId == cevap.Id).Select(x => new { x.ImageName, x.ImageUrl, x.Tipi }).ToList();
                //var belge = db.Resimlers.Where(x => x.KonuId == konu.KonuId && x.Tipi.StartsWith("cb") && x.CevapId == cevap.Id).ToList();
                dtgBelge2.DataSource = belgeler;


                //if (belge1!=null)
                //{
                //    txtBelgec1.Text = belge1.ImageUrl;
                //}
                //else
                //{
                //    txtBelgec1.Text = "";
                //}

                //var belge2 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "E" && x.CevapId == cevap.Id);
                //if (belge2!=null)
                //{
                //    txtBelgec2.Text = belge2.ImageUrl;
                //}
                //else
                //{
                //    txtBelgec2.Text = "";
                //}

                //var belge3 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "F" && x.CevapId == cevap.Id);
                //if (belge3 != null)
                //{
                //    txtBelgec3.Text = belge3.ImageUrl;
                //}
                //else
                //{
                //    txtBelgec3.Text = "";
                //}

                txtbxCevap.Text = cevap.Cevap;
                txtbxCKonuTur.Text = konutur.Ad;
                txtbxCFirma.Text = cari.Crisim;
                
                if (stok != null)
                {
                    txtbxCStokAdı.Text = stok.Stokadi;
                    txtbxCStokKodu.Text = stok.Stokkod;
                    txtbxCStokAdeti.Text = stok.Stokadet.ToString();
                }
                else
                {
                    txtbxCStokAdı.Text = "";
                    txtbxCStokKodu.Text = "";
                    txtbxCStokAdeti.Text = "";
                }
                txtbxCGorusen.Text = kullanıcı.AdSoyad;
                txtbxCGorusulen.Text = cevap.Gorusulen;
                txtbxCTarih.Text = konu.Tarih.ToString();

                var stokImg1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "5" && x.CevapId == cevap.Id);
                var stokImg2 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "6" && x.CevapId == cevap.Id);
                var stokImg3 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "7" && x.CevapId == cevap.Id);
                var stokImg4 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "8" && x.CevapId == cevap.Id);

                pbC1.ImageLocation = stokImg1 != null ? pbC1.ImageLocation = stokImg1 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg1.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
                pbC2.ImageLocation = stokImg2 != null ? pbC2.ImageLocation = stokImg2 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg2.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
                pbC3.ImageLocation = stokImg3 != null ? pbC3.ImageLocation = stokImg3 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg3.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
                pbC4.ImageLocation = stokImg4 != null ? pbC4.ImageLocation = stokImg4 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg4.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
            }
            else
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmBuyukResim frb = new FrmBuyukResim();
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var stokImg1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "1");
            frb.pbBuyukResim.ImageLocation = pbC1.ImageLocation = stokImg1 != null ? pbK1.ImageLocation = stokImg1 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg1.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
            frb.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmBuyukResim frb = new FrmBuyukResim();
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var stokImg2 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "2");
            frb.pbBuyukResim.ImageLocation = stokImg2 != null ? pbK2.ImageLocation = stokImg2 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg2.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
            frb.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmBuyukResim frb = new FrmBuyukResim();
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var stokImg3 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "3");
            frb.pbBuyukResim.ImageLocation = stokImg3 != null ? pbK3.ImageLocation = stokImg3 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg3.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
            frb.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            FrmBuyukResim frb = new FrmBuyukResim();
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var stokImg4 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "4");
            frb.pbBuyukResim.ImageLocation = stokImg4 != null ? pbK4.ImageLocation = stokImg4 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg4.ImageUrl : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;
            frb.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var secilenCevap = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");
            var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Cevap == secilenCevap.ToString());
            FrmBuyukResim frb = new FrmBuyukResim();
            var stokImg1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "5" && x.CevapId == cevap.Id);
            frb.pbBuyukResim.ImageLocation = stokImg1 != null ? pbC1.ImageLocation = stokImg1 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg1.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;

            frb.Show();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var secilenCevap = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");
            var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Cevap == secilenCevap.ToString());
            FrmBuyukResim frb = new FrmBuyukResim();
            var stokImg2 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "6" && x.CevapId == cevap.Id);
            frb.pbBuyukResim.ImageLocation = stokImg2 != null ? pbC2.ImageLocation = stokImg2 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg2.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;

            frb.Show();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var secilenCevap = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");
            var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Cevap == secilenCevap.ToString());
            FrmBuyukResim frb = new FrmBuyukResim();
            var stokImg3 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "7" && x.CevapId == cevap.Id);
            frb.pbBuyukResim.ImageLocation = stokImg3 != null ? pbC3.ImageLocation = stokImg3 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg3.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;

            frb.Show();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var secilenCevap = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");
            var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Cevap == secilenCevap.ToString());
            FrmBuyukResim frb = new FrmBuyukResim();
            var stokImg4 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "8" && x.CevapId == cevap.Id);
            frb.pbBuyukResim.ImageLocation = stokImg4 != null ? pbC4.ImageLocation = stokImg4 != null ? "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + stokImg4.ImageName : "\\\\192.168.1.100\\Havuz\\FIRMA MUM RESİMLERİ\\UrunGorselleri\\" + "" : null;

            frb.Show();
        }

        private void btnGozat1_Click(object sender, EventArgs e)
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var belge1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "A");
            FrmParca frp = new FrmParca();
            if (belge1!=null)
            {
                string path = belge1.ImageUrl;
                Process process = new Process();
                process.StartInfo.FileName = path;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            else
            {

            }
            
        }

        private void btnGozat2_Click(object sender, EventArgs e)
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var belge1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "B");
            FrmParca frp = new FrmParca();
            if (belge1 != null)
            {
                string path = belge1.ImageUrl;
                Process process = new Process();
                process.StartInfo.FileName = path;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            else
            {

            }
        }

        private void btnGozat3_Click(object sender, EventArgs e)
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var belge1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "C");
            FrmParca frp = new FrmParca();
            if (belge1 != null)
            {
                string path = belge1.ImageUrl;
                Process process = new Process();
                process.StartInfo.FileName = path;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            else
            {

            }
        }

        private void btnGozatc1_Click(object sender, EventArgs e)
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var secilenCevap2 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");
            try
            {
                var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Cevap == secilenCevap2.ToString());
                var belge1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "D" && x.CevapId == cevap.Id);
                
                if (belge1 != null)
                {
                    string path = belge1.ImageUrl;
                    Process process = new Process();
                    process.StartInfo.FileName = path;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                }
                else
                {

                }
            }
            catch 
            {

                
            }
            

            
           
        }

        private void btnGozatc2_Click(object sender, EventArgs e)
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var secilenCevap2 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");
            try
            {
                var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Cevap == secilenCevap2.ToString());
                var belge1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "E" && x.CevapId == cevap.Id);

                if (belge1 != null)
                {
                    string path = belge1.ImageUrl;
                    Process process = new Process();
                    process.StartInfo.FileName = path;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                }
                else
                {

                }
            }
            catch 
            {

                
            }
            
        }

        private void btnGozatc3_Click(object sender, EventArgs e)
        {
            try
            {
                var secilenCevap2 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cevap");
                var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
                var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Cevap == secilenCevap2.ToString());
                var belge1 = db.Resimlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.Tipi == "F" && x.CevapId == cevap.Id);

                if (belge1 != null)
                {
                    string path = belge1.ImageUrl;
                    Process process = new Process();
                    process.StartInfo.FileName = path;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                }
                else
                {

                }
            }
            catch 
            {

                
            }
            
        }

        public void belgeDoldur()
        {
            var konu = db.Konulars.FirstOrDefault(x => x.Konu == secilenKonu);
            var belgeler = db.Resimlers.Where(x => x.KonuId == konu.KonuId && x.Tipi.StartsWith("kb")).Select(x => new { x.ImageName, x.ImageUrl, x.Tipi}).ToList();
            dtgBelge1.DataSource = belgeler;


        }
        private void dtgBelge1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgBelge1.Columns[e.ColumnIndex].Name=="Gozat")
            {
                string path = dtgBelge1.CurrentRow.Cells[2].Value.ToString();
                Process process = new Process();
                process.StartInfo.FileName = path;
                process.StartInfo.UseShellExecute = true;
                process.Start();

            }
        }

        private void dtgBelge2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgBelge2.Columns[e.ColumnIndex].Name == "dataGridViewButtonColumn1")
            {
                string path = dtgBelge2.CurrentRow.Cells[2].Value.ToString();
                Process process = new Process();
                process.StartInfo.FileName = path;
                process.StartInfo.UseShellExecute = true;
                process.Start();

            }
        }
    }


}
