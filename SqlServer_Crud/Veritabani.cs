using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServer_Crud
{
    internal class Veritabani
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-357TRHC\\SQLEXPRESS;Initial Catalog=DataBase;Integrated Security=True");
    }
}
