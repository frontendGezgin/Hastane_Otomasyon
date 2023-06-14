using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13.Bölüm_Hastane_Proje
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void btnHastaGirisi_Click(object sender, EventArgs e)
        {
            FrmHastaGiris fr = new FrmHastaGiris();//Hasta giriş formundan fr isimli nesne türettim
            fr.Show(); // bu üstünde çalıştığım formu gizle bana fr nesnesinden türettiğim formu getir 
            this.Hide();    
        }

        private void btnDoktorGirisi_Click(object sender, EventArgs e)
        {
           FrmDoktorGiris fr = new FrmDoktorGiris();
            fr.Show();
             this.Hide();

        }

        private void btnSekreterGirisi_Click(object sender, EventArgs e)
        {
            FrmSekreterGiriş fr = new FrmSekreterGiriş();
            fr.Show();
            this.Hide();

        }
    }
}
