using acces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussines
{
    public class brandController

    {
        private connection connection;
        public brandController()
        {
            connection = new connection();
        }
        public List<brand> list()
        {
            List<brand> brandList = new List<brand>();
            try {
                connection.setSqlQuery("select m.id, m.Descripcion Nombre from MARCAS m");
                connection.read();
                while (connection.getReader().Read())
                {
                    brand brand = new brand();
                    brand.id = (int)connection.getReader()["id"];
                    brand.name = (string)connection.getReader()["Nombre"];
                    brandList.Add(brand);
                }
                return brandList;
            } 
            catch (Exception ex) { throw ex; } 
            finally { connection.close(); }
        }
    }
}
