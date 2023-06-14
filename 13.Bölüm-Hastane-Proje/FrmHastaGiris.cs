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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();   //sql baglanti sınıfını çağırıyorum. 
        private void UyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr = new FrmHastaKayit();
            fr.Show();
            
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From  Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();//komuttan gelen değerleri oku
            //while verileri okuyup yazdırmak için kullanıır 
            //if  verilerin doğruluğunun doğru olup olmadıpının kontrolü
            if (dr.Read()) // eğer dr komut okuma işlemini doğrubir şekilde gerçekleştiriyorsa 
            {
                FrmHastaDetay fr = new FrmHastaDetay();//doğru bir şekilde okuduysa Hastadetay sayfasına gitsin 
                fr.tc = mskTC.Text;//tc nesensi aslında hastadetayda puplic olduğu için fr nesnesiyle erişim yapabiliyorum.
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC & Şifre");
            }
            bgl.baglanti().Close();
            


        }

      
    }
}
