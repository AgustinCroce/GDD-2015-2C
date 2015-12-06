namespace AerolineaFrba.Abm_Rol
{
    partial class ListadoRol
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
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BT_Deshabilitar = new System.Windows.Forms.Button();
            this.BT_Habilitar = new System.Windows.Forms.Button();
            this.BT_eliminar = new System.Windows.Forms.Button();
            this.BT_modificar = new System.Windows.Forms.Button();
            this.BT_agregar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_rol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_buscar = new System.Windows.Forms.Button();
            this.DGV_rol = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BT_eliminar_funcionalidad = new System.Windows.Forms.Button();
            this.BT_agregar_funcionalidad = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_rol)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 315);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Salir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BT_Deshabilitar);
            this.groupBox2.Controls.Add(this.BT_Habilitar);
            this.groupBox2.Controls.Add(this.BT_eliminar);
            this.groupBox2.Controls.Add(this.BT_modificar);
            this.groupBox2.Controls.Add(this.BT_agregar);
            this.groupBox2.Location = new System.Drawing.Point(395, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 173);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // BT_Deshabilitar
            // 
            this.BT_Deshabilitar.Enabled = false;
            this.BT_Deshabilitar.Location = new System.Drawing.Point(17, 106);
            this.BT_Deshabilitar.Name = "BT_Deshabilitar";
            this.BT_Deshabilitar.Size = new System.Drawing.Size(75, 23);
            this.BT_Deshabilitar.TabIndex = 4;
            this.BT_Deshabilitar.Text = "Deshabilitar";
            this.BT_Deshabilitar.UseVisualStyleBackColor = true;
            this.BT_Deshabilitar.Click += new System.EventHandler(this.BT_Deshabilitar_Click);
            // 
            // BT_Habilitar
            // 
            this.BT_Habilitar.Enabled = false;
            this.BT_Habilitar.Location = new System.Drawing.Point(17, 77);
            this.BT_Habilitar.Name = "BT_Habilitar";
            this.BT_Habilitar.Size = new System.Drawing.Size(75, 23);
            this.BT_Habilitar.TabIndex = 3;
            this.BT_Habilitar.Text = "Habilitar";
            this.BT_Habilitar.UseVisualStyleBackColor = true;
            this.BT_Habilitar.Click += new System.EventHandler(this.BT_Habilitar_Click);
            // 
            // BT_eliminar
            // 
            this.BT_eliminar.Enabled = false;
            this.BT_eliminar.Location = new System.Drawing.Point(17, 135);
            this.BT_eliminar.Name = "BT_eliminar";
            this.BT_eliminar.Size = new System.Drawing.Size(75, 23);
            this.BT_eliminar.TabIndex = 2;
            this.BT_eliminar.Text = "Eliminar";
            this.BT_eliminar.UseVisualStyleBackColor = true;
            this.BT_eliminar.Click += new System.EventHandler(this.BT_eliminar_Click);
            // 
            // BT_modificar
            // 
            this.BT_modificar.Enabled = false;
            this.BT_modificar.Location = new System.Drawing.Point(17, 48);
            this.BT_modificar.Name = "BT_modificar";
            this.BT_modificar.Size = new System.Drawing.Size(75, 23);
            this.BT_modificar.TabIndex = 1;
            this.BT_modificar.Text = "Modificar";
            this.BT_modificar.UseVisualStyleBackColor = true;
            this.BT_modificar.Click += new System.EventHandler(this.BT_modificar_Click);
            // 
            // BT_agregar
            // 
            this.BT_agregar.Location = new System.Drawing.Point(17, 19);
            this.BT_agregar.Name = "BT_agregar";
            this.BT_agregar.Size = new System.Drawing.Size(75, 23);
            this.BT_agregar.TabIndex = 0;
            this.BT_agregar.Text = "Agregar";
            this.BT_agregar.UseVisualStyleBackColor = true;
            this.BT_agregar.Click += new System.EventHandler(this.BT_agregar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_rol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BT_buscar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 63);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // TB_rol
            // 
            this.TB_rol.Location = new System.Drawing.Point(65, 21);
            this.TB_rol.MaxLength = 30;
            this.TB_rol.Name = "TB_rol";
            this.TB_rol.Size = new System.Drawing.Size(329, 20);
            this.TB_rol.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar";
            // 
            // BT_buscar
            // 
            this.BT_buscar.Location = new System.Drawing.Point(400, 19);
            this.BT_buscar.Name = "BT_buscar";
            this.BT_buscar.Size = new System.Drawing.Size(75, 23);
            this.BT_buscar.TabIndex = 3;
            this.BT_buscar.Text = "Buscar";
            this.BT_buscar.UseVisualStyleBackColor = true;
            this.BT_buscar.Click += new System.EventHandler(this.BT_buscar_Click);
            // 
            // DGV_rol
            // 
            this.DGV_rol.AllowUserToAddRows = false;
            this.DGV_rol.AllowUserToDeleteRows = false;
            this.DGV_rol.AllowUserToResizeColumns = false;
            this.DGV_rol.AllowUserToResizeRows = false;
            this.DGV_rol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_rol.Location = new System.Drawing.Point(12, 81);
            this.DGV_rol.MultiSelect = false;
            this.DGV_rol.Name = "DGV_rol";
            this.DGV_rol.ReadOnly = true;
            this.DGV_rol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_rol.ShowCellToolTips = false;
            this.DGV_rol.ShowEditingIcon = false;
            this.DGV_rol.ShowRowErrors = false;
            this.DGV_rol.Size = new System.Drawing.Size(377, 227);
            this.DGV_rol.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BT_eliminar_funcionalidad);
            this.groupBox3.Controls.Add(this.BT_agregar_funcionalidad);
            this.groupBox3.Location = new System.Drawing.Point(395, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 79);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Funcionalidades";
            // 
            // BT_eliminar_funcionalidad
            // 
            this.BT_eliminar_funcionalidad.Enabled = false;
            this.BT_eliminar_funcionalidad.Location = new System.Drawing.Point(17, 48);
            this.BT_eliminar_funcionalidad.Name = "BT_eliminar_funcionalidad";
            this.BT_eliminar_funcionalidad.Size = new System.Drawing.Size(75, 23);
            this.BT_eliminar_funcionalidad.TabIndex = 2;
            this.BT_eliminar_funcionalidad.Text = "Eliminar";
            this.BT_eliminar_funcionalidad.UseVisualStyleBackColor = true;
            this.BT_eliminar_funcionalidad.Click += new System.EventHandler(this.button3_Click);
            // 
            // BT_agregar_funcionalidad
            // 
            this.BT_agregar_funcionalidad.Enabled = false;
            this.BT_agregar_funcionalidad.Location = new System.Drawing.Point(17, 19);
            this.BT_agregar_funcionalidad.Name = "BT_agregar_funcionalidad";
            this.BT_agregar_funcionalidad.Size = new System.Drawing.Size(75, 23);
            this.BT_agregar_funcionalidad.TabIndex = 0;
            this.BT_agregar_funcionalidad.Text = "Agregar";
            this.BT_agregar_funcionalidad.UseVisualStyleBackColor = true;
            this.BT_agregar_funcionalidad.Click += new System.EventHandler(this.button6_Click);
            // 
            // ListadoRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 347);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.DGV_rol);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoRol";
            this.Text = "Roles";
            this.Load += new System.EventHandler(this.ListadoRol_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_rol)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BT_eliminar;
        private System.Windows.Forms.Button BT_modificar;
        private System.Windows.Forms.Button BT_agregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_buscar;
        private System.Windows.Forms.DataGridView DGV_rol;
        private System.Windows.Forms.TextBox TB_rol;
        private System.Windows.Forms.Button BT_Deshabilitar;
        private System.Windows.Forms.Button BT_Habilitar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BT_eliminar_funcionalidad;
        private System.Windows.Forms.Button BT_agregar_funcionalidad;

    }
}