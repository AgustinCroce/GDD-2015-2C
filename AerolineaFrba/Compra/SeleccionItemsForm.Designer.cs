﻿namespace AerolineaFrba.Compra
{
    partial class SeleccionItemsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addEncomiendaButton = new System.Windows.Forms.Button();
            this.deleteEncomiendaButton = new System.Windows.Forms.Button();
            this.addPasajeButton = new System.Windows.Forms.Button();
            this.deletePasajeButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.encomiendaGridView = new System.Windows.Forms.DataGridView();
            this.pasajeGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.encomiendaGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasajeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos encomienda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datos pasajes";
            // 
            // addEncomiendaButton
            // 
            this.addEncomiendaButton.Location = new System.Drawing.Point(136, 4);
            this.addEncomiendaButton.Name = "addEncomiendaButton";
            this.addEncomiendaButton.Size = new System.Drawing.Size(75, 23);
            this.addEncomiendaButton.TabIndex = 2;
            this.addEncomiendaButton.Text = "Agregar";
            this.addEncomiendaButton.UseVisualStyleBackColor = true;
            this.addEncomiendaButton.Click += new System.EventHandler(this.addEncomiendaButton_Click);
            // 
            // deleteEncomiendaButton
            // 
            this.deleteEncomiendaButton.Enabled = false;
            this.deleteEncomiendaButton.Location = new System.Drawing.Point(217, 4);
            this.deleteEncomiendaButton.Name = "deleteEncomiendaButton";
            this.deleteEncomiendaButton.Size = new System.Drawing.Size(75, 23);
            this.deleteEncomiendaButton.TabIndex = 3;
            this.deleteEncomiendaButton.Text = "Borrar";
            this.deleteEncomiendaButton.UseVisualStyleBackColor = true;
            this.deleteEncomiendaButton.Click += new System.EventHandler(this.deleteEncomiendaButton_Click);
            // 
            // addPasajeButton
            // 
            this.addPasajeButton.Location = new System.Drawing.Point(136, 119);
            this.addPasajeButton.Name = "addPasajeButton";
            this.addPasajeButton.Size = new System.Drawing.Size(75, 23);
            this.addPasajeButton.TabIndex = 5;
            this.addPasajeButton.Text = "Agregar";
            this.addPasajeButton.UseVisualStyleBackColor = true;
            this.addPasajeButton.Click += new System.EventHandler(this.addPasajeButton_Click);
            // 
            // deletePasajeButton
            // 
            this.deletePasajeButton.Enabled = false;
            this.deletePasajeButton.Location = new System.Drawing.Point(217, 119);
            this.deletePasajeButton.Name = "deletePasajeButton";
            this.deletePasajeButton.Size = new System.Drawing.Size(75, 23);
            this.deletePasajeButton.TabIndex = 6;
            this.deletePasajeButton.Text = "Borrar";
            this.deletePasajeButton.UseVisualStyleBackColor = true;
            this.deletePasajeButton.Click += new System.EventHandler(this.deletePasajeButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(369, 337);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 8;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // encomiendaGridView
            // 
            this.encomiendaGridView.AllowUserToAddRows = false;
            this.encomiendaGridView.AllowUserToDeleteRows = false;
            this.encomiendaGridView.AllowUserToResizeColumns = false;
            this.encomiendaGridView.AllowUserToResizeRows = false;
            this.encomiendaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.encomiendaGridView.Location = new System.Drawing.Point(15, 33);
            this.encomiendaGridView.MultiSelect = false;
            this.encomiendaGridView.Name = "encomiendaGridView";
            this.encomiendaGridView.ReadOnly = true;
            this.encomiendaGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.encomiendaGridView.ShowCellToolTips = false;
            this.encomiendaGridView.ShowEditingIcon = false;
            this.encomiendaGridView.ShowRowErrors = false;
            this.encomiendaGridView.Size = new System.Drawing.Size(422, 80);
            this.encomiendaGridView.TabIndex = 19;
            // 
            // pasajeGridView
            // 
            this.pasajeGridView.AllowUserToAddRows = false;
            this.pasajeGridView.AllowUserToDeleteRows = false;
            this.pasajeGridView.AllowUserToResizeColumns = false;
            this.pasajeGridView.AllowUserToResizeRows = false;
            this.pasajeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pasajeGridView.Location = new System.Drawing.Point(15, 156);
            this.pasajeGridView.MultiSelect = false;
            this.pasajeGridView.Name = "pasajeGridView";
            this.pasajeGridView.ReadOnly = true;
            this.pasajeGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pasajeGridView.ShowCellToolTips = false;
            this.pasajeGridView.ShowEditingIcon = false;
            this.pasajeGridView.ShowRowErrors = false;
            this.pasajeGridView.Size = new System.Drawing.Size(422, 175);
            this.pasajeGridView.TabIndex = 20;
            // 
            // SeleccionItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 368);
            this.Controls.Add(this.pasajeGridView);
            this.Controls.Add(this.encomiendaGridView);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.deletePasajeButton);
            this.Controls.Add(this.addPasajeButton);
            this.Controls.Add(this.deleteEncomiendaButton);
            this.Controls.Add(this.addEncomiendaButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SeleccionItemsForm";
            this.Text = "Ingreso de items";
            this.Load += new System.EventHandler(this.SeleccionItemsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.encomiendaGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasajeGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addEncomiendaButton;
        private System.Windows.Forms.Button deleteEncomiendaButton;
        private System.Windows.Forms.Button addPasajeButton;
        private System.Windows.Forms.Button deletePasajeButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.DataGridView encomiendaGridView;
        private System.Windows.Forms.DataGridView pasajeGridView;
    }
}