using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRM.Data;
using CRM.Formlar;
using CRM.Model;
using Microsoft.EntityFrameworkCore;

namespace CRM.Formlar
{
    public partial class FrmCevap : Form
    {
        CevikTeknikTestProjContext db = new CevikTeknikTestProjContext();
        public FrmCevap()
        {
            InitializeComponent();
        }
        public int KullanıcıId;
        public int KonuId;
        public int Id;
        public int rowIndex;
        public string path;
        private void FrmCevap_Load(object sender, EventArgs e)
        {
            combo();
        }

        public void formuDoldur()
        {

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtbxCevap.Text == null)
            {
                MessageBox.Show("Lütfen Cevap Girişi Yapınız.");
            }
            else if (txtbxGorusulen.Text == null)
            {
                MessageBox.Show("Lütfen Görüşülen Kişi Bilgisi Giriniz.");
            }
            else
            {
                if (KonuId != 0)
                {
                    //var cevap = db.Cevaplars.FirstOrDefault(x => x.KonuId == KonuId && x.Id == Id);
                    Cevaplar yenicevap = new Cevaplar();
                    var konu = db.Konulars.FirstOrDefault(x => x.KonuId == KonuId);
                    yenicevap.KonuId = konu.KonuId;
                    yenicevap.Cevap = txtbxCevap.Text;
                    yenicevap.GorusenId = KullanıcıId;
                    yenicevap.Gorusulen = txtbxGorusulen.Text;
                    yenicevap.Tarih = dateTimePicker1.Value;
                    //var CariId = db.Scaris.Where(i => i.Crisim == cari).Select(i => i.Crid).FirstOrDefault();
                    var CariId = db.Scaris.FirstOrDefault(x=>x.Crid==konu.CariId).Crid;
                    yenicevap.CariId = CariId;
                    db.Add(yenicevap);
                    db.SaveChanges();

                    foreach (DataGridViewRow row in dtgBelge.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowindex = row.Index;
                            DataGridViewCell veri = row.Cells[2]; // İlgili sütunun indeksini belirtin
                            if (veri.Value != null)
                            {

                                Resimler belgeEkle = new Resimler();
                                belgeEkle.CevapId = yenicevap.Id;
                                belgeEkle.KonuId = konu.KonuId;
                                belgeEkle.ImageName = row.Cells[1].Value.ToString();
                                belgeEkle.StId = konu.StokId ;
                                belgeEkle.ImageUrl = veri.Value.ToString();
                                belgeEkle.Tipi = $"cb{rowindex + 1}";
                                db.Resimlers.Add(belgeEkle);
                                db.SaveChanges();
                                //string belge = veri.Value.ToString();
                                //Belgeler.Add(belge);
                            }
                        }
                        
                        
                    }

                    if (pbResim1.Image != null)
                    {
                        resimKaydet(pbResim1, "5");

                    }
                    else
                    {

                    }
                    if (pbResim2.Image != null)
                    {
                        resimKaydet(pbResim2, "6");
                    }
                    else
                    {

                    }
                    if (pbResim3.Image != null)
                    {
                        resimKaydet(pbResim3, "7");
                    }
                    else
                    {

                    }
                    if (pbResim4.Image != null)
                    {
                        resimKaydet(pbResim4, "8");
                    }
                    else
                    {

                    }
                    //else
                    //{
                    //    var belgeKonuId = (db.Konulars.OrderByDescending(x => x.KonuId).FirstOrDefault()).KonuId;
                    //    belge.KonuId = belgeKonuId;
                    //    var stokId = (db.Konulars.OrderByDescending(x => x.KonuId).FirstOrDefault()).StokId;
                    //    belge.StId = stokId;
                    //}

                    
                    MessageBox.Show("Cevap Eklendi");
                    this.Hide();

                    //frm.Listele();

                }
                else
                {
                    Cevaplar ekle = new Cevaplar();
                    //FrmParca fr = new FrmParca();
                    string konutxt = txtbxKonu.Text;
                    var konu = db.Konulars.FirstOrDefault(k => k.Konu == konutxt);
                    var stokId = konu.StokId;
                    ekle.KonuId = konu.KonuId; 
                    string cari = txtbxCari.Text;
                    var CariId = db.Scaris.Where(i => i.Crisim == cari).Select(i => i.Crid).FirstOrDefault();
                    ekle.CariId = CariId;
                    ekle.GorusenId =KullanıcıId;
                    ekle.Gorusulen = txtbxGorusulen.Text;
                    ekle.Tarih = Convert.ToDateTime(dateTimePicker1.Value.ToString());
                    ekle.Cevap = txtbxCevap.Text;
                    db.Cevaplars.Add(ekle);
                    db.SaveChanges();


                    if (pbResim1.Image != null)
                    {
                        resimKaydet(pbResim1, "5");

                    }
                    else
                    {

                    }
                    if (pbResim2.Image != null)
                    {
                        resimKaydet(pbResim2, "6");
                    }
                    else
                    {

                    }
                    if (pbResim3.Image != null)
                    {
                        resimKaydet(pbResim3, "7");
                    }
                    else
                    {

                    }
                    if (pbResim4.Image != null)
                    {
                        resimKaydet(pbResim4, "8");
                    }
                    else
                    {

                    }

                    foreach (DataGridViewRow row in dtgBelge.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowindex = row.Index;
                            DataGridViewCell veri = row.Cells[2]; // İlgili sütunun indeksini belirtin
                            if (veri.Value != null)
                            {

                                Resimler belgeEkle = new Resimler();
                                belgeEkle.KonuId = konu.KonuId;
                                belgeEkle.CevapId = ekle.Id;
                                belgeEkle.ImageName = row.Cells[1].Value.ToString();
                                belgeEkle.StId = stokId;
                                belgeEkle.ImageUrl = veri.Value.ToString();
                                belgeEkle.Tipi = $"cb{rowindex + 1}";
                                db.Resimlers.Add(belgeEkle);
                                db.SaveChanges();

                            }
                        }


                    }

