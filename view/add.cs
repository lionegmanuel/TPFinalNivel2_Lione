using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using acces;
using bussines;
namespace view
{
    public partial class add : Form
    {

        private articleController articleController = new articleController();
        private categoryController categoryController = new bussines.categoryController();
        private brandController brandController = new brandController();
        private bool modify = false; //cuando la accion a realizar sea una modificacion, se le asigna valor true
        private article modifyArticle;
        private OpenFileDialog archive = null;
        public add()
        {
            InitializeComponent();
        }
        public add(article article)
        {
            this.modifyArticle = article;
            modify = true;
            InitializeComponent();

        }
        private void addBtn_Click(object sender, EventArgs e)
        {

            bool confirmRegister = true;

            if (modifyArticle == null)
            {

                article art = new article();
                if (!Regex.IsMatch(nameTxt.Text, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Ingrese un nómbre válido", "Ingrese carácteres válidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    confirmRegister = false;
                }
                else art.name = nameTxt.Text;
                art.description = descriptionTxt.Text;
                if (!Regex.IsMatch(priceTxt.Text, @"^\d+(\.\d+)?$"))
                {
                    MessageBox.Show("Ingrese caracteres numéricos válidos", "Ingrese carácteres válidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    confirmRegister = false;
                }
                else art.price = decimal.Parse(priceTxt.Text);
                if (!Regex.IsMatch(articleCodeTxt.Text, @"^(?=.*[a-zA-Z])(?=.*[0-9])[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("El código del artículo se compone de letras y números de forma OBLIGATORIA", "Ingrese carácteres válidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    confirmRegister = false;
                }
                else art.articleCode = articleCodeTxt.Text;
                art.brand = (brand)brandCbo.SelectedItem;
                art.category = (category)categoryCbo.SelectedItem;
                art.image = imageTxt.Text;

                if (string.IsNullOrEmpty(nameTxt.Text) || string.IsNullOrEmpty(descriptionTxt.Text) || string.IsNullOrEmpty(priceTxt.Text) || string.IsNullOrEmpty(articleCodeTxt.Text) || string.IsNullOrEmpty(descriptionTxt.Text)
                    || brandCbo.SelectedIndex == -1 || categoryCbo.SelectedIndex == -1 || string.IsNullOrEmpty(imageTxt.Text)) MessageBox.Show("Complete todos los campos.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (confirmRegister)
                    {
                        articleController.register(art);
                        MessageBox.Show("¡Registro realizado con éxito!", "Registro realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                if (archive != null && !(imageTxt.Text.ToUpper().Contains("HTTP")))
                {
                    if (!Directory.Exists(ConfigurationManager.AppSettings["imageFolder"]))
                    {
                        try
                        {
                            Directory.CreateDirectory(ConfigurationManager.AppSettings["imageFolder"]);
                            File.Copy(archive.FileName, ConfigurationManager.AppSettings["imageFolder"] + archive.SafeFileName); //guardado de la imagen de forma local
                        }
                        catch (Exception ex) {
                            Console.WriteLine("Destino objetivo a crear:\n" + ConfigurationManager.AppSettings["imageFolder"]);
                            MessageBox.Show("La carpeta destino no se encontró y no puedo ser creada.", "Error el crear carpeta", MessageBoxButtons.OK, MessageBoxIcon.Stop); throw ex; }
                    }

                }

            }
            else MessageBox.Show("No se puede realizar un registro.", "Modificación en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error); //cuando se esté modificando y se intente registrar

        }

        private void add_Load(object sender, EventArgs e)
        {
            List<category> categories = categoryController.list();
            List<brand> brands = brandController.list();
            categoryCbo.DataSource = categories;
            brandCbo.DataSource = brands;

            if (modify && modifyArticle != null) //modificacion de datos
            {
                nameTxt.Text = modifyArticle.name;
                descriptionTxt.Text = modifyArticle.description;
                priceTxt.Text = modifyArticle.price.ToString();
                articleCodeTxt.Text = modifyArticle.articleCode;
                brandCbo.SelectedIndex = brandCbo.FindStringExact(modifyArticle.brand.name.ToString());
                categoryCbo.SelectedIndex = categoryCbo.FindStringExact(modifyArticle.category.name.ToString());
                imageTxt.Text = modifyArticle.image;
            }
            else
            { //registro nuevo
                categoryCbo.SelectedIndex = -1;
                brandCbo.SelectedIndex = -1;
            }

        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            bool confirmModify = true;
            if (modify && modifyArticle != null) //modificacion a realizar = se paso un articulo por parametro
            {
                string oldestName = modifyArticle.name; //guarda el nombre actual del articulo (Si se llegase a modifcar el nombre, se mostrará por pantalla el nombre viejo)
                if (!string.IsNullOrEmpty(nameTxt.Text) && !nameTxt.Text.Equals(modifyArticle.name))
                {
                    if (!Regex.IsMatch(nameTxt.Text, @"^[a-zA-Z\s]+$"))
                    {
                        MessageBox.Show("Ingrese un nómbre válido", "Ingrese carácteres válidos", MessageBoxButtons.OK, MessageBoxIcon.Error); modifyArticle.price = 0;
                        confirmModify = false;
                    }
                    else modifyArticle.name = nameTxt.Text;
                }
                if (!string.IsNullOrEmpty(descriptionTxt.Text) && !descriptionTxt.Text.Equals(modifyArticle.description)) modifyArticle.description = descriptionTxt.Text;
                if (!string.IsNullOrEmpty(priceTxt.Text.ToString()) && !priceTxt.Text.Equals(modifyArticle.price.ToString()))
                {
                    if (!Regex.IsMatch(priceTxt.Text, @"^\d+(\.\d+)?$")) { MessageBox.Show("Ingrese caracteres numéricos válidos", "Ingrese carácteres válidos", MessageBoxButtons.OK, MessageBoxIcon.Error); modifyArticle.price = 0; confirmModify = false; }
                    else modifyArticle.price = decimal.Parse(priceTxt.Text);
                }
                if (!string.IsNullOrEmpty(articleCodeTxt.Text) && !articleCodeTxt.Text.Equals(modifyArticle.articleCode))
                {
                    if (!Regex.IsMatch(articleCodeTxt.Text, @"^(?=.*[a-zA-Z])(?=.*[0-9])[a-zA-Z0-9]+$"))
                    {
                        MessageBox.Show("El código del artículo se compone de letras y números de forma OBLIGATORIA", "Ingrese carácteres válidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        confirmModify = false;
                    }
                    else modifyArticle.articleCode = articleCodeTxt.Text;
                }

                if (brandCbo.SelectedIndex != -1 && !brandCbo.SelectedItem.Equals(modifyArticle.brand)) modifyArticle.brand = (brand)brandCbo.SelectedItem;
                if (categoryCbo.SelectedIndex != -1 && !categoryCbo.SelectedItem.Equals(modifyArticle.category)) modifyArticle.category = (category)categoryCbo.SelectedItem;
                if (!string.IsNullOrEmpty(imageTxt.Text) && !imageTxt.Text.Equals(modifyArticle.image)) modifyArticle.image = imageTxt.Text;

                if (string.IsNullOrEmpty(nameTxt.Text) || string.IsNullOrEmpty(descriptionTxt.Text) || string.IsNullOrEmpty(priceTxt.Text) || string.IsNullOrEmpty(articleCodeTxt.Text)
                    || brandCbo.SelectedIndex == -1 || categoryCbo.SelectedIndex == -1 || string.IsNullOrEmpty(imageTxt.Text))
                {
                    MessageBox.Show("¡Debe completar TODOS los campos!", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    confirmModify = false;
                }
                if (confirmModify)
                {
                    articleController.modify(modifyArticle);
                    if (modifyArticle.name != oldestName) MessageBox.Show("El artículo que estaba registrado por " + oldestName + " fue actualizado con éxito.", "Artículo actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information); //cuando el NOMBRE del artículo FUE modificado
                    else MessageBox.Show("El artículo " + modifyArticle.name + " fue modificado con éxito."); //cuando el NOMBRE del artículo NO se vio alterado
                    this.Close();
                }
                if (archive != null && !(imageTxt.Text.ToUpper().Contains("HTTP")))
                {

                    if (!Directory.Exists(ConfigurationManager.AppSettings["imageFolder"]))
                    {
                        try
                        {
                            Directory.CreateDirectory(ConfigurationManager.AppSettings["imageFolder"]);
                            File.Copy(archive.FileName, ConfigurationManager.AppSettings["imageFolder"] + archive.SafeFileName); //guardado de la imagen de forma local
                        }
                        catch (Exception ex) { MessageBox.Show("La carpeta destino no se encontró y no puedo ser creada.", "Error el crear carpeta", MessageBoxButtons.OK, MessageBoxIcon.Stop); throw ex; }
                    }
                }
            }
            else MessageBox.Show("No se puede realizar una modificación.", "Registro en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error); //cuando se esté registrando y se intente modificar
        }
        private void addImageBtn_Click(object sender, EventArgs e)
        {
            archive = new OpenFileDialog();
            archive.Filter = "jpg|*.jpg";
            try {
                if (archive.ShowDialog() == DialogResult.OK)
                {
                    imageTxt.Text = archive.FileName;
                    imageTxt.ReadOnly = true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error al cargar imagen.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        } 
    }
}

