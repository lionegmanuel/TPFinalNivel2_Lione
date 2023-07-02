using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using acces;
namespace bussines
{
    public class articleController
    {
        private connection connection;
        public articleController() {
            connection = new connection();
        }

        public List<article> articleList() {
            
            List<article> list = new List<article>();
            try {
                connection.setSqlQuery("select art.id, art.Codigo, art.Nombre, art.Descripcion, marca.Descripcion Marca, marca.id idMarca, cat.Descripcion Categoria, cat.id idCategoria, art.ImagenURL, art.Precio from ARTICULOS art, MARCAS marca, CATEGORIAS cat where art.IdMarca = marca.Id and art.IdCategoria = cat.id; ");
                connection.read();
                while (connection.getReader().Read()) {
                    article art = new article();
                    category cat = new category();
                    brand brand = new brand();
                    //categorias y marca
                    cat.name = (string)connection.getReader()["Categoria"];
                    cat.id = (int)connection.getReader()["idCategoria"];
                    brand.name = (string)connection.getReader()["Marca"];
                    brand.id = (int)connection.getReader()["idMarca"];
                    art.id = (int)connection.getReader()["id"];
                    art.name = (string)connection.getReader()["Nombre"];
                    art.description = (string)connection.getReader()["Descripcion"];
                    art.price = (decimal)connection.getReader()["Precio"];
                    art.articleCode = (string)connection.getReader()["Codigo"];
                    art.brand = brand;
                    art.category = cat;
                    art.image = (string)connection.getReader()["ImagenURL"];
                    //agrega a la lista el dispositivo
                    list.Add(art);
                }
                return list;

            } 
            catch (Exception ex) { throw ex; }
            finally { connection.getCommand().Parameters.Clear(); connection.close(); }


            
        }
        public List<article> find(string sql)
        {
            List<article> filterList = new List<article> ();
            //sql = parte de la sentencia SQL a concatenar para realizar el filtrado
            try {
                connection.setSqlQuery("SELECT art.id, art.Codigo, art.Nombre, art.Descripcion, marca.Descripcion Marca, marca.id idMarca, cat.Descripcion Categoria, cat.id idCategoria, art.ImagenURL, art.Precio from ARTICULOS art, MARCAS marca, CATEGORIAS cat "+sql +" and art.IdMarca = marca.Id and art.IdCategoria = cat.id;");
                connection.read();
                while (connection.getReader().Read())
                {
                    article art = new article();
                    category cat = new category();
                    brand brand = new brand();
                    //categorias y marca
                    cat.name = (string)connection.getReader()["Categoria"];
                    cat.id = (int)connection.getReader()["idCategoria"];
                    brand.name = (string)connection.getReader()["Marca"];
                    brand.id = (int)connection.getReader()["idMarca"];
                    art.id = (int)connection.getReader()["id"];
                    art.name = (string)connection.getReader()["Nombre"];
                    art.description = (string)connection.getReader()["Descripcion"];
                    art.price = (decimal)connection.getReader()["Precio"];
                    art.articleCode = (string)connection.getReader()["Codigo"];
                    art.brand = brand;
                    art.category = cat;
                    art.image = (string)connection.getReader()["ImagenURL"];
                    //agrega a la lista el dispositivo
                    filterList.Add(art);
                }
                return filterList;
            }
            catch (Exception ex) { throw ex; }
            finally { connection.getCommand().Parameters.Clear(); connection.close(); }
        }
        public void register(article article) { 
            try {
                connection.setSqlQuery("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)");
                connection.getCommand().Parameters.AddWithValue("@codigo", article.articleCode);
                connection.getCommand().Parameters.AddWithValue("@nombre", article.name);
                connection.getCommand().Parameters.AddWithValue("@descripcion", article.description);
                connection.getCommand().Parameters.AddWithValue("@idMarca", article.brand.id);
                connection.getCommand().Parameters.AddWithValue("@idCategoria",article.category.id);
                connection.getCommand().Parameters.AddWithValue("@imagenUrl", article.image);
                connection.getCommand().Parameters.AddWithValue("@precio", article.price);
                connection.execute();
            } 
            
            catch (Exception ex) 
            { throw ex; }  
            finally { connection.close(); } 
        
        }
        public void modify(article article) {
            try {
                connection.setSqlQuery("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, idCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio where id = @idArticulo");
                connection.getCommand().Parameters.AddWithValue("@codigo", article.articleCode);
                connection.getCommand().Parameters.AddWithValue("@nombre", article.name );
                connection.getCommand().Parameters.AddWithValue("@descripcion",article.description );
                connection.getCommand().Parameters.AddWithValue("@idMarca",article.brand.id );
                connection.getCommand().Parameters.AddWithValue("@idCategoria", article.category.id );
                connection.getCommand().Parameters.AddWithValue("@imagenUrl", article.image );
                connection.getCommand().Parameters.AddWithValue("@precio", article.price);
                connection.getCommand().Parameters.AddWithValue("@idArticulo", article.id);

                connection.execute();
            } 
            catch (Exception ex) { throw ex; } 
            finally { connection.getCommand().Parameters.Clear(); connection.close();}
        }
    //   //public void logicDelete(article article) { 
       //     try {
       //         connection.setSqlQuery("delete from ARTICULOS where id = @id");
      //          connection.getCommand().Parameters.AddWithValue("id", article.id);
       //         connection.execute();
      //      } 
       //     catch (Exception ex) { throw ex; } 
       //     finally { connection.close();}
      //  }
        public void permanentDelete (article article) {
            try
            {
                connection.setSqlQuery("delete from ARTICULOS where id = @id");
                connection.getCommand().Parameters.AddWithValue("id", article.id);
                connection.execute();
            }
            catch (Exception ex) { throw ex; }
            finally { connection.getCommand().Parameters.Clear(); connection.close(); }
        }
        public article articleDetail(article article)
        {
            article art = new article();
            category category = new category();
            brand brand = new brand();
            int id = article.id;
            try {
                
                connection.setSqlQuery("select art.id, art.Codigo, art.Nombre, art.Descripcion, marca.Descripcion Marca, marca.id idMarc, cat.Descripcion Categoria, cat.id idCat,art.ImagenURL, art.Precio from ARTICULOS art, MARCAS marca, CATEGORIAS cat where art.IdMarca = marca.Id and art.IdCategoria = cat.id and art.Id = @id;");
                connection.getCommand().Parameters.Clear();
                connection.getCommand().Parameters.AddWithValue("@id", id);
                connection.read();
                if (connection.getReader().Read())
                {
                    //categoria y marca
                    brand.name = (string)connection.getReader()["Marca"];
                    brand.id = (int)connection.getReader()["idMarc"];
                    category.name = (string)connection.getReader()["Categoria"];
                    category.id = (int)connection.getReader()["idCat"];

                    //articulo
                    art.id = (int)connection.getReader()["id"];
                    art.name = (string)connection.getReader()["Nombre"];
                    art.description = (string)connection.getReader()["Descripcion"];
                    art.price = (decimal)connection.getReader()["Precio"];
                    art.articleCode = (string)connection.getReader()["Codigo"];
                    art.brand = brand;
                    art.category = category;
                    art.image = (string)connection.getReader()["ImagenURL"];
                }
                Console.WriteLine(
                    "\n1-Articulo seleccionado: "+art.name+"\n2-Descripcion: "+art.description+"\n3-Categoría: "+art.category+"\n4-Precio: "+art.price
                    );
                return art;
             } 
            catch (Exception ex) { throw ex; }
            finally { connection.getCommand().Parameters.Clear(); connection.close(); }
 

        }
    }
}
