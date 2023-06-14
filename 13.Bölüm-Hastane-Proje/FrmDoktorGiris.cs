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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();    
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
                SqlCommand  komut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@p1  and DoktorSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",mskTC.Text);
            komut.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();//verileri okutucaz
            if (dr.Read())  //Eğer okuma işlemi doğru birşeklde gerçekleşiyorsa
            {
                FrmDoktorDetay fr = new FrmDoktorDetay();
                fr.TC=mskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre");
                }
                bgl.baglanti().Close();
            }
        }
    }