                    MessageBox.Show("Cevap Kaydedildi");
                    this.Hide();
                    //Form1 frm = (Form1)Application.OpenForms["Form1"];
                    //frm.ShowDialog();
                    //frm.Listele();
                }

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
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
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
            var resimCevapId = (db.Cevaplars.OrderByDescending(x => x.Id).FirstOrDefault()).Id;
            rs.KonuId = resimKonuId;
            var stokId = (db.Konulars.OrderByDescending(x => x.KonuId).FirstOrDefault()).StokId;
            rs.StId = stokId;
            //rs.StId = lpStokAd.EditValue != null ? (double)lpStokAd.EditValue : 0; ;
            rs.ImageUrl = imagePath;
            rs.Tipi = Tip;
            rs.CevapId = resimCevapId;
            rs.ImageName = imageFile;
            db.Resimlers.Add(rs);
            db.SaveChanges();
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
        ComboBox belgeCombo;

        private void dtgBelge_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            belgeCombo = e.Control as ComboBox;
            if (belgeCombo != null)
            {
                belgeCombo.SelectedIndexChanged -= new EventHandler(belgeCombo_SelectedIndexChanged);
                belgeCombo.SelectedIndexChanged += belgeCombo_SelectedIndexChanged;
            }
        }

        private void belgeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilen = (sender as ComboBox).SelectedItem.ToString();
            if (secilen == "Ekle" && dtgBelge.CurrentRow.Cells[1].Value == null && dtgBelge.CurrentRow.Cells[2].Value == null)
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


                }



            }

            else if (secilen == "Sil" && dtgBelge.CurrentRow.Cells[1].Value != null && dtgBelge.CurrentRow.Cells[2].Value != null)
            {
                int rowindex = dtgBelge.CurrentRow.Index + 1;
                File.Delete(dtgBelge.CurrentRow.Cells[2].Value.ToString());
                if (KonuId != null)
                {
                    var konu = db.Konulars.FirstOrDefault(x => x.KonuId == KonuId);
                    var bKonuId = konu.KonuId;
                    db.Database.ExecuteSqlRaw($"delete from Resimler where KonuId={bKonuId} and Tipi='cb{rowindex}'");


                }
                else
                {
                    var belgeKonuId = (db.Konulars.OrderByDescending(x => x.KonuId).FirstOrDefault()).KonuId;
                    db.Database.ExecuteSqlRaw($"delete from Resimler where KonuId={belgeKonuId} and Tipi='cb{rowindex}'");
                }

                dtgBelge.CurrentRow.Cells[1].Value = null;
                dtgBelge.CurrentRow.Cells[2].Value = null;
                dtgBelge.CurrentRow.Cells[1].ReadOnly = true;
                dtgBelge.CurrentRow.Cells[2].ReadOnly = true;

            }

        }
    }
}
