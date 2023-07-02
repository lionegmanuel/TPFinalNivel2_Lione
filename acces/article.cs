using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace acces
{
    public class article
    {
        
        public int id { get; set; }
        [DisplayName("Código de artículo")]
        public string articleCode { get;set; }
        [DisplayName("Nombre")]
        public string name { get; set; }
        [DisplayName("Descripción")]
        public string description { get; set; }
        [DisplayName("Marca")]
        public brand brand { get; set; }
        [DisplayName("Categoría")]
        public category category { get; set; }
        public string image { get; set; } //refiere a la URL de la imagen, sea de forma local o remota
        [DisplayName("Categoría")]
        public decimal price { get; set; }  

    }
}
