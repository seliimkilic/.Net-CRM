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

namespace CRM.Formlar
{
    public partial class frmKonuIzin : Form
    {
        public frmKonuIzin()
        {
            InitializeComponent();
        }
        CevikTeknikTestProjContext db = new CevikTeknikTestProjContext();
        public void lpDoldur()
        {
            lpKullanıcı.Properties.DataSource = db.Kullanıcılars.ToList();
            lpKullanıcı.Properties.DisplayMember = "AdSoyad";
            lpKullanıcı.Properties.ValueMember = "Id";
            lpKullanıcı.ItemIndex = -1;

        }

        private void frmKonuIzin_Load(object sender, EventArgs e)
        {
            lpDoldur();
            //  Listele();


            liste();

        }


        public void liste()
        {
            if (lpKullanıcı.Text != "Kullanıcı Seçiniz..." && lpKullanıcı.EditValue
                != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Konu", typeof(string));
                dt.Columns.Add("AdSoyad", typeof(string));
                dt.Columns.Add("Durum", typeof(string));
                dt.Columns.Add("KonuId", typeof(string));
                dt.Columns.Add("KullanıcıId", typeof(string));

                int kullanıcıId = int.Parse(lpKullanıcı.EditValue.ToString());

                foreach (var konu in db.Konulars.Distinct().ToList()) // konuların hepsini kontrol etmek için bunu yazdım
                {
                    // bu konu ve kullanıcı izinler tablosunda aynı satır içerisinde var mı 
                    if (db.Izinlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.KullanıcıId == kullanıcıId) != null)
                    {
                        //varsa
                        dt.Rows.Add(
                            
                            db.Konulars.FirstOrDefault(x => x.KonuId == konu.KonuId).Konu,
                            db.Kullanıcılars.FirstOrDefault(x => x.Id == kullanıcıId).AdSoyad,
                            db.Izinlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.KullanıcıId == kullanıcıId).Durum == true ? "Açık" : "Kapalı",
                            db.Konulars.FirstOrDefault(x => x.KonuId == konu.KonuId).KonuId.ToString(),
                            db.Kullanıcılars.FirstOrDefault(x => x.Id == kullanıcıId).Id.ToString()
                            

                            );
                    }
                    else
                    {
                        dt.Rows.Add(


                              db.Konulars.FirstOrDefault(x => x.KonuId == konu.KonuId).Konu,
                              db.Kullanıcılars.FirstOrDefault(x => x.Id == kullanıcıId).AdSoyad,
                              "Belirsiz",
                              db.Konulars.FirstOrDefault(x => x.KonuId == konu.KonuId).KonuId.ToString(),
                              db.Kullanıcılars.FirstOrDefault(x => x.Id == kullanıcıId).Id.ToString()
                            
                              );

                    }


                }




