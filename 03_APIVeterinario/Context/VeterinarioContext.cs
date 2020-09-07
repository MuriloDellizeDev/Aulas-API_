using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIVeterinario.Context
{
    public class VeterinarioContext
    {


        SqlConnection con = new SqlConnection();

        public VeterinarioContext()
        {
            con.ConnectionString = @"Data Source=DESKTOP-ODQTMCL\SQLEXPRESS;Initial Catalog=Veterianario;User ID=sa;Password=sa132";
        }

        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {

                con.Open();

            }

            return con;
        }

        public void Desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {

                con.Close();

            }
        }
    }
}
