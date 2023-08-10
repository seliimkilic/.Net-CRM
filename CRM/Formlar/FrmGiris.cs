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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        CevikTeknikTestProjContext db = new CevikTeknikTestProjContext();

        public int KullanıcıId;
        private void FrmGiris_Load(object sender, EventArgs e)
        {
            lpGiris.Properties.DataSource = db.Kullanıcılars.ToList();
            lpGiris.Properties.DisplayMember = "AdSoyad";
            lpGiris.Properties.ValueMember = "Id";
            lpGiris.ItemIndex = -1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            Giris();
        }

        public void Giris()
        {
            if (lpGiris.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre Girin..", " Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                var kullanıcııd = db.Kullanıcılars.Where(x => x.AdSoyad == lpGiris.Text).Select(x=>x.Id).FirstOrDefault();
                if (kullanıcııd == null)
                {
                    MessageBox.Show("Hatalı giriş yaptınız.Lütfen bilgilerinizi kontrol edin.", " Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (kullanıcııd != null && textBox1.Text == "1234")
                {
                    KullanıcıId = kullanıcııd;
                    FrmParca frmp = new FrmParca();
                    frmp.KullanıcıId = KullanıcıId;
                    FrmCevap frmc = new FrmCevap();
                    frmc.KullanıcıId = KullanıcıId;
                    Form1 frm = new Form1();
                    frm.KullanıcıId = KullanıcıId;
                    FrmAyrıntılar fra = new FrmAyrıntılar();
                    fra.KullanıcıId = KullanıcıId;

                    this.Hide();
                    frm.Show();
                    

                    
                    
                }
                
            }
        }
    }
}
