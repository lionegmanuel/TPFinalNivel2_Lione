using acces;
using bussines;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace view
{
    public partial class frmPrincipal : Form
    {
        private List<article> articleList;
        private articleController controller;
        private ArrayList filterOptions;
        private helperClass help;
        public frmPrincipal()
        {
            this.filterOptions = new ArrayList();
            this.help = new helperClass();
            this.controller = new articleController();
            InitializeComponent();
        }
        private void filterOptionsLoad()
        {
            filterOptions.Add("Nombre");
            filterOptions.Add("Precio");
            filterOptions.Add("Código");
            filterOptions.Add("Marca");
            filterOptions.Add("Categoría");

            help.filterOptionsLoad(filterCb1, filterOptions);
            filterOptions.Clear();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            filterOptionsLoad();
            articleLoad();  
        }


        private void articleLoad() { //metodo para cargar los elementos registrados en la base de datos.
                articleList = controller.articleList();
                try
                {
                    articleDgv.DataSource = articleList;
                    articleDgv.ClearSelection();
                    articleDgv.Columns["image"].Visible = false;
                    articleDgv.Columns["id"].Visible = false;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡No hay dispositivos registrados!");
                }
        }

        private void detailBtn_Click(object sender, EventArgs e)
        { 
            article art = (article)articleDgv.CurrentRow.DataBoundItem;
            if (art == null) MessageBox.Show("Debe seleccionar un artículo.");
            else {
                article detailArt = controller.articleDetail(art);
                articleDetail detail = new articleDetail(detailArt);
                detail.ShowDialog();
            }
            
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            article art = (article)articleDgv.CurrentRow.DataBoundItem;
            if (art == null) MessageBox.Show("¡Debe seleccionar un artículo!", "Seleccione un artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                add modify = new add(art);
                modify.ShowDialog();
                articleLoad();
            }
            
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            article art = (article)articleDgv.CurrentRow.DataBoundItem;
            if (art == null) MessageBox.Show("¡Debe seleccionar un artículo para eliminar!", "Seleccione un artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                DialogResult input = MessageBox.Show("¿Desea hacer una eliminación permanente del articulo "+art.name+ "?", "Confirmar eliminación de artículo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (input == DialogResult.Yes) { controller.permanentDelete(art); articleLoad(); MessageBox.Show("El artículo " + art.name + " fue eliminado exitosamente.", "Eliminación realizada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else if (input == DialogResult.No) MessageBox.Show("El articulo "+art.name+" no fue eliminado.", "Eliminación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Proceso cancelado.", "Eliminación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            add register = new add();
            register.ShowDialog();
            articleLoad();
        }

        private void filterCb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterOptions.Count > 0)
            {
                filterOptions.Clear();
                filterCb2.Items.Clear();
            }   
            if ( filterCb1.SelectedItem.ToString() == "Nombre" || filterCb1.SelectedItem.ToString() ==  "Código" || filterCb1.SelectedItem.ToString() == "Marca" || filterCb1.SelectedItem.ToString() ==  "Categoría") {
                filterOptions.Add("Se llama...");
                filterOptions.Add("Contiene...");
            } else
            {
                filterOptions.Add("Menor a (<)");
                filterOptions.Add("Igual a (=)");
                filterOptions.Add("Mayor a (>)");
            }

            help.filterOptionsLoad(filterCb2, filterOptions); //carga de filtros

       }

        private void filterCb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterLbl.Visible = true;
            filterTxt.Visible = true;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string filter = filterTxt.Text;
            string sql = "";
            
            if (filterCb1.SelectedIndex == -1) MessageBox.Show("Seleccione una opción de filtrado", "Seleccione una opcion para filtrar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (filterCb2.SelectedIndex == -1) MessageBox.Show("Seleccione un criterio para filtrar", "Seleccione un criterio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //validaciones para la entrada (Cuando se permiten textos, cuando se permite texto + numeros y cuando solo numeros)
            else if (filterCb1.SelectedIndex == 1 && !Regex.IsMatch(filter, @"^\d+(\.\d+)?$")) MessageBox.Show("Ingrese un precio válido", "Ingrese un valor correcto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (filterCb1.SelectedIndex == 2 && filterCb2.SelectedIndex == 0 && !Regex.IsMatch(filter, @"^(?=.*[a-zA-Z])(?=.*[0-9])[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Ingrese un código de artículo válido", "Ingrese un valor correcto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if ((filterCb1.SelectedIndex == 0 || filterCb1.SelectedIndex == 3 || filterCb1.SelectedIndex == 4) && !Regex.IsMatch(filter, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Ingrese carácteres válidos. No se permiten carácteres numéricos", "Ingrese un valor correcto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            //cuando NO se ingrese nada.
            else if (string.IsNullOrEmpty(filter)) MessageBox.Show("Ingrese un filtro válido.", "Ingrese un valor correcto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                switch (filterCb2.SelectedItem.ToString())
                {
                    case "Se llama...":
                        if (filterCb1.SelectedIndex == 0) sql = "WHERE UPPER(art.Nombre) = '" + filter.ToUpper() + "'";
                        else if (filterCb1.SelectedIndex == 2) sql = "WEHERE UPPER(art.Codigo) = '" + filter.ToUpper() + "'";
                        else if (filterCb1.SelectedIndex == 3) sql = "WHERE UPPER(marca.Descripcion) = '" + filter.ToUpper() + "'";
                        else sql = "WHERE UPPER(cat.Descripcion) = '" + filter.ToUpper() + "'";
                        break;
                    case "Contiene...":
                        if (filterCb1.SelectedIndex == 0)
                            sql = "WHERE UPPER(art.Nombre) LIKE '%" + filter.ToUpper() + "%'";
                        else if (filterCb1.SelectedIndex == 2)
                            sql = "WHERE UPPER(art.Codigo) LIKE '%" + filter.ToUpper() + "%'";
                        else if (filterCb1.SelectedIndex == 3)
                            sql = "WHERE UPPER(marca.Descripcion) LIKE '%" + filter.ToUpper() + "%'";
                        else
                            sql = "WHERE UPPER(cat.Descripcion) LIKE '%" + filter.ToUpper() + "%'";
                        break;
                    case "Menor a (<)":
                        sql = "WHERE art.Precio < " + filter;
                        break;

                    case "Igual a (=)":
                        sql = "WHERE art.Precio = " + filter;
                        break;
                    case "Mayor a (>)":
                        sql = "WHERE art.Precio > " + filter;
                        break;
                }

                List<article> filterList = controller.find(sql);
                if (filterList.Count > 0)
                {
                    if (articleDgv != null) articleDgv.DataSource = null;
                    articleDgv.DataSource = filterList;
                    articleDgv.Columns["image"].Visible = false;
                    articleDgv.Columns["id"].Visible = false;
                }
                else MessageBox.Show("No hay articulos que cumplan con los siguientes criterios:\n1-Filtrado por: " + filterCb1.SelectedItem.ToString() + "\n2-Criterio de filtrado: " + filterCb2.SelectedItem.ToString() + "\n3-Filtro: " + filter, "No se obtuvo resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }


    }
}