                gridControl1.DataSource = dt;



            }



        }
        

        private void lpKullanıcı_EditValueChanged(object sender, EventArgs e)
        {
            liste();
            
            
        }

        private void izinVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var secilenDurum = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Durum");
            if (secilenDurum.ToString()=="Kapalı")
            {
                var secilenKonuId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KonuId");
                var secilenKullanıcıId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KullanıcıId");


                var izin = db.Izinlers.FirstOrDefault(x => x.KonuId == Convert.ToInt32(secilenKonuId) && x.KullanıcıId == Convert.ToInt32(secilenKullanıcıId));
                izin.Durum = true;
                db.SaveChanges();
                liste();
            }
            else if (secilenDurum.ToString() == "Belirsiz")
            {
                var secilenKonuId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KonuId");
                var secilenKullanıcıId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KullanıcıId");
                var secilenRolId = db.Kullanıcılars.Where(x => x.Id == Convert.ToInt32(secilenKullanıcıId)).Select(x=>x.RolId).FirstOrDefault();
                Izinler izin = new Izinler();
                izin.KonuId = Convert.ToInt32(secilenKonuId);
                izin.RolId = Convert.ToInt32(secilenRolId);
                izin.KullanıcıId = Convert.ToInt32(secilenKullanıcıId);
                izin.Durum = true;
                db.Add(izin);
                db.SaveChanges();
                liste();
            }
            else
            {

            }

        }

        private void izinKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var secilenDurum = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Durum");
            if (secilenDurum.ToString() == "Açık")
            {
                var secilenKonuId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KonuId");
                var secilenKullanıcıId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KullanıcıId");


                var izin = db.Izinlers.FirstOrDefault(x => x.KonuId == Convert.ToInt32(secilenKonuId) && x.KullanıcıId == Convert.ToInt32(secilenKullanıcıId));
                izin.Durum = false;
                db.SaveChanges();
                liste();
            }
            else
            {
                
            }
        }

        private void rBIzinli_CheckedChanged(object sender, EventArgs e)
        {
            if (lpKullanıcı.Text == "Kullanıcı Seçiniz..." && lpKullanıcı.EditValue != null)
            {
                MessageBox.Show("Lütfen Kullanıcı Seçiniz");
            }
            if (lpKullanıcı.Text != "Kullanıcı Seçiniz..." && lpKullanıcı.EditValue!= null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Konu", typeof(string));
                dt.Columns.Add("AdSoyad", typeof(string));
                dt.Columns.Add("Durum", typeof(string));
                dt.Columns.Add("KonuId", typeof(string));
                dt.Columns.Add("KullanıcıId", typeof(string));

                int kullanıcıId = int.Parse(lpKullanıcı.EditValue.ToString());

                foreach (var konu in db.Konulars.Distinct().ToList()) 
                {
                    
                    if (db.Izinlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.KullanıcıId == kullanıcıId && x.Durum==true) != null)
                    {
                        
                        dt.Rows.Add(

                            db.Konulars.FirstOrDefault(x => x.KonuId == konu.KonuId).Konu,
                            db.Kullanıcılars.FirstOrDefault(x => x.Id == kullanıcıId).AdSoyad,
                            db.Izinlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.KullanıcıId == kullanıcıId).Durum == true ? "Açık" : "Kapalı",
                            db.Konulars.FirstOrDefault(x => x.KonuId == konu.KonuId).KonuId.ToString(),
                            db.Kullanıcılars.FirstOrDefault(x => x.Id == kullanıcıId).Id.ToString()

                            );
                    }
                    else
                    {

                    }

                }

                gridControl1.DataSource = dt;
            }
        }

        private void rBIzinsiz_CheckedChanged(object sender, EventArgs e)
        {
            if (lpKullanıcı.Text == "Kullanıcı Seçiniz..." && lpKullanıcı.EditValue != null)
            {
                MessageBox.Show("Lütfen Kullanıcı Seçiniz");
            }
            if (lpKullanıcı.Text != "Kullanıcı Seçiniz..." && lpKullanıcı.EditValue != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Konu", typeof(string));
                dt.Columns.Add("AdSoyad", typeof(string));
                dt.Columns.Add("Durum", typeof(string));
                dt.Columns.Add("KonuId", typeof(string));
                dt.Columns.Add("KullanıcıId", typeof(string));

                int kullanıcıId = int.Parse(lpKullanıcı.EditValue.ToString());

                foreach (var konu in db.Konulars.Distinct().ToList()) 
                {
                   
                    if (db.Izinlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.KullanıcıId == kullanıcıId && x.Durum == false) != null)
                    {
                        
                        dt.Rows.Add(

                            db.Konulars.FirstOrDefault(x => x.KonuId == konu.KonuId).Konu,
                            db.Kullanıcılars.FirstOrDefault(x => x.Id == kullanıcıId).AdSoyad,
                            db.Izinlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.KullanıcıId == kullanıcıId).Durum == true ? "Açık" : "Kapalı",
                            db.Konulars.FirstOrDefault(x => x.KonuId == konu.KonuId).KonuId.ToString(),
                            db.Kullanıcılars.FirstOrDefault(x => x.Id == kullanıcıId).Id.ToString()

                            );
                    }
                    else
                    {

                    }

                }

                gridControl1.DataSource = dt;
            }
        }

        

        private void rBbelirsiz_CheckedChanged(object sender, EventArgs e)
        {
            if (lpKullanıcı.Text == "Kullanıcı Seçiniz..." && lpKullanıcı.EditValue != null)
            {
                MessageBox.Show("Lütfen Kullanıcı Seçiniz");
            }
            if (lpKullanıcı.Text != "Kullanıcı Seçiniz..." && lpKullanıcı.EditValue != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Konu", typeof(string));
                dt.Columns.Add("AdSoyad", typeof(string));
                dt.Columns.Add("Durum", typeof(string));
                dt.Columns.Add("KonuId", typeof(string));
                dt.Columns.Add("KullanıcıId", typeof(string));

                int kullanıcıId = int.Parse(lpKullanıcı.EditValue.ToString());

                foreach (var konu in db.Konulars.Distinct().ToList()) // konuların hepsini kontrol etmek için bunu yazdım
                {
                    // bu konu ve kullanıcı izinler tablosunda aynı satır içerisinde var mı 
                    if (db.Izinlers.FirstOrDefault(x => x.KonuId == konu.KonuId && x.KullanıcıId == kullanıcıId) == null)
                    {
                        
                        dt.Rows.Add(

                            db.Konulars.FirstOrDefault(x => x.KonuId == konu.KonuId).Konu,
                            db.Kullanıcılars.FirstOrDefault(x => x.Id == kullanıcıId).AdSoyad,
                            "Belirsiz",
                            db.Konulars.FirstOrDefault(x => x.KonuId == konu.KonuId).KonuId,
                            db.Kullanıcılars.FirstOrDefault(x => x.Id == kullanıcıId).Id

                            );
                    }
                    else
                    {

                    }
                }

                gridControl1.DataSource = dt;
            }
        }
        private void rBTumu_CheckedChanged(object sender, EventArgs e)
        {
            liste();
        }
    }

}
