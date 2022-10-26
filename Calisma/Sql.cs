using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Calisma
{ 
    class Sql
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-L96504Q\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
            baglanti.Open();
            return baglanti;
            
        }
    }
}
