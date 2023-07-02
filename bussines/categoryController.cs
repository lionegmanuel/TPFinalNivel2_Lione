using acces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussines
{
    public class categoryController
    {
        private connection connection;
        public categoryController()
        {
            connection = new connection();
        }

        public List<category> list()
        {
            List<category> list = new List<category>();
            try {
                connection.setSqlQuery("select c.id, c.Descripcion Nombre from CATEGORIAS c");
                connection.read();
                while (connection.getReader().Read()){
                    category category = new category();
                    category.id = (int)connection.getReader()["id"];
                    category.name = (string)connection.getReader()["Nombre"];
                    list.Add(category);
                }
            } 
            catch(Exception ex) { throw ex; } 
            finally { connection.close(); }
            return list;
        }
    }
}
