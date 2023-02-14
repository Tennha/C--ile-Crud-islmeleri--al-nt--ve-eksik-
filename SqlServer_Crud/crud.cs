using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServer_Crud
{
    internal class crud
    {
        public static bool ESG(string sql, SqlCommand command)
        {
            if (Veritabani.baglanti.State == ConnectionState.Closed)
            {
                Veritabani.baglanti.Open();
            }
            command.Connection = Veritabani.baglanti;
            command.CommandText = sql;
            command.ExecuteNonQueryAsync();
            try
            { return true; }
            catch
            { return false; }
            finally
            { Veritabani.baglanti.Close(); }
        }
        public static DataTable list(string sql)
        {
            DataTable tbl = new DataTable();
            SqlDataAdapter adtr = new SqlDataAdapter(sql, Veritabani.baglanti);

            adtr.Fill(tbl);
            return tbl;
        }
    }
}