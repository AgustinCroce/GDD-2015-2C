﻿namespace AerolineaFrba.Abm_Aeronave
{
    partial class ListadoAeronave
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
            this.BT_baja_serivicio = new System.Windows.Forms.Button();
            this.BT_fuera_servicio = new System.Windows.Forms.Button();
            this.BT_eliminar = new System.Windows.Forms.Button();
            this.BT_modificar = new System.Windows.Forms.Button();
            this.BT_agregar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_servicio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_buscar = new System.Windows.Forms.Button();
            this.DGV_aeronave = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_aeronave)).BeginInit();
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
            this.groupBox2.Controls.Add(this.BT_baja_serivicio);
            this.groupBox2.Controls.Add(this.BT_fuera_servicio);
            this.groupBox2.Controls.Add(this.BT_eliminar);
            this.groupBox2.Controls.Add(this.BT_modificar);
            this.groupBox2.Controls.Add(this.BT_agregar);
            this.groupBox2.Location = new System.Drawing.Point(989, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(122, 227);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // BT_baja_serivicio
            // 
            this.BT_baja_serivicio.Enabled = false;
            this.BT_baja_serivicio.Location = new System.Drawing.Point(8, 135);
            this.BT_baja_serivicio.Name = "BT_baja_serivicio";
            this.BT_baja_serivicio.Size = new System.Drawing.Size(108, 23);
            this.BT_baja_serivicio.TabIndex = 4;
            this.BT_baja_serivicio.Text = "Baja de Servicio";
            this.BT_baja_serivicio.UseVisualStyleBackColor = true;
            this.BT_baja_serivicio.Click += new System.EventHandler(this.BT_baja_serivicio_Click);
            // 
            // BT_fuera_servicio
            // 
            this.BT_fuera_servicio.Enabled = false;
            this.BT_fuera_servicio.Location = new System.Drawing.Point(8, 106);
            this.BT_fuera_servicio.Name = "BT_fuera_servicio";
            this.BT_fuera_servicio.Size = new System.Drawing.Size(108, 23);
            this.BT_fuera_servicio.TabIndex = 3;
            this.BT_fuera_servicio.Text = "Fuera de Servicio";
            this.BT_fuera_servicio.UseVisualStyleBackColor = true;
            this.BT_fuera_servicio.Click += new System.EventHandler(this.BT_fuera_servicio_Click);
            // 
            // BT_eliminar
            // 
            this.BT_eliminar.Enabled = false;
            this.BT_eliminar.Location = new System.Drawing.Point(6, 77);
            this.BT_eliminar.Name = "BT_eliminar";
            this.BT_eliminar.Size = new System.Drawing.Size(110, 23);
            this.BT_eliminar.TabIndex = 2;
            this.BT_eliminar.Text = "Eliminar";
            this.BT_eliminar.UseVisualStyleBackColor = true;
            this.BT_eliminar.Click += new System.EventHandler(this.BT_eliminar_Click);
            // 
            // BT_modificar
            // 
            this.BT_modificar.Enabled = false;
            this.BT_modificar.Location = new System.Drawing.Point(6, 48);
            this.BT_modificar.Name = "BT_modificar";
            this.BT_modificar.Size = new System.Drawing.Size(110, 23);
            this.BT_modificar.TabIndex = 1;
            this.BT_modificar.Text = "Modificar";
            this.BT_modificar.UseVisualStyleBackColor = true;
            this.BT_modificar.Click += new System.EventHandler(this.BT_modificar_Click);
            // 
            // BT_agregar
            // 
            this.BT_agregar.Location = new System.Drawing.Point(6, 19);
            this.BT_agregar.Name = "BT_agregar";
            this.BT_agregar.Size = new System.Drawing.Size(110, 23);
            this.BT_agregar.TabIndex = 0;
            this.BT_agregar.Text = "Agregar";
            this.BT_agregar.UseVisualStyleBackColor = true;
            this.BT_agregar.Click += new System.EventHandler(this.BT_agregar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_servicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BT_buscar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1099, 63);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // CB_servicio
            // 
            this.CB_servicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_servicio.FormattingEnabled = true;
            this.CB_servicio.Location = new System.Drawing.Point(65, 21);
            this.CB_servicio.Name = "CB_servicio";
            this.CB_servicio.Size = new System.Drawing.Size(906, 21);
            this.CB_servicio.TabIndex = 4;
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
            this.BT_buscar.Location = new System.Drawing.Point(983, 21);
            this.BT_buscar.Name = "BT_buscar";
            this.BT_buscar.Size = new System.Drawing.Size(110, 23);
            this.BT_buscar.TabIndex = 3;
            this.BT_buscar.Text = "Buscar";
            this.BT_buscar.UseVisualStyleBackColor = true;
            this.BT_buscar.Click += new System.EventHandler(this.BT_buscar_Click);
            // 
            // DGV_aeronave
            // 
            this.DGV_aeronave.AllowUserToAddRows = false;
            this.DGV_aeronave.AllowUserToDeleteRows = false;
            this.DGV_aeronave.AllowUserToResizeColumns = false;
            this.DGV_aeronave.AllowUserToResizeRows = false;
            this.DGV_aeronave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_aeronave.Location = new System.Drawing.Point(12, 81);
            this.DGV_aeronave.MultiSelect = false;
            this.DGV_aeronave.Name = "DGV_aeronave";
            this.DGV_aeronave.ReadOnly = true;
            this.DGV_aeronave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_aeronave.ShowCellToolTips = false;
            this.DGV_aeronave.ShowEditingIcon = false;
            this.DGV_aeronave.ShowRowErrors = false;
            this.DGV_aeronave.Size = new System.Drawing.Size(971, 227);
            this.DGV_aeronave.TabIndex = 15;
            // 
            // ListadoAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 348);
            this.Controls.Add(this.DGV_aeronave);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoAeronave";
            this.Text = "Aeronaves";
            this.Load += new System.EventHandler(this.ListadoAeronave_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_aeronave)).EndInit();
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
        private System.Windows.Forms.DataGridView DGV_aeronave;
        private System.Windows.Forms.ComboBox CB_servicio;
        private System.Windows.Forms.Button BT_baja_serivicio;
        private System.Windows.Forms.Button BT_fuera_servicio;

    }
}