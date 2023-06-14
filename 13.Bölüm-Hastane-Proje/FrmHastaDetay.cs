using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _13.Bölüm_Hastane_Proje
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string tc; //Formlar arsı geçiş yapmak için Public değişken oluşturduk1.adım
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;    //Form yüklendiği zaman da lbltc nin textine tc den gelen değer yazsın.
            //AD SOYAD ÇEKME 


            SqlCommand komut = new SqlCommand("select HastaAd ,HastaSoyad From Tbl_Hastalar wHere HastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",LblTC.Text);//LblTC ye Eşit olan Adı ve soyadı getirsin
            SqlDataReader dr = komut.ExecuteReader();     //dr benim veri okuyucumu çalıştıracak okuma işlemini gerçekleştirecek
            while(dr.Read())  //dr komutum çalıştığı müttetçe,Listeleme için kullanılır.
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1]; //sütunbazlı iki değer döner biri dr0 den gelen diğeri dr den gelen dr1 den gelen 2.sütun
                
            }
            bgl.baglanti().Close();

            //RANDEVU GEÇMİŞİ
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From  Tbl_Randevular Where HastaTC=" + tc, bgl.baglanti());//datagride veri aktarmak için kommandım dı 
            // dataadapter ın içini doldur tablodan gelen değerler ile 
            da.Fill(dt);
            dataGridView1.DataSource = dt;//datagridin veri kaynağı = dt den gelen değer 

            //BRANŞLARI ÇEKME 
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
           SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();


        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();    

            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where  DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbBrans.Text);
             SqlDataReader dr3= komut3.ExecuteReader();
            while(dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " +dr3[1]);
            }
            bgl.baglanti().Close();


        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();//datagride veri çekeceğiz| sqlde string ifadeleri tek tırnak içinde yazamıyoruz
            SqlDataAdapter da = new SqlDataAdapter("select * From Tbl_Randevular Where RandevuBrans='" + cmbBrans.Text + "'" + "and RandevuDoktor='" + cmbDoktor.Text+"' and RandevuDurumu=0",bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;


        }

        private void LnkBilgiDüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDüzenle fr = new FrmBilgiDüzenle();
            fr.TCno = LblTC.Text;
            fr.Show();
        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex; 
            txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Randevular Set RandevuDurumu=1, HastaTC=@p1,HastaSikayet=@p2 where Randevuidi=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",LblTC.Text);
            komut.Parameters.AddWithValue("@p2",RchSikayet.Text);
            komut.Parameters.AddWithValue("@p3",txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
