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
using System.Windows.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace CRM.Formlar
{
    public partial class frmYeniKonuTur : Form
    {
        CevikTeknikTestProjContext db = new CevikTeknikTestProjContext();
        public frmYeniKonuTur()
        {
            InitializeComponent();
        }

        private void frmYeniKonuTur_Load(object sender, EventArgs e)
        {
            kolonlar();
            turDoldur();
            checkDoldur();
            dtgKonuTur.DataBindingComplete += dtgKonuTur_DataBindingComplete;
            dtgKonuTur.CurrentCellDirtyStateChanged += dtgKonuTur_CurrentCellDirtyStateChanged;
            Controls.Add(dtgKonuTur);
        }

        private void dtgKonuTur_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //foreach (DataGridViewRow row in dtgKonuTur.Rows)
            //{
            //    bool isActive = Convert.ToBoolean(row.Cells["Durum"].Value);
            //    DataGridViewCheckBoxCell checkBoxCell = row.Cells["Seç"] as DataGridViewCheckBoxCell;

            //    if (isActive)
            //    {
            //        checkBoxCell.Value = true;
            //        checkBoxCell.Selected = true;
            //    }
            //    else
            //    {
            //        checkBoxCell.Value = false;
            //        checkBoxCell.Selected = false;
            //    }
            //}
        }

        private void dtgKonuTur_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgKonuTur.IsCurrentCellDirty && dtgKonuTur.CurrentCell.ColumnIndex == dtgKonuTur.Columns["Seç"].Index)
            {
                dtgKonuTur.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        public void kolonlar()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Seç";
            checkBoxColumn.Name = "Seç";

            dtgKonuTur.Columns.Add(checkBoxColumn);

            //DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            //textBoxColumn.HeaderText = "Konu Türü";
            //textBoxColumn.Name = "KonuTürü";

            //dtgKonuTur.Columns.Add(textBoxColumn);

            DataGridViewTextBoxColumn textBoxColumn2 = new DataGridViewTextBoxColumn();
            textBoxColumn2.HeaderText = "Durum";
            textBoxColumn2.Name = "Durum";

            dtgKonuTur.Columns.Add(textBoxColumn2);

        }

        public void turDoldur()
        {
            var konuTur = db.KonuTurus.Select(x => new { x.Ad, Durumu = x.Aktif == true ? "Aktif" : "Pasif", x.Id }).ToList();
            //item.AktifPasif == true ? "A" : "P"
            //AktifPasif = konu.AktifPasif, = konu.AktifPasif == true ? "A" : "P"
            dtgKonuTur.DataSource = konuTur;
            
            dtgKonuTur.Columns["Id"].Visible = false;
            dtgKonuTur.Columns["Durumu"].Visible = false;
        }

        private void dtgKonuTur_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == dtgKonuTur.Columns["Seç"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dtgKonuTur.Rows[e.RowIndex].Cells["Seç"];
                bool isChecked = (bool)checkBoxCell.Value;
                string secim = checkBoxCell.Value.ToString();
                var secilenId = (int)dtgKonuTur.CurrentRow.Cells["Id"].Value;   
                var secilen = db.KonuTurus.FirstOrDefault(x => x.Id == secilenId);
                
                if (secilen!=null)
                {
                    if (isChecked==true)
                    {
                        // Aktif durumunu güncelle
                        secim = "Aktif";
                        secilen.Aktif = true;
                        //int aktifColumnIndex = secilenAktif.Index;
                        //dtgKonuTur.Rows[e.RowIndex].Cells["Aktif"].Value = isChecked;
                        dtgKonuTur.CurrentRow.Cells["Durum"].Value = "Aktif";
                        checkBoxCell.Selected = true;

                        // Değişikliği kaydet
                        db.SaveChanges();
                        //turDoldur();
                        //var konuTur = db.KonuTurus.Select(x => new { Aktif = x.Aktif == true ? "Aktif" : "Pasif", x.Ad, x.Id }).ToList();
                        //dtgKonuTur.DataSource = konuTur;
                    }
                    else
                    {
                        secim = "Pasif";
                        secilen.Aktif = false;
                        //dtgKonuTur.CurrentRow.Cells["Durum"].Value = secim;
                        //dtgKonuTur.CurrentRow.Cells[2].Value = secim;
                        //dtgKonuTur.Rows[e.RowIndex].Cells["Aktif"].Value = isChecked;
                        dtgKonuTur.CurrentRow.Cells["Durum"].Value = "Pasif";
                        checkBoxCell.Selected = false;
                        db.SaveChanges();
                        //turDoldur();
                        //var konuTur = db.KonuTurus.Select(x => new { Aktif = x.Aktif == true ? "Aktif" : "Pasif", x.Ad, x.Id }).ToList();
                        //dtgKonuTur.DataSource = konuTur;
                    }


                }
                else
                {
                    
                }

            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            //repositoryItemCheckEdit.ValueChecked = true; // Seçildiğinde atanan değer (true)
            //repositoryItemCheckEdit.ValueUnchecked = false; // Seçilmediğinde atanan değer (false)
            //gridView1.Columns["Aktif"].ColumnEdit = repositoryItemCheckEdit;
            //DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //if (e.Column.FieldName == "Aktif")
            //{
            //    string value = view.GetRowCellValue(e.RowHandle, "Aktif") != null ? view.GetRowCellValue(e.RowHandle, "Aktif").ToString() : "0";
            //    if (value == "True")
            //    {
            //        //bilmem click =true gibi 
            //    }
            //}
        }

        public void checkDoldur ()
        {
            foreach (DataGridViewRow row in dtgKonuTur.Rows)
            {
                //bool isActive = Convert.ToBoolean(row.Cells["Aktif"].Value);
                string isActive = (row.Cells["Durumu"].Value).ToString();
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Seç"] as DataGridViewCheckBoxCell;

                if (isActive=="Aktif")
                {
                    checkBoxCell.Value = true;
                    checkBoxCell.Selected = true;
                    row.Cells["Durum"].Value = "Aktif";

                }
                else
                {
                    checkBoxCell.Value = false;
                    checkBoxCell.Selected = false;
                    row.Cells["Durum"].Value = "Pasif";
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            KonuTuru tur = new KonuTuru();
            if (txtYeniKonuTur.Text == "")
            {
                MessageBox.Show("Konu Türü Girişi Yapınız!");
            }
            tur.Ad = txtYeniKonuTur.Text;
            tur.Aktif = true;
            db.Add(tur);
            db.SaveChanges();
            MessageBox.Show("Konu Türü Eklendi.");
            //this.Hide();
            //frmYeniKonuTur frm = new frmYeniKonuTur();
            //frm.ShowDialog();
            
            turDoldur();
            checkDoldur();
            dtgKonuTur.DataBindingComplete += dtgKonuTur_DataBindingComplete;
            dtgKonuTur.CurrentCellDirtyStateChanged += dtgKonuTur_CurrentCellDirtyStateChanged;
            Controls.Add(dtgKonuTur);

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            string secilenTur = dtgKonuTur.CurrentRow.Cells["Ad"].Value.ToString();
            txtYeniKonuTur.Text = secilenTur;
            int secilenId = (int)dtgKonuTur.CurrentRow.Cells["Id"].Value;
            var secili = db.KonuTurus.FirstOrDefault(x => x.Id == secilenId);
            if (txtYeniKonuTur.Text=="")
            {
                MessageBox.Show("Konu Türü Girişi Yapınız!");
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int secilenId = (int)dtgKonuTur.CurrentRow.Cells["Id"].Value;
            string secilenTur = dtgKonuTur.CurrentRow.Cells["Ad"].Value.ToString();
            DialogResult cevap = MessageBox.Show($"{secilenTur} Konu türünü silmek istediğinizden eminmisiniz ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                db.Database.ExecuteSqlRaw($"delete from KonuTuru where Id={secilenId}");
                MessageBox.Show("Konu Türü Silindi");
            }
            else
            {

            }
            turDoldur();
            checkDoldur();
            dtgKonuTur.DataBindingComplete += dtgKonuTur_DataBindingComplete;
            dtgKonuTur.CurrentCellDirtyStateChanged += dtgKonuTur_CurrentCellDirtyStateChanged;
            Controls.Add(dtgKonuTur);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            int secilenId = (int)dtgKonuTur.CurrentRow.Cells["Id"].Value;
            var secili = db.KonuTurus.FirstOrDefault(x => x.Id == secilenId);
            if (txtYeniKonuTur.Text == "")
            {
                MessageBox.Show("Konu Türü Girişi Yapınız!");
            }
            secili.Ad = txtYeniKonuTur.Text;
            db.SaveChanges();
            MessageBox.Show("Konu Türü Güncellendi");
            turDoldur();
            checkDoldur();
            dtgKonuTur.DataBindingComplete += dtgKonuTur_DataBindingComplete;
            dtgKonuTur.CurrentCellDirtyStateChanged += dtgKonuTur_CurrentCellDirtyStateChanged;
            Controls.Add(dtgKonuTur);
        }
    }
}
