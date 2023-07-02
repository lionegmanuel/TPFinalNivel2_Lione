using acces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace view
{
    public class helperClass //clase helper con metodos útiles para toda la aplicación
    {
        public void pictureLoad(string urlImage, PictureBox pb )
        {
            try
            {
                pb.Load(urlImage);
            } catch (Exception ex)
            {
                pb.Load("https://www.unfe.org/wp-content/uploads/2019/04/SM-placeholder.png");
                Console.WriteLine("Imagen NO encontrada");
            }
        }
        public void filterOptionsLoad(ComboBox cb, ArrayList array){ cb.Items.AddRange(array.ToArray());}
        
    }
}
