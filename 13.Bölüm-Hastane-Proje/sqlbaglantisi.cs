using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Bölüm_Hastane_Proje
{
    public class sqlbaglantisi
    {
        public SqlConnection  baglanti()
        { 
            SqlConnection baglan = new SqlConnection(@"data source=.; initial catalog=HastaneProje; integrated security=True ");
            baglan.Open();
            return baglan;  //Data Source=EMRE_ACAR;Initial Catalog=HastaneProje;Integrated Security=True

        }
    }
}
