using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiemtrathu
{
    internal class ProcessDataBase
    {
        string stringcon = @"Data Source=DESKTOP-3GCI6TQ\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
        SqlConnection con;
        public void KetNoi()
        {
            con = new SqlConnection(stringcon);
            if (con.State != ConnectionState.Open)
                con.Open();
        }
        public void DongKetNoi()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Dispose();
        }
        public DataTable DocBang(string sql)
        {
            DataTable tb = new DataTable();
            KetNoi();
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(tb);
            DongKetNoi();
            return tb;
        }
        public void CapNhat(string sql)
        {
            SqlCommand cmm = new SqlCommand();
            KetNoi();
            cmm.CommandText = sql;
            cmm.Connection = con;
            cmm.ExecuteNonQuery();
            cmm.Dispose();
            DongKetNoi();
        }
    
}
}
