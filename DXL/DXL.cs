using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
    public class DXL
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlConnection cn;
        DataTable dt = new DataTable();
        public DXL()
        {
            cn = new SqlConnection("Data Source=LAPTOP-G3VSBFBH\\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True");
        }
        public void open()
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
        }
        public void close()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }
        public DataTable Reader(string sp, SqlParameter[] p)
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = cn;
            if (p != null)
            { cmd.Parameters.AddRange(p); }
            cmd.ExecuteScalar();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        //Remove Update Add
        public void RUA(string sp, SqlParameter[] p)
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = cn;
            if (p != null)
            { cmd.Parameters.AddRange(p); }
            cmd.ExecuteNonQuery();
        }
    }
}
       
