using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM
{
    public partial class FrmDisYazisma : Form
    {
        public FrmDisYazisma()
        {
            InitializeComponent();
        }
        public int KonuId;
        private void FrmDisYazisma_Load(object sender, EventArgs e)
        {
            if (KonuId > 0)
            {

            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            if (KonuId > 0)
            {

            }
            else
            {
                if (txtbxKonu.Text == "")
                {
                    MessageBox.Show("Lütfen Konu Girişi Yapınız.");
                }
                else
                {

                    DialogResult cevap = MessageBox.Show(txtbxKonu.Text + " için cevap eklemek ister misiniz?", "Cevap Ekle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        FrmIcYazisma frm = new FrmIcYazisma();
                        frm.Show();

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
    }
}
