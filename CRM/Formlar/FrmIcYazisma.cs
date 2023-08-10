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
using System.Data.SqlClient;
using CRM.Properties;
using CRM.Formlar;

namespace CRM
{
    public partial class FrmIcYazisma : Form
    {
        public int Id;
        public int KonuId;


        CevikTeknikTestProjContext db = new CevikTeknikTestProjContext();
        public FrmIcYazisma()
        {
            InitializeComponent();
        }


        private void FrmIcYazisma_Load(object sender, EventArgs e)
        {

            cariAdCombo();
            cariKodCombo();
            KullanıcıCombo();
            GoruntuleyenCombo();

        }
        public void cariAdCombo()
        {
            lpFirmaAd.Properties.DataSource = db.Scaris.ToList();
            lpFirmaAd.Properties.ValueMember = "Crid";
            lpFirmaAd.Properties.DisplayMember = "Crisim";
            lpFirmaAd.ItemIndex = -1;


        }

        public void cariKodCombo()
        {
            lpFirmaKod.Properties.DataSource = db.Scaris.ToList();
            lpFirmaKod.Properties.ValueMember = "Crid";
            lpFirmaKod.Properties.DisplayMember = "Crkod";
            lpFirmaKod.ItemIndex = -1;
        }
        public void GoruntuleyenCombo()
        {
            lpGoruntuleyenler.Properties.DataSource = db.Kullanıcılars.ToList();
            lpGoruntuleyenler.Properties.ValueMember = "Id";
            lpGoruntuleyenler.Properties.DisplayMember = "AdSoyad";




            //cmbKullanıcılar.DataSource = db.Kullanıcılars.ToList(); 
            //cmbKullanıcılar.ValueMember = "Id";
            //cmbKullanıcılar.DisplayMember = "AdSoyad";
            //cmbKullanıcılar.SelectedIndex = -1;
        }

        public void KullanıcıCombo()
        {
            lpKullanıcılar.Properties.DataSource = db.Kullanıcılars.ToList();
            lpKullanıcılar.Properties.ValueMember = "Id";
            lpKullanıcılar.Properties.DisplayMember = "AdSoyad";
            lpKullanıcılar.ItemIndex = -1;
            //lpKullanıcılar.ItemIndex = 0;
            //lpKullanıcılar.Enabled = false;

        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    Form1 fr = (Form1)Application.OpenForms["Form1"];
            //    if (Id > 0)
            //    {
            //        var konu = db.Konulars.FirstOrDefault(k => k.Id == Id);
            //        .SelectedValue = cevap.GorusenKisiId;
            //        cevap.Cevap1 = txtbxCevap.Text;
            //        cevap.GorusulenKisi = txtbxGorusulen.Text;
            //        cevap.KonuId = KonuId;


            //    }
            //    else
            //    {
            //        Cevap cevap = new Cevap();
            //        cevap.GorusenKisiId = Convert.ToInt32(cmbGorusen.SelectedValue.ToString());
            //        cevap.Cevap1 = txtbxCevap.Text;
            //        cevap.Tarih = dateTimePicker1.Value;
            //        cevap.GorusulenKisi = txtbxGorusulen.Text;
            //        cevap.KonuId = KonuId;


            //        db.Add(cevap);

            //    }

            //    db.SaveChanges();
            //    fr.Listele();
            //    this.Close();
            //}
            //catch 
            //{


            //}
            if (txtbxKonu.Text == "")
            {
                MessageBox.Show("Lütfen Konu Girişi Yapınız.");
            }
            else
            {
                if (txtbxKonu.Text.Length <= 20)
                {
                    DialogResult cevap1 = MessageBox.Show($"Konu :{txtbxKonu.Text}... için cevap eklemek istermisiniz ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap1 == DialogResult.Yes)
                    {

                        FrmCevap frm = new FrmCevap();
                        frm.Show();
                        frm.txtbxKonu.Text = txtbxKonu.Text;
                        double cariId = (double)lpFirmaAd.EditValue;
                        var firm = db.Scaris.FirstOrDefault(f => f.Crid == cariId);
                        frm.txtbxCari.Text = firm.Crisim;


                    }
                    else
                    {
                        this.Close();
                    }
                }
                else if (txtbxKonu.Text.Length > 20)
                {
                    DialogResult cevap = MessageBox.Show($"Konu :{txtbxKonu.Text.Substring(0, 20)}... için cevap eklemek istermisiniz ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {

                        FrmCevap frm = new FrmCevap();
                        frm.Show();
                        frm.txtbxKonu.Text = txtbxKonu.Text;
                        double cariId = (double)lpFirmaAd.EditValue;
                        var firm = db.Scaris.FirstOrDefault(f => f.Crid == cariId);
                        frm.txtbxCari.Text = firm.Crisim;

                    }
                    else
                    {
                        this.Close();

                    }
                }

            }



        }



        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lpGoruntuleyenler_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (lpGoruntuleyenler.Text != "")
            {
                lstbxGoruntuleyenler.Items.Add(lpGoruntuleyenler.Text);
            }

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
                    double cariId = (double)lpFirmaKod.EditValue;
                    var cari = db.Scaris.FirstOrDefault(x => x.Crid == cariId);
                    lpFirmaAd.Text = cari.Crisim;
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
                    double cariId = (double)lpFirmaAd.EditValue;
                    var cari = db.Scaris.FirstOrDefault(x => x.Crid == cariId);
                    lpFirmaKod.Text = cari.Crkod;
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

    }
}
