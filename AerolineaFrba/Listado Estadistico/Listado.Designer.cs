﻿namespace AerolineaFrba.Listado_Estadistico
{
    partial class Listado
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
            this.TC_listado = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DGV_1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGV_2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DGV_3 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DGV_4 = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.DGV_5 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.CB_anio = new System.Windows.Forms.ComboBox();
            this.CB_semestre = new System.Windows.Forms.ComboBox();
            this.BT_actualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TC_listado.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_4)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_5)).BeginInit();
            this.SuspendLayout();
            // 
            // TC_listado
            // 
            this.TC_listado.Controls.Add(this.tabPage1);
            this.TC_listado.Controls.Add(this.tabPage2);
            this.TC_listado.Controls.Add(this.tabPage3);
            this.TC_listado.Controls.Add(this.tabPage4);
            this.TC_listado.Controls.Add(this.tabPage5);
            this.TC_listado.Location = new System.Drawing.Point(12, 60);
            this.TC_listado.Name = "TC_listado";
            this.TC_listado.SelectedIndex = 0;
            this.TC_listado.Size = new System.Drawing.Size(741, 247);
            this.TC_listado.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DGV_1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(733, 221);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Destinos vas vendidos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DGV_1
            // 
            this.DGV_1.AllowUserToAddRows = false;
            this.DGV_1.AllowUserToDeleteRows = false;
            this.DGV_1.AllowUserToResizeColumns = false;
            this.DGV_1.AllowUserToResizeRows = false;
            this.DGV_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_1.Location = new System.Drawing.Point(6, 7);
            this.DGV_1.MultiSelect = false;
            this.DGV_1.Name = "DGV_1";
            this.DGV_1.ReadOnly = true;
            this.DGV_1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_1.ShowCellToolTips = false;
            this.DGV_1.ShowEditingIcon = false;
            this.DGV_1.ShowRowErrors = false;
            this.DGV_1.Size = new System.Drawing.Size(721, 208);
            this.DGV_1.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGV_2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(733, 221);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Destinos con aeronaves mas vacías";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGV_2
            // 
            this.DGV_2.AllowUserToAddRows = false;
            this.DGV_2.AllowUserToDeleteRows = false;
            this.DGV_2.AllowUserToResizeColumns = false;
            this.DGV_2.AllowUserToResizeRows = false;
            this.DGV_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_2.Location = new System.Drawing.Point(6, 6);
            this.DGV_2.MultiSelect = false;
            this.DGV_2.Name = "DGV_2";
            this.DGV_2.ReadOnly = true;
            this.DGV_2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_2.ShowCellToolTips = false;
            this.DGV_2.ShowEditingIcon = false;
            this.DGV_2.ShowRowErrors = false;
            this.DGV_2.Size = new System.Drawing.Size(721, 208);
            this.DGV_2.TabIndex = 18;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DGV_3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(733, 221);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Clientes con mas millas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DGV_3
            // 
            this.DGV_3.AllowUserToAddRows = false;
            this.DGV_3.AllowUserToDeleteRows = false;
            this.DGV_3.AllowUserToResizeColumns = false;
            this.DGV_3.AllowUserToResizeRows = false;
            this.DGV_3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_3.Location = new System.Drawing.Point(6, 6);
            this.DGV_3.MultiSelect = false;
            this.DGV_3.Name = "DGV_3";
            this.DGV_3.ReadOnly = true;
            this.DGV_3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_3.ShowCellToolTips = false;
            this.DGV_3.ShowEditingIcon = false;
            this.DGV_3.ShowRowErrors = false;
            this.DGV_3.Size = new System.Drawing.Size(721, 208);
            this.DGV_3.TabIndex = 18;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DGV_4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(733, 221);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Destinos mas cancelados";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // DGV_4
            // 
            this.DGV_4.AllowUserToAddRows = false;
            this.DGV_4.AllowUserToDeleteRows = false;
            this.DGV_4.AllowUserToResizeColumns = false;
            this.DGV_4.AllowUserToResizeRows = false;
            this.DGV_4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_4.Location = new System.Drawing.Point(6, 6);
            this.DGV_4.MultiSelect = false;
            this.DGV_4.Name = "DGV_4";
            this.DGV_4.ReadOnly = true;
            this.DGV_4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_4.ShowCellToolTips = false;
            this.DGV_4.ShowEditingIcon = false;
            this.DGV_4.ShowRowErrors = false;
            this.DGV_4.Size = new System.Drawing.Size(721, 208);
            this.DGV_4.TabIndex = 19;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.DGV_5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(733, 221);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Aeronaces mas fuera de servicio";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // DGV_5
            // 
            this.DGV_5.AllowUserToAddRows = false;
            this.DGV_5.AllowUserToDeleteRows = false;
            this.DGV_5.AllowUserToResizeColumns = false;
            this.DGV_5.AllowUserToResizeRows = false;
            this.DGV_5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_5.Location = new System.Drawing.Point(6, 6);
            this.DGV_5.MultiSelect = false;
            this.DGV_5.Name = "DGV_5";
            this.DGV_5.ReadOnly = true;
            this.DGV_5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_5.ShowCellToolTips = false;
            this.DGV_5.ShowEditingIcon = false;
            this.DGV_5.ShowRowErrors = false;
            this.DGV_5.Size = new System.Drawing.Size(721, 208);
            this.DGV_5.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CB_anio
            // 
            this.CB_anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_anio.FormattingEnabled = true;
            this.CB_anio.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019"});
            this.CB_anio.Location = new System.Drawing.Point(48, 20);
            this.CB_anio.Name = "CB_anio";
            this.CB_anio.Size = new System.Drawing.Size(121, 21);
            this.CB_anio.TabIndex = 19;
            // 
            // CB_semestre
            // 
            this.CB_semestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_semestre.FormattingEnabled = true;
            this.CB_semestre.Items.AddRange(new object[] {
            "1",
            "2"});
            this.CB_semestre.Location = new System.Drawing.Point(252, 20);
            this.CB_semestre.Name = "CB_semestre";
            this.CB_semestre.Size = new System.Drawing.Size(194, 21);
            this.CB_semestre.TabIndex = 20;
            // 
            // BT_actualizar
            // 
            this.BT_actualizar.Location = new System.Drawing.Point(668, 18);
            this.BT_actualizar.Name = "BT_actualizar";
            this.BT_actualizar.Size = new System.Drawing.Size(75, 23);
            this.BT_actualizar.TabIndex = 21;
            this.BT_actualizar.Text = "Actualizar";
            this.BT_actualizar.UseVisualStyleBackColor = true;
            this.BT_actualizar.Click += new System.EventHandler(this.BT_actualizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Año";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Semestre";
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 350);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_actualizar);
            this.Controls.Add(this.CB_semestre);
            this.Controls.Add(this.CB_anio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TC_listado);
            this.Name = "Listado";
            this.Text = "Listado";
            this.Load += new System.EventHandler(this.Listado_Load);
            this.TC_listado.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_4)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TC_listado;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DGV_1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView DGV_2;
        private System.Windows.Forms.DataGridView DGV_3;
        private System.Windows.Forms.DataGridView DGV_4;
        private System.Windows.Forms.DataGridView DGV_5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CB_anio;
        private System.Windows.Forms.ComboBox CB_semestre;
        private System.Windows.Forms.Button BT_actualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}