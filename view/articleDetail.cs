using acces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace view
{
    public partial class articleDetail : Form
    {
        private article art;
        public articleDetail(article art)
        {
            this.art = art;
            InitializeComponent();
        }

        private void articleDetail_Load(object sender, EventArgs e)
        {
            helperClass pictureLoad = new helperClass();
            nameDetailTxt.Text = art.name;
            nameDetailTxt.Select(nameDetailTxt.Text.Length, 0); // Establece el punto de selección al final del texto
            nameDetailTxt.SelectionLength = 0; // Deselecciona cualquier texto resaltado
            descriptionDetailTxt.Text = art.description;
            priceDetailTxt.Text = art.price.ToString();
            brandDetailTxt.Text = art.brand.name;
            categoryDetailTxt.Text = art.category.name;
            articleCodeDetailTxt.Text = art.articleCode;
            pictureLoad.pictureLoad(art.image, imageDetailPb);
             

        
        }
    }
}
