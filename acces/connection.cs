using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;

namespace acces
{
    public class connection
    {
        //property's
        private SqlConnection con;
        private SqlDataReader reader;
        private SqlCommand cmd;

        public connection() {
            con  = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            cmd = new SqlCommand();
        }
        //métodos de conexion
        private void open()
        {
            try
            {
                cmd.Connection = con;
                con.Open();
            } catch (Exception ex) { throw ex; }
                    
        }
        public void close()
        {
            if (reader != null) reader.Close();
            con.Close();
        }
        public void execute() {
            open();
            try
            {
                cmd.ExecuteNonQuery();
            } catch (Exception ex) { throw ex;}
        } //operaciones de tipo SP (insert, update, delete)
        public void read() {
            open();
            try {  
                reader = cmd.ExecuteReader();
            } catch (Exception ex) { throw ex;}
        } //operaciones de tipo lectura y consultas

        //métodos de utilidad (helpers)
        public void setSqlQuery(string query) { //setea la sentencia SQL a utilizar en el codigo = atajo de facil acceso
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
        }
        public SqlDataReader getReader() { return  reader; }
        public SqlCommand getCommand() { return cmd; }
    }
}
