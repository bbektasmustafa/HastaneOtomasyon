using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HastaneOtomasyon
{
    

    internal class SqlBaglanti
    {
        public SqlConnection baglanti() {

            SqlConnection baglan = new SqlConnection("Data Source=mustafabe\\SQLEXPRESS;Initial Catalog=HastaneOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        
        }
    }
}
