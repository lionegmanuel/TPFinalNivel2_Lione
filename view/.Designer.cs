namespace view
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.articleDgv = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.detailBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.filterCb1 = new System.Windows.Forms.ComboBox();
            this.filterCb2 = new System.Windows.Forms.ComboBox();
            this.filterTxt = new System.Windows.Forms.TextBox();
            this.filterLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.articleDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // articleDgv
            // 
            this.articleDgv.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.articleDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.articleDgv.Location = new System.Drawing.Point(22, 25);
            this.articleDgv.MultiSelect = false;
            this.articleDgv.Name = "articleDgv";
            this.articleDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.articleDgv.Size = new System.Drawing.Size(894, 547);
            this.articleDgv.TabIndex = 0;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(22, 599);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(101, 30);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Registrar Artículo";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(148, 599);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(101, 30);
            this.modifyBtn.TabIndex = 2;
            this.modifyBtn.Text = "Modificar Artículo";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(274, 599);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(101, 30);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Eliminar Artículo";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // detailBtn
            // 
            this.detailBtn.Location = new System.Drawing.Point(802, 515);
            this.detailBtn.Name = "detailBtn";
            this.detailBtn.Size = new System.Drawing.Size(101, 44);
            this.detailBtn.TabIndex = 4;
            this.detailBtn.Text = "Ver detalles de Artículo";
            this.detailBtn.UseVisualStyleBackColor = true;
            this.detailBtn.Click += new System.EventHandler(this.detailBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(944, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filtrar por:";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(1037, 168);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(101, 28);
            this.searchBtn.TabIndex = 6;
            this.searchBtn.Text = "Buscar";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // filterCb1
            // 
            this.filterCb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterCb1.FormattingEnabled = true;
            this.filterCb1.Location = new System.Drawing.Point(948, 68);
            this.filterCb1.Name = "filterCb1";
            this.filterCb1.Size = new System.Drawing.Size(121, 21);
            this.filterCb1.TabIndex = 7;
            this.filterCb1.SelectedIndexChanged += new System.EventHandler(this.filterCb1_SelectedIndexChanged);
            // 
            // filterCb2
            // 
            this.filterCb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterCb2.FormattingEnabled = true;
            this.filterCb2.Location = new System.Drawing.Point(1102, 68);
            this.filterCb2.Name = "filterCb2";
            this.filterCb2.Size = new System.Drawing.Size(121, 21);
            this.filterCb2.TabIndex = 8;
            this.filterCb2.SelectedIndexChanged += new System.EventHandler(this.filterCb2_SelectedIndexChanged);
            // 
            // filterTxt
            // 
            this.filterTxt.Location = new System.Drawing.Point(1083, 118);
            this.filterTxt.Name = "filterTxt";
            this.filterTxt.Size = new System.Drawing.Size(140, 20);
            this.filterTxt.TabIndex = 9;
            this.filterTxt.Visible = false;
            // 
            // filterLbl
            // 
            this.filterLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.filterLbl.Location = new System.Drawing.Point(945, 101);
            this.filterLbl.Name = "filterLbl";
            this.filterLbl.Size = new System.Drawing.Size(132, 54);
            this.filterLbl.TabIndex = 10;
            this.filterLbl.Text = "Ingrese el criterio a utilizar para la búsqueda =>";
            this.filterLbl.Visible = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.filterLbl);
            this.Controls.Add(this.filterTxt);
            this.Controls.Add(this.filterCb2);
            this.Controls.Add(this.filterCb1);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.detailBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.articleDgv);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.articleDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView articleDgv;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button detailBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ComboBox filterCb1;
        private System.Windows.Forms.ComboBox filterCb2;
        private System.Windows.Forms.TextBox filterTxt;
        private System.Windows.Forms.Label filterLbl;
    }
}

